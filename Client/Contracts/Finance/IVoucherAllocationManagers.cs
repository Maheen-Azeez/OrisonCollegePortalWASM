using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IVoucherAllocationManagers
    {
        Task<bool> Delete(int Vids);

        public Task<int> Autoallo(string Dateauto, int AccountID, int BranchID);
        public Task<HttpResponseMessage> Savestatement(dtStudentStatement value);
        public Task<HttpResponseMessage> Savefee(SchoolStudentTran value);
        public Task<HttpResponseMessage> Updatestatement(dtStudentStatement value);
        public Task<IEnumerable<dtStudentStatement>> GetStatements(int Vid, int AccountID, int BranchID);
        public Task<IEnumerable<dtStudentStatement>> Getallo(int Vid, int AccountID, int BranchID);
    }
}
