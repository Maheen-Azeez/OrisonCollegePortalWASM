using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Concretes;
using OrisonCollegePortal.Shared.Entities;
using SecurityService;
using System.Data;
using System.Data.Common;

namespace OrisonCollegePortal.Server.Concretes
{
    public class MiscellaneousMasterManager : IMiscellaneousMasterManager
    {
        private readonly IConfiguration _config;
        private readonly IDapperManager _dapperManager;
        public MiscellaneousMasterManager(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<List<MiscellaneousMasterdata>> ComboMaster(string Source, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@cmbsource", Source, DbType.String);

            var StudentLists = Task.FromResult(_dapperManager.GetAll<MiscellaneousMasterdata>("select distinct ID,Source,Description from COL_MasterMisc where source=@cmbsource", Key, dbPara, commandType: CommandType.Text));
            return await StudentLists;
        }

        public async Task<int> DeleteMaster(int id, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@id", id);

            int newID = Convert.ToInt32(_dapperManager.Execute("Delete from COL_MasterMisc where id=@id", Key, dbPara, commandType: CommandType.Text));
            return newID;
        }

        public async Task<List<MiscellaneousMasterdata>> GetMaster(string Key)
        {
            var dbPara = new DynamicParameters();
            var StudentList = Task.FromResult(_dapperManager.GetAll<MiscellaneousMasterdata>("select distinct source from COL_MasterMisc", Key, null, commandType: CommandType.Text));
            return await StudentList;
        }

        public async Task<long> SaveMaster(MiscellaneousMasterdata value, string Key)
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
                    dbPara.Add("Source", value.Source);
                    dbPara.Add("Description", value.Description);
                    dbPara.Add("Code", value.Code);
                    dbPara.Add("VDefault", value.VDefault);
                    dbPara.Add("Criteria", "InsertMasterMisc", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[COLWeb_MiscMaster]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
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



