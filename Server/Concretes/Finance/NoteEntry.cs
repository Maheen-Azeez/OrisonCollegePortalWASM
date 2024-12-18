using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class NoteEntry : INoteEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public NoteEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateNotes(SchoolStudentNote NotesEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountId", NotesEntry.AccountId, DbType.Int64);
            dbPara.Add("NoteDate", NotesEntry.NoteDate, DbType.DateTime);
            dbPara.Add("Category", NotesEntry.Category, DbType.String);
            dbPara.Add("Remarks", NotesEntry.Remarks, DbType.String);
            dbPara.Add("NatureOfOffense", NotesEntry.NatureOfOffense, DbType.String);
            dbPara.Add("ActionTaken", NotesEntry.ActionTaken, DbType.String);
            dbPara.Add("OffenseLocation", NotesEntry.OffenseLocation, DbType.String);
            dbPara.Add("TeacherName", NotesEntry.TeacherName, DbType.String);
            dbPara.Add("Subject", NotesEntry.Subject, DbType.String);
            dbPara.Add("Criteria", "InsertNotes", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("StudentNote_EntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> UpdateNotes(SchoolStudentNote NotesEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("AccountId", NotesEntry.AccountId, DbType.Int64);
            dbPara.Add("NoteDate", NotesEntry.NoteDate, DbType.DateTime);
            dbPara.Add("Category", NotesEntry.Category, DbType.String);
            dbPara.Add("Remarks", NotesEntry.Remarks, DbType.String);
            dbPara.Add("NatureOfOffense", NotesEntry.NatureOfOffense, DbType.String);
            dbPara.Add("ActionTaken", NotesEntry.ActionTaken, DbType.String);
            dbPara.Add("OffenseLocation", NotesEntry.OffenseLocation, DbType.String);
            dbPara.Add("TeacherName", NotesEntry.TeacherName, DbType.String);
            dbPara.Add("Subject", NotesEntry.Subject, DbType.String);
            dbPara.Add("Criteria", "UpdateNotes", DbType.String);
            dbPara.Add("AccID", NotesEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Update("StudentNote_EntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> DeleteNote(SchoolStudentNote NotesEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("AccountId", NotesEntry.AccountId, DbType.Int64);
            dbPara.Add("Criteria", "DeleteNotes", DbType.String);
            dbPara.Add("AccID", NotesEntry.Id, DbType.Int64);

            int newID = Convert.ToInt32(_dapperManager.Update("StudentNote_EntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;

        }
    }
}
