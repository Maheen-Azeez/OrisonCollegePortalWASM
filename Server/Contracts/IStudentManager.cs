using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IStudentManager
    {
        Task<List<Student>> GetAll(int branchid, string Accyear, string Key);
        Task<string> GetNextStudentCode(int branchid, string Key);
        Task<long> Insert(int id, Student student, IDbConnection db, IDbTransaction tran);
        Task<bool> Update(Student student, IDbConnection db, IDbTransaction tran);

        Task<Student> GetStudent(string ID,string Key);
        Task<List<string>> GetComboList(string type, string Key);
        Task<List<Col_AccademicYear>> GetAccyear(string Key);
        Task<Col_Intake> GetIntake(string name,string Key);
        Task<string> GetAbbr(int BranchID, string Key);
        public Task<string> getHomeUrl(string Key);
        public Task<string> getLogoutUrl(string Key);
        public Task<string> getParentHomeUrl(string Key);
        public Task<string> getLogo(int BranchID, string Key);
        public Task<string> getLogoUrl(string Key);
        Task<List<dtoStudentRegisterDefault>?> GetStudentsDefault(string AcademicYear, int? BranchID, string? Category, int? UserID, string Key);

    }
}
