using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.General
{
    public class SchoolWebMenuSettings
    {
        public int Id { get; set; }
        public string? MenuName { get; set; }
        public string? Section { get; set; }
        public bool Visible { get; set; }
        public string? OriginalTitle { get; set; }
        public string? NewTitle { get; set; }
    }
}
