using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities
{
    public class Student
    {
        public int AccountId { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? UnivRegNum { get; set; }
        public int BranchId { get; set; }
        public string? AcademicYear { get; set; }
        public string? Status { get; set; }
        public string? SubStatus { get; set; }
        public string? MobileNo1 { get; set; }
        public string? MobileNo2 { get; set; }
        public string? ProgrammeCode { get; set; }
        public string? ProgrammeYear { get; set; }
        public DateTime? Dob { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
        public string? Qualification { get; set; }
        public string? Attendedschool { get; set; }
        public string? Attendeduniversity { get; set; }
        public string? Stream { get; set; }
        public string? Religion { get; set; }
        public string? TeleNo { get; set; }
        public string? TeleNoOff { get; set; }
        public string? Otheremail { get; set; }
        public string? TeleNoRes { get; set; }
        public string? PerAddress { get; set; }
        public string? CommAddress { get; set; }
        public string? Email { get; set; }
        public string? University { get; set; }
        public string? Level { get; set; }
        public string? Modeofstudy { get; set; }
        public string? EntryYear { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Session { get; set; }
        public string? EntryPoint { get; set; }
        public string? EnrollmentStatus { get; set; }
        public string? Subjects { get; set; }
        public string? OptSubjects { get; set; }
        public string? SecondLanguage { get; set; }
        public string? Remarks { get; set; }
        public byte[]? Photo { get; set; }
        public int P_Id { get; set; }
        public string? FName { get; set; }
        public string? parentcode { get; set; }
        public string? parentname { get; set; }
        public string? MName { get; set; }
        public string? TelFather { get; set; }
        public string? TelMother { get; set; }
        public string? Guardian { get; set; }
        public string? Guardian_Email { get; set; }
        public string? MobileNo { get; set; }
        public string? P_Email { get; set; }

        public string? PickupPoint { get; set; }
        public string? DropOffPoint { get; set; }
        public string? Area { get; set; }
        public string? Emirate { get; set; }
        public string? StreetName { get; set; }
        public string? BuildingName { get; set; }
        public string? FlatNo { get; set; }
        public string? AllotedBusNo { get; set; }
    }
}
