using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Demo.SignalR.Hubs
{
    [HubName("imHub")]
    public class ImHub : Hub
    {
        public Task Send(string nick,string message)
        {
            return Clients.All.Send(nick, message);
        }
    }
}