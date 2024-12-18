using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IParentAccEntry
    {
        Task<int> CreateParentAc(Accounts ParentAccentry, IDbConnection db, IDbTransaction tran);
        //Task<ActionResult<Account>> CreateParentAc(Account ac);

        Task<long> UpdateParentAc(Accounts accEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
