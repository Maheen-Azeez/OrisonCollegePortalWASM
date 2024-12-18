using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IPostingManager
    {
        Task<HttpResponseMessage> CreatePostingVoucher(dtsVoucher Voucher);
        Task<HttpResponseMessage> DeletePostingVoucher(dtsVoucher Voucher);

        Task<HttpResponseMessage> Postallindividual(int AccountID, int BranchID, string Criteria, string CmbAccYear, string StatementFromDate, string StatementEndDate);
        Task<HttpResponseMessage> Invoicegeneration(int AccountID, int BranchID, string CmbAccYear, string Taxvoicedate, string StatementFromDate, string StatementEndDate);

        Task<HttpResponseMessage> DeletePostingVoucherClass(dtsVoucher Voucher);
        public Task<int> GetVtype(string FeeType);
        public Task<int> getUniqueAccID(string Value);
        public Task<List<SchoolTaxInvoicedt>?> Getdatas(int BranchID, string AcademicYear, int AccountID);
        public Task<List<SchoolTaxInvoicedt>?> Getdatass(int BranchID, string AcademicYear, int AccountID);

        public Task<int> FeePostChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string FeeSchedule);
        public Task<int> FeeAllocChecking(int AccountId, int vtype, string fromdate, string todate, string Type);
        public Task<int> FeeAllocCheckingClassWise(string Class, int vtype, string fromdate, string todate, string Type, string AcademicYear);

        public Task<IEnumerable<dtFeeSchedule>?> GetFeeSchedule(string AcademicYear, int BranchID, String Code, string fromdate, string todate, string Type);

        public Task<IEnumerable<dtStudentRegister>?> GetStudentsDetails(string AcademicYear, int BranchID, string Class, string Type, string fromdate, string todate);

        public Task<dtFeeSchedule?> GetAddFees(int FeeId, string AcademicYear, int BranchID);

        public Task<IEnumerable<dtAdditionalFee>?> GetAdditionalFee(string AcademicYear, string Type, int BranchID);

        public Task<IEnumerable<dtDiscountSchedule>?> GetDiscountSchedule(int BranchID, String Schedule);

        public Task<dtStudentFeeSummary?> GetFeeSummary(int AccountId, int? BranchID, String AcademicYear);

        public Task<IEnumerable<dtStudentFeeDetails>?> GetFeeDetails(int AccountId, int BranchID, String AcademicYear);

        public Task<IEnumerable<AdditionalSchedule>?> GetAdditionalSchedules(int BranchID, string AcademicYear);

        //Update FeeAmount
        public Task<HttpResponseMessage> UpdateFeeAmount(dtsVoucher value);
        Task<HttpResponseMessage> DeleteFeeAmount(int ID);
        //
        //Additional Fee
        public Task<HttpResponseMessage> SaveAdditionalFee(SchoolAdditionalPayment AdFee);
        public Task<HttpResponseMessage> UpdateAdditionalFee(SchoolAdditionalPayment masterMisc);
        //
        //TaxInvoice
        public Task<List<SchoolTaxInvoicedt>?> GetSchoolTaxInvoice(string AcademicYear, int ID);
        public Task<HttpResponseMessage> UpdateCollection(SchoolTaxInvoicedt Collected);
        public Task<HttpResponseMessage> UpdateInvoice(SchoolTaxInvoicedt Invoice);
        public Task<HttpResponseMessage> PostBulkData(dtPostClass Voucher);
        public Task<HttpResponseMessage> PostUnallocateData(dtPostClass Voucher);
        //Mass Posting
        public Task<List<dtBulkPost>?> GetMassPosting(int BranchID, string AcademicYear, string FromDate, string ToDate, string Schedule);
        Task<HttpResponseMessage> BulkPostAll(dtsVoucher Voucher);

        Task<HttpResponseMessage> Bulkpost(int UserID, int BranchID, string Type, string Class, string CmbAccYear, string FromDate, string ToDate);

        public Task<HttpResponseMessage> postallbulkdata(dtPostClass Voucher);
        public Task<HttpResponseMessage> poststudentdata(dtPostClass Voucher);

    }
}