using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Server.Concretes.General
{
    public class ShortCutManager: IShortCutManager
    {
        private readonly IDapperManager _dapperManager;
        public ShortCutManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }
        public async Task<List<ShortCuts>> GetShortCuts(string ModuleName, int BranchID,string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ModuleName", ModuleName, DbType.String);
            dbPara.Add("BranchID", BranchID, DbType.Int32);
            dbPara.Add("Criteria", "ModuleShortCuts", DbType.String);
            var dtShortCuts = Task.FromResult(_dapperManager.GetAll<ShortCuts>("[OrisonPortal_ShortCutsSP]", key, dbPara,commandType: CommandType.StoredProcedure));
            return await dtShortCuts;
        }
    }
}
