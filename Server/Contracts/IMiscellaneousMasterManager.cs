
using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Concretes
{
    public interface IMiscellaneousMasterManager
    {
        Task<List<MiscellaneousMasterdata>> ComboMaster(string Source, string Key);
        Task<List<MiscellaneousMasterdata>> GetMaster(string Key);
        public Task<int> DeleteMaster(int id, string Key);
        public Task<long> SaveMaster(MiscellaneousMasterdata value, string Key);
    }
}
