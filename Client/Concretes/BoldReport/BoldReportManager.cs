using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.BoldReport;
using OrisonCollegePortal.Shared.Entities.BoldReport;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using Syncfusion.Blazor.Diagrams;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.BoldReport
{
    public class BoldReportManager : IBoldReportManager
    {
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        private string? key;
        public BoldReportManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
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
        public async Task<MemoryStream> GetReport(DataSource Value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                Value.Con = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("API/BoldReport/GetReport", Value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            var ms = new MemoryStream();
            res.Content.CopyToAsync(ms).Wait();
            return res.IsSuccessStatusCode ? ms : null!;
        }
        public async Task<List<DtoReceiptPrint>?> GetFeeRecieptByID(long? VID, int? ONO, string? AccYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoReceiptPrint>?>("API/BoldReport/GetFeeRecieptByID?VID=" + VID + "&AccYear=" + AccYear + "&ONO=" + ONO + "&BranchID=" + BranchID + "&Key=" + key);

        }

        public Task<List<DtoReceiptPrint>?> GetFeeRecieptNoAllocPreReg(long? VID, int? ONO, string? AccYear, int? BranchID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DtoReceiptPrint>?> GetFeeRecieptPreReg(long? VID, int? ONO, string? AccYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoReceiptPrint>?>("API/BoldReport/BoldReport/GetFeeRecieptNoAllocPreReg?VID=" + VID + "&AccYear=" + AccYear + "&ONO=" + ONO + "&BranchID=" + BranchID + "&Key=" + key);

        }

        public async Task<List<DtoReceiptPrint>?> GetFeeRecieptReReg(long? VID, int? ONO, string? AccYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoReceiptPrint>?>("API/BoldReport/GetFeeRecieptReReg?VID=" + VID + "&AccYear=" + AccYear + "&ONO=" + ONO + "&BranchID=" + BranchID + "&Key=" + key);

        }

        public async Task<List<DtoReceiptPrint>?> GetFeeVtype(long? VID, int? BranchID, string? Criteria)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoReceiptPrint>?>("API/BoldReport/GetVtype?VID=" + VID + "&BranchID=" + BranchID + "&Key=" + key + "&Criteria=" + Criteria);

        }

        public async Task<int> SendEmail(DtoEmail EmailDetails)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("API/BoldReport/EmailDetail", EmailDetails);
                var data = await res.Content.ReadFromJsonAsync<DtoResultID>();
                var send = Convert.ToInt32(data!.ID);
                return send;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return 0; }
        }

        public async Task<List<DtoReceiptPrint>?> MerrylandGetFeeRecieptByID(long? VID, string? AccYear, int? ONO)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoReceiptPrint>?>("API/BoldReport/MerrylandGetFeeRecieptByID?VID=" + VID + "&ONO =" + ONO + "&AccYear=" + AccYear + "&Key=" + key);

        }

        public async Task<List<DtoReceiptPrint>?> GetFeeRecieptAcc(long? VID, int? ONO, string? AccYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<DtoReceiptPrint>?>("API/BoldReport/GetFeeRecieptAcc?VID=" + VID + "&AccYear=" + AccYear + "&ONO=" + ONO + "&BranchID=" + BranchID + "&Key=" + key);

        }
    }
}