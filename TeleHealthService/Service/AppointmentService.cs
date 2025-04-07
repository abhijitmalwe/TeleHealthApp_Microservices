
using Microsoft.EntityFrameworkCore;
using TeleHealthService.Data;
using TeleHealthService.Model;
using TeleHealthService.Service.IService;
using TeleHealthService.Service.IService;

namespace TeleHealthService.Service
{
    public class AppointmentService : IAppointmentService
    {
        //private readonly AppDbContext _appDbContext;
        //public AppointmentService(AppDbContext appDbContext)
        //{
        //    _appDbContext = appDbContext;
        //}
        private readonly IAppointmentRepository _repo;
        private readonly IVideoService _videoService;

        public AppointmentService(IAppointmentRepository repo, IVideoService videoService)
        {
            _repo = repo;
            _videoService = videoService;
        }

        public async Task<Guid> CreateAppointmentAsync(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            appointment.Status = "Scheduled";
            appointment.VideoRoomName = await _videoService.GenerateRoomNameAsync(appointment.Id);
            await _repo.AddAsync(appointment);
            return appointment.Id;
        }

        public async Task<Appointment> GetAppointmentAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
