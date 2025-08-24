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
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly AppDbContext _context;
        public ErrorLogRepository(AppDbContext context) => _context = context;

        public async Task AddErrorLogAsync(ErrorLog log)
        {
            _context.ErrorLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
