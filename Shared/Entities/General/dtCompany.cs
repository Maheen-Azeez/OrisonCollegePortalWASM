using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.General
{
    public class dtCompany
    {
        public int? Id { get; set; }
        public int? CompanyType { get; set; }
        public string? CompanyCode { get; set; }
        public string? Description { get; set; }
     
        public string? CompanyName { get; set; }
        public string? BranchName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public string? Fax { get; set; }
        public DateTime? EntryFrom { get; set; }
        public string? LetterHead { get; set; }
        public bool? AllowDelete { get; set; }
        public string? Currency { get; set; }
        public string? Trnno { get; set; }
        public string? Ernno { get; set; }
        public string? Vatplace { get; set; }
        public int? BankAccount { get; set; }
        public int? CashAccount { get; set; }
        public int? CardAccount { get; set; }
        public int? DiscountAccount { get; set; }
        public string? LogoName { get; set; }
        public string? Curriculum { get; set; }
        public string? Abbr { get; set; }
        public string? DomainName { get; set; }
        public string? ReportPath { get; set; }
        public string? ReportPathVpn { get; set; }
        public string? PayTabProfileId { get; set; }
        public string? PayTabServerKey { get; set; }
        public string? PayTabCallbackUrl { get; set; }
        public string? PayTabReturnUrl { get; set; }
        public decimal? NewRegFee { get; set; }
        public decimal? ReRegFee { get; set; }
        public int? Target { get; set; }
        public int? Capacity { get; set; }
        public decimal? ReReg_Fee { get; set; }
    }
}
