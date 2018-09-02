using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TextEndeavor.Hubs
{
    public class GameHub: Hub
    {
        public async Task SendCommand(string command)
        {
            await Clients.Caller.SendAsync("CommandResponse", $"Command '{command}' received.");
        }
    }
}