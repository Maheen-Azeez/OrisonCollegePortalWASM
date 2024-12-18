
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IInvAccounts : IDisposable
    {
      
        public Task<IEnumerable<DtoInvAccounts>?> GetPreRegReceipt(int? BranchID);
      //  public Task<DtoInvAccounts?> GetStudent(int? BranchID, long? AccID);

        public Task<IEnumerable<DtoInvAccounts>> GetAccountsByCategoryReceipt(string? AccCategory, int? BranchID);

        public Task<IEnumerable<DtoInvAccounts>?> GetStudentsAccountsReceipt(int? BranchID, string? receiptType);
       // public  Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentsAccountsReceiptGlobal(int? BranchID, string? receiptType);
        public Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentsAccountsReceiptGlobal(int? BranchID, string? receiptType);

        public Task<DtoInvAccounts?> GetAccountsDetails(string? value, int? BranchID);
        public Task<DtoInvAccounts?> GetStudentDetails(int? AccountId);
        public Task<IEnumerable<DtoInvAccounts>?> GetAccountsByCategory(string? value, string? BranchID);
    }
}
