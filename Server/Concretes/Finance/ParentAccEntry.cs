using Dapper;
using OrisonCollegePortal.Server.Concretes.Finance;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class ParentAccEntry : IParentAccEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public ParentAccEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateParentAc(Accounts ParentAccentry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ParentCode", ParentAccentry.AccountCode, DbType.String);
            dbPara.Add("ParentName", ParentAccentry.AccountName, DbType.String);
            dbPara.Add("ParentLevel", ParentAccentry.ParentLevel, DbType.String);
            dbPara.Add("Parent", ParentAccentry.Parent, DbType.String);
            dbPara.Add("VoucherEntry", ParentAccentry.VoucherEntry, DbType.String);
            dbPara.Add("AccountGroup", ParentAccentry.AccountGroup, DbType.String);
            dbPara.Add("SubGroup", ParentAccentry.SubGroup, DbType.String);
            dbPara.Add("AccCategory", ParentAccentry.AccCategory, DbType.String);
            dbPara.Add("ShowChild", ParentAccentry.ShowChild, DbType.String);
            dbPara.Add("Isdefault", ParentAccentry.Isdefault, DbType.String);
            dbPara.Add("AllowEntry", ParentAccentry.AllowEntry, DbType.String);
            dbPara.Add("InActive", ParentAccentry.InActive, DbType.String);
            dbPara.Add("BranchID", ParentAccentry.BranchId, DbType.Int32);
            dbPara.Add("CreatedDate", ParentAccentry.CreatedDate, DbType.DateTime);
            dbPara.Add("ModifiedDate", ParentAccentry.ModifiedDate, DbType.DateTime);
            dbPara.Add("CUser", ParentAccentry.CreatedUser, DbType.Int32);
            dbPara.Add("MUser", ParentAccentry.ModifiedUser, DbType.Int32);
            dbPara.Add("Criteria", "InsertAccounts", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("Parent_AcEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<long> UpdateParentAc(Accounts ParentAccentry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("ParentCode", ParentAccentry.AccountCode, DbType.String);
            dbPara.Add("ParentName", ParentAccentry.AccountName, DbType.String);
            dbPara.Add("ParentLevel", ParentAccentry.ParentLevel, DbType.String);
            dbPara.Add("Parent", ParentAccentry.Parent, DbType.String);
            dbPara.Add("VoucherEntry", ParentAccentry.VoucherEntry, DbType.String);
            dbPara.Add("AccountGroup", ParentAccentry.AccountGroup, DbType.String);
            dbPara.Add("SubGroup", ParentAccentry.SubGroup, DbType.String);
            dbPara.Add("AccCategory", ParentAccentry.AccCategory, DbType.String);
            dbPara.Add("ShowChild", ParentAccentry.ShowChild, DbType.String);
            dbPara.Add("Isdefault", ParentAccentry.Isdefault, DbType.String);
            dbPara.Add("AllowEntry", ParentAccentry.AllowEntry, DbType.String);
            dbPara.Add("InActive", ParentAccentry.InActive, DbType.String);
            dbPara.Add("BranchID", ParentAccentry.BranchId, DbType.Int32);
            dbPara.Add("CreatedDate", ParentAccentry.CreatedDate, DbType.DateTime);
            dbPara.Add("ModifiedDate", ParentAccentry.ModifiedDate, DbType.DateTime);
            dbPara.Add("CUser", ParentAccentry.CreatedUser, DbType.Int32);
            dbPara.Add("MUser", ParentAccentry.ModifiedUser, DbType.Int32);
            dbPara.Add("Criteria", "UpdateAccounts", DbType.String);
            dbPara.Add("AccID", ParentAccentry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long newID = _dapperManager.Update("Parent_AcEntrySP", Key, dbPara, commandType: CommandType.StoredProcedure);
            return newID;
        }
    }
}
