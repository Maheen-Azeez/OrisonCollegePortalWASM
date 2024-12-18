using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtoStudentRegisterDefault
    {
        [Key]
        public int AccountID { get; set; }
        public int ID { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? StudentStatus { get; set; }
        public string? Sex { get; set; }
        public string? Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Class { get; set; }
        public string? Division { get; set; }
        public string? JoiningAcademicYear { get; set; }
        public DateTime StartsFrom { get; set; }
        public string? ParentCode { get; set; }
        public string? ParentName { get; set; }
        public string? PerMobile { get; set; }
        public string? Email { get; set; }
        public string? Mother { get; set; }
        public string? MotherEmail { get; set; }
        public string? MotherMobile { get; set; }
        public string? AcademicYear { get; set; }
        public string? Shift { get; set; }
        public string? Memo { get; set; }
        public string? MinistryStatus { get; set; }
        public string? SubStatus { get; set; }
        public string? Age { get; set; }
        public string? SmsNumber { get; set; }
        public string? ArabNonArab { get; set; }
        public string? BusMode { get; set; }
        public string? BusNo { get; set; }
        public string? SENChild { get; set; }
        public string? SportsHouse { get; set; }
        public string? Religion { get; set; }
        public string? Mobile { get; set; }
        public string? TRNNo { get; set; }
        public string? Emirates { get; set; }
        public string? Address1 { get; set; }
        public DateTime ProcessedDate { get; set; }
        public int? AllcID { get; set; }
        public int? ParentID { get; set; }
        public string? Slanguage { get; set; }
    }
}
