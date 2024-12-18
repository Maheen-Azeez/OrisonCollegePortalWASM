using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IFeeManager
    {
        Task<List<FeeMaster>> GetFeeSchedule(int BranchID,string Key);
        Task<List<FeeMaster>> GetPostedFee(int AccountId, string Key);

        Task<FeeMaster> GetAcademicYear(string Key);
        Task<long> InsertPostedFee(FeeMaster feeMaster, string Key);
        Task<bool> DeleteDepostedRecords(int Id, string Key);
        Task<List<MastDesignation>> BindComboBox(string type, string Key);
        Task<int> FeePostChecking(FeeMaster feeMaster, string Key);
    }
}
