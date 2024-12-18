using OrisonCollegePortal.Shared.Entities;
namespace OrisonCollegePortal.Server.Contracts
{
    public interface IDocumentManager
    {
        Task<List<Documents>> GetAllDocuments(int branchid, string Key);
        Task<List<Documents>> GetDocumentsById(int id, string Key);
        Task<Documents> GetDocumentByDocId(int id, string Key);
        Task<bool> InsertDocuments(Documents documents , string Key);
        Task<bool> UpdateDocuments(Documents documents, string Key);
        Task<bool> Delete(int ID, string Key);
    }
}
