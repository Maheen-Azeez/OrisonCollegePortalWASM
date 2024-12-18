using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IDocumentImageEntry
    {
        public Task<long> SaveDocumentImage(SchoolDocImage DocImgEntry, IDbConnection db, IDbTransaction tran);
        public Task<long> UpdateDocumentImage(SchoolDocImage DocImgEntry, IDbConnection db, IDbTransaction tran);
        public Task<long> SaveParentDocumentImage(SchoolParentDocImage DocImgEntry, IDbConnection db, IDbTransaction tran);
        public Task<long> UpdateParentDocumentImage(SchoolParentDocImage DocImgEntry, IDbConnection db, IDbTransaction tran);
    }
}
