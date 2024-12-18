using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Client.Contracts
{
    public interface IMiscellaneousMasterManager
    {
        public Task<List<MiscellaneousMasterdata>?> GetMaster();
        public Task<HttpResponseMessage> SaveMaster(MiscellaneousMasterdata value);
        public Task<HttpResponseMessage> UpdatMaster();
        Task<bool> DeleteMaster(int id);
        public Task<List<MiscellaneousMasterdata>?> ComboMaster(string Source);

    }
}
