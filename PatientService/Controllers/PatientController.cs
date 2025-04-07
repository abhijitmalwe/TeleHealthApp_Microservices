using Microsoft.AspNetCore.Mvc;
using PatientService.Entities;
using PatientService.Service.IService;

namespace PatientService.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Patient patient)
        {
            var patientId = await _patientService.RegisterPatientAsync(patient);
            return Ok(new { Message = "Patient registered successfully.", PatientId = patientId });
        }
    }
}
