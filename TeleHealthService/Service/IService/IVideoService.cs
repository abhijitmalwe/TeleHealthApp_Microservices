using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleHealthService.Service.IService
{
    public interface IVideoService
    {
        Task<string> GenerateRoomNameAsync(Guid appointmentId);
    }
}
