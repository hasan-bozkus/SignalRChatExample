using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRChatExample.Hubs
{
    public class MessageHub : Hub
    {
        static List<string> clients = new List<string>();

        public async Task SendingMessageAsync(string message, string userName)
        {
            await Clients.All.SendAsync("receivedMessage", message, userName);
        }

        public async override Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("JoinedUser", $"{Context.ConnectionId}");
        }

        async public override Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("LeavedUser", $"{Context.ConnectionId}");
        }
    }
}
