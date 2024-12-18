using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IFeePostingManager
    {
        Task<List<CollegeClass>> GetFee(string AcademicYear, int BranchID,string Key);
        Task<List<CollegeClass>> GetTransport(string AcademicYear, int BranchID, string Key);
        Task<List<CollegeClass>> GetAdmission(string AcademicYear, int BranchID, string Key);
        Task<List<CollegeClass>> GetFeeDiscount(int BranchID, string Key);
        Task<List<CollegeClass>> GetOtherFee(string AcademicYear, int BranchID, string Key);

        Task<int> GetVtype(string vtype, string Key);
        Task<int> getUniqueAccID(string Value, string Key);
        Task<int> FeePostChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Remark, string Key);
        Task<int> FeeDiscountChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Remark, string Key);
        Task<List<dtFeeSchedule>> GetFeeSchedule(string AcademicYear, int BranchID, String Code, DateTime fromdate, DateTime todate, string Type, string Key);
        Task<List<dtDiscountSchedule>> GetDiscountSchedule(int BranchID, String Schedule, string Key);
        Task<long> CreatePostingVoucher(dtsVoucher Voucher, string Key);
        Task<long> PostingDiscount(dtsVoucher Voucher, string Key);
        Task<dtStudentFeeSummary> GetFeeSummary(int AccountId, int BranchID, String AcademicYear, string Key);
        Task<List<dtStudentFeeDetails>> GetFeeDetails(int AccountId, int BranchID, String AcademicYear, string Key);
        Task<List<dtStudentStatement>> GetStatement(int BranchID, int AccountID, DateTime SDate, DateTime EDate, string Key);
        Task<int> FeeAllocChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Key);
        Task<long> DeletePostingVoucher(dtsVoucher Voucher, string Key);
    }
}
