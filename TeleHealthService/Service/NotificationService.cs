using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHealthService.Model;
using TeleHealthService.Service.IService;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TeleHealthService.Service
{
    public class NotificationService : INotificationService
    {
        public async Task SendNotificationAsync(NotificationRequest request)
        {
            if (request.Type == "email")
            {
                // Send Email logic
            }
            else if (request.Type == "sms")
            {
                // Use Twilio Free Tier for SMS
                const string accountSid = "<your_twilio_account_sid>";
                const string authToken = "<your_twilio_auth_token>";
                TwilioClient.Init(accountSid, authToken);

                await MessageResource.CreateAsync(
                    body: request.Message,
                    from: new Twilio.Types.PhoneNumber("+1<your_twilio_number>"),
                    to: new Twilio.Types.PhoneNumber(request.PhoneNumber)
                );
            }
        }
    }
}
