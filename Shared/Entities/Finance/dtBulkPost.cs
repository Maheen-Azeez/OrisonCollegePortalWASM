namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtBulkPost
    {
        public string? Posted { get; set; }
        public string? FeeSchedule { get; set; }

        public int AccountID { get; set; }
        public string? Class { get; set; }
        public string? StudentName { get; set; }
        public string? AccountName { get; set; }
        public string? AccountCode { get; set; }

        public string? ParentCode { get; set; }
        public string? ParentName { get; set; }

        public string? Division { get; set; }
        public string? StudentCode { get; set; }
        public int? BranchId { get; set; }
        public string? Academicyear { get; set; }
        public decimal Amount { get; set; }   
    }
}
