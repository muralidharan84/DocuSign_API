using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Docusign.JobContract.API.Application.DocuSign.Commands.GeneratePDF
{


    public class GenerateReportCommandHandler
       : IRequestHandler<GenerateReportCommand, string>
    {

        private readonly IDocuSignApiClient _docuSignApiClient; // low-level integration
        public GenerateReportCommandHandler(IDocuSignApiClient docuSignApiClient)
        {
            _docuSignApiClient = docuSignApiClient;
        }
        public async Task<string> Handle(GenerateReportCommand request, CancellationToken cancellationToken)
        {
            return await _docuSignApiClient.GetOfferLetterPDFAsync(
               request.Document
           );
        }

    }


}
