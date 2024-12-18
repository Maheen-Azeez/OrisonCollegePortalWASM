using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Contracts.General
{
    public interface IDBOperation: IDisposable
    {
        //Task<string>GetAcademicYear(int BranchID);
        Task<List<SchoolAcademicYear>> GetAcademicYear(int BranchID, string Con);
        Task<string> GetCurrentAcademicYear(int? BranchID, string Con);
        Task<List<SchoolClassMaster>> GetClass(int? BranchID, string Con);
        Task<List<SchoolClassMaster>> GetClass(int? BranchID, string AcademicYear, string Con);
        Task<List<SchoolClass>> GetDivision(int? BranchID, string Con);
        Task<List<SchoolClass>> GetDivision(int? BranchID, string AcademicYear, string Con);
        Task<List<SchoolClass>> GetDivisionByClass(int? BranchID, string Class, string Con);
        Task<List<SchoolClassMaster>> GetUserOwnClass(int UserID, int? BranchID, string Con);
        Task<List<SchoolClass>> GetUserOwnDivision(int UserID, int? BranchID, string Con);
        Task<List<SchoolFeeSchedule>> GetFee(string AcademicYear, int? BranchID, string Con);
        Task<List<SchoolFeeSchedule>> GetTransport(string AcademicYear, int? BranchID, string Con);
        Task<List<SchoolFeeSchedule>> GetAdmission(string AcademicYear, int? BranchID, string Con);
        Task<List<SchoolDiscountSchedule>> GetFeeDiscount(int? BranchID, string Con);
        Task<List<SchoolFeeSchedule>> GetActivity(string AcademicYear, int? BranchID, string Con);
        Task<List<Accounts>> GetStaff(int? BranchID, string Con);
        //Task<List<dtStudentRegister>> GetParent(int? BranchID, string Con);
        Task<List<dtoStudentRegisterDefault>> GetParent(int? BranchID, string Con);
        Task<List<HrtransportationMast>> GetBusDetails(int? BranchID, string Con);
        //Task<List<Account>> GetPLevel();
        Task<string> GetPLevel(string Con);
        Task<string> GetPLevelID(string Con);
        Task<string> GetAccountGroup(int PID, string Con);
        Task<string> GetSubGroup(int PID, string Con);
        Task<string> GetAccCategory(int PID, string Con);
        Task<string> GetShowChild(int PID, string Con);
        Task<string> GetAccCategoryMast(string Con);
        //Task<List<Company>> GetAbbr(int BranchID);
        Task<string> GetAbbr(int BranchID, string Con);
        Task<string> GetNextNo(int BranchID, string Con);
        Task<string> GetSExistNo(int BranchID, string Con);
        Task<string> GetParentNextNo(int branchID, string Scode, string Con);

        Task<string> GetStaffID(int BranchID, string Code, string Con);
        Task<string> GetSchool(string Con);
        Task<string> GetCompany(int? BranchID, string Con);
        Task<string> GetExistStudent(string Scode, int BranchID, string Con);
        Task<string> GetExistSyncStudent(string Scode, int BranchID, string Con);
        Task<string> GetExistParentID(string Pcode, int BranchID, string Con);
        Task<string> GetTeacherName(string Class, string Division, int BranchID, string Con);
        Task<string> GetSMSTemplate(int BranchID, string Con);
        public Task<List<dtCompany>> GetCompanyDetails(long BranchID, string Con);
        public Task<List<object>> GetCombanyLogo(int BranchID, string Con);
        Task<string> DocUrl(string Path, string Con);
        Task<string> GetMailType(int BranchID, string Con);
        public Task<List<SchoolMailTemplate>> GetMailTemplate(string Type, int BranchID, string key);
        Task<List<dtCompany>> GetEmirates(string key);
        Task<string> GetDefEmirate(int branchId, string key);
        public Task<List<dtoFormLabelSettings>> GetFormLabels(string FormName, string Key);
    }
}
