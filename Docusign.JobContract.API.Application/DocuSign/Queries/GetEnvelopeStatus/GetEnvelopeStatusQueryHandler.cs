namespace Docusign.JobContract.API.Application.DocuSign.Queries.GetEnvelopeStatus
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetEnvelopeStatusQueryHandler
        : IRequestHandler<GetEnvelopeStatusQuery, string>
    {
        private readonly IDocuSignApiClient _docuSignApiClient;

        public GetEnvelopeStatusQueryHandler(IDocuSignApiClient docuSignApiClient)
        {
            _docuSignApiClient = docuSignApiClient;
        }

        public async Task<string> Handle(GetEnvelopeStatusQuery request, CancellationToken cancellationToken)
        {
            return await _docuSignApiClient.GetEnvelopeStatusAsync(request.EnvelopeId);
        }
    }

}
