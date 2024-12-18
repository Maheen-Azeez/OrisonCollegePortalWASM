using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolFeeMaster
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public int PriorityNo { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Remarks { get; set; }
        public int PostTo { get; set; }
        public DateTime? DueDate { get; set; }
        public bool DiscountPossible { get; set; }
        public string? Type { get; set; }
        public decimal Amount { get; set; }
        public bool DateChecking { get; set; }
        public string? AcademicYear { get; set; }
        public int Discount { get; set; }
        public string? ReceiptType { get; set; }
        public string? DiscountType { get; set; }
        public bool VatApplicable { get; set; }
        public string? VatPercent { get; set; }
        public string? Taxcode { get; set; }
        public bool VatInclusive { get; set; }
        public int BranchId { get; set; }
        public DateTime? EndDate { get; set; }

        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? DiscountAccountCode { get; set; }
        public string? DiscountAccountName { get; set; }
    }
}
