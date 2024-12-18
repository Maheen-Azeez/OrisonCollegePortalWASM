using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface INoteEntry
    {
        Task<int> CreateNotes(SchoolStudentNote NotesEntry, IDbConnection db, IDbTransaction tran);

        Task<int> UpdateNotes(SchoolStudentNote NotesEntry, IDbConnection db, IDbTransaction tran, string Key);

        Task<int> DeleteNote(SchoolStudentNote NotesEntry, IDbConnection db, IDbTransaction tran, string Key);
    }
}
