using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IDocumentsEntry
    {
        Task<long> SaveDocument(SchoolDocument DocEntry, IDbConnection db, IDbTransaction tran);
        Task<long> UpdateDocument(SchoolDocument DocEntry, IDbConnection db, IDbTransaction tran);
        Task<long> DeleteDocument(SchoolDocument DocEntry, IDbConnection db, IDbTransaction tran, string Con);
        Task<long> SaveParentDocument(SchoolParentDocument DocEntry, IDbConnection db, IDbTransaction tran);
        Task<long> UpdateParentDocument(SchoolParentDocument DocEntry, IDbConnection db, IDbTransaction tran);
        Task<long> DeleteParentDocument(SchoolParentDocument DocEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
