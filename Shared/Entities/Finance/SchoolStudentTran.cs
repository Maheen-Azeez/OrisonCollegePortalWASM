﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolStudentTran
    {
        public int Id { get; set; }
        public string? AcademicYear { get; set; }
        public int AccountId { get; set; }
        public string? RollNo { get; set; }
        public string? Status { get; set; }
        public string? PrevStatus { get; set; }
        public string? Prevclass { get; set; }
        public string? Class { get; set; }
        public string? Division { get; set; }
        public string? ModeOfStudy { get; set; }
        public DateTime? StartsFrom { get; set; }
        public string? Ssection { get; set; }
        public string? FinalResult { get; set; }
        public string? ReTestResult { get; set; }
        public int? ClNo { get; set; }
        public string? OptionalDivision { get; set; }
        public DateTime? ActualJoiningDate { get; set; }
        public string? Shift { get; set; }
        public int? ClassNo { get; set; }
        public bool? Reregistered { get; set; }
        public bool? Result { get; set; }
        public bool? IdPrinted { get; set; }
        public string? FeeSchedule { get; set; }
        public string? TransSchedule { get; set; }
        public string? AdmissionSchedule { get; set; }
        public string? DiscountSchedule { get; set; }
        public string? TranDiscountSchedule { get; set; }
        public bool? FeeDiscount { get; set; }
        public bool? TranDiscount { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string? CourseStream { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public DateTime? TranStartDate { get; set; }
        public string? TransScheduleDummy { get; set; }
        public string? ReRegistrationStatus { get; set; }
        public DateTime? ReRegistrationDate { get; set; }
        public string? SubStatus { get; set; }
        public string? AmPrivateTran { get; set; }
        public string? PmPrivateTran { get; set; }
        public string? PrivateTranName { get; set; }
        public string? PrivateTranRelation { get; set; }
        public string? PrivateTranEmiratesId { get; set; }
        public string? PrivateTranContact { get; set; }
        public bool? mobile_app_access { get; set; }
        public bool? Photoallowed { get; set; }
        public bool? ReRegBlock { get; set; }
        public string? DiscountRemarks { get; set; }
        public DateTime? Mdate { get; set; }
        public bool? MonthlyPayment { get; set; }
        public bool? Fullpaid { get; set; }
        public bool? Voucherprinted { get; set; }
        //public string BusMode { get; set; }
        //public string BusNo { get; set; }
        //public string GoingBusNo { get; set; }
        //public string BusPoint { get; set; }
        //public string BusArea { get; set; }
        //public string BusTimeIn { get; set; }
        //public string BusTimeOut { get; set; }
        //public string BusName { get; set; }
        //public string DropOffPoint { get; set; }
        //public string BusStopNo { get; set; }
        //public string BusStopNoTo { get; set; }
        public string? Bus_Mode { get; set; }
        public string? Bus_No { get; set; }
        public string? Going_Bus_No { get; set; }
        public string? Bus_Point { get; set; }
        public string? Bus_Area { get; set; }
        public string? Bus_Time_In { get; set; }
        public string? Bus_Time_Out { get; set; }
        public string? Bus_Name { get; set; }
        public string? Drop_Off_Point { get; set; }
        public string? Bus_Stop_No { get; set; }
        public string? Bus_Stop_No_To { get; set; }
        public string? PersonWaitingInStop { get; set; }
        public string? RequiredAttention { get; set; }
        public string? ThirdPartyPayment { get; set; }
        public string? ThirdPartyCompany { get; set; }
        public bool? Iep { get; set; }
        public bool? ESL_ELD { get; set; }
        public bool? French { get; set; }
        public decimal? Discount { get; set; }
        public string? VatPct { get; set; }
        public decimal? VatAmount { get; set; }
        public string? SpecialNeed { get; set; }
        public string? SpecialNeedCategory { get; set; }
        public string? SpecialNeedDescription { get; set; }
        public string? GoingBusNo2 { get; set; }
        public string? GoingBusNo3 { get; set; }
        public string? GoingBusNo4 { get; set; }
        public string? TransportationRemark { get; set; }
        public int? SponsorId { get; set; }
        public string? OptionalBusNo { get; set; }
        public string? OptionalStopNo { get; set; }
        public string? LearningSkill { get; set; }
        public DateTime? BusDiscontinuationDate { get; set; }
        public string? StudyModel { get; set; }
        public string? TransportationModel { get; set; }
        public string? GroupAllocation { get; set; }
        public DateTime? StudyModelDate { get; set; }
        public int? BranchId { get; set; }
        public string? OldSection { get; set; }
        public string? OldClass { get; set; }
        public DateTime? LastAttendenceDate { get; set; }
        public string? Muser { get; set; }
        public string? BusRoute { get; set; }

        public string? ParentMake { get; set; }
        public string? ParentModel { get; set; }
        public string? ParentPlateNo { get; set; }
        public string? ParentColor { get; set; }
        public string? ParentYearofMfg { get; set; }
        public string? ParentName { get; set; }
        public string? ParentContact { get; set; }
        public string? ParentLicense { get; set; }
        public DateTime? ParentLicenseExpiry { get; set; }
        public string? DriverMake { get; set; }
        public string? DriverModel { get; set; }
        public string? DriverPlateNo { get; set; }
        public string? DriverColor { get; set; }
        public string? DriverYearofMfg { get; set; }
        public string? DriverName { get; set; }
        public string? DriverContact { get; set; }
        public string? DriverLicense { get; set; }
        public DateTime? DriverLicenseExpiry { get; set; }
        public string? BuildingName { get; set; }
        public string? StreetName { get; set; }
        public string? Zone { get; set; }
        public string? Sector { get; set; }
        public string? FlatNo { get; set; }
        public string? PlotNo { get; set; }
        public string? AdmissionCategory { get; set; }
        public string? ReRegBlockRemarks { get; set; }
        public string? DiscountSchedule2 { get; set; }
        public string? DiscountSchedule3 { get; set; }
    }
}
