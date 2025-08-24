using Docusign.JobContract.API.Application.DocuSign.Commands.SendDocumentForSigning;
using Docusign.JobContract.API.Application.DocuSign.Queries.GetEnvelopeStatus;
using Docusign.JobContract.API.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Docusign.JobContract.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvelopesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnvelopesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("send")]
        //public async Task<IActionResult> Send([FromForm] IFormFile file, [FromQuery] string recipientEmail, [FromQuery] string recipientName)
        //{
        //    using var ms = new MemoryStream();
        //    await file.CopyToAsync(ms);

        //    var envelopeId = await _mediator.Send(new SendDocumentForSigningCommand(recipientEmail, recipientName, "", file.FileName));
        //    return Ok(new { EnvelopeId = envelopeId });
        //}
        [HttpPost("send")]
        public async Task<IActionResult> SendOfferForSinging([FromBody] SendStringDocumentRequest request)
        {
            var envelopeLog = await _mediator.Send(new SendDocumentForSigningCommand(
                request.RecipientEmail, request.RecipientName, request.Content, request.FileName));

            return Ok(new { envelopeLog = envelopeLog });
        }

        [HttpGet("{envelopeId}/status")]
        public async Task<IActionResult> GetStatus(string envelopeId)
        {
            var status = await _mediator.Send(new GetEnvelopeStatusQuery(envelopeId));
            return Ok(new { Status = status });
        }
    }

}
