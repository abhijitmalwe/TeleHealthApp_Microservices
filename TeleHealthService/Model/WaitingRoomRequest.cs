using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleHealthService.Model
{
    public class WaitingRoomRequest
    {
        public Guid AppointmentId { get; set; }
        public string UserType { get; set; } // "Patient" or "Staff"
        public string ConnectionId { get; set; }
    }
}
