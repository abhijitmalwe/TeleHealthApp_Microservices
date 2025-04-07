using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleHealthService.Model
{
    public class NotificationRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string Type { get; set; } // email or sms
    }
}
