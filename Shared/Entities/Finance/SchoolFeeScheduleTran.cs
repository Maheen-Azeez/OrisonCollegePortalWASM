using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolFeeScheduleTran
    {
        public int Id { get; set; }
        public string? FeeSchedule { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int? PriorityNo { get; set; }
        public string? Remarks { get; set; }
        public int ToPost { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string? Category { get; set; }
        public string? AcademicYear { get; set; }
        public decimal? DiscAmount { get; set; }
        public int? BranchId { get; set; }
        public string? RowState { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatPct { get; set; }
    }
}
