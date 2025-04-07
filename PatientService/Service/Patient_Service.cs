using PatientService.Constants;
using PatientService.Models;
using PatientService.Entities;
using PatientService.Service.IService;
using Mapster;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using PatientService.Entities;
using PatientService.Model;
using PatientService.Service.IService;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Generators;

namespace DeliveryService.Service
{
    public class Patient_Service : IPatientService
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IEmailService _emailService;

        public Patient_Service(AppDbContext context, IPublishEndpoint publishEndpoint, IEmailService emailService)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
            _emailService = emailService;
        }

        public async Task<string> RegisterPatientAsync(Patient patient)
        {
            // Check if patient already exists by email
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Email == patient.Email);
            if (existingPatient != null)
            {
                throw new InvalidOperationException("A patient with this email already exists.");
            }

            // Proceed with registration
            patient.Id = Guid.NewGuid().ToString();
            patient.Password = Guid.NewGuid().ToString().Substring(0, 8);

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            await _emailService.SendAsync(patient.Email, "Welcome!", $"Hello {patient.Name}, your password is: {patient.Password}");

            await _publishEndpoint.Publish(new PatientRegisteredEvent
            {
                PatientId = patient.Id,
                Email = patient.Email,
                Name = patient.Name
            });

            return patient.Id;
        }

    }
}
