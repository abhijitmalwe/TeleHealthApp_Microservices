using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TeleHealthService.Model;
using TeleHealthService.Service.IService;

namespace TeleHealthService.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            var id = await _service.CreateAppointmentAsync(appointment);
            return Ok(new { AppointmentId = id });
        }

        [HttpGet("getappointmentbyid/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var appointment = await _service.GetAppointmentAsync(id);
            return Ok(appointment);
        }
    }

}
