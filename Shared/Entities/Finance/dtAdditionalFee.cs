namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtAdditionalFee
    {
        public string? Code { get; set; }
        public string? FeeSchedule { get; set; }
        public int? Priorityno { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Remarks { get; set; }
        public int PostTo { get; set; }
        public DateTime DueDate { get; set; }
        public string? AcademicYear { get; set; }
        public int BranchId { get; set; }
        public Boolean? DiscountPossible { get; set; }
        public string? Type { get; set; }
        public Boolean? DateChecking { get; set; }
        public int? Discount { get; set; }
        public string? ReceiptType { get; set; }
        public string? DiscountType { get; set; }
        public Boolean? VatApplicable { get; set; }
        public int VatPercent { get; set; }
        public string? TAXCode { get; set; }
        public Boolean? VatInclusive { get; set; }
        public decimal Amount { get; set; }
    }
}

