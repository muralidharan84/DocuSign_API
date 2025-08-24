using Docusign.JobContract.API.Core.Models;
using MediatR;

namespace Docusign.JobContract.API.Application.DocuSign.Commands.GeneratePDF
{

    public class GenerateReportCommand : IRequest<string>
    {
        public JobOfferModel Document { get; }

        public GenerateReportCommand(JobOfferModel document)
        {
            Document = document;
        }
    }



}
