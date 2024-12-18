using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IStudentArabicEntry
    {
        Task<int> CreateStudentArabic(SchoolStudentsArabic StudentArabicEntry, IDbConnection db, IDbTransaction tran);

        Task<int> UpdateStudentArabic(SchoolStudentsArabic StudentArabicEntry, IDbConnection db, IDbTransaction tran, string Con);
    }
}
