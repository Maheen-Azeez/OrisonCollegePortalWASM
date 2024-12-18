using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IParentEntry
    {
        Task<int> CreateParent(SchoolParentMaster ParentEntry, IDbConnection db, IDbTransaction tran);

        Task<int> UpdateParent(SchoolParentMaster ParentEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
