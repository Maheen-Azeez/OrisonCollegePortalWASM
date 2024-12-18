using Syncfusion.Blazor.Diagrams;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using Blazored.SessionStorage;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Client.Services
{
    public class SendMailService
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public SendMailService(HttpClient _httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = _httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<int> SendEmail(DtoEmailSettings EmailDetails)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("API/SendMail/EmailSending", EmailDetails);
                var data = await res.Content.ReadFromJsonAsync<dtError>();
                var send = Convert.ToInt32(data!.ID);
                return send;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return 0;
            }
        }

        public async Task<int> AWSSendMail(DtoEmailSettings EmailDetails)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("API/SendMail/AWSSendEmail", EmailDetails);
                var data = await res.Content.ReadFromJsonAsync<dtError>();
                var send = Convert.ToInt32(data!.ID);
                return send;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return 0;
            }
        }
    }
}
