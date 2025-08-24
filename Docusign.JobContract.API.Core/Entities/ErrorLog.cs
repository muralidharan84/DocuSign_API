using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Core.Entities
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
    }
}
