using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    
        public class SchoolTaxInvoiceManager : ISchoolTaxInvoiceManager
        {
            HttpClient httpClient = new HttpClient();

            private string? key;

            private readonly ISessionStorageService SessionStorage;
            public SchoolTaxInvoiceManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
            {
                this.httpClient = httpClient;
                this.SessionStorage = _SessionStorage;
            }

        public async Task<List<SchoolTaxInvoicedt>?> GetSchoolTaxInvoice(string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            //return await httpClient.GetFromJsonAsync<List<SchoolTaxInvoicedt>>(BaseUrl + "SchoolTaxInvoiceManager/Gets?AcademicYear=" + AcademicYear + "&Con=" + Con);
            return await httpClient.GetFromJsonAsync<List<SchoolTaxInvoicedt>>( "api/SchoolTaxInvoiceManager/Gets?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&key=" + key);
        }

        public async Task<List<SchoolTaxInvoicedt>?> get(int id, string AcademicYear,int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<SchoolTaxInvoicedt>>("api/SchoolTaxInvoiceManager/get?id=" + id + "&AcademicYear=" + AcademicYear+ "&BranchID=" + BranchID + "&key=" + key);
        }

        public async Task<SchoolTaxInvoicedt>? Getdata(string AcademicYear, int id)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

                var Student = await httpClient.GetFromJsonAsync<SchoolTaxInvoicedt>("api/SchoolTaxInvoiceManager/Getdatas?AcademicYear=" + AcademicYear + "&id=" + id + "&key=" + key);
                return Student!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;

            }
        }

        public async Task<IEnumerable<SchoolMailTemplate>?> GetMailTemplate(string Type, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolMailTemplate>>("api/DB/MailTemplate?Type=" + Type + "&BranchID=" + BranchID + "&key=" + key);
        }

        public async Task<List<dtStudentStatement>?> GetTaxInvoiceStatement(string AccountCode, string AcademicYear, string StartDate, string EndDate, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<dtStudentStatement>>("api/SchoolTaxInvoiceManager/TaxInvoiceStatement?AccountCode=" + AccountCode + "&AcademicYear=" + AcademicYear + "&StartDate=" + StartDate + "&EndDate=" + EndDate + "&BranchID=" + BranchID + "&key=" + key);
        }
    }
}




