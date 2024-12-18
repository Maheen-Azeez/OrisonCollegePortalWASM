using System.ComponentModel.DataAnnotations;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtVoucher
    {
        [Key]
        public long ID { get; set; }
        public string? VNo { get; set; }
        public int VType { get; set; }
        public int VNoInt { get; set; }
        public string? RefNo { get; set; }
        public DateTime VDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? VoucherAgainst { get; set; }
        public string? CommonNarration { get; set; }
        public int BranchID { get; set; }
        public int Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public bool? Posted { get; set; }
        public bool? Printed { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Freezed { get; set; }
        public bool? IsCanceled { get; set; }
        public long? UserTrackID { get; set; }
        public string? PreparedBy { get; set; }
        public int? AccountID { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public int? StaffID { get; set; }
        public string? StaffName { get; set; }
        public string? StaffCode { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserID { get; set; }
        public int? ModifiedUserID { get; set; }
        public DateTime? CanceledDate { get; set; }
        public int? CanceledUserID { get; set; }
        public string? CurrencyAbbr { get; set; }
        public decimal? VATAmt { get; set; }
        public decimal? ExciseAmt { get; set; }
        public string? DocNo { get; set; }
        public string? PostingCode { get; set; }
        public decimal? VATPaid { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? VRound { get; set; }
        public decimal? TRound { get; set; }
        public string? Remark { get; set; }
        public string? RowState { get; set; }
    }
}
