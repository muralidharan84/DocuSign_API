using Docusign.JobContract.API.Application.DocuSign;
using Docusign.JobContract.API.Infrastructure.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Infrastructure.Services
{
    public class SignalREnvelopeStatusNotifier : IEnvelopeStatusNotifier
    {
        private readonly IHubContext<EnvelopeStatusHub> _hubContext;

        public SignalREnvelopeStatusNotifier(IHubContext<EnvelopeStatusHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyStatusChangedAsync(string envelopeId, string status)
        {
            //await _hubContext.Clients.Group(envelopeId)
            //    .SendAsync("EnvelopeStatusUpdated", new { envelopeId, status });
        }
    }
}
