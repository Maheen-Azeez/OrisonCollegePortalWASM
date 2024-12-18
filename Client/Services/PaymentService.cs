using Blazored.SessionStorage;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Services
{
    public class PaymentService
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public PaymentService(HttpClient _httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = _httpClient;
            this.SessionStorage = _SessionStorage;
        }

        public async Task<string> webRequestCreate(string? ApiUrl, string ApiKey, string jsonContent)
        {
            try
            {
                key = await SessionStorage.GetItemAsync<string>("token_key");
                HttpResponseMessage response;
                response = await httpClient.GetAsync("API/LinkGeneration/WebRequest?ApiUrl=" + ApiUrl + "&ApiKey=" + ApiKey + "&jsonContent=" + HttpUtility.UrlEncode(jsonContent));
                string VID = "";
                var data = await response.Content.ReadFromJsonAsync<dtError>();
                VID = data!.Result!;
                return VID;
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
