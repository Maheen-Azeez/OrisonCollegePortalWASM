using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities
{
    public class CollegeClass
    {
        public int ID { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public string FeeSchedule { get; set; }
        public string Schedule { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
    }
}
