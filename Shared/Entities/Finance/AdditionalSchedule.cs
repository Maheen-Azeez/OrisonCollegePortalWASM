namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class AdditionalSchedule
    {
        public string? Type { get; set; }
        public string? FeeSchedule { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public Decimal Total { get; set; }
        public string? AcademicYear { get; set; }
        public string? BranchID { get; set; }
    }
}
