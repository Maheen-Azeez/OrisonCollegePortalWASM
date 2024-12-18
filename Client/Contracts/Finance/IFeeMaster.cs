using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IFeeMaster
    {
        public Task<IEnumerable<Accounts>?> GetPostTo(int? BranchID);
        public Task<IEnumerable<VtypeTrans>?> GetReceipt();
        public Task<IEnumerable<SchoolFeeMaster>?> GetFeeMasterList(string AcademicYear, int? BranchID);

        public Task<SchoolFeeMaster?> GetDTFeeMaster(int ID, int? BranchID);

        public Task<string> GetID(string Code);
        public Task<string> GetReceiptTypeID();

        public Task<SchoolFeeMaster?> GetExistFeeMaster(string FeeID, int? BranchID);
        public Task<HttpResponseMessage> SaveFeeMaster(SchoolFeeMaster value);
        public Task<HttpResponseMessage> UpdateFeeMaster(SchoolFeeMaster value);
        public Task<HttpResponseMessage> DeleteFeeMasterByID(dtMasterStudent Fee);
    }
}
