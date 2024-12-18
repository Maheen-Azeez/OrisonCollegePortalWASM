using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Client.Contracts
{
    public interface IDocumentManager
    {
        Task<List<Documents>> GetAllDocuments(int branchid);
        Task<List<Documents>> GetDocumentsById(int id);
        Task<Documents> GetDocumentByDocId(int id);

        Task<HttpResponseMessage> InsertDocument(Documents documents);
        Task<HttpResponseMessage> UpdateDocument(Documents documents);
        Task<HttpResponseMessage> Delete(int ID);
    }
}
