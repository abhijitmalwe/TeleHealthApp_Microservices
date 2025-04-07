using App.Common.Constants;
using App.Common.Models;
using AuthService.Data;
using AuthService.Entities;
using AuthService.Model;
using AuthService.Service.IService;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbcontext;
        private readonly IJwtService _jwtService;

        public UserService(AppDbContext appDbcontext, IJwtService jwtService )
        {
            _appDbcontext = appDbcontext;  
            _jwtService = jwtService;   
        }

        public async Task<AppResponse<LoginResDto>> Login(LoginReq req)
        {
            try
            {
                var user = await _appDbcontext.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == req.Email && u.Password == req.Password);

                if (user == null) return AppResponse.Fail<LoginResDto>(null, "Invalid Email or Password", HttpStatusCodes.NotFound);

                string Token = _jwtService.Authenticate(user.UserId, user.Name, user.Email, "patient");
                var userDto = user.Adapt<UserDto>();

                var LoginRes = new LoginResDto
                {
                    Token = Token,
                    user = userDto,
                };
                return AppResponse.Success(LoginRes);

            }
            catch (Exception ex)
            {
                return AppResponse.Fail<LoginResDto>(null, ex.Message, HttpStatusCodes.InternalServerError);
            }
        }

    }
}
