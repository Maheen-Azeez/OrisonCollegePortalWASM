using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using OrisonCollegePortal.Shared.Entities.General;
using Syncfusion.Blazor.Diagrams;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Services
{
    public class UserRightsService
    {
        private string? key;
        HttpClient http = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        private readonly NavigationManager navigationManager;

        public UserRightsService(HttpClient httpClient, ISessionStorageService _SessionStorage, NavigationManager navigationManager)
        {
            http = httpClient;
            this.SessionStorage = _SessionStorage;
            this.navigationManager = navigationManager;
        }

        public async Task<UserRights?> GetUserRights(int? UserID, string Keyword, string Module, int? BranchId)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await http.GetFromJsonAsync<UserRights?>("API/UserRights/Rights?ID=" + UserID + "&Keyword=" + Keyword + "&Module=" + Module + "&BranchId=" + BranchId + "&Key=" + key);
        }
        //public void Export(string table, string type, Query query = null)
        //{
        //    navigationManager.NavigateTo(query != null ? query.ToUrl($"/export/northwind/{table}/{type}") : $"/export/northwind/{table}/{type}", true);
        //}
    }
}
