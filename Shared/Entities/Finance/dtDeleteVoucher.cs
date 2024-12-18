namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtDeleteVoucher
    {
        public int AccountId { get; set; }
        public int VType { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Discount { get; set; }

        public string? Type { get; set; }
        public string? Class { get; set; }
        public string? AcademicYear { get; set; }
        public string? Schedule { get; set; }
        public int? BranchID { get; set; }
    }
}
