using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Application.DocuSign
{
    public interface IEnvelopeStatusNotifier
    {
        Task NotifyStatusChangedAsync(string envelopeId, string status);
    }
}
