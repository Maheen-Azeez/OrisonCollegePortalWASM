using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concrete.Students
{
    public class StudentFeeManager : IStudentFeeManager
    {
        private readonly IDapperManager _dapperManager;
        public StudentFeeManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }


        public async Task<List<dtStudentFeeRegister>> GetStudentFeeRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
            dbPara.Add("@DateTo", ToDate, DbType.DateTime);
            dbPara.Add("@Status", Status, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtStudentFeeRegister>("[Col_StudentFeeRegister]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentFeeList;
        }
        public async Task<List<dtfeewiseregister>> GetFeeWiseRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
            dbPara.Add("@DateTo", ToDate, DbType.DateTime);
            dbPara.Add("@Status", Status, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtfeewiseregister>("[Col_FeeWiseRegister]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentFeeList;
        }
        public async Task<List<dtfeewiseregister>> GetFeeWiseRegisterbyclassanddivision(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type,string cls,string div,string des, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
            dbPara.Add("@DateTo", ToDate, DbType.DateTime);
            dbPara.Add("@Status", Status, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@class", cls, DbType.String);
            dbPara.Add("@Division", div, DbType.String);
            dbPara.Add("@Description", des, DbType.String);



            var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtfeewiseregister>("[Col_FeeWiseRegisterbyclassanddivision]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentFeeList;
        }
        //Parent--Student Newly added
        public async Task<List<dtStudentFeeRegister>> GetParentStudentFeeWise(string AcademicYear, int BranchID, string Criteria, int AccountId, DateTime FromDate, DateTime ToDate, string Status, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@Accountid", AccountId, DbType.Int32);
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
                dbPara.Add("@DateTo", ToDate, DbType.DateTime);
                dbPara.Add("@Status", Status, DbType.String);
                dbPara.Add("@Criteria", Criteria, DbType.String);

                var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtStudentFeeRegister>("[ParentStudent_FeeWiseRegister]", key, dbPara, commandType: CommandType.StoredProcedure));
                return await StudentFeeList;
            }catch(Exception ex) { Console.WriteLine(ex.Message);return null; }
        }
        public async Task<List<dtStudentFeeRegister>> GetTermWiseRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
            dbPara.Add("@DateTo", ToDate, DbType.DateTime);
            dbPara.Add("@Status", Status, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtStudentFeeRegister>("[SchoolWeb_TermwiseFeeSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentFeeList;
        }
        public async Task<List<dtStudentFeeRegister>> GetParentFee(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
            dbPara.Add("@DateTo", ToDate, DbType.DateTime);
            dbPara.Add("@Status", Status, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtStudentFeeRegister>("[COL_ParentFeeSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentFeeList;
        }
        public async Task<List<dtStudentFeeRegister>> GetFeeConflict(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
            dbPara.Add("@DateTo", ToDate, DbType.DateTime);
            dbPara.Add("@Status", Status, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtStudentFeeRegister>("[Col_FeeConflictSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentFeeList;
        }

        public async Task<List<dtStudentFeeRegister>> GetStudentFeeRegisterAll(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@FromDate", AcademicYear, DbType.DateTime);
            dbPara.Add("@ToDate", AcademicYear, DbType.DateTime);
            var StudentFeeList = Task.FromResult(_dapperManager.GetAll<dtStudentFeeRegister>("[School_StudentFeeRegisterAll]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentFeeList;
        }

        public async Task<int> DeleteVoucher(int VID, int bvid, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@receiptvid", VID);
            dbPara.Add("@billvid", bvid);
            dbPara.Add("Criteria", "DeleteVoucher");
            //dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
            int  newID = Convert.ToInt32(_dapperManager.Execute("[Col_FeeWiseDelete]", key, dbPara, commandType: CommandType.StoredProcedure));
            return  newID;

        }

        public async Task<int> DeleteAllVoucherallocation(int AccountID, DateTime Dates, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID);
            dbPara.Add("@Date", Dates, DbType.DateTime);
            dbPara.Add("Criteria", "DeleteAllVoucherallocation");
            //dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
            int newID = Convert.ToInt32(_dapperManager.Execute("[Col_FeeWiseDelete]", key, dbPara, commandType: CommandType.StoredProcedure));
            return  newID;
        }
        public async Task<List<object>> GetStudentFeeRegisters(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                dbPara.Add("@DateFrom", FromDate, DbType.DateTime);
                dbPara.Add("@DateTo", ToDate, DbType.DateTime);
                var StudentFeeList = Task.FromResult(_dapperManager.GetAll<object>("[School_StudentFeeRegisterDetails]", key, dbPara, commandType: CommandType.StoredProcedure));
                return await StudentFeeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw ;
            }
        }
    }
}
