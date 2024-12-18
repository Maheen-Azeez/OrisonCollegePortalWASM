using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Contracts.General
{
    public interface IUserRightsManager
    {
        public Task<UserRights> GetUserRights(int? ID, string Keyword, string Module, int? BranchId, string Con);
    }
}
