using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Core.Entities
{
    public class SendStringDocumentRequest
    {
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
    }
}
