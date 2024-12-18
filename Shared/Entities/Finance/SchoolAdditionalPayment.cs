using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolAdditionalPayment
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? Activity { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal Amount { get; set; }
        public bool? Posted { get; set; }
        public int? PostTo { get; set; }
        public string? Remarks { get; set; }
        public int? Repeat { get; set; }
        public string? VoucherId { get; set; }
        public string? Type { get; set; }
        public DateTime? SupEndDate { get; set; }
    }
}
