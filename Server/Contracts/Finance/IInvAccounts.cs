
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IInvAccounts : IDisposable
    {
        public Task<List<DtoInvAccounts>> GetPreRegisterStudents(int BranchID, string Key);
        public Task<DtoInvAccounts> GetAccountsDetails(string value, int BranchID, string Key);
        Task<DtoInvAccounts>? GetDTAccount(int? AccountID, string? AccountCode,string? Criteria, int BranchID, string Key);
        public Task<List<DtoInvAccounts>> GetAccountsByCategory(string AccCategory, string AccSubCategory, string Key);
        public Task<List<DtoInvAccounts>> GetStudentsAccounts(int BranchID, string Key, string? ReceiptType);
        public Task<List<dtoStudentRegisterDefault>> GetStudentsAccountsGlobal(int BranchID, string Key, string? ReceiptType);

        Task<List<DtoInvAccounts>> GetAccounts(string AccCategory, int BranchID, string Key);
        public Task<DtoInvAccounts> GetStudent(int BranchID, long AccID, string Key);

    }
}
