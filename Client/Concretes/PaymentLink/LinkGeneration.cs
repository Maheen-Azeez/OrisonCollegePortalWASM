using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.PaymentLink;
using OrisonCollegePortal.Shared.Entities.PaymentLink;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.PaymentLink
{
    public class LinkGeneration : ILinkGeneration
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public LinkGeneration(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<IEnumerable<NexopayPurpose>?> GetPurpose()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("Master_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<NexopayPurpose>>("api/LinkGeneration/GetPurpose?Key=" + key);
        }
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentListByClass(string Class, string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/LinkGeneration/StudentListByClass?Class=" + Class + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<StudentData>?> GetStudentData(int AccountID, string SchoolCode)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<StudentData>>("api/LinkGeneration/GetStudentData?AccountID=" + AccountID + "&SchoolCode=" + SchoolCode + "&Key=" + key);
        }
        public async Task<HttpResponseMessage> SavePaymentRequest(Models.OrderRequest value, string SchoolCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/LinkGeneration/SavePaymentRequest?SchoolCode=" + SchoolCode + "&Key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
    }
}
