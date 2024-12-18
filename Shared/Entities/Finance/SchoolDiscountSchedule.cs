using System;
using System.Collections.Generic;

#nullable disable

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public partial class SchoolDiscountSchedule
    {
        public int Id { get; set; }
        public string Schedule { get; set; }
        public string Type { get; set; }
        public DateTime? StartDate { get; set; }
        public string Discount { get; set; }
        public string Description { get; set; }
        public string DiscountType { get; set; }
        public string Child { get; set; }
        public int BranchID { get; set; }
        public int PostTo { get; set; }
        public string NetDiscount { get; set; }

        public string AccountCode { get; set; }
        public string AccountName { get; set; }
    }
}
