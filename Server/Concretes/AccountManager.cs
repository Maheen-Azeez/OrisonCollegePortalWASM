using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes
{
    public class AccountManager : IAccountManager
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;
        private readonly IStudentManager _studentmanager;
        string c;
        public AccountManager(IDapperManager dapperManager, IConfiguration config, IStudentManager studentmanager)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _studentmanager = studentmanager;


        }
        //public async Task<string> NextNum(int branchid)
        //{
        //    string code = await _studentmanager.GetNextStudentCode(branchid);
        //    c = code;
        //    return code;
        //}
        public async Task<long> InsertParentAccount(Student student, IDbConnection db, IDbTransaction tran)
        {
          try
            {
                //int newID;
                long newID;
                var dbPara = new DynamicParameters();
                dbPara.Add("ParentCode", student.parentcode, DbType.String);
                dbPara.Add("ParentName", student.parentname, DbType.String);
                //dbPara.Add("ParentLevel", student.ParentLevel, DbType.String);
                //dbPara.Add("Parent", student.Parent, DbType.String);
                //dbPara.Add("VoucherEntry", student.VoucherEntry, DbType.String);
                //dbPara.Add("AccountGroup",'1' , DbType.Int32);
                //dbPara.Add("SubGroup", student.SubGroup, DbType.String);
                //dbPara.Add("AccCategory", student.AccCategory, DbType.String);
                //dbPara.Add("ShowChild", student.ShowChild, DbType.String);
                //dbPara.Add("Isdefault", student.Isdefault, DbType.String);
                //dbPara.Add("AllowEntry", student.AllowEntry, DbType.String);
                //dbPara.Add("InActive",student.InActive, DbType.String);
                dbPara.Add("BranchID", student.BranchId, DbType.Int32);
                //dbPara.Add("CreatedDate", student.CreatedDate, DbType.DateTime);
                //dbPara.Add("ModifiedDate", student.ModifiedDate, DbType.DateTime);
                //dbPara.Add("CUser", student.CreatedUser, DbType.Int32);
                //dbPara.Add("MUser", student.ModifiedUser, DbType.Int32);
                dbPara.Add("Criteria", "InsertParentAccounts", DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                newID = _dapperManager.Insert("[College_AccountSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

                return newID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<long> InsertStudentAccount(Student student, IDbConnection db, IDbTransaction tran)
        {

            long newID;
            try
            {

                var dbPara = new DynamicParameters();
                dbPara.Add("StudCode", student.AccountCode, DbType.String);
                dbPara.Add("Studname", student.AccountName, DbType.String);
                //dbPara.Add("ParentLevel", student.ParentLevel, DbType.String);
                dbPara.Add("Parent", student.P_Id, DbType.Int32);
                //dbPara.Add("VoucherEntry", student.VoucherEntry, DbType.String);
                //dbPara.Add("AccountGroup", student.AccountGroup, DbType.String);
                //dbPara.Add("SubGroup", student.SubGroup, DbType.String);
                //dbPara.Add("AccCategory", student.AccCategory, DbType.String);
                //dbPara.Add("ShowChild", student.ShowChild, DbType.String);
                //dbPara.Add("Isdefault", student.Isdefault, DbType.String);
                //dbPara.Add("AllowEntry", student.AllowEntry, DbType.String);
                //dbPara.Add("InActive", student.InActive, DbType.String);
                dbPara.Add("BranchID", student.BranchId, DbType.Int32);
                //dbPara.Add("CreatedDate", student.CreatedDate, DbType.DateTime);
                //dbPara.Add("ModifiedDate", student.ModifiedDate, DbType.DateTime);
                //dbPara.Add("CUser", student.CreatedUser, DbType.Int32);
                //dbPara.Add("MUser", student.ModifiedUser, DbType.Int32);
                dbPara.Add("Criteria", "InsertStudentAccounts", DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                newID = _dapperManager.Insert("[College_AccountSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return newID;
        }

        public async Task<bool> UpdateStudentAccount(Student student, IDbConnection db, IDbTransaction tran)
        {
            try
            {

                var dbPara = new DynamicParameters();
                dbPara.Add("AccID", student.AccountId, DbType.Int32);
                dbPara.Add("Studname", student.AccountName, DbType.String);
                dbPara.Add("Criteria", "UpdateStudentAccounts", DbType.String);
                _dapperManager.UpdateTable("[College_AccountSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }



        public async Task<bool> UpdateParentAccount(Student student, IDbConnection db, IDbTransaction tran)
        {
            try
            {

                var dbPara = new DynamicParameters();
                dbPara.Add("AccID", student.P_Id, DbType.Int32);
                dbPara.Add("ParentName", student.FName, DbType.String);
                dbPara.Add("Criteria", "UpdateParentAccounts", DbType.String);
                _dapperManager.UpdateTable("[College_AccountSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

    }
}
