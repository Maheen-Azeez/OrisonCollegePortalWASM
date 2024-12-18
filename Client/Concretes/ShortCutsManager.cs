using System.Net.Http.Json;
using System.Web;
using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Client.Concretes
{
    public class ShortCutsManager : IShortCutsManager
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public ShortCutsManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }

        public async Task<List<ShortCuts>?> GetShortCuts(string ModuleName, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<ShortCuts>>("api/ShortCuts?ModuleName=" + ModuleName + "&BranchID=" + BranchID + "&Key=" + key);
        }
    }
}
