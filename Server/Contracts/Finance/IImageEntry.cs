using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IImageEntry
    {
        Task<int> CreateImage(SchoolImage ImageEntry, IDbConnection db, IDbTransaction tran);

        Task<int> UpdateImage(SchoolImage ImageEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
