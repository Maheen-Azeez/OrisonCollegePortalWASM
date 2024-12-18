using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Dynamic;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IStudentManager
    {
        Task<List<Student>> GetAll(int BranchId, string accyear );
        Task<HttpResponseMessage> InsertStudent(Student student);
        Task<HttpResponseMessage> UpdateStudent(Student student);
        Task<string> GetNextStudentCode(int branchid);
        public Task<string> GetAbbr(int BranchID);
        Task<Col_Intake> GetIntake(string name);

        Task<Student> GetStudent(int id);
        Task<List<string>> GetCombolist(string type);
        Task<IEnumerable<Col_AccademicYear>> GetAcademicYear();
        public Task<IEnumerable<dtStudentRegister>?> GetStudents(string AcademicYear, int? BranchID, string? Category, int? UserID);
        public Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterAll(string AcademicYear, int? BranchID, string? Category, int? UserID);
      //  public Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentsDefault(string AcademicYear, int? BranchID, string? Category, int? UserID);
        public Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentRegisterAllDefault(string AcademicYear, int? BranchID, string? Category, int? UserID);
        public Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterCustomized(string AcademicYear, int? BranchID, string? Category, int? UserID);
        public Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterCustomizedAll(string AcademicYear, int? BranchID, string? Category, int? UserID);
        public Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterDetailed(string AcademicYear, int? BranchID, string? Category, int? UserID);
        public Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterDetailedAll(string AcademicYear, int? BranchID, string? Category, int? UserID);
        public Task<IEnumerable<SchoolAcademicYear>?> GetAcademicYear(int? BranchID);
        public Task<string> GetCurrentAcademicYear(int? BranchID);
        public Task<string> GetSchool();
        public Task<string> GetCompany(int? BranchID);
        public Task<string> getHomeUrl();
        public Task<string> getParentHomeUrl();
        public Task<string> getLogoutUrl();

        public Task<string> getLogo(int? BranchID);
        public Task<string> getLogoUrl();

        public Task<HttpResponseMessage> SaveSyncData(dtSyncData Student);
        public Task<HttpResponseMessage> SaveSyncDatawithparent(dtSyncData Student);

        public Task<IEnumerable<SchoolWebMenuSettings>?> EnableMenu(string Menu);
        public Task<IEnumerable<dtCompany>?> GetCompanyDetails(long BranchID);
        public Task<IEnumerable<dtStudentRegister>?> GetPromoted(string AcademicYearTo, int AccountID);
        public Task<string> GetGrade(int AccountID);
        public Task<HttpResponseMessage> SavePromo(dtStudentRegister Promo);
        public Task<List<ExpandoObject>> GetCombanyLogo(int? BranchID);
        Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentsDefault(string AcademicYear, int? BranchID, string? Category, int? UserID);
    }
}
