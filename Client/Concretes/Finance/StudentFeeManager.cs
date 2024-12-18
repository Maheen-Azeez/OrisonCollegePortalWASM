using Blazored.SessionStorage;
using Newtonsoft.Json;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Dynamic;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class StudentFeeManager : IStudentFeeManager
    {
        private string? key;
        HttpClient httpClient = new HttpClient();  
        private readonly ISessionStorageService SessionStorage;
        public StudentFeeManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
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
        public async Task<IEnumerable<dtStudentFeeRegister>?> GetStudentFeeRegister(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeRegister>>("api/StudentFee?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&Type=" + Type + "&key=" + key);
        }
        //newly added feewise--student parent
        public async Task<IEnumerable<dtStudentFeeRegister>?> GetParentStudentFeeWise(string AcademicYear, int BranchID, string Criteria, int AccountId, string FromDate, string ToDate, string Status)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeRegister>>("api/StudentFee/ParentStudentFeeWise?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Criteria=" + Criteria + "&AccountId=" + AccountId + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&key=" + key);
        }

        public async Task<IEnumerable<dtfeewiseregister>?> GetFeeWiseRegister(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));


            return await httpClient.GetFromJsonAsync<IEnumerable<dtfeewiseregister>>("api/StudentFee/FeeWise?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&Type=" + Type + "&key=" + key);
        }

        public async Task<IEnumerable<dtfeewiseregister>?> GetFeeWiseRegisterbyclassanddivision(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type,string cls,string div,string des)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));


            return await httpClient.GetFromJsonAsync<IEnumerable<dtfeewiseregister>>("api/StudentFee/FeeWiseclass?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&Type=" + Type +"&cls=" + cls + "&div=" + div+"&des=" + des + "&key=" + key);
        }
        public async Task<IEnumerable<dtStudentFeeRegister>?> GetTermFeeRegister(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));


            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeRegister>>("api/StudentFee/TermWise?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&Type=" + Type + "&key=" + key);
        }
        public async Task<IEnumerable<dtStudentFeeRegister>?> GetParentFee(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));


            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeRegister>>("api/StudentFee/ParentFees?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&Type=" + Type + "&key=" + key);
        }
        public async Task<IEnumerable<dtStudentFeeRegister>?> GetFeeConflict(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeRegister>>("api/StudentFee/FeeConflict?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&Type=" + Type + "&key=" + key);
        }
        public async Task<IEnumerable<SchoolAcademicYear>?> GetAcademicYear(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolAcademicYear>>("api/DB?BranchID=" + BranchID + "&key=" + key);

        }
        public async Task<IEnumerable<dtStudentFeeRegister>?> GetStudentFeeRegisterAll(string AcademicYear, int BranchID, string FromDate, string ToDate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeRegister>>("api/StudentFee/StudentAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&key=" + key);

        }



        public async Task<IEnumerable<SchoolMailTemplate>?> GetMailTemplate(string Type, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolMailTemplate>>("api/DB/MailTemplate?Type=" + Type + "&BranchID=" + BranchID + "&key=" + key);
        }

        public async Task<string> GetSMSTemplate(int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            var code = await httpClient.GetStringAsync("api/DB/SMSTemplate?BranchID=" + BranchID + "&key=" + key);
            return code;
        }
        public async Task<HttpResponseMessage> DeleteVoucher(int VID, int bvid)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.DeleteAsync("api/StudentFee/DeleteVoucher?VID=" + VID + "&bvid=" + bvid + "&key=" + key);
        }
        public async Task<HttpResponseMessage> DeleteAllVoucherallocation(int AccountID, string Dates)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.DeleteAsync("api/StudentFee/DeleteAllVoucherallocation?AccountID=" + AccountID + "&Dates=" + Dates + "&key=" + key);
        }
        public async Task<IEnumerable<ExpandoObject>?> GetStudentFeeRegisters(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            try
            {
                List<ExpandoObject?> Result = new List<ExpandoObject?>();
                var report = await httpClient.GetFromJsonAsync<List<object>>("api/StudentFee/Feedetails?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Status=" + Status + "&Type=" + Type + "&key=" + key);
                foreach (var d in report!)
                {
                    Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(d.ToString()!));
                }
                return Result!;

            }
            catch (Exception e)
            {

                throw e;


            }
        }


    }
}
