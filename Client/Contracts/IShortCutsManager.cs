using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Client.Contracts
{
    public interface IShortCutsManager
    {
        public Task<List<ShortCuts>?> GetShortCuts(string ModuleName, int? BranchID);
    }
}
