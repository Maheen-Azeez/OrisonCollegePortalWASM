namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class AdditionalTrack
    {
        public int ID { get; set; }
        public string? Code { get; set; }
        public string? AcademicYear { get; set; }
        public int PNo { get; set; }
        public int PostTo { get; set; }
        public string? ReceiptType { get; set; }
        public string? VatPercent { get; set; }
        public string? TaxCode { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public int PriorityNo { get; set; }
        public int BranchID { get; set; } 

        public bool VATInclusive { get; set; }

        public bool VATApplicable{get; set;}
    }
}
