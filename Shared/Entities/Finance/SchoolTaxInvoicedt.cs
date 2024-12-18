namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolTaxInvoicedt
    {
        public int id { get; set; }
        public int BranchID { get; set; }
        public int UserID { get; set; }
        public string? invno { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public DateTime? invoicedate { get; set; }
        public string? accountcode { get; set; }
        public string? accountname { get; set; }
        public string? Class { get; set; }
        public string? Parentcode { get; set; }
        public string? Term { get; set; }
        public string? division { get; set; }
        public string? shift { get; set; }
        public string? AcademicYear { get; set; }
        public string? Vno { get; set; }
        public DateTime VDate { get; set; }
        public string? Feedescription { get; set; }
        public decimal FeeAmount { get; set; }
        public string? VatPercent { get; set; }
        public decimal VatAmount { get; set; }
        public decimal amount { get; set; }
        public string? Username { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Discount { get; set; }

        public DateTime DueDate { get; set; }
        public int TId { get; set; }
        public string? InNo { get; set; }
        public string? email { get; set; }
        public string? ParentName { get; set; }
        public string? permobile { get; set; }
        public DateTime FeeDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? category { get; set; }
        public string? PreparedBy { get; set; }
        public string? Taxcode { get; set; }
        public string? Muncipality { get; set; }
        public string? Company { get; set; }


    }
}
