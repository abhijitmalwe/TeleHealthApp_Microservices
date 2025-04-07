namespace PatientService.Service.IService
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}
