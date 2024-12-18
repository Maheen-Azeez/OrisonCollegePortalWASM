using Dapper;

using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Data;
using System.Drawing;
using System.Web;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class InvAccountsManager : IInvAccounts
    {
        private readonly IDapperManager _dapperManager;
        private bool disposedValue;
        public InvAccountsManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
        

      
        public async Task<List<DtoInvAccounts>> GetPreRegisterStudents(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("BranchID", BranchID, DbType.Int64);
            dbPara.Add("Criteria", "PreReceiptStudents", DbType.String);

            var Accounts = Task.FromResult(_dapperManager.GetAll<DtoInvAccounts>
                                ("[FINWEB_INVENTORYVoucherSP]", Key, dbPara,
                                commandType: CommandType.StoredProcedure));
            return await Accounts;
        }
        public async Task<DtoInvAccounts> GetAccountsDetails(string value, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@value", HttpUtility.UrlDecode(value), DbType.String);
            dbPara.Add("BranchID", BranchID, DbType.Int64);
            var obj = Task.FromResult(_dapperManager.Get<DtoInvAccounts>($"select * from  AccountsVW where Accountname=@value", Key, dbPara,
                     commandType: CommandType.Text));
            return await obj;
        }

        public async Task<DtoInvAccounts>? GetDTAccount(int? AccountID,string? AccountCode,string?Criteria, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountID", AccountID, DbType.Int64);
            dbPara.Add("Criteria", Criteria, DbType.String);
            dbPara.Add("AccountCode", AccountCode, DbType.String);
            dbPara.Add("BranchId", BranchID, DbType.Int64);
            var obj = Task.FromResult(_dapperManager.Get<DtoInvAccounts>("[FINWEB_INVENTORYVoucherSP]", Key, dbPara,
                                commandType: CommandType.StoredProcedure));
            return await obj;
        }
        public async Task<List<DtoInvAccounts>> GetAccountsByCategory(string AccCategory, string AccSubCategory, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccCategory", AccCategory, DbType.String);
            dbPara.Add("AccSubCategory", AccSubCategory, DbType.String);
            dbPara.Add("Criteria", "AccountMasterByCategory", DbType.String);

            var Accounts = Task.FromResult(_dapperManager.GetAll<DtoInvAccounts>
                                ("[FINWEB_INVENTORYVoucherSP]", Key, dbPara,
                                commandType: CommandType.StoredProcedure));
            return await Accounts;
        }

        public async Task<List<DtoInvAccounts>> GetAccounts(string AccCategory, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccCategory", AccCategory, DbType.String);
            dbPara.Add("BranchID", BranchID, DbType.Int64);
            dbPara.Add("Criteria", "AccountsByCategory", DbType.String);
            //dtInvVoucher voucher = new dtInvVoucher();
            var Accounts = Task.FromResult(_dapperManager.GetAll<DtoInvAccounts>
                                ("[FINWEB_INVENTORYVoucherSP]", Key, dbPara,
                                commandType: CommandType.StoredProcedure));
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return await Accounts;
        }
        public async Task<List<DtoInvAccounts>> GetStudentsAccounts(int BranchID, string Key, string? ReceiptType)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("BranchId", BranchID, DbType.Int32);
                dbPara.Add("ReceiptType", ReceiptType, DbType.String);
                var Accounts = Task.FromResult(_dapperManager.GetAll<DtoInvAccounts>
                                    ("[Col_AccountMasterSP]", Key, dbPara,
                                    commandType: CommandType.StoredProcedure));
                return await Accounts;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<List<dtoStudentRegisterDefault>> GetStudentsAccountsGlobal(int BranchID, string Key, string? ReceiptType)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("BranchId", BranchID, DbType.Int32);
                dbPara.Add("ReceiptType", ReceiptType, DbType.String);
                var Accounts = Task.FromResult(_dapperManager.GetAll<dtoStudentRegisterDefault>
                                    ("[Col_AccountMasterSP]", Key, dbPara,
                                    commandType: CommandType.StoredProcedure));
                return await Accounts;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<DtoInvAccounts> GetStudent(int BranchID, long AccID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountID", AccID, DbType.Int64);
            dbPara.Add("Criteria", "StudentDetails", DbType.String);
            dbPara.Add("BranchID", BranchID, DbType.Int64);
            var obj = Task.FromResult(_dapperManager.Get<DtoInvAccounts>("[Col_AccountMasterSP]", Key,dbPara,
                                commandType: CommandType.StoredProcedure));
            return await obj;
        }
    }
}

