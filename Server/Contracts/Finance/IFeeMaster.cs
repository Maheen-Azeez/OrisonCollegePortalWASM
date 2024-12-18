using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IFeeMaster
    {
        Task<List<Accounts>> GetPostTo(int BranchID, string Key);
        Task<List<VtypeTrans>> GetReceipt(string Key);
        Task<List<SchoolFeeMaster>> GetFeeMasterList(string AcademicYear, int BranchID, string Key);
        Task<SchoolFeeMaster> GetDTFeeMaster(int ID, int BranchID, string Key);
        Task<string> GetID(string AccountCode, string Key);
        Task<string> GetReceiptTypeID(string Key);

        Task<long> CreateFeeMaster(SchoolFeeMaster student, string Key);
        Task<long> EditFeeMaster(SchoolFeeMaster student, string Key);
        Task<long> DeleteFeeMaster(dtMasterStudent Fee, string Key);

        Task<SchoolFeeMaster> GetExistFeeMaster(int FeeID, int BranchID, string Key);
    }
}
