using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtAdvanceReceiptRegister
    {
        public string VNo { get; set; }
        public string AccountCode { get; set; }
        public DateTime Date { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public string Shift { get; set; }
        public string iscanceled { get; set; }
        public string ChequeDetails { get; set; }
        public decimal Card { get; set; }
        public decimal Cash { get; set; }

        public decimal Cheque { get; set; }


    }
}
