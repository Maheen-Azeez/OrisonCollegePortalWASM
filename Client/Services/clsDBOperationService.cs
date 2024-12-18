using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Services
{
    public class clsDBOperationService
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public clsDBOperationService(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<object?> GetScalar(string cmd)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<object>("API/clsDBOperation/GetScalar?cmd=" + cmd + "&Key=" + key);
        }
        public async Task<IEnumerable<object>?> GetTable(string cmd)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<object>>("API/clsDBOperation/GetTable?cmd=" + cmd + "&Key=" + key);
        }
        public async Task<object?> GetScalarMaster(string cmd)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("Master_key"));
            return await httpClient.GetFromJsonAsync<object>("API/clsDBOperation/GetScalar?cmd=" + cmd + "&Key=" + key);
        }
        //public async Task<IEnumerable<dtAcademicYear>> GetAcademicYear(string cmd)
        //{
        //    return await httpClient.GetJsonAsync<IEnumerable<dtAcademicYear>>(BaseUrl + "clsDBOperation/GetTable?cmd=" + cmd);
        //}
    }
}
