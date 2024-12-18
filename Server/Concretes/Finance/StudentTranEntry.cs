using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class StudentTranEntry : IStudentTranEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public StudentTranEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateStudentTran(SchoolStudentTran StudentTranEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AcademicYear", StudentTranEntry.AcademicYear, DbType.String);
            dbPara.Add("Status", StudentTranEntry.Status, DbType.String);
            dbPara.Add("AccountId", StudentTranEntry.AccountId, DbType.Int32);
            dbPara.Add("RollNo", StudentTranEntry.RollNo, DbType.String);
            dbPara.Add("Class", StudentTranEntry.Class, DbType.String);
            dbPara.Add("Division", StudentTranEntry.Division, DbType.String);
            dbPara.Add("Shift", StudentTranEntry.Shift, DbType.String);
            dbPara.Add("OptionalDivision", StudentTranEntry.OptionalDivision, DbType.String);
            dbPara.Add("PrevStatus", StudentTranEntry.PrevStatus, DbType.String);
            dbPara.Add("StartsFrom", StudentTranEntry.StartsFrom, DbType.DateTime);
            dbPara.Add("CourseStream", StudentTranEntry.CourseStream, DbType.String);
            dbPara.Add("ReRegistrationStatus", StudentTranEntry.ReRegistrationStatus, DbType.String);
            dbPara.Add("AdmissionDate", StudentTranEntry.AdmissionDate, DbType.DateTime);
            dbPara.Add("ReRegistrationDate", StudentTranEntry.ReRegistrationDate, DbType.DateTime);
            dbPara.Add("TranStartDate", StudentTranEntry.TranStartDate, DbType.DateTime);
            dbPara.Add("SubStatus", StudentTranEntry.SubStatus, DbType.String);
            dbPara.Add("SpecialNeed", StudentTranEntry.SpecialNeed, DbType.String);
            dbPara.Add("Reregistered", StudentTranEntry.Reregistered, DbType.Boolean);
            dbPara.Add("French", StudentTranEntry.French, DbType.Boolean);
            dbPara.Add("Iep", StudentTranEntry.Iep, DbType.Boolean);
            dbPara.Add("EslEld", StudentTranEntry.ESL_ELD, DbType.Boolean);
            dbPara.Add("Result", StudentTranEntry.Result, DbType.Boolean);
            dbPara.Add("Photoallowed", StudentTranEntry.Photoallowed, DbType.Boolean);
            dbPara.Add("MobileAppAccess", StudentTranEntry.mobile_app_access, DbType.Boolean);
            dbPara.Add("FeeDiscount", StudentTranEntry.FeeDiscount, DbType.Boolean);
            dbPara.Add("TranDiscount", StudentTranEntry.TranDiscount, DbType.Boolean);
            dbPara.Add("MonthlyPayment", StudentTranEntry.MonthlyPayment, DbType.Boolean);
            dbPara.Add("AmPrivateTran", StudentTranEntry.AmPrivateTran, DbType.String);
            dbPara.Add("PmPrivateTran", StudentTranEntry.PmPrivateTran, DbType.String);
            dbPara.Add("PrivateTranName", StudentTranEntry.PrivateTranName, DbType.String);
            dbPara.Add("PrivateTranRelation", StudentTranEntry.PrivateTranRelation, DbType.String);
            dbPara.Add("PrivateTranEmiratesId", StudentTranEntry.PrivateTranEmiratesId, DbType.String);
            dbPara.Add("PrivateTranContact", StudentTranEntry.PrivateTranContact, DbType.String);
            dbPara.Add("DiscountSchedule", StudentTranEntry.DiscountSchedule, DbType.String);
            dbPara.Add("DiscountSchedule2", StudentTranEntry.DiscountSchedule2, DbType.String);
            dbPara.Add("DiscountSchedule3", StudentTranEntry.DiscountSchedule3, DbType.String);
            dbPara.Add("TranDiscountSchedule", StudentTranEntry.TranDiscountSchedule, DbType.String);
            dbPara.Add("DiscountRemarks", StudentTranEntry.DiscountRemarks, DbType.String);
            dbPara.Add("FeeSchedule", StudentTranEntry.FeeSchedule, DbType.String);
            dbPara.Add("TransSchedule", StudentTranEntry.TransSchedule, DbType.String);
            dbPara.Add("AdmissionSchedule", StudentTranEntry.AdmissionSchedule, DbType.String);
            dbPara.Add("BusMode", StudentTranEntry.Bus_Mode, DbType.String);
            dbPara.Add("BusNo", StudentTranEntry.Bus_No, DbType.String);
            dbPara.Add("GoingBusNo", StudentTranEntry.Going_Bus_No, DbType.String);
            dbPara.Add("BusName", StudentTranEntry.Bus_Name, DbType.String);
            dbPara.Add("BusStopNo", StudentTranEntry.Bus_Stop_No, DbType.String);
            dbPara.Add("BusStopNoTo", StudentTranEntry.Bus_Stop_No_To, DbType.String);
            dbPara.Add("BusArea", StudentTranEntry.Bus_Area, DbType.String);
            dbPara.Add("BusPoint", StudentTranEntry.Bus_Point, DbType.String);
            dbPara.Add("DropOffPoint", StudentTranEntry.Drop_Off_Point, DbType.String);
            dbPara.Add("BusTimeIn", StudentTranEntry.Bus_Time_In, DbType.String);
            dbPara.Add("BusTimeOut", StudentTranEntry.Bus_Time_Out, DbType.String);
            dbPara.Add("BusDiscontinuationDate", StudentTranEntry.BusDiscontinuationDate, DbType.DateTime);
            dbPara.Add("TransportationRemark", StudentTranEntry.TransportationRemark, DbType.String);
            dbPara.Add("StudyModel", StudentTranEntry.StudyModel, DbType.String);
            dbPara.Add("StudyModelDate", StudentTranEntry.StudyModelDate, DbType.DateTime);
            dbPara.Add("TransportationModel", StudentTranEntry.TransportationModel, DbType.String);
            dbPara.Add("GroupAllocation", StudentTranEntry.GroupAllocation, DbType.String);
            dbPara.Add("ThirdPartyPayment", StudentTranEntry.ThirdPartyPayment, DbType.String);
            dbPara.Add("ThirdPartyCompany", StudentTranEntry.ThirdPartyCompany, DbType.String);
            dbPara.Add("BranchId", StudentTranEntry.BranchId, DbType.Int32);
            dbPara.Add("Criteria", "InsertStudentTrans", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("ColStudentTran_EntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> UpdateStudentTran(SchoolStudentTran StudentTranEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("AcademicYear", StudentTranEntry.AcademicYear, DbType.String);
            dbPara.Add("Status", StudentTranEntry.Status, DbType.String);
            dbPara.Add("AccountId", StudentTranEntry.AccountId, DbType.Int32);
            dbPara.Add("RollNo", StudentTranEntry.RollNo, DbType.String);
            dbPara.Add("Class", StudentTranEntry.Class, DbType.String);
            dbPara.Add("Division", StudentTranEntry.Division, DbType.String);
            dbPara.Add("Shift", StudentTranEntry.Shift, DbType.String);
            dbPara.Add("OptionalDivision", StudentTranEntry.OptionalDivision, DbType.String);
            dbPara.Add("PrevStatus", StudentTranEntry.PrevStatus, DbType.String);
            dbPara.Add("StartsFrom", StudentTranEntry.StartsFrom, DbType.DateTime);
            dbPara.Add("CourseStream", StudentTranEntry.CourseStream, DbType.String);
            dbPara.Add("ReRegistrationStatus", StudentTranEntry.ReRegistrationStatus, DbType.String);
            dbPara.Add("AdmissionDate", StudentTranEntry.AdmissionDate, DbType.DateTime);
            dbPara.Add("ReRegistrationDate", StudentTranEntry.ReRegistrationDate, DbType.DateTime);
            dbPara.Add("TranStartDate", StudentTranEntry.TranStartDate, DbType.DateTime);
            dbPara.Add("SubStatus", StudentTranEntry.SubStatus, DbType.String);
            dbPara.Add("SpecialNeed", StudentTranEntry.SpecialNeed, DbType.String);
            dbPara.Add("Reregistered", StudentTranEntry.Reregistered, DbType.Boolean);
            dbPara.Add("French", StudentTranEntry.French, DbType.Boolean);
            dbPara.Add("Iep", StudentTranEntry.Iep, DbType.Boolean);
            dbPara.Add("EslEld", StudentTranEntry.ESL_ELD, DbType.Boolean);
            dbPara.Add("Result", StudentTranEntry.Result, DbType.Boolean);
            dbPara.Add("Photoallowed", StudentTranEntry.Photoallowed, DbType.Boolean);
            dbPara.Add("MobileAppAccess", StudentTranEntry.mobile_app_access, DbType.Boolean);
            dbPara.Add("FeeDiscount", StudentTranEntry.FeeDiscount, DbType.Boolean);
            dbPara.Add("TranDiscount", StudentTranEntry.TranDiscount, DbType.Boolean);
            dbPara.Add("MonthlyPayment", StudentTranEntry.MonthlyPayment, DbType.Boolean);
            dbPara.Add("AmPrivateTran", StudentTranEntry.AmPrivateTran, DbType.String);
            dbPara.Add("PmPrivateTran", StudentTranEntry.PmPrivateTran, DbType.String);
            dbPara.Add("PrivateTranName", StudentTranEntry.PrivateTranName, DbType.String);
            dbPara.Add("PrivateTranRelation", StudentTranEntry.PrivateTranRelation, DbType.String);
            dbPara.Add("PrivateTranEmiratesId", StudentTranEntry.PrivateTranEmiratesId, DbType.String);
            dbPara.Add("PrivateTranContact", StudentTranEntry.PrivateTranContact, DbType.String);
            dbPara.Add("DiscountSchedule", StudentTranEntry.DiscountSchedule, DbType.String);
            dbPara.Add("DiscountSchedule2", StudentTranEntry.DiscountSchedule2, DbType.String);
            dbPara.Add("DiscountSchedule3", StudentTranEntry.DiscountSchedule3, DbType.String);
            dbPara.Add("TranDiscountSchedule", StudentTranEntry.TranDiscountSchedule, DbType.String);
            dbPara.Add("DiscountRemarks", StudentTranEntry.DiscountRemarks, DbType.String);
            dbPara.Add("FeeSchedule", StudentTranEntry.FeeSchedule, DbType.String);
            dbPara.Add("TransSchedule", StudentTranEntry.TransSchedule, DbType.String);
            dbPara.Add("AdmissionSchedule", StudentTranEntry.AdmissionSchedule, DbType.String);
            dbPara.Add("BusMode", StudentTranEntry.Bus_Mode, DbType.String);
            dbPara.Add("BusNo", StudentTranEntry.Bus_No, DbType.String);
            dbPara.Add("GoingBusNo", StudentTranEntry.Going_Bus_No, DbType.String);
            dbPara.Add("BusName", StudentTranEntry.Bus_Name, DbType.String);
            dbPara.Add("BusStopNo", StudentTranEntry.Bus_Stop_No, DbType.String);
            dbPara.Add("BusStopNoTo", StudentTranEntry.Bus_Stop_No_To, DbType.String);
            dbPara.Add("BusArea", StudentTranEntry.Bus_Area, DbType.String);
            dbPara.Add("BusPoint", StudentTranEntry.Bus_Point, DbType.String);
            dbPara.Add("DropOffPoint", StudentTranEntry.Drop_Off_Point, DbType.String);
            dbPara.Add("BusTimeIn", StudentTranEntry.Bus_Time_In, DbType.String);
            dbPara.Add("BusTimeOut", StudentTranEntry.Bus_Time_Out, DbType.String);
            dbPara.Add("BusDiscontinuationDate", StudentTranEntry.BusDiscontinuationDate, DbType.DateTime);
            dbPara.Add("TransportationRemark", StudentTranEntry.TransportationRemark, DbType.String);
            dbPara.Add("StudyModel", StudentTranEntry.StudyModel, DbType.String);
            dbPara.Add("StudyModelDate", StudentTranEntry.StudyModelDate, DbType.DateTime);
            dbPara.Add("TransportationModel", StudentTranEntry.TransportationModel, DbType.String);
            dbPara.Add("GroupAllocation", StudentTranEntry.GroupAllocation, DbType.String);
            dbPara.Add("ThirdPartyPayment", StudentTranEntry.ThirdPartyPayment, DbType.String);
            dbPara.Add("ThirdPartyCompany", StudentTranEntry.ThirdPartyCompany, DbType.String);
            dbPara.Add("BranchId", StudentTranEntry.BranchId, DbType.Int32);
            dbPara.Add("Criteria", "UpdateStudentTran", DbType.String);
            dbPara.Add("AccID", StudentTranEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Update("ColStudentTran_EntrySP",Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }


    }

}
