using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string? Class { get; set; }
        public string? Division { get; set; }
        public string? ProgrammeYear { get; set; }
        public string? ProgrammeCode { get; set; }
        public string? Programme { get; set; }
        public int? StaffId { get; set; }
        public string? Strength { get; set; }
        public string? Block { get; set; }
        public string? Room { get; set; }
        public int? StaffIda { get; set; }
        public string? Shift { get; set; }
        public string? Building { get; set; }
        public string? Section { get; set; }
        public int? BranchId { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? AccYear { get; set; }
        public string? AcademicYear { get; set; }
    }
}
