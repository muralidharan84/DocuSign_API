
namespace Docusign.JobContract.API.Application.DocuSign.Commands.GeneratePDF
{
    public interface IGenerateReportCommandHandler
    {
        Task<string> Handle(GenerateReportCommand request, CancellationToken cancellationToken);
    }
}