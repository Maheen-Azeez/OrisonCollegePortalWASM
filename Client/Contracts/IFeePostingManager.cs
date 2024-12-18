using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts
{
    public interface IFeePostingManager
  {
        public Task<IEnumerable<CollegeClass>> GetFee(string AcademicYear, int BranchID);
        public Task<IEnumerable<CollegeClass>> GetTransport(string AcademicYear, int BranchID);
        public Task<IEnumerable<CollegeClass>> GetAdmission(string AcademicYear, int BranchID);
        public Task<IEnumerable<CollegeClass>> GetFeeDiscount(int BranchID);
        public Task<IEnumerable<CollegeClass>> GetOtherFee(string AcademicYear, int BranchID);
        public Task<int> GetVtype(string FeeType);
        public Task<int> getUniqueAccID(string Value);
        public Task<int> FeePostChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string Remark);
        public Task<int> FeeDiscountChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string Remark);
        public Task<IEnumerable<dtFeeSchedule>> GetFeeSchedule(string AcademicYear, int BranchID, String Code, string fromdate, string todate, string Type);
        public Task<IEnumerable<dtDiscountSchedule>> GetDiscountSchedule(int BranchID, String Schedule);
        Task<HttpResponseMessage> CreatePostingVoucher(dtsVoucher Voucher);
        Task<HttpResponseMessage> PostingDiscountVoucher(dtsVoucher Voucher);
        public Task<dtStudentFeeSummary> GetFeeSummary(int AccountId, int BranchID, String AcademicYear);
        public Task<IEnumerable<dtStudentFeeDetails>> GetFeeDetails(int AccountId, int BranchID, String AcademicYear );
        public Task<int> FeeAllocChecking(int AccountId, int vtype, string fromdate, string todate, string Type );
        Task<HttpResponseMessage> DeletePostingVoucher(dtsVoucher Voucher);
        public Task<IEnumerable<dtStudentStatement>> GetStatement(int BranchID, int AccountID, string SDate, string EDate);
    }
}
