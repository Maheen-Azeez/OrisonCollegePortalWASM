using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolFeeSchedule
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? FeeSchedule { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Remarks { get; set; }
        public decimal? Total { get; set; }
        public string? AcademicYear { get; set; }
        public string? Class { get; set; }
        public bool? FeeDiscount { get; set; }
        public int BranchId { get; set; }
    }
}
