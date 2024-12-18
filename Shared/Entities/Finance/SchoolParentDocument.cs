using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolParentDocument
    {
        public int Id { get; set; }
        public string? DocumentType { get; set; }
        public int? AccountId { get; set; }
        public string? DocumentNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? IssuePlace { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
    }
}
