using Docusign.JobContract.API.Core.Models;

namespace Docusign.JobContract.API.Application.DocuSign
{
    public interface IPdfGenerator
    {
      string GeneratePdf(RecipientModel document);
    }
}
