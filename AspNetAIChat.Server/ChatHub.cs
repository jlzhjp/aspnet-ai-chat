using Microsoft.AspNetCore.SignalR;
using System.Security;

namespace AspNetAIChat.Server;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
    }
}
