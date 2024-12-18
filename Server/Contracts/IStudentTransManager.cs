using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IStudentTransManager
    {
        Task<long> Insert(int id, Student student, IDbConnection db, IDbTransaction tran);
        Task<bool> Update(Student student, IDbConnection db, IDbTransaction tran);
    }
}
