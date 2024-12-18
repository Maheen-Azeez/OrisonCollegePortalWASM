using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IAdditionalPayment
    {
        Task<List<AdditionalTrack>?> Getdata(int? BranchID, string AcademicYear);
        public Task<AdditionalTrack?> GetAdditional(int? BranchID, int ID);
        public Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> DeleteAdditional(int ID);
        public Task<HttpResponseMessage> SaveMaster(AdditionalTrack value);
        public Task<HttpResponseMessage> UpdateMaster(AdditionalTrack value);
        public Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> EditSaveUserTrack(DtoUserTrack value);
        public Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID);
        public Task<string> GetID(string Code);
        public Task<IEnumerable<VtypeTrans>?> GetReceipt();
        public Task<string> GetReceiptTypeID();

    }
}
