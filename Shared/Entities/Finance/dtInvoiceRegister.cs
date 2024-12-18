using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtInvoiceRegister
    {
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public DateTime Taxvoicedate { get; set; }
        public string Invoicedornot { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string Division { get; set; }
        public string AcademicYear { get; set; }
        public int BranchID { get; set; }


        public string InvNo { get; set; }
        public string vno { get; set; }

        public string Class { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmt { get; set; }
        public decimal TaxableAmt { get; set; }
    }
}
