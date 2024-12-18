using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes
{
    public class ParentManager : IParentManager
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public ParentManager(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;


        }

        public async Task<long> Insert(int id, Student student, IDbConnection db, IDbTransaction tran)
        {
            try
            {
                long newID;

                var dbPara = new DynamicParameters();

                dbPara.Add("Criteria", "Insert_Parent", DbType.String);
                dbPara.Add("AccountId", id, DbType.Int32);

                dbPara.Add("FatherName", student.FName, DbType.String);
                dbPara.Add("TelFather", student.TelFather, DbType.String);
                dbPara.Add("MotherName", student.MName, DbType.String);
                dbPara.Add("TelMother", student.TelMother, DbType.String);
                dbPara.Add("G_Email", student.Guardian_Email, DbType.String);
                newID = _dapperManager.Insert("[Col_ParentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

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

                dbPara.Add("Criteria", "Update_Parent", DbType.String);
                dbPara.Add("id", student.AccountId, DbType.Int32);

                dbPara.Add("FatherName", student.FName, DbType.String);
                dbPara.Add("TelFather", student.TelFather, DbType.String);
                dbPara.Add("MotherName", student.MName, DbType.String);
                dbPara.Add("TelMother", student.TelMother, DbType.String);
                dbPara.Add("G_Email", student.Guardian_Email, DbType.String);
                _dapperManager.UpdateTable("[Col_ParentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
