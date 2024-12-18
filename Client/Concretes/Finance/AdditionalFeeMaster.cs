using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class AdditionalFeeMaster : IAdditionalFeeMaster
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public AdditionalFeeMaster(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<List<SchoolFeeMaster>?> Getdata(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolFeeMaster>>("api/AdditionalFee/GetFee?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<SchoolFeeMaster?> GetAdditional(int? BranchID, int ID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<SchoolFeeMaster>("api/AdditionalFee/Additional?BranchID=" + BranchID + "&ID=" + ID + "&Key=" + key);
        }

        public async Task<string> GetID(string Code)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccountID = await httpClient.GetStringAsync("api/AdditionalFee/AccountID?AccountCode=" + Code + "&Key=" + key);
            return AccountID!;
        }

        public async Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/AdditionalFee/AddSaveUserTrack?Key=" + key, value);
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
                res = await httpClient.PostAsJsonAsync("api/AdditionalFee/EditSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> SaveMaster(SchoolFeeMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/AdditionalFee/SaveMas?Key=" + key, value);

            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateMaster(SchoolFeeMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/AdditionalFee/UpdateMas?Key=" + key, value);

            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return res;
        }

        public async Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>("api/AdditionalFee/PostTo?BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<IEnumerable<VtypeTrans>?> GetReceipt()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<VtypeTrans>>("api/AdditionalFee/Receipt?Key=" + key);
        }

        public async Task<HttpResponseMessage> DeleteAdditional(int ID)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.DeleteAsync("api/AdditionalFee/Deletes?Id=" + ID + "&Key=" + key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/AdditionalFee/DeleteSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }
    }
}
