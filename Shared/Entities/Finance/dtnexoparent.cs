using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtnexoparent
    {

        public string? Id { get; set; }
        public string? AdditionalId { get; set; }
        public string? schoolId { get; set; }

        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int AddressId { get; set; }
        public bool Billing { get; set; }
        public bool CanShareWithOtherParents { get; set; }
        public bool ContactOnly { get; set; }
        public string? ContactType { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public bool Deceased { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmergencyNotes { get; set; }
        public string? Fax { get; set; }
        public string? Forename { get; set; }
        public bool IncludeInAllMailMerges { get; set; }
        public bool IncludeInMailMergeForBilling { get; set; }
        public bool IncludeInMailMergeForCorrespondence { get; set; }
        public bool IncludeInMailMergeForReports { get; set; }
        public DateTime LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? MiddleNames { get; set; }
        public string? MobileNumber { get; set; }
        public string? NationalId { get; set; }
        public string? ParentalResponsibility { get; set; }
        public string? PassportNumber { get; set; }
        public string? PersonGuid { get; set; }
        public string? PersonId { get; set; }
        public string? Postcode { get; set; }
        public string? PreferredPaymentMethod { get; set; }
        public bool Private { get; set; }
        public string? Profession { get; set; }
        public string? Relationship { get; set; }
        public string? RelationshipOfJointContact { get; set; }
        public string? SecondaryPersonGuid { get; set; }
        public string? SecondaryPersonId { get; set; }
        public string? Surname { get; set; }
        public string? TaxRegistrationNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Title { get; set; }
        public string? Town { get; set; }
        public string? WorkTelephoneNumber { get; set; }
        public Address? Address { get; set; }
        
    }

    public class Address
    {
        public string? Id { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? AddressId { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public string? Postcode { get; set; }
        public string? Town { get; set; }
    }

    public class RootObject
    {
        public List<dtnexoparent>? Contacts { get; set; }
    }
}

