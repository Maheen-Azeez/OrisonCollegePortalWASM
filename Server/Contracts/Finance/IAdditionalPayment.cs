using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IAdditionalPayment
    {
        Task<List<Accounts>> GetPostTo(int BranchID, string Key);
        Task<string> GetID(string AccountCode, string Key);
        Task<List<VtypeTrans>> GetReceipt(string Key);
        Task<string> GetReceiptTypeID(string Key);
        Task<List<AdditionalTrack>> Getdata(int BranchID, string AcademicYear, string Key);
        Task<AdditionalTrack> GetAdditional(int BranchID, int ID, string Key);
        public Task<int> DeleteAdditional(int ID, string Key);
        Task<long> DeleteSaveUserTrack(DtoUserTrack User, string Key);
        public Task<long> SaveMaster(AdditionalTrack value, string Key);
        public Task<long> UpdateMaster(AdditionalTrack value, string Key);
        Task<long> AddSaveUserTrack(DtoUserTrack User, string Key);
        Task<long> EditSaveUserTrack(DtoUserTrack User, string Key);

    }
}
