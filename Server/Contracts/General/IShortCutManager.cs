using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Contracts.General
{
    public interface IShortCutManager
    {
        Task<List<ShortCuts>> GetShortCuts(string ModuleName, int BranchID, string key);
    }
}
