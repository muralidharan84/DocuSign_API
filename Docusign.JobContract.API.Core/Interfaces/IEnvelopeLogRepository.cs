using Docusign.JobContract.API.Core.Entities;

namespace MyApp.Core.Interfaces
{
    
        public interface IEnvelopeLogRepository
        {
            Task AddEnvelopeLogAsync(EnvelopeLog log);
        }
}
