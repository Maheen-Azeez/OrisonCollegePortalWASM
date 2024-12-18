using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.General;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.General
{
    public class UserTrackEntry: IUserTrack
    {
        private readonly IDapperManager _dapperManager;

        public UserTrackEntry(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public async Task<long> UserTrackUpdation(DtoUserTrack userTrack, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("UserId", userTrack.UserId, DbType.Int64);
            dbPara.Add("TableName", userTrack.TableName, DbType.String);
            dbPara.Add("ActionDate", userTrack.ActionDate, DbType.DateTime);
            dbPara.Add("Reason", userTrack.Reason, DbType.String);
            dbPara.Add("ActionID", userTrack.ActionId, DbType.Int64);
            dbPara.Add("RowID", userTrack.RowId, DbType.Int64);
            dbPara.Add("MachineName", userTrack.MachineName, DbType.String);
            dbPara.Add("ModuleName", userTrack.ModuleName, DbType.String);
            dbPara.Add("Reference", userTrack.Reference, DbType.String);
            dbPara.Add("Amount", userTrack.Amount, DbType.Decimal);
            dbPara.Add("Remark", "Inserted From Web", DbType.String);
            if (userTrack.Company == "ARCADIA")
            {
                dbPara.Add("VNO", userTrack.VNO, DbType.String);
                dbPara.Add("Vtype", userTrack.vtypeAbbr, DbType.String);
            }
            //dbPara.Add("Criteria", "Insert_UserTrack", DbType.String);

            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long newID = _dapperManager.Insert("[COLStudent_UserTrackSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return newID;
        }

        public void Dispose()
        {
            //
        }
    }
}
