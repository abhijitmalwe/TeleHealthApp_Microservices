
using TeleHealthService.Model;

namespace TeleHealthService.Service.IService
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointmentAsync(Appointment appointment);
        Task<Appointment> GetAppointmentAsync(Guid id);
    }
}
