using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeleHealthService.Model;

namespace TeleHealthService.Service
{
    public class WaitingRoomHub : Hub
    {
        public async Task JoinWaitingRoom(WaitingRoomRequest request)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, request.AppointmentId.ToString());
            await Clients.Group(request.AppointmentId.ToString()).SendAsync("UserJoined", request.UserType);
        }
    }
}
