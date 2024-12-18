using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using Syncfusion.Blazor.Diagrams;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class PostingManager : IPostingManager
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        int vtype, feeexist, AccID, allocexist;
        public PostingManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
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

        public async Task<HttpResponseMessage> CreatePostingVoucher(dtsVoucher Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/post?key=" + key, Voucher);

        }
        public async Task<HttpResponseMessage> DeletePostingVoucher(dtsVoucher Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/depost?key=" + key, Voucher);

        }
        public async Task<HttpResponseMessage> DeletePostingVoucherClass(dtsVoucher Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/depostclass?key=" + key, Voucher);

        }

        public async Task<List<SchoolTaxInvoicedt>?> Getdatas(int BranchID, string AcademicYear, int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<SchoolTaxInvoicedt>>("api/Posting/Getdatas?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&AccountID=" + AccountID + "&key=" + key);
        }
        public async Task<List<SchoolTaxInvoicedt>?> Getdatass(int BranchID, string AcademicYear, int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<SchoolTaxInvoicedt>>("api/Posting/Getdatass?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&AccountID=" + AccountID + "&key=" + key);
        }
        async Task<HttpResponseMessage> IPostingManager.Postallindividual(int AccountID, int BranchID, string Criteria, string CmbAccYear, string StatementFromDate, string StatementEndDate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            try
            {
                return await httpClient.GetAsync("api/Posting/Postallindividual?AccountID=" + AccountID + "&BranchID=" + BranchID + "&Criteria=" + Criteria + "&CmbAccYear=" + CmbAccYear + "&StatementFromDate=" + StatementFromDate + "&StatementEndDate=" + StatementEndDate + "&key=" + key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
               
            }
        }
        async Task<HttpResponseMessage> IPostingManager.Invoicegeneration(int AccountID, int BranchID, string CmbAccYear, string Taxvoicedate, string StatementFromDate, string StatementEndDate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            try
            {
                return await httpClient.GetAsync("api/Posting/Invoicegeneration?AccountID=" + AccountID + "&BranchID=" + BranchID + "&CmbAccYear=" + CmbAccYear + "&Taxvoicedate=" + Taxvoicedate + "&StatementFromDate=" + StatementFromDate + "&StatementEndDate=" + StatementEndDate + "&key=" + key);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<IEnumerable<AdditionalSchedule>?> GetAdditionalSchedules(int BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<AdditionalSchedule>>("api/Posting/AdditionalSchedule?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&key=" + key);
        }
        public async Task<int> GetVtype(string FeeType)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            vtype = await httpClient.GetFromJsonAsync<int>("api/Posting/vtype?FeeType=" + FeeType + "&key=" + key);
            return vtype;
        }
        public async Task<int> getUniqueAccID(string Value)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            AccID = await httpClient.GetFromJsonAsync<int>("api/Posting/keyword?Value=" + Value + "&key=" + key);
            return AccID;
        }
        public async Task<int> FeePostChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string FeeSchedule)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            feeexist = await httpClient.GetFromJsonAsync<int>("api/Posting/feexist?AccountId=" + AccountId + "&vtype=" + vtype + "&fromdate=" + fromdate + "&todate=" + todate + "&type=" + Type + "&FeeSchedule=" + FeeSchedule + "&key=" + key);
            return feeexist;
        }

        public async Task<int> FeeAllocChecking(int AccountId, int vtype, string fromdate, string todate, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            allocexist = await httpClient.GetFromJsonAsync<int>("api/Posting/allocexist?AccountId=" + AccountId + "&vtype=" + vtype + "&fromdate=" + fromdate + "&todate=" + todate + "&type=" + Type + "&key=" + key);
            return allocexist;
        }
        public async Task<int> FeeAllocCheckingClassWise(string Class, int vtype, string fromdate, string todate, string Type, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            allocexist = await httpClient.GetFromJsonAsync<int>("api/Posting/allocexistclass?Class=" + Class + "&vtype=" + vtype + "&fromdate=" + fromdate + "&todate=" + todate + "&type=" + Type + "&AcademicYear=" + AcademicYear + "&key=" + key);
            return allocexist;
        }
        public async Task<IEnumerable<dtFeeSchedule>?> GetFeeSchedule(string AcademicYear, int BranchID, String Code, string fromdate, string todate, string Type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<dtFeeSchedule>>("api/Posting/FeeSchedule?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Code=" + Code + "&fromdate=" + fromdate + "&todate=" + todate + "&Type=" + Type + "&key=" + key);

        }
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentsDetails(string AcademicYear, int BranchID, string Class, string Type, string fromdate, string todate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));


            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Posting/Students?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Class=" + Class + "&Type=" + Type + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);

        }
        public async Task<dtFeeSchedule?> GetAddFees(int FeeId, string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<dtFeeSchedule>("api/Posting/AddFees?FeeId=" + FeeId + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&key=" + key);

        }
        public async Task<IEnumerable<dtAdditionalFee>?> GetAdditionalFee(string AcademicYear, string Type, int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));


            return await httpClient.GetFromJsonAsync<IEnumerable<dtAdditionalFee>>("api/Posting/AdditionalFee?AcademicYear=" + AcademicYear + "&Type=" + Type + "&BranchID=" + BranchID + "&key=" + key);

        }
        public async Task<dtStudentFeeSummary?> GetFeeSummary(int AccountId, int? BranchID, String AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<dtStudentFeeSummary>("api/Posting/FeeSummary?AccountId=" + AccountId + "&BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }


        public async Task<HttpResponseMessage> PostBulkData(dtPostClass Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/BulkData?key=" + key, Voucher);

        }
        public async Task<HttpResponseMessage> poststudentdata(dtPostClass Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/poststudentdata?key=" + key, Voucher);
        }
        public async Task<HttpResponseMessage> PostUnallocateData(dtPostClass Voucher)

        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/UnallocateData?key=" + key, Voucher);
        }
        public async Task<HttpResponseMessage> postallbulkdata(dtPostClass Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/postallbulkdata?key=" + key, Voucher);
        }
        public async Task<IEnumerable<dtStudentFeeDetails>?> GetFeeDetails(int AccountId, int BranchID, String AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentFeeDetails>>("api/Posting/FeeDetails?AccountId=" + AccountId + "&BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&key=" + key);
        }
        public async Task<IEnumerable<dtDiscountSchedule>?> GetDiscountSchedule(int BranchID, String Schedule)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<IEnumerable<dtDiscountSchedule>>("api/Posting/DiscountSchedule?BranchID=" + BranchID + "&Schedule=" + Schedule + "&key=" + key);
        }

        //Update FeeAmount
        public async Task<HttpResponseMessage> UpdateFeeAmount(dtsVoucher value)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync("api/Posting/UpdateFeeAmount?key=" + key, value);

            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> DeleteFeeAmount(int ID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            var result = await httpClient.DeleteAsync("api/Posting/DeleteFeeAmount?ID=" + ID + "&key=" + key);
            return result;
        }
        //
        //Additional Fee
        public async Task<HttpResponseMessage> SaveAdditionalFee(SchoolAdditionalPayment AdFee)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/AddAdditionalFee?key=" + key, AdFee);
        }
        public async Task<HttpResponseMessage> UpdateAdditionalFee(SchoolAdditionalPayment fee)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync("api/Posting/updateAdditionalFee?key=" + key, fee);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<List<SchoolTaxInvoicedt>?> GetSchoolTaxInvoice(string AcademicYear, int ID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<SchoolTaxInvoicedt>>("api/Posting/Gets?AcademicYear=" + AcademicYear + "&ID=" + ID + "&key=" + key);
        }

        public async Task<HttpResponseMessage> UpdateCollection(SchoolTaxInvoicedt Collected)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync("api/Posting/GenerateCollected?key=" + key, Collected);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateInvoice(SchoolTaxInvoicedt Invoice)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync("api/Posting/GenerateInvoices?key=" + key, Invoice);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<List<dtBulkPost>?> GetMassPosting(int BranchID, string AcademicYear, string FromDate, string ToDate, string Schedule)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.GetFromJsonAsync<List<dtBulkPost>>("api/Posting/GetMassPost?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&Schedule=" + Schedule + "&Type=GetMassPosting" + "&key=" + key);
        }

        public async Task<HttpResponseMessage> BulkPostAll(dtsVoucher Voucher)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            return await httpClient.PostAsJsonAsync("api/Posting/BulkPostAll?key=" + key, Voucher);

        }
        async Task<HttpResponseMessage> IPostingManager.Bulkpost(int UserID, int BranchID, string Type, string Class, string CmbAccYear, string FromDate, string ToDate)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));

            try
            {
                return await httpClient.GetAsync("api/Posting/Bulkpost?UserID=" + UserID + "&BranchID=" + BranchID + "&Type=" + Type + "&Class=" + Class + "&CmbAccYear=" + CmbAccYear + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&key=" + key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
