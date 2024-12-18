using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.General
{
    public class dtoFormLabelSettings
    {
        public int ID { get; set; }
        public string? FormName { get; set; }
        public string? LabelName { get; set; }
        public string? OriginalCaption { get; set; }
        public string? NewCaption { get; set; }
        public bool Visible { get; set; }
    }
}
