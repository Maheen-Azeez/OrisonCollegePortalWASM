using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IStudentTranEntry
    {
        Task<int> CreateStudentTran(SchoolStudentTran StudentTranEntry, IDbConnection db, IDbTransaction tran);

        Task<int> UpdateStudentTran(SchoolStudentTran StudentTranEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
