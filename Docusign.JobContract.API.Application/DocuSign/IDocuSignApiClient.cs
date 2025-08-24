using Docusign.JobContract.API.Core.Entities;
using Docusign.JobContract.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Application.DocuSign
{
    public interface IDocuSignApiClient
    {
        Task<EnvelopeLog> SendStringDocumentForSigningAsync(
        string recipientEmail,
        string recipientName,
        string content,
        string fileName);

        Task<string> GetEnvelopeStatusAsync(string EnvelopeId);

        Task<string> GetOfferLetterPDFAsync(JobOfferModel document);
    }
}
