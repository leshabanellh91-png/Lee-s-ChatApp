using Microsoft.AspNetCore.SignalR;

namespace LeratosChatServer.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        var chatMessage = new
        {
            User = user,
            Text = message,
            SentAt = DateTime.UtcNow
        };

        await Clients.All.SendAsync("ReceiveMessage", chatMessage);
    }
}
