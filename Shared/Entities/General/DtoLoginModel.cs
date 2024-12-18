using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.General
{
    public class DtoLoginModel
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public int? AccountID { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Section { get; set; }
        public int BranchID { get; set; }
        public string? BranchName { get; set; }
        public string? AcademicYear { get; set; }
        public string? Language { get; set; }
    }
}
