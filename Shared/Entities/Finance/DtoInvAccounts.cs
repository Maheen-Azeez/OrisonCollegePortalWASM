using System.ComponentModel.DataAnnotations;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class DtoInvAccounts
    {
        [Key]
        public int ID { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? TRNNo { get; set; }
        public string? AccCategory { get; set; }
        public string? SubGroup { get; set; }
        public string? AccountGroup { get; set; }
        public bool? VoucherEntry { get; set; }
        public string? GroupType { get; set; }
        public int? ParentID { get; set; }
        public string? ParentCode { get; set; }
        public string? Parent { get; set; }
        public string? Address1 { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? ContactPerson { get; set; }
        public string? Category { get; set; }
        public int? StaffID { get; set; }
        public string? StaffName { get; set; }
        public string? Price { get; set; }
        public string? PBNo { get; set; }
        public bool? IsDefault { get; set; }
        public string? Country { get; set; }
        public string? Emirates { get; set; }
        public string? VATPlace { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? CompanyName { get; set; }
        public string? Department { get; set; }
        public int? DesignationID { get; set; }
        public string? Website { get; set; }
        public string? Remarks { get; set; }
        public string? fileName { get; set; }
        public string? Class { get; set; }
        public string? Division { get; set; }
        public string? Nationality { get; set; }
        public string? Sex { get; set; }
        public int? AllcID { get; set; }
        public decimal? Amount { get; set; }

    }
}
