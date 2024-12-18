using System.Net.Http.Json;
using System.Web;
using Blazored.SessionStorage;
using OrisonCollegePortal.Shared.Entities.General;
using Syncfusion.Blazor.Diagrams;

namespace OrisonCollegePortal.Client.Services
{
    public class GeneralServices: IDisposable
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public GeneralServices(HttpClient _httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = _httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any managed resources here
            }
            // Dispose of any unmanaged resources here
        }

        public async Task<string> getLogo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("API/Home/Logo?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<string?> getLogoUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("API/Home/LogoUrl?Key=" + key);
        }
        public async Task<string?> GetURL(string? source)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("API/MasterMisc?Source=" + source + "&Key=" + key);
        }
        public async Task<List<DtoMenuSettings>?> GetMenu()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoMenuSettings>?>("API/MenuSettings?Key=" + key);
        }
        public async Task<string?> GetBranchSettings(string? category)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("API/Balance/BranchSettings?category=" + category + "&Key=" + key);
        }
        public async Task<UserRights?> GetUserRights(int? UserID, string? Keyword, string? Module, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<UserRights?>("API/UserRights/Rights?ID=" + UserID + "&Keyword=" + Keyword + "&Module=" + Module + "&BranchId=" + BranchID + "&Key=" + key);
        }
        public async Task<object?> GetScalar(string cmd)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<object>("API/Values/GetScalar?cmd=" + cmd + "&Key=" + key);
        }
        //Receipt
        //VtypeTran->DtoVtypeTran
        //public async Task<List<DtoVtypeTran>?> getEntryMode(string EntryMode, bool FinWeb, string Con)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<List<DtoVtypeTran>>( "API/Settings/" + EntryMode + "/" + FinWeb + "?Key=" + key);

        //}
        public async Task<List<dtoFormLabelSettings>?> GetLabels(string FormName)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<dtoFormLabelSettings>?>("api/FormLabel/GetLabels?FormLabel=" + FormName + "&Key=" + key);
        }

        public async Task<DateTime> GetServerDateTime()
        {
            var response = await httpClient.GetAsync("api/Date/GetDate");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DateTime>();
        }

        //public async Task<List<DtoReRegAccCategory>?> GetReRegCat(string ReRegValue)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<List<DtoReRegAccCategory>?>("API/Settings/ReRegAccCat?ReRegValue=" + ReRegValue + "&Key=" + key);

        //}


        public async Task<string?> GetSettings(string? category)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("API/Settings?category=" + category + "&Key=" + key);
        }
    }     
}