using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolClassMaster
    {
        public int Id { get; set; }
        public int? Pno { get; set; }
        public string? Class { get; set; }
        public string? ClassName { get; set; }
        public string? RomanName { get; set; }
        public string? PromotedClass { get; set; }
        public string? ClassInArabic { get; set; }
        public string? PromotedClassArab { get; set; }
        public int? BranchId { get; set; }
        public string? Shift { get; set; }
        public string? AccYear { get; set; }
        public string? AcademicYear { get; set; }
    }
}
