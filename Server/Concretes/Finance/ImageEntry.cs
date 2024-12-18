using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class ImageEntry : IImageEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public ImageEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateImage(SchoolImage ImageEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("StudentId", ImageEntry.StudentId, DbType.Int64);
            dbPara.Add("Type", ImageEntry.Type, DbType.String);
            dbPara.Add("Photo", ImageEntry.Photo, DbType.Binary);
            dbPara.Add("Criteria", "InsertImage", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("StudentImage_EntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> UpdateImage(SchoolImage ImageEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("StudentId", ImageEntry.StudentId, DbType.Int64);
            dbPara.Add("Type", ImageEntry.Type, DbType.String);
            dbPara.Add("Photo", ImageEntry.Photo, DbType.Binary);
            dbPara.Add("Criteria", "UpdateImage", DbType.String);
            dbPara.Add("AccID", ImageEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Update("StudentImage_EntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }
    }
}
