using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtImportStudent
    {
        public int ST_ID { get; set; }
        public string? ST_ARB_NAME { get; set; }
        public string? FatherName { get; set; }
        public string? ST_ENG_NAME { get; set; }
        public DateTime ST_BirthDate { get; set; }
        public DateTime ST_JoinDate { get; set; }
        public int ParID { get; set; }
        public string? TEL1 { get; set; }
        public string? TEL2 { get; set; }
        public string? MOB_NO { get; set; }
        public string? Email { get; set; }
        public string? section_arb { get; set; }
        public string? section_eng { get; set; }
        public string? Class_arb { get; set; }
        public string? Class_Eng { get; set; }
        public string? Registered { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModify { get; set; }
    }
}
