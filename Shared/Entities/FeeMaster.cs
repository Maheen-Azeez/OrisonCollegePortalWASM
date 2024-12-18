using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities
{
    public class FeeMaster
    {
        public int Id { get; set; }
        public int BranchID { get; set; }
        public int AccountId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FeeSchedule { get; set; }
        public string Type { get; set; }
        public Decimal Amount { get; set; }
        public string Discount { get; set; }
        public string AcademicYear { get; set; }
        public string DiscountSchedule { get; set; }
        public bool? FeeDiscount { get; set; }
        public int vtype { get; set; }
        public long VID { get; set; }
    }
}
