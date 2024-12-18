using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolImage
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? Type { get; set; }
        public byte[]? Photo { get; set; }
    }
}
