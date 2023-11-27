using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChatExample.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendingMessageAsync(string message, string userName)
        {
            await Clients.All.SendAsync("receivedMessage", message, userName);
        }
    }
}
