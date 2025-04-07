using PatientService.Models;
using PatientService.Model;
using PatientService.Entities;

namespace PatientService.Service.IService
{
    public interface IPatientService
    {
        Task<string> RegisterPatientAsync(Patient patient);
    }
}
