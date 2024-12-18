using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities
{
    public class dtStudentTransaction
    {
        public string FeeSchedule { get; set; }
        public string TransSchedule { get; set; }
        public string AdmissionSchedule { get; set; }
        public string DiscountSchedule { get; set; }
        public string OtherFee { get; set; }
        public string TranDiscountSchedule { get; set; }
        public string AdmDiscountSchedule { get; set; }
        public bool? FeeDiscount { get; set; }
        public bool? TranDiscount { get; set; }
    }
}
