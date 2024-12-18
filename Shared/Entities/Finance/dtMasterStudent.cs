using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtMasterStudent
    {
        public Accounts? accentry { get; set; }
        public SchoolStudent? Studententry { get; set; }
        public SchoolStudentTran? Studenttranentry { get; set; }
       public SchoolStudentsArabic? Studentarabicentry { get; set; }

        public Accounts? ParentAccentry { get; set; }
        public SchoolParentMaster? Parententry { get; set; }

        public SchoolImage? Imageentry { get; set; }
        public SchoolStudentNote? Notesentry { get; set; }
        public SchoolFamilyDetail? Relationentry { get; set; }

        public SchoolDocument? docmaster { get; set; }
        public SchoolDocImage? docImage { get; set; }

        public DtoUserTrack? UserTrack { get; set; }

        public SchoolFeeMaster? FeeMasterEntry { get; set; }

        public SchoolParentDocument? Parentdocmaster { get; set; }
        public SchoolParentDocImage? ParentdocImage { get; set; }
    }
}
