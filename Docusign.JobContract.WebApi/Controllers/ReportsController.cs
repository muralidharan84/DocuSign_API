using Docusign.JobContract.API.Application.DocuSign.Commands.GeneratePDF;
using Docusign.JobContract.API.Core.Models;
using DocuSign.eSign.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Docusign.JobContract.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateReport([FromBody] JobOfferModel content)
        {
            try
            {
                var pdfUrl = await _mediator.Send(new GenerateReportCommand(content));
                // build public URL
                var fileName = $"JobOffer_{content.CandidateName}.pdf";
                var fileUrl = $"{Request.Scheme}://{Request.Host}/GeneratedReports/{fileName}";
              
                return Ok(new { url = fileUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
