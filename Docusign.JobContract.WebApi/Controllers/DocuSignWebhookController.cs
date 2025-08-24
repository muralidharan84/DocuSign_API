using Docusign.JobContract.API.Application.DocuSign;
using Microsoft.AspNetCore.Mvc;

namespace Docusign.JobContract.WebApi.Controllers
{
    [ApiController]
    [Route("api/webhooks/docusign")]
    public class DocuSignWebhookController : ControllerBase
    {
        private readonly IEnvelopeStatusNotifier _notifier;

        public DocuSignWebhookController(IEnvelopeStatusNotifier notifier)
        {
            _notifier = notifier;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string body)
        {
            // Parse envelopeId + status from XML
            var envelopeId = "parsed...";
            var status = "parsed...";

            // Notify Application
            await _notifier.NotifyStatusChangedAsync(envelopeId, status);

            return Ok();
        }
    }

}
