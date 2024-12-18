using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance

{
    public class DtoStudentReceiptStatement
    {
		public int ID { get; set; }
		public string? VNo { get; set; }
		public int VType { get; set; }
		public string? VoucherType { get; set; }
		public decimal? Amount { get; set; }
		public DateTime? VDate { get; set; }
		public int Posted { get; set; }
		public string? RefNo { get; set; }
		public int IsCanceled { get; set; }
		public decimal? Discount { get; set; }
		public decimal? NetAmt { get; set; }
		public string? Field5 { get; set; }
		public string? VNoInt { get; set; }
		public int AccountID { get; set; }
		public string? AccountCode { get; set; }
		public string? AccountName { get; set; }
		public string? Grade { get; set; }
		public string? Description { get; set; }
	}
}
