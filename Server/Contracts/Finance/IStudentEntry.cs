using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IStudentEntry
    {
        Task<int> CreateStudent(SchoolStudent StudentEntry, IDbConnection db, IDbTransaction tran);

        Task<int> UpdateStudent(SchoolStudent StudentEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
