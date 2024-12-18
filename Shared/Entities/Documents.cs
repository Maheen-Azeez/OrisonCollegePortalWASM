using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities
{
    public class Documents
    {
        public int Account_id { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public int Document_id { get; set; }
        public string? Type { get; set; }
        public string? DocumentNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? IssuePlace { get; set; }
        public string? FileName { get; set; }
        public string? Path { get; set; }
        public double? FileSize { get; set; }
    }
}
