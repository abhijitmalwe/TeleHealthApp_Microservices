using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHealthService.Model;
using TeleHealthService.Service.IService;

namespace TeleHealthService.Controllers
{
    [ApiController]
    [Route("api/notify")]
    public class NotifyController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotifyController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send(NotificationRequest request)
        {
            await _notificationService.SendNotificationAsync(request);
            return Ok(new { Status = "Notification Sent" });
        }
    }

}
