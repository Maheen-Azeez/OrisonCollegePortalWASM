namespace OrisonCollegePortal.Shared.Entities.General
{
    public class VtypeTrans
    {

        public int ID { get; set; }
        public int BasicType { get; set; }
        public string? VType { get; set; }
        public string? Abbreviation { get; set; }
        public string? Title { get; set; }
        public string? PrintTitle { get; set; }
        public int DocumentType { get; set; }
        public string? AutoPosting { get; set; }
        public string? PrintAfterSave { get; set; }
        public string? ShowCheques { get; set; }
        public string? ShowAllocation { get; set; }
        public int Numbering { get; set; }
        public string? MustTally { get; set; }
        public string? AllowDuplicate { get; set; }
        public string? Editable { get; set; }
        public string? EntryMode { get; set; }
        public int OrderNo { get; set; }
        public string? MainRowType { get; set; }
        public int InvoiceType { get; set; }
        public int RowType { get; set; }
        public int CashAccount { get; set; }
        public int BankAccount { get; set; }
        public int CardAccount { get; set; }
        public int PostAccount { get; set; }
        public string? ArabicName { get; set; }
        public int CCTRowType { get; set; }
        public int CCStockType { get; set; }
        public string? ImportSource { get; set; }
        public string? ToVeCc { get; set; }
        public int WHID { get; set; }
        public bool FinWeb { get; set; }
    }
}
