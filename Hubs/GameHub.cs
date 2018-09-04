using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TextEndeavor.Hubs
{
    public class GameHub: Hub
    {

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("CommandResponse", $"You are '{Context.UserIdentifier}'.");
        }

        public async Task SendCommand(string command)
        {
            await Clients.All.SendAsync("CommandResponse", $"Command '{command}' received.");
        }
    }
}