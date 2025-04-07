
using MassTransit;
using Microsoft.EntityFrameworkCore;
using StaffService.Data;
using StaffService.Entities;
using StaffService.Model;
using StaffService.Service.IService;


namespace StaffService.Service
{
    public class StaffService : IStaffService
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public StaffService(AppDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<string> RegisterStaffAsync(Staff staff)
        {
            staff.Id = Guid.NewGuid().ToString();
            staff.Password = Guid.NewGuid().ToString().Substring(0, 8);

            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();

            //await _emailService.SendAsync(staff.Email, "Staff Registered", $"Hi {staff.Name}, your login credentials: {staff.Password}");

            await _publishEndpoint.Publish(new StaffRegisteredEvent
            {
                StaffId = staff.Id,
                Email = staff.Email,
                Name = staff.Name,
                Password = staff.Password
            });

            return staff.Id;
        }
    }
}
