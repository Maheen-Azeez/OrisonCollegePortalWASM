using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class StudentArabicEntry : IStudentArabicEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public StudentArabicEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateStudentArabic(SchoolStudentsArabic StudentArabicEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountId", StudentArabicEntry.AccountId, DbType.Int64);
            dbPara.Add("GuardianName", StudentArabicEntry.GuardianName, DbType.String);
            dbPara.Add("AcademicYear", StudentArabicEntry.AcademicYear, DbType.String);
            dbPara.Add("Criteria", "InsertArabic", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("StudentArabic_EntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> UpdateStudentArabic(SchoolStudentsArabic StudentArabicEntry, IDbConnection db, IDbTransaction tran, string key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("AccountId", StudentArabicEntry.AccountId, DbType.Int64);
            dbPara.Add("GuardianName", StudentArabicEntry.GuardianName, DbType.String);
            dbPara.Add("AcademicYear", StudentArabicEntry.AcademicYear, DbType.String);
            dbPara.Add("Criteria", "UpdateArabic", DbType.String);
            dbPara.Add("AccID", StudentArabicEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Update("StudentArabic_EntrySP",key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

    }
}
