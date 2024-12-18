using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolMailTemplate
    {
        public int Id { get; set; }
        public string? Template { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public int? BranchId { get; set; }
    }
}
