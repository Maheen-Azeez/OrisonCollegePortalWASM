using OrisonCollegePortal.Shared.Entities.BoldReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class DtoEmailSettings
    {
        public string? GetFromUser { get; set; }
        public string? GetHost { get; set; }
        public string? GetPort { get; set; }
        public string? GetPwd { get; set; }
        public string? GetCompanyName { get; set; }
        public string? GetUsername { get; set; }
        public DataSource? dt { get; set; }

        public string? To { get; set; }
        public string? Bcc { get; set; }
        public string? Cc { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? Attachments { get; set; }
    }
}
