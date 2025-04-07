using AuthService.Model;
using AuthService.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

       
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReq model)
        {
            var serviceRes = await _userService.Login(model);
            return Ok(serviceRes);
        }
    }
}
