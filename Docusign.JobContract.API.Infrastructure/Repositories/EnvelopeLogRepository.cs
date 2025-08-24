using Docusign.JobContract.API.Core.Entities;
using Docusign.JobContract.API.Infrastructure.Data;
using MyApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Infrastructure.Repositories
{
    public class EnvelopeLogRepository : IEnvelopeLogRepository
    {
        private readonly AppDbContext _context;
        public EnvelopeLogRepository(AppDbContext context) => _context = context;

        public async Task AddEnvelopeLogAsync(EnvelopeLog log)
        {
            _context.EnvelopeLog.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
