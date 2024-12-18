using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtfeewiseregister
    {
        public int AccountID { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? StudentStatus { get; set; }
        public DateTime? Date { get; set; }
        public string? Class { get; set; }
        public string? Division { get; set; }
        public string? Email { get; set; }
        public string? JoiningAcademicYear { get; set; }
        public string? PerMobile { get; set; }
        public string? ParentCode { get; set; }
        public string? ParentName { get; set; }
        public string? AcademicYear { get; set; }
        public string? SmsNumber { get; set; }
        public string? Description { get; set; }
        public Decimal Credit { get; set; }
        public Decimal Debit { get; set; }
        public Decimal Balance { get; set; }
        public Decimal Paid { get; set; }
        public string? Shift { get; set; }
    }
}
