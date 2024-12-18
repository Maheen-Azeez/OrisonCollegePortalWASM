using Dapper;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Data;
using System.Globalization;

namespace OrisonCollegePortal.Server.Concretes
{
    public class StudentManager : IStudentManager
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public StudentManager(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;


        }

        public void Dispose()
        {

        }
        public async Task<List<Col_AccademicYear>> GetAccyear(string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                var no = await Task.FromResult(_dapperManager.GetAll<Col_AccademicYear>("select * from Col_academicyear",Key, dbPara, commandType: CommandType.Text));
                return no;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Student>> GetAll(int branchid, string Accyear, string Key)
        {
            try
            {
                string branchId = branchid.ToString();

                var dbPara = new DynamicParameters();


                dbPara.Add("Criteria", "GetAllStudents", DbType.String);
                dbPara.Add("BranchId", branchid, DbType.Int32);
                dbPara.Add("AcademicYear", Accyear, DbType.String);
                var no = await Task.FromResult(_dapperManager.GetAll<Student>("[Col_StudentSP]",Key, dbPara, commandType: CommandType.StoredProcedure));
               
                return no;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<string>> GetComboList(string type, string Key)
        {
            var dbPara = new DynamicParameters();


            dbPara.Add("Criteria", type, DbType.String);

            var no = Task.FromResult(_dapperManager.GetAll<string>("[Col_ComboBoxStudentSP]",Key, dbPara, commandType: CommandType.StoredProcedure));

            return await no;
        }

        public async Task<Col_Intake> GetIntake(string name,string Key)
        {
            try
            {
                var dbpara = new DynamicParameters();
                dbpara.Add("name", name, DbType.String);
                var no = await Task.FromResult(_dapperManager.Get<Col_Intake>("select * from col_intake where name=@name",Key, dbpara, commandType: CommandType.Text));
                return no;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetNextStudentCode(int branchid, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Criteria", "NextJobNo", DbType.String);
                dbPara.Add("branchid", branchid, DbType.Int32);
                // var no = Task.FromResult(_dapperManager.Get<string>("select [dbo].[NEXTNUMBER_COLLEGESTUDENTS] (@Criteria, @branchid)", dbPara, commandType: CommandType.Text));
                var no = Task.FromResult(_dapperManager.Get<string>("sp_GetNextStudentCode", Key, dbPara, commandType: CommandType.StoredProcedure));
                return await no;
                //Select cast([dbo].[NEXTNUMBER_NURSERYSTUDENTS] (@Criteria, @branchid) as int)

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> GetAbbr(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Abbr = Task.FromResult(_dapperManager.Get<string>("Select Abbr from Company where ID='" + BranchID + "'",Key, dbPara, commandType: CommandType.Text));
            return await Abbr;
        }

        public async Task<Student> GetStudent(string ID, string Key)
        {
            var dbPara = new DynamicParameters();

            int IDd = Convert.ToInt32(ID);
            dbPara.Add("id", IDd, DbType.Int32);
            dbPara.Add("Criteria", "StudentDataById", DbType.String);

            var no = Task.FromResult(_dapperManager.Get<Student>("[Col_StudentSP]", Key, dbPara, commandType: CommandType.StoredProcedure));

            return await no;
        }

        public async Task<long> Insert(int id, Student student, IDbConnection db, IDbTransaction tran)
        {
            try
            {
                long newID = 0;

                var dbPara = new DynamicParameters();

                dbPara.Add("Criteria", "INSERTSTUDENT", DbType.String);
                dbPara.Add("AccountId", id, DbType.String);
                dbPara.Add("UnivRegNum", student.UnivRegNum, DbType.String);
                dbPara.Add("DOB", student.Dob, DbType.DateTime);
                dbPara.Add("Nationality", student.Nationality, DbType.String);
                dbPara.Add("Gender", student.Gender, DbType.String);
                dbPara.Add("Religion", student.Religion, DbType.String);
                dbPara.Add("TelNum", student.TeleNo, DbType.String);
                dbPara.Add("TelNumOffice", student.TeleNoOff, DbType.String);
                dbPara.Add("email", student.Email, DbType.String);
                dbPara.Add("EntryYear", student.EntryYear, DbType.String);
                dbPara.Add("EntryPoint", student.EntryPoint, DbType.String);
                dbPara.Add("Guardian", student.Guardian, DbType.String);
                dbPara.Add("MobNoGuardian", student.MobileNo, DbType.String);
                dbPara.Add("EmailGuardian", student.P_Email, DbType.String);
                dbPara.Add("PermenentAddress", student.PerAddress, DbType.String);
                dbPara.Add("CommunicationAddress", student.CommAddress, DbType.String);
                dbPara.Add("TelNumRes", student.TeleNoRes, DbType.String);
                dbPara.Add("Session", student.Session, DbType.String);
                dbPara.Add("BranchID", student.BranchId, DbType.Int32);
               // dbPara.Add("CourseEndDate", student.EndDate, DbType.String);
                dbPara.Add("CourseEndDate", student.EndDate?.ToString("MM/dd/yyyy"), DbType.String);
                newID = _dapperManager.Insert("[Col_StudentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

                return newID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(Student student, IDbConnection db, IDbTransaction tran)
        {
            try
            {


                var dbPara = new DynamicParameters();

                dbPara.Add("Criteria", "UPDATESTUDENT", DbType.String);
                dbPara.Add("id", student.AccountId, DbType.String);
                dbPara.Add("UnivRegNum", student.UnivRegNum, DbType.String);
                dbPara.Add("DOB", student.Dob, DbType.DateTime);
                dbPara.Add("Nationality", student.Nationality, DbType.String);
                dbPara.Add("Gender", student.Gender, DbType.String);
                dbPara.Add("Religion", student.Religion, DbType.String);
                dbPara.Add("TelNum", student.TeleNo, DbType.String);
                dbPara.Add("TelNumOffice", student.TeleNoOff, DbType.String);
                dbPara.Add("email", student.Email, DbType.String);
                dbPara.Add("EntryYear", student.EntryYear, DbType.String);
                dbPara.Add("EntryPoint", student.EntryPoint, DbType.String);
                dbPara.Add("Guardian", student.Guardian, DbType.String);
                dbPara.Add("MobNoGuardian", student.MobileNo, DbType.String);
                dbPara.Add("EmailGuardian", student.P_Email, DbType.String);
                dbPara.Add("PermenentAddress", student.PerAddress, DbType.String);
                dbPara.Add("CommunicationAddress", student.CommAddress, DbType.String);
                dbPara.Add("TelNumRes", student.TeleNoRes, DbType.String);
                dbPara.Add("Session", student.Session, DbType.String);
                //  dbPara.Add("CourseEndDate", student.EndDate, DbType.String);
                dbPara.Add("CourseEndDate", student.EndDate?.ToString("MM/dd/yyyy"), DbType.String);
                dbPara.Add("EmailGuardian", student.P_Email, DbType.String);
                _dapperManager.UpdateTable("[Col_StudentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Task<string> getHomeUrl(string key)
        {
            var code = Task.FromResult(_dapperManager.Get<string>("select top 1 Description from MasterMisc where Source='Home'", key, null, commandType: CommandType.Text));
            return code;
        }
        public Task<string> getParentHomeUrl(string key)
        {
            var code = Task.FromResult(_dapperManager.Get<string>("select top 1 Description from MasterMisc where Source like 'ParentHomeURL'", key, null, commandType: CommandType.Text));
            return code;
        }
        public Task<string> getLogoutUrl(string key)
        {
            var dbPara = new DynamicParameters();
            var code = Task.FromResult(_dapperManager.Get<string>("select top 1 Description from MasterMisc where Source='Logout'", key, dbPara, commandType: CommandType.Text));
            return code;
        }

        public Task<string> getLogo(int BranchID, string key)
        {
            var code = Task.FromResult(_dapperManager.Get<string>("Select LogoName from Company where ID='" + BranchID + "'", key, null, commandType: CommandType.Text));
            return code;
        }

        public Task<string> getLogoUrl(string key)
        {
            var code = Task.FromResult(_dapperManager.Get<string>("select Description from mastermisc where source='LogoPath'", key, null, commandType: CommandType.Text));
            return code;
        }

        public async Task<List<dtoStudentRegisterDefault>?> GetStudentsDefault(string AcademicYear, int? BranchID, string? Category, int? UserID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@Category", Category, DbType.String);
            dbPara.Add("@UserID", UserID, DbType.Int32);
            var StudentList = Task.FromResult(_dapperManager.GetAll<dtoStudentRegisterDefault>("[Col_StudentRegister]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }
    }
}
