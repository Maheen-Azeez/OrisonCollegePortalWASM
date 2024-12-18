using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using SecurityService;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Net;
using System.Security.Principal;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class FeeSchedule : IFeeSchedule
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;
        private IUserTrack _UserTrackrepository;
        public FeeSchedule(IDapperManager dapperManager, IConfiguration config, IUserTrack UserTrackrepository)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _UserTrackrepository = UserTrackrepository;
        }

        public async Task<List<SchoolFeeSchedule>> GetFeeScheduleList(int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            //var FeeList = Task.FromResult(_dapperManager.GetAll<SchoolFeeSchedule>("SELECT s.ID, FeeSchedule, Description, s.StartDate, Remarks, Total, Type, s.AcademicYear, Class, FeeDiscount FROM School_FeeSchedule s inner join School_AcademicYear a on s.AcademicYear=a.AcademicYear where a.Status='Current' and a.BranchID=@BranchID and s.BranchID=@BranchID", dbPara, Con, commandType: CommandType.Text));
            var FeeList = Task.FromResult(_dapperManager.GetAll<SchoolFeeSchedule>("SELECT s.ID, FeeSchedule, Description, s.StartDate, Remarks, Total, Type, s.AcademicYear, Programme, FeeDiscount FROM Col_FeeSchedule s inner join Col_AcademicYear a on s.AcademicYear=a.AcademicYear where a.AcademicYear=@AcademicYear and a.BranchID=@BranchID and s.BranchID=@BranchID", Key, dbPara, commandType: CommandType.Text));
            return await FeeList;
        }

        public async Task<string> GetFeeSchedule(string ID, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@ID", ID, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var AccountID = Task.FromResult(_dapperManager.Get<string>("select FeeSchedule from Col_FeeSchedule where id=@ID and BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await AccountID;
        }

        public async Task<List<SchoolFeeScheduleTran>> GetFeeScheduleList(string Fee, int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Fee", Fee, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            //var FeeList = Task.FromResult(_dapperManager.GetAll<SchoolFeeScheduleTran>("SELECT FeeSchedule, Code, Description, PriorityNo, Remarks,convert(varchar,DueDate,103) as Due,DueDate,convert(decimal(10,2),Amount)as Amount, Category, s.ID, s.AcademicYear, ToPost,DiscAmount FROM School_FeeScheduleTrans s inner join School_AcademicYear a on s.AcademicYear=a.AcademicYear WHERE (FeeSchedule = @Fee and  s.BranchID=@BranchID) AND (a.Status = 'Current' AND A.BranchID=@BranchID)", Key, dbPara, commandType: CommandType.Text));
            var FeeList = Task.FromResult(_dapperManager.GetAll<SchoolFeeScheduleTran>("SELECT FeeSchedule, Code, Description, PriorityNo, Remarks,convert(varchar,DueDate,103) as Due,DueDate,convert(decimal(10,2),Amount)as Amount, Category, s.ID, s.AcademicYear, ToPost,DiscAmount FROM School_FeeScheduleTrans s inner join School_AcademicYear a on s.AcademicYear=a.AcademicYear WHERE (FeeSchedule = @Fee and  s.BranchID=@BranchID) AND (a.AcademicYear = @AcademicYear AND A.BranchID=@BranchID)", Key, dbPara, commandType: CommandType.Text));
            return await FeeList;
        }

        public async Task<SchoolFeeSchedule> GetDTFeeScheduleData(int ID, int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@ID", ID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            //var FeeMaster = Task.FromResult(_dapperManager.Get<SchoolFeeSchedule>("SELECT ID, FeeSchedule, Description,convert(varchar, StartDate,103)as StartDate, Remarks, Total, Type, AcademicYear, Class, FeeDiscount FROM School_FeeSchedule WHERE (AcademicYear =  (select  AcademicYear from School_AcademicYear where Status='Current' and BranchID=@BranchID)) and id=@ID", dbPara, commandType: CommandType.Text));
            //var FeeMaster = Task.FromResult(_dapperManager.Get<SchoolFeeSchedule>("SELECT ID, FeeSchedule, Description,StartDate, Remarks, Total, Type, AcademicYear, Class, FeeDiscount FROM School_FeeSchedule WHERE (AcademicYear =  (select  AcademicYear from School_AcademicYear where Status='Current' and BranchID=@BranchID)) and id=@ID", Key, dbPara, commandType: CommandType.Text));
            var FeeMaster = Task.FromResult(_dapperManager.Get<SchoolFeeSchedule>("SELECT ID, FeeSchedule, Description,StartDate, Remarks, Total, Type, AcademicYear, Class, FeeDiscount FROM Col_FeeSchedule WHERE (AcademicYear =  @AcademicYear) and id=@ID", Key, dbPara, commandType: CommandType.Text));
            return await FeeMaster;
        }

        public async Task<string> GetStudCode(string CourseStream, string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@CourseStream", CourseStream, DbType.String);
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@Shift", Shift, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE coursestream='" + CourseStream + "' and ProgrammeCode='" + Class + "' AND shift='" + Shift + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "' and isnull(Col_StudentTRANS.FeeSchedule,'None')='None'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCodeSecond(string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@Shift", Shift, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            //var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(School_Students.AccountID) FROM School_Students INNER JOIN School_StudentTrans ON School_Students.AccountID=School_StudentTrans.AccountID WHERE Class='" + Class + "'AND shift='" + Shift + "' AND Academicyear='" + AcademicYear + "' and School_Studenttrans.Status='Studying' and School_Studenttrans.BranchID='" + BranchID + "' and isnull(replace(School_StudentTRANS.FeeSchedule,'',null),'None')='None'", dbPara, commandType: CommandType.Text));
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE Class='" + Class + "' AND  Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "' and isnull(Col_StudentTRANS.FeeSchedule,'None')='None'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCodeThird(string CourseStream, string Class, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@CourseStream", CourseStream, DbType.String);
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE coursestream='" + CourseStream + "' and Class='" + Class + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "' and isnull(Col_StudentTRANS.FeeSchedule,'None')='None'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCodeFourth(string Class, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE Class='" + Class + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "' and isnull(Col_StudentTRANS.FeeSchedule,'None')='None'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCountTransport(string BusNo, string BusMode, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BusNo", BusNo, DbType.String);
            dbPara.Add("@BusMode", BusMode, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE BusNo='" + BusNo + "' AND BusMode='" + BusMode + "' AND AcademicYear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and and Col_Studenttrans.BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCountRegistration(string JoiningYear, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@JoiningYear", JoiningYear, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE JoiningAcademicYear='" + JoiningYear + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "' and isnull(Col_StudentTRANS.AdmissionSchedule,'None')='None'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<List<SchoolFeeMaster>> GetCode(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var FeeCode = Task.FromResult(_dapperManager.GetAll<SchoolFeeMaster>("select distinct code,Description,PostTo,DueDate from Col_FeeMaster where BranchID=@BranchID", Key, dbPara, commandType: CommandType.Text));
            return await FeeCode;
        }

        public async Task<string> GetCategory(string Code, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Code", Code, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var AccountID = Task.FromResult(_dapperManager.Get<string>("Select Category from Col_FeeMaster where code=@Code and BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await AccountID;
        }

        public async Task<string> GetExistFeeSchedule(string FeeSchedule, int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@FeeSchedule", FeeSchedule, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var ExistFeeSchedule = Task.FromResult(_dapperManager.Get<string>("Select FeeSchedule from Col_FeeSchedule where FeeSchedule=@FeeSchedule and AcademicYear=@AcademicYear and BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await ExistFeeSchedule;
        }

        public async Task<List<SchoolStudentTran>> GetDTStudentTrans(string FeeSchedule, int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@FeeSchedule", FeeSchedule, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var SchoolStudentTrans = Task.FromResult(_dapperManager.GetAll<SchoolStudentTran>("Select FeeSchedule from Col_StudentTrans where FeeSchedule=@FeeSchedule and AcademicYear=(select academicyear from Col_academicyear where AcademicYear=@AcademicYear and BranchID=@BranchID) and BranchID=@BranchID", Key, dbPara, commandType: CommandType.Text));
            return await SchoolStudentTrans;
        }
        //public async Task<SchoolFeeMaster> GetDocumentByDocId(int FeeID)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("@ID", FeeID, DbType.Int32);
        //    var Fee = Task.FromResult(_dapperManager.Get<SchoolFeeMaster>("Select * from School_FeeScheduleTrans where ID=@ID", dbPara, commandType: CommandType.Text));
        //    return await Fee;
        //}
        //public async Task<List<SchoolFeeMaster>> GetDescription(int BranchID)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("@BranchID", BranchID, DbType.String);
        //    var FeeCode = Task.FromResult(_dapperManager.GetAll<SchoolFeeMaster>("select distinct Description from School_FeeMaster where BranchID=@BranchID", dbPara, commandType: CommandType.Text));
        //    return await FeeCode;
        //}

        //public async Task<List<SchoolFeeMaster>> GetFeePost(int BranchID)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("@BranchID", BranchID, DbType.String);
        //    var FeeCode = Task.FromResult(_dapperManager.GetAll<SchoolFeeMaster>("select distinct PostTo from School_FeeMaster where BranchID=@BranchID", dbPara, commandType: CommandType.Text));
        //    return await FeeCode;
        //}

        public async Task<long> EditStudentTrans(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchId", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE coursestream=@CourseStream and ProgrammeCode=@Class AND shift=@Shift and academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchId and isnull(Col_StudentTRANS.FeeSchedule,'None')='None')AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> EditStudTrans(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    //newID = _dapperManager.UpdateQuery("UPDATE School_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT School_Students.AccountID FROM School_Students INNER JOIN School_StudentTrans ON School_Students.AccountID=School_StudentTrans.AccountID WHERE Class=@Class AND shift=@Shift and academicyear=@AcademicYear and School_Studenttrans.Status='Studying' and School_Studenttrans.BranchID=@BranchID and isnull(School_StudentTRANS.FeeSchedule,'None')='None')AS DT WHERE DT.AccountID=School_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", dbPara, commandType: CommandType.Text);
                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE Class=@Class AND academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchID and isnull(Col_StudentTRANS.FeeSchedule,'None')='None')AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> UpdateStudentTrans(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE coursestream=@CourseStream and Class=@Class and academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchID and isnull(Col_StudentTRANS.FeeSchedule,'None')='None')AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> UpdateStudTrans(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);

                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE  Class=@Class and academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchID and isnull(Col_StudentTRANS.FeeSchedule,'None')='None')AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> UpdateStudentTransSchedule(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@BusNo", dt.Bus_No, DbType.String);
                    dbPara.Add("@BusMode", dt.Bus_Mode, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_StudentTRANS SET TransSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE BusNo=@BusNo AND BusMode=@BusMode AND AcademicYear=@AcademicYear and Col_Studenttrans.Status='Studying'  and Col_Studenttrans.BranchID=@BranchID)AS DT WHERE DT.AccountID=Col_StudentTRANS.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> UpdateStudentAdmissionSchedule(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@JoiningYear", dt.Status, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET AdmissionSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE  JoiningAcademicYear=@JoiningYear and academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchID and isnull(Col_StudentTRANS.AdmissionSchedule,'None')='None')AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }


        public async Task<long> SaveFeeSchedule(SchoolFeeSchedule dt, string Key)
        {
            long newID = 0;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("Type", dt.Type, DbType.String);
                    dbPara.Add("FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("Description", dt.Description, DbType.String);
                    dbPara.Add("StartDate", dt.StartDate, DbType.DateTime);
                    dbPara.Add("AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("Programme", dt.Class, DbType.String);
                    dbPara.Add("BranchId", dt.BranchId, DbType.Int32);
                    dbPara.Add("Total", dt.Total, DbType.Decimal);
                    dbPara.Add("Criteria", "InsertFeeSchedule", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[Col_FeeScheduleEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            //return newID;
            return await Task.FromResult(newID);
        }

        public async Task<long> SaveFeeScheduleTran(SchoolFeeScheduleTran dt, string Key)
        {
            long newID = 0;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("Code", dt.Code, DbType.String);
                    dbPara.Add("Description", dt.Description, DbType.String);
                    dbPara.Add("ToPost", dt.ToPost, DbType.Int32);
                    dbPara.Add("DueDate", dt.DueDate, DbType.DateTime);
                    dbPara.Add("Amount", dt.Amount, DbType.Decimal);
                    //dbPara.Add("Discount", dt.DiscAmount, DbType.Decimal);
                    dbPara.Add("Category", dt.Category, DbType.String);
                    dbPara.Add("AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("Criteria", "InsertFeeScheduleTrans", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[Col_FeeScheduleTranEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> UpdateFeeSchedule(SchoolFeeSchedule dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("Type", dt.Type, DbType.String);
                    dbPara.Add("FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("Description", dt.Description, DbType.String);
                    dbPara.Add("StartDate", dt.StartDate, DbType.DateTime);
                    dbPara.Add("AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("Class", dt.Class, DbType.String);
                    dbPara.Add("BranchId", dt.BranchId, DbType.Int32);
                    dbPara.Add("Total", dt.Total, DbType.Decimal);
                    dbPara.Add("Criteria", "EditFeeSchedule", DbType.String);
                    dbPara.Add("AccID", dt.Id, DbType.Int64);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[Col_FeeScheduleEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> UpdateFeeScheduleTran(SchoolFeeScheduleTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("Code", dt.Code, DbType.String);
                    dbPara.Add("Description", dt.Description, DbType.String);
                    dbPara.Add("ToPost", dt.ToPost, DbType.Int32);
                    dbPara.Add("DueDate", dt.DueDate, DbType.DateTime);
                    dbPara.Add("Amount", dt.Amount, DbType.Decimal);
                    dbPara.Add("Discount", dt.DiscAmount, DbType.Decimal);
                    dbPara.Add("Category", dt.Category, DbType.String);
                    dbPara.Add("AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("Criteria", "EditFeeScheduleTrans", DbType.String);
                    dbPara.Add("AccID", dt.Id, DbType.Int64);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[Col_FeeScheduleTranEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> DeleteFeeSchedule(SchoolFeeSchedule Fee, string Key)
        {
            int newID;
            using IDbConnection db = GetConnection(Key);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    newID = await DeleteFee(Fee, db, tran, Key);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<int> DeleteFee(SchoolFeeSchedule feeSchedule, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("FeeSchedule", feeSchedule.FeeSchedule, DbType.String);
            dbPara.Add("Criteria", "DeleteFeeSchedule", DbType.String);
            dbPara.Add("AccID", feeSchedule.Id, DbType.Int64);

            int newID = Convert.ToInt32(_dapperManager.Update("Col_FeeScheduleEntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<long> DeleteFeeScheduleTrans(SchoolFeeScheduleTran Fee, string Key)
        {
            int newID;
            using IDbConnection db = GetConnection(Key);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    newID = await DeleteFeetrans(Fee, db, tran, Key);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<int> DeleteFeetrans(SchoolFeeScheduleTran feeScheduletrans, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("FeeSchedule", feeScheduletrans.FeeSchedule, DbType.String);
            dbPara.Add("Code", feeScheduletrans.Code, DbType.String);
            dbPara.Add("Description", feeScheduletrans.Description, DbType.String);
            dbPara.Add("ToPost", feeScheduletrans.ToPost, DbType.Int32);
            dbPara.Add("DueDate", feeScheduletrans.DueDate, DbType.DateTime);
            dbPara.Add("Amount", feeScheduletrans.Amount, DbType.Decimal);
            dbPara.Add("Criteria", "DeleteFeeScheduleTrans", DbType.String);
            dbPara.Add("AccID", feeScheduletrans.Id, DbType.Int64);

            int newID = Convert.ToInt32(_dapperManager.Execute("Col_FeeScheduleTranEntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public static string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }

        public async Task<long> SaveUserTrack(DtoUserTrack User, string Key)
        {
            int newID;
            using IDbConnection db = GetConnection(Key);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    DtoUserTrack user = User;
                    user.Reason = "Delete FeeSchedule of - " + User.Reason + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> SaveFeeUserTrack(DtoUserTrack User, string Key)
        {
            int newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    DtoUserTrack user = User;
                    user.Reason = "Save Fee Schedule,FeeSchedule " + User.Reason + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> SaveFeeTranUserTrack(DtoUserTrack User, string Key)
        {
            int newID;
            using IDbConnection db = GetConnection(Key);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    DtoUserTrack user = User;
                    user.Reason = "Save FeeScheduleTrans,FeeSchedule " + User.Reason + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> SaveUpdateFeeUserTrack(DtoUserTrack User, string Key)
        {
            int newID;
            using IDbConnection db = GetConnection(Key);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    DtoUserTrack user = User;
                    user.Reason = "Update Fee Schedule,FeeSchedule " + User.Reason + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 2;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public DbConnection GetConnection(string key)
        {
            Security security = new Security();
            return new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString(security.Decrypt(key)), "", true));
        }

        public async Task<string> GetStudCountAll(string Class, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE Col_StudentTrans.ProgrammeCode='" + Class + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCodeOverwrite(string CourseStream, string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@CourseStream", CourseStream, DbType.String);
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@Shift", Shift, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE  Col_StudentTrans.ProgrammeCode='" + Class + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }
        public async Task<long> UpdateStudTransOverwrite(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);

                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchID)AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> EditStudTransOverwrite(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    //newID = _dapperManager.UpdateQuery("UPDATE School_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT School_Students.AccountID FROM School_Students INNER JOIN School_StudentTrans ON School_Students.AccountID=School_StudentTrans.AccountID WHERE Class=@Class AND shift=@Shift and academicyear=@AcademicYear and School_Studenttrans.Status='Studying' and School_Studenttrans.BranchID=@BranchID and isnull(School_StudentTRANS.FeeSchedule,'None')='None')AS DT WHERE DT.AccountID=School_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", dbPara, commandType: CommandType.Text);
                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE Class=@Class AND academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchID)AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }
        public async Task<long> EditStudentTransOverwrite(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchId", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE coursestream=@CourseStream and Class=@Class AND shift=@Shift and academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchId)AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }
        public async Task<long> UpdateStudentTransOverwrite(SchoolStudentTran dt, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    //dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("@FeeSchedule", dt.FeeSchedule, DbType.String);
                    dbPara.Add("@CourseStream", dt.CourseStream, DbType.String);
                    dbPara.Add("@Class", dt.Class, DbType.String);
                    dbPara.Add("@Shift", dt.Shift, DbType.String);
                    dbPara.Add("@AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("@BranchID", dt.BranchId, DbType.Int32);
                    dbPara.Add("@Criteria", "EditStudent", DbType.String);
                    dbPara.Add("@AccID", dt.Id, DbType.Int64);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateQuery("UPDATE Col_Studenttrans SET FeeSchedule=@FeeSchedule FROM (SELECT Col_Students.AccountID FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE coursestream=@CourseStream and Class=@Class and academicyear=@AcademicYear and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID=@BranchID)AS DT WHERE DT.AccountID=Col_Studenttrans.AccountID AND ACADEMICYEAR=@AcademicYear set @NewID=@AccID", Key, dbPara, commandType: CommandType.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }
        public async Task<string> GetStudCodeSecondOverwrite(string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@Shift", Shift, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            //var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(School_Students.AccountID) FROM School_Students INNER JOIN School_StudentTrans ON School_Students.AccountID=School_StudentTrans.AccountID WHERE Class='" + Class + "'AND shift='" + Shift + "' AND Academicyear='" + AcademicYear + "' and School_Studenttrans.Status='Studying' and School_Studenttrans.BranchID='" + BranchID + "' and isnull(replace(School_StudentTRANS.FeeSchedule,'',null),'None')='None'", dbPara, commandType: CommandType.Text));
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE Class='" + Class + "' AND  Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCodeThirdOverwrite(string CourseStream, string Class, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@CourseStream", CourseStream, DbType.String);
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE coursestream='" + CourseStream + "' and Class='" + Class + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }

        public async Task<string> GetStudCodeFourthOverwrite(string Class, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var StudentCount = Task.FromResult(_dapperManager.Get<string>("SELECT count(Col_Students.AccountID) FROM Col_Students INNER JOIN Col_StudentTrans ON Col_Students.AccountID=Col_StudentTrans.AccountID WHERE Class='" + Class + "' AND Academicyear='" + AcademicYear + "' and Col_Studenttrans.Status='Studying' and Col_Studenttrans.BranchID='" + BranchID + "'", Key, dbPara, commandType: CommandType.Text));
            return await StudentCount;
        }
    }
}
