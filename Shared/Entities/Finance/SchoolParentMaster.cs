using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolParentMaster
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? TelOff { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Pobox { get; set; }
        public string? Occupation { get; set; }
        public string? Location { get; set; }
        public string? Type { get; set; }
        public string? Mother { get; set; }
        public string? MotherTelOff { get; set; }
        public string? MotherMobile { get; set; }
        public string? MotherFax { get; set; }
        public string? MotherEmail { get; set; }
        public string? Guardian { get; set; }
        public string? PerTelOff { get; set; }
        public string? PermMobile { get; set; }
        public string? GuardianFax { get; set; }
        public string? GuardianRelation { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Emirates { get; set; }
        public string? PerTel { get; set; }
        public string? PerMobile { get; set; }
        public string? PerFax { get; set; }
        public string? PerEmail { get; set; }
        public string? PerAddress1 { get; set; }
        public string? PerAddress2 { get; set; }
        public string? PerAddress3 { get; set; }
        public string? PerPobox { get; set; }
        public string? PerCountry { get; set; }
        public string? PerState { get; set; }
        public string? PerCity { get; set; }
        public string? PerEmirates { get; set; }
        public string? GuardianRemarks { get; set; }
        public string? PerPhone { get; set; }
        public string? Company { get; set; }
        public string? Profession { get; set; }
        public string? PlaceOfWork { get; set; }
        public string? IsGuardian { get; set; }
        public string? SmsNumber { get; set; }
        public bool? SpeakEnglish { get; set; }
        public bool? SpeakEnglishMother { get; set; }
        public string? PerMobile2 { get; set; }
        public string? PerEmail2 { get; set; }
        public string? MotherMobile2 { get; set; }
        public string? MotherEmail2 { get; set; }
        public string? MotherProfession { get; set; }
        public string? ParentType { get; set; }
        public string? MotherHomeTel { get; set; }
        public string? FatherName { get; set; }
        public string? SecondRelation { get; set; }
        public string? MotherWorkingPlace { get; set; }
        public string? MotherCompany { get; set; }
        public string? RelationContacts { get; set; }
        public string? StreetName { get; set; }
        public string? Muncipality { get; set; }
        public string? ParentNationality { get; set; }
        public string? Qualification { get; set; }
        public string? MotherQualification { get; set; }
        public string? MotherNationality { get; set; }
        public string? ThirdPerEmiratesid { get; set; }
        public string? FatherEmitaresId { get; set; }
        public DateTime? FatherEidexpiry { get; set; }
        public string? MotherEmiratesId { get; set; }
        public DateTime? MotherEidexpiry { get; set; }
        public bool? Deceased { get; set; }
        public DateTime? DeceasedDate { get; set; }
        public string? ChildPickUpYes { get; set; }
        public string? Iseligible { get; set; }
        public byte[]? FatherPhoto { get; set; }
        public byte[]? MotherPhoto { get; set; }
        public bool? Divorced { get; set; }
        public bool? Fdeceased { get; set; }
        public bool? Mdeceased { get; set; }
        public byte[]? SecondMotherPhoto { get; set; }
        public bool? ParentBlocked { get; set; }
        public string? ThirdRemarks { get; set; }
        public string? ThirdContactEmail { get; set; }
        public string? Remarksgrms { get; set; }
        public int? StaffParent { get; set; }
        public byte[]? ThirdContactPhoto { get; set; }
        public string? WhatsAppNo { get; set; }
        public string? PrimaryContact { get; set; }
        public DateTime? ParentMDate { get; set; }
        public string? InvoiceAgainst { get; set; }
    }
}
