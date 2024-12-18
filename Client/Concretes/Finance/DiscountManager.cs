using System.Net.Http.Json;
using System.Web;
using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Logics.Concrete.Students
{
    public class DiscountManager : IDiscountManager
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public DiscountManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<HttpResponseMessage> SaveMaster(SchoolDiscountSchedule value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/DiscountManager/SaveMas?Key=" + key, value);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }

        public async Task<List<SchoolDiscountSchedule>?> GetAll(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolDiscountSchedule>>("api/" + BranchID + "&Key=" + key);
        }

        public async Task<SchoolDiscountSchedule> Getdt(int? BranchID)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var Student = await httpClient.GetFromJsonAsync<SchoolDiscountSchedule>("api/DiscountManager/Getdt?BranchID=" + BranchID + "&Key=" + key);
                return Student!;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<List<SchoolDiscountSchedule>?> Getdata(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolDiscountSchedule>>("api/DiscountManager/Get?BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<HttpResponseMessage> UpdateMaster(SchoolDiscountSchedule value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/DiscountManager/UpdateMas?Key=" + key, value);
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return res;
        }

        public async Task<SchoolDiscountSchedule?> GetDTDiscount(int Id, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<SchoolDiscountSchedule>("api/DiscountManager/Discount?Id=" + Id + "&Key=" + key);
        }

        public async Task<HttpResponseMessage> DeleteDiscount(int Id)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.DeleteAsync("api/DiscountManager/Deletes?Id=" + Id + "&Key=" + key);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/DiscountManager/AddSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> EditSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/DiscountManager/EditSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/DiscountManager/DeleteSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<string> GetID(string Code)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccountID = await httpClient.GetStringAsync("api/DiscountManager/AccountID?AccountCode=" + Code + "&Key=" + key);
            return AccountID;
        }

        public async Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>("api/DiscountManager/PostTo?BranchID=" + BranchID + "&Key=" + key);
        }
    }
}
