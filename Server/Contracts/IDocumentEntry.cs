using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IDocumentEntry
    {
        Task<long> SaveDocument(Documents docEntry, IDbConnection db, IDbTransaction tran);
        Task<long> UpdateDocument(Documents docEntry, IDbConnection db, IDbTransaction tran);
    }
}
