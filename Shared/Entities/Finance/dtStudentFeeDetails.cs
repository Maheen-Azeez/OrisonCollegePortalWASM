using System.ComponentModel.DataAnnotations;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtStudentFeeDetails
    {
        [Key]
        public string? VNo { get; set; }
        public DateTime VDate { get; set; }
        public string? VoucherAgainst { get; set; }
        public string? CommonNarration { get; set; }
        public Decimal FeeAmount { get; set; }
        public Decimal Allocated { get; set; }
        public Decimal AllocatedAmount { get; set; }
        public Decimal Vat { get; set; }
        public string? VatType { get; set; }
        public int ID { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Balance { get; set; }
        public Decimal credit { get; set; }
        public Decimal Debit { get; set; }
        public Decimal Paid { get; set; }
    }
}
