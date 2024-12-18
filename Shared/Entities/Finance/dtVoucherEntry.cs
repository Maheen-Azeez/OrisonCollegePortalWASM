using System.ComponentModel.DataAnnotations;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtVoucherEntry
    {
        [Key]
        public long ID { get; set; }
        public long VID { get; set; }
        public string? RowType { get; set; }
        public int AccountID { get; set; }
        public decimal? SlNo { get; set; }
        public string? Description { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? Reference { get; set; }
        public long? RefID { get; set; }
        public bool? VisibleonPrint { get; set; }
        public bool? Reconciled { get; set; }
        public DateTime? ReconciledDate { get; set; }
        public bool? Active { get; set; }
        public string? Action { get; set; }
        public long? UserTrackID { get; set; }
        public string? TranType { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? PostingSubCode { get; set; }
        public string? DocSubNo { get; set; }
        public string? RowState { get; set; }
        public string? TaxCode { get; set; }
        ///Update FeeAmount
        public decimal? Amount { get; set; }
    }
}
