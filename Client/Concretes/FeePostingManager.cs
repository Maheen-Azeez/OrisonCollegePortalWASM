using OrisonCollegePortal.Client.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Net.Http.Json;
using Blazored.SessionStorage;
using System.Web;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Concretes
{
    public class FeePostingManager : IFeePostingManager
    {
        private readonly HttpClient _HttpClient;
        int vtype, AccID, feeexist, allocexist;
        private string? key;
        private readonly ISessionStorageService SessionStorage;

        public FeePostingManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            _HttpClient = httpClient;
            this.SessionStorage = _SessionStorage;

        }
        
        public async Task<HttpResponseMessage> CreatePostingVoucher(dtsVoucher Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await _HttpClient.PostAsJsonAsync("api/FeePosting/post?Key=" + key, Voucher);
        }

        public async Task<HttpResponseMessage> DeletePostingVoucher(dtsVoucher Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await _HttpClient.PostAsJsonAsync("api/FeePosting/depost?Key=" + key, Voucher);
        }

        public async Task<int> FeeAllocChecking(int AccountId, int vtype, string fromdate, string todate, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            allocexist = await _HttpClient.GetFromJsonAsync<int>("api/FeePosting/allocexist?AccountId=" + AccountId + "&vtype=" + vtype + "&fromdate=" + fromdate + "&todate=" + todate + "&type=" + Type + "&Key=" + key);
            return allocexist;
        }

        public async Task<int> FeePostChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string Remark)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            feeexist = await _HttpClient.GetFromJsonAsync<int>("api/FeePosting/feexist?AccountId=" + AccountId + "&vtype=" + vtype + "&fromdate=" + fromdate + "&todate=" + todate + "&type=" + Type + "&Remark=" + Remark + "&Key=" + key);
            return feeexist;
        }
        public async Task<int> FeeDiscountChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string Remark)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            feeexist = await _HttpClient.GetFromJsonAsync<int>("api/FeePosting/Discountexist?AccountId=" + AccountId + "&vtype=" + vtype + "&fromdate=" + fromdate + "&todate=" + todate + "&type=" + Type + "&Remark=" + Remark + "&Key=" + key);
            return feeexist;
        }
        public async Task<IEnumerable<CollegeClass>> GetOtherFee(string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key")?? "");
            var result=await _HttpClient.GetFromJsonAsync<IEnumerable<CollegeClass>>("api/FeePosting/OtherFee?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return result ?? Enumerable.Empty<CollegeClass>();
        }
        public async Task<IEnumerable<CollegeClass>> GetAdmission(string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result = await _HttpClient.GetFromJsonAsync<IEnumerable<CollegeClass>>("api/FeePosting/Admission?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return result ?? Enumerable.Empty<CollegeClass>();
        }
        public async Task<IEnumerable<CollegeClass>> GetFeeDiscount(int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result = await _HttpClient.GetFromJsonAsync<IEnumerable<CollegeClass>>("api/FeePosting/FeeDiscount?BranchID=" + BranchID + "&Key=" + key);
            return result ?? Enumerable.Empty<CollegeClass>();
        }
       
        public async Task<IEnumerable<CollegeClass>> GetFee(string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result= await _HttpClient.GetFromJsonAsync<IEnumerable<CollegeClass>>("api/FeePosting/Fee?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return result ?? Enumerable.Empty<CollegeClass>();
        }
        public async Task<IEnumerable<CollegeClass>> GetTransport(string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result= await _HttpClient.GetFromJsonAsync<IEnumerable<CollegeClass>>("api/FeePosting/Transport?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return result ?? Enumerable.Empty<CollegeClass>();
        }
        public async Task<IEnumerable<dtStudentFeeDetails>> GetFeeDetails(int AccountId, int BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result= await _HttpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeDetails>>("api/FeePosting/FeeDetails?AccountId=" + AccountId + "&BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
            return result ?? Enumerable.Empty<dtStudentFeeDetails>();
        }

       

        public async Task<IEnumerable<dtFeeSchedule>> GetFeeSchedule(string AcademicYear, int BranchID, string Code, string fromdate, string todate, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result= await _HttpClient.GetFromJsonAsync<IEnumerable<dtFeeSchedule>>("api/FeePosting/FeeSchedule?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Code=" + Code + "&fromdate=" + fromdate + "&todate=" + todate + "&Type=" + Type + "&Key=" + key);
            return result ?? Enumerable.Empty<dtFeeSchedule>();
        }

        public async Task<dtStudentFeeSummary> GetFeeSummary(int AccountId, int BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result= await _HttpClient.GetFromJsonAsync<dtStudentFeeSummary>("api/FeePosting/FeeSummary?AccountId=" + AccountId + "&BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
            return result;
        }
        public async Task<IEnumerable<dtDiscountSchedule>> GetDiscountSchedule(int BranchID, string Schedule)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var result= await _HttpClient.GetFromJsonAsync<IEnumerable<dtDiscountSchedule>>("api/FeePosting/DiscountSchedule?BranchID=" + BranchID + "&Schedule=" + Schedule + "&Key=" + key);
            return result ?? Enumerable.Empty<dtDiscountSchedule>();
        }

        public async Task<IEnumerable<dtStudentStatement>> GetStatement(int BranchID, int AccountID, string SDate, string EDate)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var Statement = await _HttpClient.GetFromJsonAsync<IEnumerable<dtStudentStatement>>("api/FeePosting/StudentStatement?BranchID=" + BranchID + "&AccountID=" + AccountID + "&SDate=" + SDate + "&EDate=" + EDate + "&Key=" + key);
                return Statement ?? Enumerable.Empty<dtStudentStatement>();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        

        public async Task<int> getUniqueAccID(string Value)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            AccID = await _HttpClient.GetFromJsonAsync<int>("api/FeePosting/keyword?Value=" + Value + "&Key=" + key);
            return AccID;
        }

        public async Task<int> GetVtype(string FeeType)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            vtype = await _HttpClient.GetFromJsonAsync<int>("api/FeePosting/vtype?FeeType=" + FeeType + "&Key=" + key );
            return vtype;
        }

        public async Task<HttpResponseMessage> PostingDiscountVoucher(dtsVoucher Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await _HttpClient.PostAsJsonAsync("api/FeePosting/postDiscount?Key=" + key, Voucher);
        }
    }
}
