using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    

    public class InvoiceRegisterManager : IInvoiceRegisterManager
    {
        HttpClient httpClient = new HttpClient();

        private string? key;

        private readonly ISessionStorageService SessionStorage;
        public InvoiceRegisterManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public async Task<List<dtInvoiceRegister>?> GetInvoice(string AcademicYear, int BranchID, string fromdate, string todate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<dtInvoiceRegister>>( "api/InvoiceRegister/GetInvoice?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);
        }

        public async Task<List<dtAdvanceReceiptRegister>?> Getadvance(string AcademicYear, int BranchID, string fromdate, string todate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<dtAdvanceReceiptRegister>>("api/InvoiceRegister/Getadvance?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);
        }
        public async Task<List<dtInvoiceRegister>?> GetInvoices(string AcademicYear, int BranchID, string fromdate, string todate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<dtInvoiceRegister>>("api/InvoiceRegister/GetInvoices?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);
        }
        async Task<bool> IInvoiceRegisterManager.collectedtax(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string CmbAccYear)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                await httpClient.GetAsync("api/InvoiceRegister/collectiontax?BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&invdate=" + invdate + "&UserID=" + UserID + "&AccountID=" + AccountID + "&CmbAccYear=" + CmbAccYear + "&key=" + key);
                return true;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        async Task<bool> IInvoiceRegisterManager.collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                await httpClient.GetAsync("api/InvoiceRegister/collection?BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&invdate=" + invdate + "&UserID=" + UserID + "&AccountID=" + AccountID + "&key=" + key);
                return true;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
        }

        public async Task<HttpResponseMessage> post(dtInvoiceRegister value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                res = await httpClient.PostAsJsonAsync("api/InvoiceRegister/posts?key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
    }
}
