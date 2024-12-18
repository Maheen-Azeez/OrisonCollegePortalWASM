namespace OrisonCollegePortal.Shared.Entities.General
{
    public class UserRights
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int? ProfileID { get; set; }
        public int BranchID { get; set; }
        public int KeywordID { get; set; }
        public string? Category { get; set; }
        public bool AllowOpen { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPrint { get; set; }
        public bool AccessDenied { get; set; }
        public string? Keyword { get; set; }
        public string? Module { get; set; }
    }
}
