using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using PatientService.Model;
using PatientService.Service.IService;
using System.Net;

namespace PatientService.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig ec;
        private readonly IConfiguration _configuration;
        public EmailService(IOptions<EmailConfig> emailConfig, IConfiguration configuration)
        {
            this.ec = emailConfig.Value;
            _configuration = configuration; 
        }
        public async Task SendAsync(string to, string subject, string body)
        {
            try{
                var emailMessage = new MimeMessage();
                this.ec.FromAddress = _configuration["SmtpConfig:FromEmailAddress"]; 
                this.ec.MailServerAddress = _configuration["SmtpConfig:HostName"]; 
                this.ec.UserPassword = _configuration["SmtpConfig:Password"]; 
                this.ec.MailServerPort = _configuration["SmtpConfig:Port"]; 
              
                emailMessage.From.Clear();
                emailMessage.From.Add(new MailboxAddress(ec.FromName, ec.FromAddress));

                emailMessage.To.Clear();
                emailMessage.To.Add(new MailboxAddress("", to));
                emailMessage.Subject = subject;
                //emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };

                var builder = new BodyBuilder();
                builder.HtmlBody = body;
                emailMessage.Body = builder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.LocalDomain = ec.LocalDomain;

                    await client.ConnectAsync(ec.MailServerAddress, Convert.ToInt32(ec.MailServerPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(ec.UserId, ec.UserPassword));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Task.CompletedTask;
        }
    }
}
