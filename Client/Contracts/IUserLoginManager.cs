using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.General;
using System.Dynamic;

namespace OrisonCollegePortal.Client.Contracts
{
    public interface IUserLoginManager
    {
        public Task<IEnumerable<DtoLoginModel>?> GetUserData(int? UserID, int? BranchID);
        public Task<string> GetCompany(int BranchID);
        public Task<IEnumerable<Col_AccademicYear>> GetAcademicYear(int BranchID);
        public Task<string> GetCurrentAcademicYear(int BranchID);

        public Task<List<ExpandoObject>> GetCompanyDetails(int BranchID);
        public Task<string> getLogo(int BranchID);
        public Task<string> getLogoUrl();
        public Task<string> getLogoutUrl();
        public Task<string> getHomeUrl();
        public Task<string> getBranchSettings(string source);
        public Task<IEnumerable<DtoLoginModel>?> LoginUser(string UserName, string Password);
    }
}
