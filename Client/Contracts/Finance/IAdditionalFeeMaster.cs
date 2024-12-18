using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IAdditionalFeeMaster
    {
        Task<List<SchoolFeeMaster>?> Getdata(int? BranchID, string AcademicYear);
        public Task<SchoolFeeMaster?> GetAdditional(int? BranchID, int ID);
        public Task<string> GetID(string Code);
        public Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> EditSaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> SaveMaster(SchoolFeeMaster value);
        public Task<HttpResponseMessage> UpdateMaster(SchoolFeeMaster value);
        public Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID);
        public Task<IEnumerable<VtypeTrans>?> GetReceipt();
        public Task<HttpResponseMessage> DeleteAdditional(int ID);
        public Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value);

    }
}
