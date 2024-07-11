using Microsoft.AspNetCore.SignalR;

namespace API_ProjectHammeau.Hubs
{
    public class GamesHub : Hub
    {
        public async Task SendMessage(string user, string message)
        => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
