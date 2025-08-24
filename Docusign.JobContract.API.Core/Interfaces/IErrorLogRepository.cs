using Docusign.JobContract.API.Core.Entities;

namespace MyApp.Core.Interfaces
{
    public interface IErrorLogRepository
    {
        Task AddErrorLogAsync(ErrorLog log);
    }
}
