using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public class InvAccountsManager : IInvAccounts

    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public InvAccountsManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
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


        public async Task<IEnumerable<DtoInvAccounts>?> GetPreRegReceipt(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoInvAccounts>>("api/InvAccounts/PreReg?BranchID=" + BranchID + " &Key=" + key);

        }

        public async Task<DtoInvAccounts?> GetAccountsDetails(string? value, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<DtoInvAccounts>("api/InvAccounts/AccountName?value=" + value + "&BranchID=" + BranchID + "&Key=" + key);

        }

        public async Task<DtoInvAccounts?> GetStudentDetails(int? AccountId)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<DtoInvAccounts>("api/InvAccounts/GetStudent?AccountId=" + AccountId + "&Key=" + key);

        }

        public Task<IEnumerable<DtoInvAccounts>?> GetAccountsByCategory(string? value, string? BranchID)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<DtoInvAccounts>> GetAccountsByCategoryReceipt(string? AccCategory, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<DtoInvAccounts[]>("api/InvAccounts/AccCategory?AccCategory=" + AccCategory + "&BranchID=" + BranchID + "&Key=" + key);
            //throw new NotImplementedException();
        }
        public async Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentsAccountsReceiptGlobal(int? BranchID, string? receiptType)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<dtoStudentRegisterDefault>>("api/InvAccounts/GetAllStudentsGlobal?BranchID=" + BranchID + " &Key=" + key + "&receiptType=" + receiptType);
        }
        public async Task<IEnumerable<DtoInvAccounts>?> GetStudentsAccountsReceipt(int? BranchID, string? receiptType)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoInvAccounts>>("api/InvAccounts/GetStudents?BranchID=" + BranchID + " &Key=" + key + "&receiptType=" + receiptType);
        }
    }
}
