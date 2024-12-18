using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IDocImageEntry
    {
        public Task<long> SaveDocumentImage(Documents DocImgEntry, IDbConnection db, IDbTransaction tran);
        public Task<long> UpdateDocumentImage(Documents DocImgEntry, IDbConnection db, IDbTransaction tran);
    }
}
