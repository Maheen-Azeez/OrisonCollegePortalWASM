using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IAccountManager
    {
        Task<long> InsertParentAccount(Student student, IDbConnection db, IDbTransaction tran);
        Task<long> InsertStudentAccount(Student student, IDbConnection db, IDbTransaction tran);
        Task<bool> UpdateStudentAccount(Student student, IDbConnection db, IDbTransaction tran);
        Task<bool> UpdateParentAccount(Student student, IDbConnection db, IDbTransaction tran);
        //public Task<List<dtAccountsMain>> GetCount(int BranchId, string AccYear, DateTime SDate, DateTime EDate, string Description, string Criteria);
        //public Task<List<dtAccountsMain>> GetGridData(int branchId, string accYear, DateTime sDate, DateTime eDate, string description, string criteria);
    }
}
