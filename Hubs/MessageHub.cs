using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRChatExample.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendingMessageAsync(string message, string userName)
        {
            await Clients.All.SendAsync("receivedMessage", message, userName);
        }

        public async override Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("JoinedUser", $"{Context.ConnectionId}");
        }

        async public override Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("LeavedUser", $"{Context.ConnectionId}");
        }
    }
}
