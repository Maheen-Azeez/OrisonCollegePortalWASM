using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IStudentAccEntry
    {
        Task<int> CreateStudentAc(Accounts accEntry, IDbConnection db, IDbTransaction tran);
        Task<ActionResult<Accounts>> CreateStudentAc(Accounts ac);

        Task<long> UpdateStudentAc(Accounts accEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
