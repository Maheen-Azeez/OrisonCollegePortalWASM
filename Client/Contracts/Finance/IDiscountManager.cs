using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IDiscountManager
    {
        public Task<List<SchoolDiscountSchedule>?> GetAll(int? BranchID);
        public Task<List<SchoolDiscountSchedule>?> Getdata(int? BranchID);
        public Task<SchoolDiscountSchedule> Getdt(int? BranchID);
        public Task<HttpResponseMessage> UpdateMaster(SchoolDiscountSchedule value);

        public Task<SchoolDiscountSchedule?> GetDTDiscount(int Id, int? BranchID);
        public Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> EditSaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value);

        public Task<HttpResponseMessage> DeleteDiscount(int Id);

        public Task<HttpResponseMessage> SaveMaster(SchoolDiscountSchedule value);

        public Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID);
        public Task<string> GetID(string Code);
    }
}
