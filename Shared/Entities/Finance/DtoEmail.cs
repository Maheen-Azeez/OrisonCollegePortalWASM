
using OrisonCollegePortal.Shared.Entities.BoldReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class DtoEmail
    {
        public string? GetFromUser { get; set; }
        public string? Category { get; set; }
        public string? GetPwd { get; set; }
        public string? Recievr { get; set; }
        public string? GetHost { get; set; }
        public string? GetPort { get; set; }
        public string? Pwd { get; set; }
        public string? SourceCon { get; set; }
        public string? GetUsername { get; set; }
        public string? GetMailBCC { get; set; }
        public string?  GetCompanyName { get; set; }
        public string? ToMail { get; set; }
        public DataSource? dt { get; set; }
        public string? parentName { get; set; }
    }
}
