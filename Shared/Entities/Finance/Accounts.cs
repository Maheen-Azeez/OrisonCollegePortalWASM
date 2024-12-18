namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class Accounts
    {
        public int Id { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public int? Parent { get; set; }
        public int ParentLevel { get; set; }
        public bool? VoucherEntry { get; set; }
        public bool FinalAccount { get; set; }
        public int AccountGroup { get; set; }
        public int? SubGroup { get; set; }
        public int? AccCategory { get; set; }
        public bool? ShowChild { get; set; }
        public bool? Isdefault { get; set; }
        public bool? AllowEntry { get; set; }
        public bool InActive { get; set; }
        public bool? Editable { get; set; }
        public long? UserTrackId { get; set; }
        public int? Currency { get; set; }
        public int? BranchId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? CreatedUser { get; set; }
        public int? ModifiedUser { get; set; }
        public int? AorderNo { get; set; }
        public int? Ccid { get; set; }
        public bool? InVisible { get; set; }
        public decimal? SortField { get; set; }
        public bool? ShowRow { get; set; }
        public string? TempCode { get; set; }
        public int? CashAccount { get; set; }
        public int? CardAccount { get; set; }
        public int? DiscountAccount { get; set; }
        public int? BankAccount { get; set; }
        public string? Sapidstudent { get; set; }
        public string? Sapidparent { get; set; }
    }
}
