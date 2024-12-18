using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtnexo
    {
        public string? Id { get; set; }
        public string? AcademicHouse { get; set; }
        public string? BirthCounty { get; set; }
        public string? Birthplace { get; set; }
        public string? BoardingHouse { get; set; }
        public string? BoardingStatus { get; set; }
        public DateTime Dob { get; set; }
        public string? EnrolmentDate { get; set; }
        public string? EnrolmentTerm { get; set; }
        public string? EnrolmentYear { get; set; }
        public string? Ethnicity { get; set; }
        public string? FamilyId { get; set; }
        public string? Forename { get; set; }
        public string? FormGroup { get; set; }
        public string? FullName { get; set; }
        public string? FutureSchoolId { get; set; }
        public string? Gender { get; set; }

        public List<HomeAddress>? HomeAddresses { get; set; }
        //public HomeAddress HomeAddresses { get; set; }

        public string? Initials { get; set; }
        public string? LabelSalutation { get; set; }
        //public List<string> Languages { get; set; }
        public DateTime LastUpdated { get; set; }
        public string? LatestPhotoId { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string? LeavingReason { get; set; }
        public string? LeavingYearGroup { get; set; }
        public string? LetterSalutation { get; set; }
        public string? Middlenames { get; set; }
        public string? MobileNumber { get; set; }
        //public List<string> Nationalities { get; set; }
        public string? OfficialName { get; set; }
        public string? PersonalEmailAddress { get; set; }
        public Guid PersonGuid { get; set; }
        public string? PersonId { get; set; }
        public string? PreferredName { get; set; }
        public string? PreviousName { get; set; }
        public string? Religion { get; set; }
        public string? ResidentCountry { get; set; }
        public string? SchoolCode { get; set; }
        public string? SchoolEmailAddress { get; set; }
        public string? SchoolId { get; set; }
        public string? Surname { get; set; }
        public string? SystemStatus { get; set; }
        public string? Title { get; set; }
        public string? TutorEmployeeId { get; set; }
        public string? UniquePupilNumber { get; set; }
        public string? YearGroup { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public string? Postcode { get; set; }
        public bool Private { get; set; }
        public string? Town { get; set; }
        public string? Nationality { get; set; }
        public List<string>? Nationalities { get; set; }


    }

    public class HomeAddress
    {
        public string? Id { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public string? Postcode { get; set; }
        public bool Private { get; set; }
        public string? Town { get; set; }
    }
}

