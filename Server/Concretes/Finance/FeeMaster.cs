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
    public class FeeMaster : IFeeMaster
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;
        private IUserTrack _UserTrackrepository;
        public FeeMaster(IDapperManager dapperManager, IConfiguration config, IUserTrack UserTrackrepository)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _UserTrackrepository = UserTrackrepository;
        }

        public async Task<List<Accounts>> GetPostTo(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Value = Task.FromResult(_dapperManager.GetAll<Accounts>("select AccountCode,AccountName,a.Id,AccCategory from AccountsListMast lm inner join AccountsList l on lm.ID=l.ListID inner join Accounts a on l.AccountID=a.ID where lm.Description='Fee Income' and (a.BranchID=@BranchID or a.BranchID is null)", Key, dbPara, commandType: CommandType.Text));
            return await Value;
        }

        public async Task<List<VtypeTrans>> GetReceipt(string Key)
        {
            var dbPara = new DynamicParameters();
            var Receipt = Task.FromResult(_dapperManager.GetAll<VtypeTrans>("select id,title from vtypetran where basictype in (select id from vtypemast where description='Receipt') and entrymode='Receipt Student'", Key, dbPara, commandType: CommandType.Text));
            return await Receipt;
        }

        public async Task<List<SchoolFeeMaster>> GetFeeMasterList(string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var FeeList = Task.FromResult(_dapperManager.GetAll<SchoolFeeMaster>("[FeeMaster]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await FeeList;
        }

        public async Task<SchoolFeeMaster> GetDTFeeMaster(int ID, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@ID", ID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            //var FeeMaster = Task.FromResult(_dapperManager.Get<SchoolFeeMaster>("SELECT Accounts.AccountName, Accounts.AccountCode, a.AccountCode AS DiscountAccountCode, a.AccountName AS DiscountAccountName, Accounts.ID AS AccountsID,School_FeeMaster.ID, School_FeeMaster.Code, School_FeeMaster.PriorityNo, School_FeeMaster.Description, School_FeeMaster.Category,School_FeeMaster.Remarks, School_FeeMaster.PostTo, Convert(varchar,School_FeeMaster.DueDate,103) as DueDate, School_FeeMaster.DiscountPossible, School_FeeMaster.Type,School_FeeMaster.Amount, School_FeeMaster.DateChecking, School_FeeMaster.AcademicYear, School_FeeMaster.ReceiptType, School_FeeMaster.Discount, School_FeeMaster.DiscountType, ISNULL(School_FeeMaster.VatApplicable, 0) AS VatApplicable, School_FeeMaster.VatPercent, School_FeeMaster.TaxCode, ISNULL(School_FeeMaster.VatInclusive, 0) AS VatInclusive FROM  Accounts INNER JOIN School_FeeMaster ON Accounts.ID = School_FeeMaster.PostTo LEFT OUTER JOIN Accounts AS a ON a.ID = School_FeeMaster.Discount WHERE (School_FeeMaster.ID = @ID) and School_FeeMaster.BranchID=@BranchID", dbPara, commandType: CommandType.Text));
            var FeeMaster = Task.FromResult(_dapperManager.Get<SchoolFeeMaster>("SELECT Accounts.AccountName, Accounts.AccountCode, a.AccountCode AS DiscountAccountCode, a.AccountName AS DiscountAccountName, Accounts.ID AS AccountsID,Col_FeeMaster.ID, Col_FeeMaster.Code, Col_FeeMaster.PriorityNo, Col_FeeMaster.Description, Col_FeeMaster.Category,Col_FeeMaster.Remarks, Col_FeeMaster.PostTo, DueDate, Col_FeeMaster.DiscountPossible, Col_FeeMaster.Type,Col_FeeMaster.Amount, Col_FeeMaster.DateChecking, Col_FeeMaster.AcademicYear, Col_FeeMaster.ReceiptType, Col_FeeMaster.Discount, Col_FeeMaster.DiscountType, ISNULL(Col_FeeMaster.VatApplicable, 0) AS VatApplicable, Col_FeeMaster.VatPercent, Col_FeeMaster.TaxCode, ISNULL(Col_FeeMaster.VatInclusive, 0) AS VatInclusive FROM  Accounts INNER JOIN Col_FeeMaster ON Accounts.ID = Col_FeeMaster.PostTo LEFT OUTER JOIN Accounts AS a ON a.ID = Col_FeeMaster.Discount WHERE (Col_FeeMaster.ID = @ID) and Col_FeeMaster.BranchID=@BranchID", Key, dbPara, commandType: CommandType.Text));
            return await FeeMaster;
        }

        public async Task<string> GetID(string AccountCode, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Code", AccountCode, DbType.String);
            var AccountID = Task.FromResult(_dapperManager.Get<string>("select id from Accounts where AccountCode='" + AccountCode + "'", Key, dbPara, commandType: CommandType.Text));
            return await AccountID;
        }

        public async Task<string> GetReceiptTypeID(string Key)
        {
            var dbPara = new DynamicParameters();
            var AccountID = Task.FromResult(_dapperManager.Get<string>("select id from vtypetran where basictype in (select id from vtypemast where description='Receipt') and entrymode='Receipt Student'", Key, dbPara, commandType: CommandType.Text));
            return await AccountID;
        }

        public async Task<long> CreateFeeMaster(SchoolFeeMaster dt, string Key)
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
                    // dbPara.Add("ID", trans.ID, DbType.Int64);
                    dbPara.Add("Code", dt.Code, DbType.String);
                    dbPara.Add("PriorityNo", dt.PriorityNo, DbType.Int32);
                    dbPara.Add("Description", dt.Description, DbType.String);
                    dbPara.Add("Category", dt.Category, DbType.String);
                    dbPara.Add("PostTo", dt.PostTo, DbType.Int32);
                    dbPara.Add("DueDate", dt.DueDate, DbType.DateTime);
                    dbPara.Add("DiscountPossible", dt.DiscountPossible, DbType.Boolean);
                    dbPara.Add("Type", dt.Type, DbType.String);
                    dbPara.Add("DateChecking", dt.DateChecking, DbType.Boolean);
                    dbPara.Add("AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("Discount", dt.Discount, DbType.Int32);
                    dbPara.Add("ReceiptType", dt.ReceiptType, DbType.String);
                    dbPara.Add("VatApplicable", dt.VatApplicable, DbType.Boolean);
                    dbPara.Add("VatPercent", dt.VatPercent, DbType.String);
                    dbPara.Add("TAXCode", dt.Taxcode, DbType.String);
                    dbPara.Add("VatInclusive", dt.VatInclusive, DbType.Boolean);
                    dbPara.Add("BranchId", dt.BranchId, DbType.Int32);
                    dbPara.Add("EndDate", dt.EndDate, DbType.DateTime);
                    dbPara.Add("Criteria", "InsertFeeMaster", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[COL_FeeMasterEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
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

        public async Task<long> EditFeeMaster(SchoolFeeMaster dt, string Key)
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
                    dbPara.Add("Code", dt.Code, DbType.String);
                    dbPara.Add("PriorityNo", dt.PriorityNo, DbType.Int32);
                    dbPara.Add("Description", dt.Description, DbType.String);
                    dbPara.Add("Category", dt.Category, DbType.String);
                    dbPara.Add("PostTo", dt.PostTo, DbType.Int32);
                    dbPara.Add("DueDate", dt.DueDate, DbType.DateTime);
                    dbPara.Add("DiscountPossible", dt.DiscountPossible, DbType.Boolean);
                    dbPara.Add("Type", dt.Type, DbType.String);
                    dbPara.Add("DateChecking", dt.DateChecking, DbType.Boolean);
                    dbPara.Add("AcademicYear", dt.AcademicYear, DbType.String);
                    dbPara.Add("Discount", dt.Discount, DbType.Int32);
                    dbPara.Add("ReceiptType", dt.ReceiptType, DbType.String);
                    dbPara.Add("VatApplicable", dt.VatApplicable, DbType.Boolean);
                    dbPara.Add("VatPercent", dt.VatPercent, DbType.String);
                    dbPara.Add("TAXCode", dt.Taxcode, DbType.String);
                    dbPara.Add("VatInclusive", dt.VatInclusive, DbType.Boolean);
                    dbPara.Add("BranchId", dt.BranchId, DbType.Int32);
                    dbPara.Add("EndDate", dt.EndDate, DbType.DateTime);
                    dbPara.Add("Criteria", "EditFeeMaster", DbType.String);
                    dbPara.Add("AccID", dt.Id, DbType.Int64);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[COL_FeeMasterEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
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

        public async Task<SchoolFeeMaster> GetExistFeeMaster(int FeeID, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@FeeID", FeeID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var FeeMaster = Task.FromResult(_dapperManager.Get<SchoolFeeMaster>("select fm.* from School_FeeMaster fm inner join School_FeeScheduleTrans fs on fm.Code=fs.Code and fm.Description=fs.Description and fm.AcademicYear=fs.AcademicYear where fm.ID=@FeeID and fm.BranchID=@BranchID", Key, dbPara, commandType: CommandType.Text));
            return await FeeMaster;
        }

        public async Task<long> DeleteFeeMaster(dtMasterStudent Fee, string Key)
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
                    SchoolFeeMaster fee = Fee.FeeMasterEntry!;
                    newID = await DeleteFee(fee, db, tran, Key);

                    DtoUserTrack user = Fee.UserTrack!;
                    user.Reason = "Delete FeeMaster of ID - " + newID + "";
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

        public async Task<int> DeleteFee(SchoolFeeMaster FeeMasterEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Code", FeeMasterEntry.Code, DbType.String);
            dbPara.Add("Criteria", "DeleteFeeMaster", DbType.String);
            dbPara.Add("AccID", FeeMasterEntry.Id, DbType.Int64);

            int newID = Convert.ToInt32(_dapperManager.Update("[COL_FeeMasterEntrySP]", Key, dbPara, commandType: CommandType.StoredProcedure));
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

        public DbConnection GetConnection(string key)
        {
            Security security = new Security();
            return new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString(security.Decrypt(key)), "", true));
        }
    }
}
