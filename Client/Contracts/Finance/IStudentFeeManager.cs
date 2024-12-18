using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Dynamic;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IStudentFeeManager
    {

        public Task<IEnumerable<dtStudentFeeRegister>?> GetStudentFeeRegister(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type);
        public Task<IEnumerable<dtfeewiseregister>?> GetFeeWiseRegister(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type);

        public Task<IEnumerable<dtfeewiseregister>?> GetFeeWiseRegisterbyclassanddivision(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type,string cls,string div,string des);

        public Task<IEnumerable<dtStudentFeeRegister>?> GetTermFeeRegister(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type);
        public Task<IEnumerable<dtStudentFeeRegister>?> GetParentFee(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type);

        public Task<IEnumerable<dtStudentFeeRegister>?> GetFeeConflict(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type);

        public Task<IEnumerable<dtStudentFeeRegister>?> GetStudentFeeRegisterAll(string AcademicYear, int BranchID, string FromDate, string ToDate);
        public Task<IEnumerable<SchoolAcademicYear>?> GetAcademicYear(int? BranchID);
        public Task<IEnumerable<dtStudentFeeRegister>?> GetParentStudentFeeWise(string AcademicYear, int BranchID, string Criteria, int AccountId, string FromDate, string ToDate, string Status);

        public Task<IEnumerable<SchoolMailTemplate>?> GetMailTemplate(string Type, int? BranchID);
        public Task<string> GetSMSTemplate(int BranchID);
        public Task<HttpResponseMessage> DeleteVoucher(int VID, int bvid);
        public Task<HttpResponseMessage> DeleteAllVoucherallocation(int AccountID, string Dates);
        public Task<IEnumerable<ExpandoObject>?> GetStudentFeeRegisters(string AcademicYear, int BranchID, string FromDate, string ToDate, string Status, string Type);
    }
}
