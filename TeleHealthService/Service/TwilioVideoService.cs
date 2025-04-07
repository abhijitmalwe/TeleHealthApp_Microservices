using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHealthService.Service.IService;

namespace TeleHealthService.Service
{
    public class TwilioVideoService : IVideoService
    {
        public async Task<string> GenerateRoomNameAsync(Guid appointmentId)
        {
            return await Task.FromResult($"video-room-{appointmentId.ToString()}");
        }
    }
}
