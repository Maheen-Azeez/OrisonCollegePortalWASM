using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class FeeMaster : IFeeMaster
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public FeeMaster(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>("api/Fee?BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<IEnumerable<VtypeTrans>?> GetReceipt()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<VtypeTrans>>("api/Fee/Receipt?Key=" + key);
        }

        public async Task<IEnumerable<SchoolFeeMaster>?> GetFeeMasterList(string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolFeeMaster>>("api/Fee/FeeMasterList?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<SchoolFeeMaster?> GetDTFeeMaster(int ID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Fee = await httpClient.GetFromJsonAsync<SchoolFeeMaster>("api/Fee/FeeMaster/" + ID + "/" + BranchID + "?Key=" + key);
            return Fee;
        }

        public async Task<string> GetID(string Code)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccountID = await httpClient.GetStringAsync("api/Fee/AccountID?AccountCode=" + Code + "&Key=" + key);
            return AccountID;
        }
        public async Task<string> GetReceiptTypeID()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccountID = await httpClient.GetStringAsync("api/Fee/ReceiptTypeID?Key=" + key);
            return AccountID;
        }

        public async Task<HttpResponseMessage> SaveFeeMaster(SchoolFeeMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/Fee/SaveFeeMaster?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateFeeMaster(SchoolFeeMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/Fee/UpdateFeeMaster?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<SchoolFeeMaster?> GetExistFeeMaster(string FeeID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Fee = await httpClient.GetFromJsonAsync<SchoolFeeMaster>("api/Fee/ExistFeeMaster/" + FeeID + "/" + BranchID + "?Key=" + key);
            return Fee;
        }

        public async Task<HttpResponseMessage> DeleteFeeMasterByID(dtMasterStudent Fee)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/Fee/DeleteFeeMaster?Key=" + key, Fee);
        }
    }
}
