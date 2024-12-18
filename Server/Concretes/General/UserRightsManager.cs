using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.General;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.General
{
    public class UserRightsManager : IUserRightsManager
    {
        private readonly IDapperManager _dapperManager;

        public UserRightsManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public async Task<UserRights> GetUserRights(int? ID, string Keyword, string Module, int? BranchId, string Con)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("userid", ID, DbType.Int32);
            dbPara.Add("Keyword", Keyword, DbType.String);
            dbPara.Add("BranchId", BranchId, DbType.Int32);
            dbPara.Add("Module", Module, DbType.String);
            dbPara.Add("type", "UserRights", DbType.String);
            var _UserRights = Task.FromResult(_dapperManager.Get<UserRights>
                                ("[COLStudent_BindDataSP]", Con, dbPara,
                                commandType: CommandType.StoredProcedure));
            return await _UserRights;
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
