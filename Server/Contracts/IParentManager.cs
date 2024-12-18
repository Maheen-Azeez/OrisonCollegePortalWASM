using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IParentManager
    {
        Task<long> Insert(int id, Student student, IDbConnection db, IDbTransaction tran);
        Task<bool> Update(Student student, IDbConnection db, IDbTransaction tran);
    }
}
