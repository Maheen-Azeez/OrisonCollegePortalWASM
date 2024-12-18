using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtNexoPay
    {
        [Key]
        public string? sourcedId { get; set; }
        public string? status { get; set; }
        public DateTime? dateLastModified { get; set; }
        public object? metadata { get; set; }
        public string? username { get; set; }
        public string? userId { get; set; }
        public string? identifier { get; set; }
        public string? givenName { get; set; }
        public string? familyName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }
        public string? role { get; set; }
        public string? email { get; set; }
        //public string demographics { get; set; }
        public List<agents>? agents { get; set; }
        public object? orgs { get; set; }
        public object? demographics { get; set; }
        public object? transportDetails { get; set; }
        //public object grades { get; set; }
        public List<string>? grades { get; set; }
        public string? password { get; set; }
        public string? fullName { get; set; }
        public DateTime joinDate { get; set; }
        public string? mobileNumber { get; set; }
        public string? address { get; set; }
        public DateTime accountEstablishedDate { get; set; }
        public string? gender { get; set; }
        public string? nationality { get; set; }
        public string? religion { get; set; }
        public string? studentQatarId { get; set; }
        public string? guardianOneFullName { get; set; }
        public string? guardianOneFirstName { get; set; }
        public string? guardianOneLastName { get; set; }
        public string? guardianTwoFullName { get; set; }
        public string? guardianTwoFirstName { get; set; }
        public string? guardianTwoLastName { get; set; }
        public string? guardianTwoMobileNumber { get; set; }
        public string? guardianThreeFirstName { get; set; }
        public string? guardianThreeLastName { get; set; }
        public string? guardianThreeMobileNumber { get; set; }
        public string? groupCode { get; set; }
        public string? primaryContact { get; set; }
        public string? guardianOneEmail { get; set; }
        public string? guardianTwoEmail { get; set; }
        public string? lastModifiedBy { get; set; }
        public string? motherQatarId { get; set; }
        public string? officeNumber { get; set; }
        public string? fatherQatarId { get; set; }
        public string? familyCode { get; set; }
        public DateTime studentDob { get; set; }
        //public string ClassDiv { get; set; }
        public classDetails? classDetails { get; set; }
        public string? grade { get; set; }
        public string? section { get; set; }
    }

    public class agents
    {
        public string? sourcedId { get; set; }
        public string? href { get; set; }
        public string? type { get; set; }
    }

    public class classDetails
    {
        public string? grade { get; set; }
        public string? section { get; set; }
    }
}
