using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Core.Entities
{
    public class EnvelopeLog
    {
        public int Id { get; set; }
        public string EnvelopeId { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
