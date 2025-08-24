using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
namespace Docusign.JobContract.API.Infrastructure.Hubs
{
        public class EnvelopeStatusHub : Hub
        {
            public async Task Subscribe(string envelopeId)
            {
                //await Groups.AddToGroupAsync(Context.ConnectionId, envelopeId);
            }
        }

}
