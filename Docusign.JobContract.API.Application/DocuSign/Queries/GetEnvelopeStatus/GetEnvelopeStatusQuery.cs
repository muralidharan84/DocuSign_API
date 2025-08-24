namespace Docusign.JobContract.API.Application.DocuSign.Queries.GetEnvelopeStatus
{
    using MediatR;

    public record GetEnvelopeStatusQuery(string EnvelopeId) : IRequest<string>;

}
