using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IRelationEntry
    {
        Task<int> CreateRelation(SchoolFamilyDetail RelationEntry, IDbConnection db, IDbTransaction tran);

        Task<int> UpdateRelation(SchoolFamilyDetail RelationEntry, IDbConnection db, IDbTransaction tran, string Key);

        Task<int> DeleteRelation(SchoolFamilyDetail RelationEntry, IDbConnection db, IDbTransaction tran, string Key);
    }
}
