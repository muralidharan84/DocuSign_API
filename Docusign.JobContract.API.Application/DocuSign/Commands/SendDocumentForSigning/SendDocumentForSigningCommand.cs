using Docusign.JobContract.API.Core.Entities;
using MediatR;
namespace Docusign.JobContract.API.Application.DocuSign.Commands.SendDocumentForSigning
{
  
       

public record SendDocumentForSigningCommand(
    string RecipientEmail,
    string RecipientName,
    string DocumentString,
    string DocumentName
) : IRequest<EnvelopeLog>;
}
