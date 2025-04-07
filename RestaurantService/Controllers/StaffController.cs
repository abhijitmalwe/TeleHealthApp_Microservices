using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffService.Entities;
using StaffService.Service.IService;

namespace StaffService.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Staff staff)
        {
            var staffId = await _staffService.RegisterStaffAsync(staff);
            return Ok(new { Message = "Staff registered successfully.", StaffId = staffId });
        }
    }
}
