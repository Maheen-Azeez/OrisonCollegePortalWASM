using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolStudentsArabic
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? Religion { get; set; }
        public string? Nationality { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Level { get; set; }
        public string? Class { get; set; }
        public string? PassportIssuePlace { get; set; }
        public string? GuardianName { get; set; }
        public string? Relation { get; set; }
        public string? Profession { get; set; }
        public string? ResAddress { get; set; }
        public string? OffAddress { get; set; }
        public string? TcCountry { get; set; }
        public string? TcAccademicYear { get; set; }
        public string? Program { get; set; }
        public string? Certificate { get; set; }
        public string? Principal { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? ResPbNo { get; set; }
        public string? OffPbNo { get; set; }
        public string? VisaIssuePlace { get; set; }
        public string? Gender { get; set; }
        public string? Ministry { get; set; }
        public string? StudentFrom { get; set; }
        public string? AcademicYear { get; set; }
        public string? TcType { get; set; }
        public string? Syllabus { get; set; }
        public string? JoiningClass { get; set; }
        public DateTime? PrevTcDate { get; set; }
        public DateTime? PrintDate { get; set; }
        public string? Arabic { get; set; }
    }
}
