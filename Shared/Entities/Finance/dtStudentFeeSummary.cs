using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtStudentFeeSummary
    {

        [Key]
        public Decimal CurrentFee { get; set; }
        public Decimal TotalFee { get; set; }
        public Decimal Paid { get; set; }
        public Decimal TotalBalance { get; set; }
        public Decimal CurrentBalance { get; set; }
        public Decimal Discount { get; set; }
    }
}
