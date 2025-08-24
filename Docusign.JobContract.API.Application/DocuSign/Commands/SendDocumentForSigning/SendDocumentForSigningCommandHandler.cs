using Docusign.JobContract.API.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Application.DocuSign.Commands.SendDocumentForSigning
{
   

    public class CreateDocumentForSigningCommandHandler
        : IRequestHandler<SendDocumentForSigningCommand, EnvelopeLog>
    {
        private readonly IDocuSignApiClient _docuSignApiClient; // low-level integration

        public CreateDocumentForSigningCommandHandler(IDocuSignApiClient docuSignApiClient)
        {
            _docuSignApiClient = docuSignApiClient;
        }

        public async Task<EnvelopeLog> Handle(SendDocumentForSigningCommand request, CancellationToken cancellationToken)
        {
            return await _docuSignApiClient.SendStringDocumentForSigningAsync(
                request.RecipientEmail,
                request.RecipientName,
                request.DocumentString,
                request.DocumentName
            );
        }
    }

}
