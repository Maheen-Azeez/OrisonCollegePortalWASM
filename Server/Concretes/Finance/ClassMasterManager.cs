using Dapper;
using Microsoft.Data.SqlClient;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using SecurityService;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Security.Principal;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class ClassMasterManager : IClassMaster
    {
        private readonly IConfiguration _config;
        private readonly IDapperManager _dapperManager;
        private IUserTrack _UserTrackrepository;
        public ClassMasterManager(IDapperManager dapperManager, IConfiguration config, IUserTrack UserTrackrepository)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _UserTrackrepository = UserTrackrepository;
        }
        public async Task<SchoolClassMaster> GetDTClassMaster(int Id, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Id", Id, DbType.Int32);

            var FeeMaster = Task.FromResult(_dapperManager.Get<SchoolClassMaster>("select * from Col_ProgramMaster where Id=@Id", Key, dbPara, commandType: CommandType.Text));
            return await FeeMaster;
        }
        public async Task<List<SchoolClassMaster>> Getdata(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);

            var ClassList = Task.FromResult(_dapperManager.GetAll<SchoolClassMaster>("select * from School_ClassMaster where BranchID=@BranchID order by PNo ASC", Key, dbPara, commandType: CommandType.Text));
            return await ClassList;
        }
        public async Task<List<SchoolClassMaster>> Getdata(int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);

            var ClassList = Task.FromResult(_dapperManager.GetAll<SchoolClassMaster>("select * from School_ClassMaster where BranchID=@BranchID and (AccYear is null or AccYear=@AcademicYear) order by PNo ASC", Key, dbPara, commandType: CommandType.Text));
            return await ClassList;
        }
        public async Task<int> DeleteMaster(int Id, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Id", Id);
            dbPara.Add("Criteria", "DeleteClass");
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Execute("[SchoolWeb_ClassMaster]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<long> SaveMaster(SchoolClassMaster value, string Key)
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
                    dbPara.Add("PNo", value.Pno, DbType.Int32);
                    dbPara.Add("Class", value.Class);
                    dbPara.Add("ClassName", value.ClassName);
                    dbPara.Add("RomanName", value.RomanName);
                    dbPara.Add("PromotedClass", value.PromotedClass);
                    dbPara.Add("ClassInArabic", value.ClassInArabic);
                    dbPara.Add("PromotedClassArab", value.PromotedClassArab);
                    dbPara.Add("BranchId", value.BranchId, DbType.Int32);
                    dbPara.Add("AcademicYear", value.AccYear);
                    dbPara.Add("Criteria", "InserClass", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[SchoolWeb_ClassMaster]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
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

        public async Task<long> UpdateMaster(SchoolClassMaster value, string Key)
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
                    dbPara.Add("PNo", value.Pno, DbType.Int32);
                    dbPara.Add("Class", value.Class);
                    dbPara.Add("ClassName", value.ClassName);
                    dbPara.Add("RomanName", value.RomanName);
                    dbPara.Add("Id", value.Id, DbType.Int32);
                    dbPara.Add("PromotedClass", value.PromotedClass);
                    dbPara.Add("ClassInArabic", value.ClassInArabic);
                    dbPara.Add("PromotedClassArab", value.PromotedClassArab);
                    //dbPara.Add("BranchId", value.BranchId);
                    dbPara.Add("Criteria", "UpdateClass", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.UpdateTable("[SchoolWeb_ClassMaster]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
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

        public async Task<List<SchoolStudentTran>> GetDTStudentTrans(string Class, int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Class", Class, DbType.String);
            dbPara.Add("BranchID", BranchID, DbType.Int32);
            dbPara.Add("AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("Criteria", "GetStudentTransClass", DbType.String);
            var StudentLists = Task.FromResult(_dapperManager.GetAll<SchoolStudentTran>("Col_StudentCommonSP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentLists;
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
                    user.Reason = "Delete Class of ID- " + User.Reason + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 3;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
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

        public async Task<long> AddSaveUserTrack(DtoUserTrack User, string Key)
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
                    user.Reason = "Add Class of- " + User.Reason + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
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

        public async Task<long> EditSaveUserTrack(DtoUserTrack User, string Key)
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
                    user.Reason = "Update Class of ID- " + User.Reason + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 2;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
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

        public async Task<long> SaveNewClassData(List<SchoolClassMaster> value, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);

            try
            {
                if (value.Count > 0)
                {
                    foreach (var dr in value)
                    {
                        var dbPara = new DynamicParameters();
                        dbPara.Add("PNo", dr.Pno, DbType.Int32);
                        dbPara.Add("Class", dr.Class);
                        dbPara.Add("ClassName", dr.ClassName);
                        dbPara.Add("RomanName", dr.RomanName);
                        dbPara.Add("PromotedClass", dr.PromotedClass);
                        dbPara.Add("ClassInArabic", dr.ClassInArabic);
                        dbPara.Add("PromotedClassArab", dr.PromotedClassArab);
                        dbPara.Add("BranchId", dr.BranchId, DbType.Int32);
                        dbPara.Add("AcademicYear", dr.AcademicYear);
                        dbPara.Add("Criteria", "InserClass", DbType.String);
                        dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                        newID = _dapperManager.Execute("SchoolWeb_ClassMaster", Key, dbPara, commandType: CommandType.StoredProcedure);
                    }
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

            return 1;
        }

        public static string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }
        public DbConnection GetConnection(string key)
        {
            Security security = new Security();
            return new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString(security.Decrypt(key)), "", true));
        }
    }
}

