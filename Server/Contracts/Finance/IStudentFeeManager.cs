using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IStudentFeeManager
    {

        Task<List<dtStudentFeeRegister>> GetStudentFeeRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key);
        Task<List<dtfeewiseregister>> GetFeeWiseRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key);

        Task<List<dtfeewiseregister>> GetFeeWiseRegisterbyclassanddivision(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type,string cls,string div, string des,string key);

        Task<List<dtStudentFeeRegister>> GetTermWiseRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key);
        Task<List<dtStudentFeeRegister>> GetParentStudentFeeWise(string AcademicYear, int BranchID, string Criteria, int AccountId, DateTime FromDate, DateTime ToDate, string Status, string key);

        Task<List<dtStudentFeeRegister>> GetParentFee(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key);
        Task<List<dtStudentFeeRegister>> GetFeeConflict(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key);

        Task<List<dtStudentFeeRegister>> GetStudentFeeRegisterAll(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string key);
        public Task<int> DeleteVoucher(int VID, int bvid, string key);
        public Task<int> DeleteAllVoucherallocation(int AccountID, DateTime Dates, string key);
        Task<List<object>> GetStudentFeeRegisters(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key);
    }
}
