using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class AdditionalPaymentMaster : IAdditionalPayment
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public AdditionalPaymentMaster(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<List<AdditionalTrack>?> Getdata(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<AdditionalTrack>>("api/AdditionalPayment/Get?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<AdditionalTrack?> GetAdditional(int? BranchID, int ID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<AdditionalTrack>("api/AdditionalPayment/Additional?BranchID=" + BranchID + "&ID=" + ID + "&Key=" + key);
        }

        public async Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/AdditionalPayment/DeleteSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> DeleteAdditional(int ID)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.DeleteAsync("api/AdditionalPayment/Deletes?Id=" + ID + "&Key=" + key);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<HttpResponseMessage> SaveMaster(AdditionalTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/AdditionalPayment/SaveMas?Key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateMaster(AdditionalTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/AdditionalPayment/UpdateMas?Key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/Additionalpayment/AddSaveUserTrack?Key=" + key, value);
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
                res = await httpClient.PostAsJsonAsync("api/AdditionalPayment/EditSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>("api/AdditionalPayment?BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<string> GetID(string Code)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccountID = await httpClient.GetStringAsync("api/AdditionalPayment/AccountID?AccountCode=" + Code + "&Key=" + key);
            return AccountID;
        }

        public async Task<IEnumerable<VtypeTrans>?> GetReceipt()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<VtypeTrans>>("api/AdditionalPayment/Receipt?Key=" + key);
        }
        public async Task<string> GetReceiptTypeID()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccountID = await httpClient.GetStringAsync("api/AdditionalPayment/ReceiptTypeID?Key=" + key);
            return AccountID;
        }
    }
}
