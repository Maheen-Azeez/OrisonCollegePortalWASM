using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IVoucherAllocationManagers
    {
        public Task<int> Delete(int Vids, string key);
        public Task<long> Savestatement(dtStudentStatement value, string key);
        public Task<long> Savefee(SchoolStudentTran value, string key);
        public Task<int> Autoallo(DateTime Dateauto, int AccountID, int BranchID, string key);

        public Task<long> Updatestatement(dtStudentStatement value, string key);
        Task<List<dtStudentStatement>> GetStatements(int Vid, int AccountID, int BranchID, string key);
        Task<List<dtStudentStatement>> Getallo(int Vid, int AccountID, int BranchID, string key);
    }
}
