using Microsoft.AspNetCore.SignalR;
using LeratosChatServer1.Models;

namespace LeratosChatServer1.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var chatMessage = new ChatMessage
            {
                User = user,
                Text = message,
                SentAt = DateTime.UtcNow
            };

            await Clients.All.SendAsync("ReceiveMessage", chatMessage);
        }
    }
}
