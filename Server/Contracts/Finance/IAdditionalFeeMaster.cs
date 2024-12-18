using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IAdditionalFeeMaster
    {
        Task<List<SchoolFeeMaster>> Getdata(int BranchID, string AcademicYear, string Key);
        Task<SchoolFeeMaster> GetAdditional(int BranchID, int ID, string Key);
        Task<string> GetID(string AccountCode, string Key);
        Task<long> AddSaveUserTrack(DtoUserTrack User, string Key);
        Task<long> EditSaveUserTrack(DtoUserTrack User, string Key);
        public Task<long> SaveMaster(SchoolFeeMaster value, string Key);
        Task<List<VtypeTrans>> GetReceipt(string Key);
        Task<List<Accounts>> GetPostTo(int BranchID, string Key);
        public Task<long> UpdateMaster(SchoolFeeMaster value, string Key);
        public Task<int> DeleteAdditional(int ID, string Key);
        Task<long> DeleteSaveUserTrack(DtoUserTrack User, string Key);
    }
}
