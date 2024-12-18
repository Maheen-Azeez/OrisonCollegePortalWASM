using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class StudentAccEntry : IStudentAccEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public StudentAccEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateStudentAc(Accounts accEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("StudCode", accEntry.AccountCode, DbType.String);
            dbPara.Add("Studname", accEntry.AccountName, DbType.String);
            dbPara.Add("ParentLevel", accEntry.ParentLevel, DbType.String);
            dbPara.Add("Parent", accEntry.Parent, DbType.String);
            dbPara.Add("VoucherEntry", accEntry.VoucherEntry, DbType.String);
            dbPara.Add("AccountGroup", accEntry.AccountGroup, DbType.String);
            dbPara.Add("SubGroup", accEntry.SubGroup, DbType.String);
            dbPara.Add("AccCategory", accEntry.AccCategory, DbType.String);
            dbPara.Add("ShowChild", accEntry.ShowChild, DbType.String);
            dbPara.Add("Isdefault", accEntry.Isdefault, DbType.String);
            dbPara.Add("AllowEntry", accEntry.AllowEntry, DbType.String);
            dbPara.Add("InActive", accEntry.InActive, DbType.String);
            dbPara.Add("BranchID", accEntry.BranchId, DbType.Int32);
            dbPara.Add("CreatedDate", accEntry.CreatedDate, DbType.DateTime);
            dbPara.Add("ModifiedDate", accEntry.ModifiedDate, DbType.DateTime);
            dbPara.Add("CUser", accEntry.CreatedUser, DbType.Int32);
            dbPara.Add("MUser", accEntry.ModifiedUser, DbType.Int32);
            dbPara.Add("Criteria", "InsertAccounts", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("Student_AcEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<ActionResult<Accounts>> CreateStudentAc(Accounts ac)
        {
            try
            {
                //using IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
                {
                    string sQuery = "Student_AcEntrySP";
                    db.Open();
                    DynamicParameters dbPara = new DynamicParameters();
                    dbPara.Add("@StudCode", ac.AccountCode, DbType.String);
                    dbPara.Add("@Studname", ac.AccountName, DbType.String);
                    dbPara.Add("@ParentLevel", ac.ParentLevel, DbType.String);
                    dbPara.Add("@Parent", ac.Parent, DbType.String);
                    dbPara.Add("@VoucherEntry", ac.VoucherEntry, DbType.String);
                    dbPara.Add("@AccountGroup", ac.AccountGroup, DbType.String);
                    dbPara.Add("@SubGroup", ac.SubGroup, DbType.String);
                    dbPara.Add("@AccCategory", ac.AccCategory, DbType.String);
                    dbPara.Add("@ShowChild", ac.ShowChild, DbType.String);
                    dbPara.Add("@Isdefault", ac.Isdefault, DbType.String);
                    dbPara.Add("@AllowEntry", ac.AllowEntry, DbType.String);
                    dbPara.Add("@InActive", ac.InActive, DbType.String);
                    dbPara.Add("@BranchID", ac.BranchId, DbType.Int32);
                    dbPara.Add("@CreatedDate", ac.CreatedDate, DbType.DateTime);
                    dbPara.Add("@ModifiedDate", ac.ModifiedDate, DbType.DateTime);
                    dbPara.Add("@CUser", ac.CreatedUser, DbType.Int32);
                    dbPara.Add("@MUser", ac.ModifiedUser, DbType.Int32);
                    dbPara.Add("@Criteria", "InsertAccounts", DbType.String);
                    dbPara.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                    var result = await db.QueryAsync<Accounts>(sQuery, dbPara, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> UpdateStudentAc(Accounts accEntry, IDbConnection db, IDbTransaction tran, string key)
        {
            var dbPara = new DynamicParameters();

            //dbPara.Add("EmpCode", accEntry.AccountCode, DbType.String);
            //dbPara.Add("Staffname", accEntry.AccountName, DbType.String);
            //dbPara.Add("BranchID", accEntry.BranchId, DbType.Int32);
            //dbPara.Add("CreatedDate", accEntry.CreatedDate, DbType.DateTime);
            //dbPara.Add("ModifiedDate", accEntry.ModifiedDate, DbType.DateTime);
            //dbPara.Add("CUser", accEntry.CreatedUser, DbType.Int32);
            //dbPara.Add("MUser", accEntry.ModifiedUser, DbType.Int32);
            dbPara.Add("StudCode", accEntry.AccountCode, DbType.String);
            dbPara.Add("Studname", accEntry.AccountName, DbType.String);
            dbPara.Add("ParentLevel", accEntry.ParentLevel, DbType.String);
            dbPara.Add("Parent", accEntry.Parent, DbType.String);
            dbPara.Add("VoucherEntry", accEntry.VoucherEntry, DbType.String);
            dbPara.Add("AccountGroup", accEntry.AccountGroup, DbType.String);
            dbPara.Add("SubGroup", accEntry.SubGroup, DbType.String);
            dbPara.Add("AccCategory", accEntry.AccCategory, DbType.String);
            dbPara.Add("ShowChild", accEntry.ShowChild, DbType.String);
            dbPara.Add("Isdefault", accEntry.Isdefault, DbType.String);
            dbPara.Add("AllowEntry", accEntry.AllowEntry, DbType.String);
            dbPara.Add("InActive", accEntry.InActive, DbType.String);
            dbPara.Add("BranchID", accEntry.BranchId, DbType.Int32);
            dbPara.Add("CreatedDate", accEntry.CreatedDate, DbType.DateTime);
            dbPara.Add("ModifiedDate", accEntry.ModifiedDate, DbType.DateTime);
            dbPara.Add("CUser", accEntry.CreatedUser, DbType.Int32);
            dbPara.Add("MUser", accEntry.ModifiedUser, DbType.Int32);
            dbPara.Add("Criteria", "UpdateAccounts", DbType.String);
            dbPara.Add("AccID", accEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long newID = _dapperManager.Update("Student_AcEntrySP", key, dbPara, commandType: CommandType.StoredProcedure);
            return newID;
        }


    }
}
