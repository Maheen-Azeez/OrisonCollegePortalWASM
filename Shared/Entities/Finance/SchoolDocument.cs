using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolDocument
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Document Type is Required")]
        public string? DocumentType { get; set; }
        public int? AccountId { get; set; }
        [Required(ErrorMessage = "Document No is Required")]
        public string? DocumentNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? IssuePlace { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
    }
}
