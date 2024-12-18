using OrisonCollegePortal.Shared.Entities.General;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.General
{
    public interface IUserTrack
    {
        Task<long> UserTrackUpdation(DtoUserTrack userTrack, IDbConnection db, IDbTransaction tran);
    }
}
