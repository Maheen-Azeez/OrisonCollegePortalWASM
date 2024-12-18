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
    public class AdditionalFeeMaster : IAdditionalFeeMaster
    {

        private readonly IConfiguration _config;
        private readonly IDapperManager _dapperManager;
        private IUserTrack _UserTrackrepository;
        public AdditionalFeeMaster(IDapperManager dapperManager, IConfiguration config, IUserTrack UserTrackrepository)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _UserTrackrepository = UserTrackrepository;
        }
        private string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
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
                    user.Reason = "Add Schedule of- " + User.Reason + "";
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
                    user.Reason = "Add Schedule of- " + User.Reason + "";
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

        public async Task<SchoolFeeMaster> GetAdditional(int BranchID, int ID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@ID", ID, DbType.Int32);
            dbPara.Add("Criteria", "GetAdditionalFeeById", DbType.String);
            var StudentList = Task.FromResult(_dapperManager.Get<SchoolFeeMaster>("[COL_AdditionalFeeMaster]", Key, dbPara,commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<List<SchoolFeeMaster>> Getdata(int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var StudentList = Task.FromResult(_dapperManager.GetAll<SchoolFeeMaster>("[AdditionalFeeMaster]", Key, dbPara,commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<string> GetID(string AccountCode, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Code", AccountCode, DbType.String);
            var AccountID = Task.FromResult(_dapperManager.Get<string>("select id from Accounts where AccountCode='" + AccountCode + "'", Key, dbPara,commandType: CommandType.Text));
            return await AccountID;
        }

        public async Task<long> SaveMaster(SchoolFeeMaster value, string Key)
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
                    dbPara.Add("Code", value.Code, DbType.String);
                    dbPara.Add("AcademicYear", value.AcademicYear, DbType.String);
                    dbPara.Add("PriorityNo", value.PriorityNo, DbType.Int32);
                    dbPara.Add("Description", value.Description, DbType.String);
                    dbPara.Add("Type", value.Type, DbType.String);
                    dbPara.Add("Amount", value.Amount, DbType.Decimal);
                    dbPara.Add("PostTo", value.PostTo, DbType.Int32);
                    dbPara.Add("ReceiptType", value.ReceiptType, DbType.String);
                    dbPara.Add("VatPercent", value.VatPercent, DbType.String);
                    dbPara.Add("TaxCode", value.Taxcode, DbType.String);
                    dbPara.Add("VATApplicable", value.VatApplicable, DbType.Boolean);
                    dbPara.Add("VATInclusive", value.VatInclusive, DbType.Boolean);
                    dbPara.Add("BranchID", value.BranchId, DbType.Int32);
                    dbPara.Add("Criteria", "SaveMaster", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[COL_AdditionalFeeMaster]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
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

        public async Task<List<VtypeTrans>> GetReceipt(string Key)
        {
            var dbPara = new DynamicParameters();
            var Receipt = Task.FromResult(_dapperManager.GetAll<VtypeTrans>("select id,title from vtypetran where basictype in (select id from vtypemast where description='Receipt') and entrymode='Receipt Student'", Key, dbPara,commandType: CommandType.Text));
            return await Receipt;
        }

        public async Task<List<Accounts>> GetPostTo(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Value = Task.FromResult(_dapperManager.GetAll<Accounts>("select AccountCode,AccountName,a.Id,AccCategory from AccountsListMast lm inner join AccountsList l on lm.ID=l.ListID inner join Accounts a on l.AccountID=a.ID where lm.Description='Fee Income' and (a.BranchID=@BranchID or a.BranchID is null)", Key, dbPara,commandType: CommandType.Text));
            return await Value;
        }

        public async Task<long> UpdateMaster(SchoolFeeMaster value, string Key)
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
                    dbPara.Add("Code", value.Code);
                    dbPara.Add("AcademicYear", value.AcademicYear);
                    dbPara.Add("PriorityNo", value.PriorityNo);
                    dbPara.Add("Description", value.Description);
                    dbPara.Add("Amount", value.Amount);
                    dbPara.Add("PostTo", value.PostTo);
                    dbPara.Add("ReceiptType", value.ReceiptType);
                    dbPara.Add("VatPercent", value.VatPercent);
                    dbPara.Add("TaxCode", value.Taxcode);
                    dbPara.Add("VATApplicable", value.VatApplicable);
                    dbPara.Add("VATInclusive", value.VatInclusive);
                    dbPara.Add("BranchID", value.BranchId, DbType.Int32);
                    dbPara.Add("Criteria", "UpdateAdditionalFee", DbType.String);
                    dbPara.Add("ID", value.Id, DbType.Int64);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[COL_AdditionalFeeMaster]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteAdditional(int ID, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@ID", ID);
                dbPara.Add("Criteria", "DeleteAdditionalFee");
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
              
                int newID = Convert.ToInt32(_dapperManager.Execute("[COL_AdditionalFeeMaster]", Key, dbPara, commandType: CommandType.StoredProcedure));
                return newID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<long> DeleteSaveUserTrack(DtoUserTrack User, string Key)
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
                    user.Reason = "Delete Schedule of- " + User.Reason + "";
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

        public DbConnection GetConnection(string key)
        {
            Security security = new Security();
            return new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString(security.Decrypt(key)), "", true));
        }

    }
}
