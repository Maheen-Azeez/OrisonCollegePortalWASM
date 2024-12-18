using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts;
using OrisonCollegePortal.Shared.Entities;
using Syncfusion.Blazor.Diagrams;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes
{
    public class DocumentManager : IDocumentManager
    {

        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public DocumentManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;

        }

        public async Task<HttpResponseMessage> Delete(int ID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.DeleteAsync("api/Document/delete?ID=" + ID + "&Key=" + key);
        }

        public void Dispose()
        {

        }

        public async Task<List<Documents>> GetAllDocuments(int branchid)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var al = await httpClient.GetFromJsonAsync<List<Documents>>("api/Document/GetAllDocuments?branchid=" + branchid + "&Key=" + key);
                return al;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Documents> GetDocumentByDocId(int id)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var al = await httpClient.GetFromJsonAsync<Documents>("api/Document/GetDocumentByDocId?id=" + id + "&Key=" + key);
                return al;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Documents>> GetDocumentsById(int id)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var al = await httpClient.GetFromJsonAsync<List<Documents>>("api/Document/GetAllDocumentsbyId?id=" + id + "&Key=" + key);
                return al;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> InsertDocument(Documents documents)
        {
            try
            {
                //HttpResponseMessage response;
                //response= await httpClient.PostJsonAsync<HttpResponseMessage>(BaseUrl + "Document/InsertDocuments",documents);
                //long ID = 0;
                //var data = await response.Content.ReadFromJsonAsync<Documents>();
                //ID = data.Document_id;
                //return ID;
                //long ID;
                //ID= 
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.PostAsJsonAsync("api/Document/InsertDocuments?Key=" + key, documents);
                //return ID;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<HttpResponseMessage> UpdateDocument(Documents documents)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.PostAsJsonAsync("api/Document/UpdateDocuments?Key=" + key, documents);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
