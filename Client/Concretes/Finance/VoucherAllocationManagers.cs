using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class VoucherAllocationManagers : IVoucherAllocationManagers
    {


        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public VoucherAllocationManagers(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }

        async Task<bool> IVoucherAllocationManagers.Delete(int Vids)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                await httpClient.DeleteAsync("api/VoucherAllocationManagers/Delete?Vids=" + Vids + "&key=" + key);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;

            }
        }

        public async Task<int> Autoallo(string Dateauto, int AccountID, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            var Student = await httpClient.GetFromJsonAsync<int>("api/VoucherAllocationManagers/Autoallo?Dateauto=" + Dateauto + "&AccountID=" + AccountID + "&BranchID=" + BranchID + "&key=" + key);
            return Student;
        }
        public async Task<IEnumerable<dtStudentStatement>> GetStatements(int Vid, int AccountID, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            var Statement = await httpClient.GetFromJsonAsync<IEnumerable<dtStudentStatement>>("api/VoucherAllocationManagers/StudentStatements?Vid=" + Vid + "&AccountID=" + AccountID + "&BranchID=" + BranchID + "&key=" + key);
            return Statement!;
        }
        public async Task<IEnumerable<dtStudentStatement>> Getallo(int Vid, int AccountID, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            var Statement = await httpClient.GetFromJsonAsync<IEnumerable<dtStudentStatement>>("api/VoucherAllocationManagers/Getallo?Vid=" + Vid + "&AccountID=" + AccountID + "&BranchID=" + BranchID + "&key=" + key);
            return Statement!;
        }
        public async Task<HttpResponseMessage> Savestatement(dtStudentStatement value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                res = await httpClient.PostAsJsonAsync("api/VoucherAllocationManagers/Save?key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
        public async Task<HttpResponseMessage> Savefee(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                res = await httpClient.PostAsJsonAsync("api/VoucherAllocationManagers/Savefees?key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
        public async Task<HttpResponseMessage> Updatestatement(dtStudentStatement value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                res = await httpClient.PostAsJsonAsync("api/VoucherAllocationManagers/Update?key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }


    }
}
