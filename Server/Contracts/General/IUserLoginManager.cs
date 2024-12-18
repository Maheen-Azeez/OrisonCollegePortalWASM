using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Contracts.General
{
    public interface IUserLoginManager
    {
        public Task<List<UserLogin>> GetUserData(int AccountID, int BranchID, string Con);
        Task<string> GetCompany(int BranchID, string Con);
        Task<List<object>> GetCompanyDetails(int BranchID, string Con);
        public Task<string> getLogo(int BranchID, string Con);
        public Task<string> getLogoUrl(string Con);
        public Task<string> getLogoutUrl(string Con);
        public Task<string> getHomeUrl(string Con);
        public Task<string> GetUrl(string scource,string Con);
        Task<List<Col_AccademicYear>> GetAcademicYear(int branchID, string con);
        Task<string> GetCurrentAcademicYear(int branchID, string con);
    }
}
