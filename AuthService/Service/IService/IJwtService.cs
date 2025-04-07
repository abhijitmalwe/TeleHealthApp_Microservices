namespace AuthService.Service.IService
{
    public interface IJwtService
    {
        string Authenticate(int userId, string userName, string Email, string Role);
    }
}
