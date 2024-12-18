using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Logics.Concrete.Students
{
    public class MiscellaneousMasterManager : IMiscellaneousMasterManager
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public MiscellaneousMasterManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }

        public async Task<List<MiscellaneousMasterdata>?> GetMaster()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<MiscellaneousMasterdata>>("api/MiscellaneousMasterManager/GetMasters?Key=" + key);
        }

        public async Task<HttpResponseMessage> SaveMaster(MiscellaneousMasterdata value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/MiscellaneousMasterManager/SaveMas?Key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }

        public Task<HttpResponseMessage> UpdatMaster()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteMaster(string Con)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MiscellaneousMasterdata>?> ComboMaster(string Source)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<MiscellaneousMasterdata>>("api/MiscellaneousMasterManager/GetComb?Source=" + Source + "&Key=" + key);
        }

        async Task<bool> IMiscellaneousMasterManager.DeleteMaster(int id)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                await httpClient.DeleteAsync("api/MiscellaneousMasterManager/Delete?id=" + id + "&Key=" + key);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
