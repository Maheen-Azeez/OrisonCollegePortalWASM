namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtStudentParam
    {
        public string? Remark { get; set; }
        public string? AcademicYear { get; set; }
        public int Branchid { get; set; }
        public int AccountID { get; set; }
        public DateTime VDate { get; set; }
        public Decimal Amount { get; set; }
        public string? CommonNarration { get; set; }
        public string? Description { get; set; }
        public string? FeetypeCode { get; set; }
        public string? PaymentmodeCode { get; set; }
        public string? Criteria { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Schedule { get; set; }
    }
}
