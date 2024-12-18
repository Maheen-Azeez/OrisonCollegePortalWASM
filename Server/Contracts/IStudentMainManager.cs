using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IStudentMainManager
    {
        Task<bool> InsertStudent(Student student, string Con);
        Task<bool> UpdateStudent(Student student, string Con);
    }
}
