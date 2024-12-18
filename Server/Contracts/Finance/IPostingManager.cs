using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IPostingManager
    {
        Task<long>? CreatePostingVoucher(dtsVoucher Voucher, string key);
        Task<long>? DeletePostingVoucher(dtsVoucher Voucher, string key);
        public Task<long>? Postallindividual(int AccountID, int BranchID, string Criteria, string CmbAccYear, string StatementFromDate, string StatementEndDate, string key);
        public Task<long>? Bulkpost(int UserID, int BranchID, string Type, string Class, string CmbAccYear, string FromDate, string ToDate, string key);

        Task<long>? poststudentdata(dtPostClass Voucher, string key);

        public Task<long>? Invoicegeneration(int AccountID, int BranchID, string CmbAccYear, string Taxvoicedate, string StatementFromDate, string StatementEndDate, string key);
        Task<List<SchoolTaxInvoicedt>?> Getdatas(int BranchID, string AcademicYear, int AccountID, string key);
        Task<List<SchoolTaxInvoicedt>?> Getdatass(int BranchID, string AcademicYear, int AccountID, string key);


        Task<int>? GetVtype(string vtype, string key);
        Task<int>? getUniqueAccID(string Value, string key);
        Task<int>? FeePostChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string FeeSchedule, string key);
        Task<int>? FeeAllocChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string key);
        Task<int>? FeeAllocCheckingClassWise(string Class, int vtype, string fromdate, string todate, string Type, string AcademicYear, string key);
        Task<List<dtFeeSchedule>?> GetFeeSchedule(string AcademicYear, int BranchID, String Code, string fromdate, string todate, string Type, string key);
        Task<dtFeeSchedule>? GetAddFees(int FeeId, string AcademicYear, int BranchID, string key);
        Task<List<dtStudentRegister>?> GetStudentsDetails(string AcademicYear, int BranchID, string Class, string Type, string fromdate, string todate, string key);
        Task<List<AdditionalSchedule>?> GetAdditionalSchedules(int BranchID, string AcademicYear, string key);
        Task<List<dtAdditionalFee>?> GetAdditionalFee(string AcademicYear, string Type, int BranchID, string key);

        Task<List<SchoolDiscountSchedule>?> GetDiscountSchedule(int BranchID, String Schedule, string key);
        Task<dtStudentFeeSummary>? GetFeeSummary(int AccountId, int BranchID, String AcademicYear, string key);
        Task<List<dtStudentFeeDetails>?> GetFeeDetails(int AccountId, int BranchID, String AcademicYear, string key);
        //Update FeeAmount
        public void UpdateFeeAmount(dtsVoucher vo, string key);
        public Task<bool>? DeleteFeeAmount(int ID, string key);
        //
        //save AdditionalFee
        Task<long> CreateAdditionalFee(SchoolAdditionalPayment dt, string key);
        void UpdateAdditionalFee(SchoolAdditionalPayment masterMisc, string key);
        //
        //TaxInvoice
        public Task<List<SchoolTaxInvoicedt>?> GetSchoolTaxInvoice(string AcademicYear, int ID, string key);
        public void UpdateCollection(SchoolTaxInvoicedt Collected, string key);
        public void UpdateInvoice(SchoolTaxInvoicedt Invoice, string key);
        Task<long>? PostBulkData(dtPostClass Voucher, string key);

        Task<long>? postallbulkdata(dtPostClass Voucher, string key);

        Task<long>? PostUnallocateData(dtPostClass Voucher, string key);

        //MassPosting
        public Task<List<dtBulkPost>?> GetMassPosting(int BranchID, string AcademicYear, string FromDate, string ToDate, string Schedule, string key);
        public Task<long>? MassDepost(dtsVoucher v, string key);
        Task<long>? BulkPostAll(dtsVoucher Voucher, string key);
    }
}
