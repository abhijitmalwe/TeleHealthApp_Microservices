using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHealthService.Model;

namespace TeleHealthService.Service.IService
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationRequest request);
    }
}
