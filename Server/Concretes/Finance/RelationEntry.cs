using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class RelationEntry : IRelationEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public RelationEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateRelation(SchoolFamilyDetail RelationEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountId", RelationEntry.AccountId, DbType.Int64);
            dbPara.Add("Name", RelationEntry.Name, DbType.String);
            dbPara.Add("Relation", RelationEntry.Relation, DbType.String);
            dbPara.Add("Address", RelationEntry.Address, DbType.String);
            dbPara.Add("Mobile", RelationEntry.Mobile, DbType.String);
            dbPara.Add("Gender", RelationEntry.Gender, DbType.String);
            dbPara.Add("OfficePhone", RelationEntry.OfficePhone, DbType.String);
            dbPara.Add("Mobile2", RelationEntry.Mobile2, DbType.String);
            dbPara.Add("Fax", RelationEntry.Fax, DbType.String);
            dbPara.Add("Email", RelationEntry.Email, DbType.String);
            dbPara.Add("Pobox", RelationEntry.Pobox, DbType.String);
            dbPara.Add("Emirate", RelationEntry.Emirate, DbType.String);
            dbPara.Add("FamilyId", RelationEntry.FamilyId, DbType.String);
            dbPara.Add("WorkingPlace", RelationEntry.WorkingPlace, DbType.String);
            dbPara.Add("Nationality", RelationEntry.Nationality, DbType.String);
            dbPara.Add("HomePhone", RelationEntry.HomePhone, DbType.String);
            dbPara.Add("SpeakEnglish", RelationEntry.SpeakEnglish, DbType.Boolean);
            dbPara.Add("Criteria", "InsertRelation", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("StudentRelation_EntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> UpdateRelation(SchoolFamilyDetail RelationEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("AccountId", RelationEntry.AccountId, DbType.Int64);
            dbPara.Add("Name", RelationEntry.Name, DbType.String);
            dbPara.Add("Relation", RelationEntry.Relation, DbType.String);
            dbPara.Add("Address", RelationEntry.Address, DbType.String);
            dbPara.Add("Mobile", RelationEntry.Mobile, DbType.String);
            dbPara.Add("Gender", RelationEntry.Gender, DbType.String);
            dbPara.Add("OfficePhone", RelationEntry.OfficePhone, DbType.String);
            dbPara.Add("Mobile2", RelationEntry.Mobile2, DbType.String);
            dbPara.Add("Fax", RelationEntry.Fax, DbType.String);
            dbPara.Add("Email", RelationEntry.Email, DbType.String);
            dbPara.Add("Pobox", RelationEntry.Pobox, DbType.String);
            dbPara.Add("Emirate", RelationEntry.Emirate, DbType.String);
            dbPara.Add("FamilyId", RelationEntry.FamilyId, DbType.String);
            dbPara.Add("WorkingPlace", RelationEntry.WorkingPlace, DbType.String);
            dbPara.Add("Nationality", RelationEntry.Nationality, DbType.String);
            dbPara.Add("HomePhone", RelationEntry.HomePhone, DbType.String);
            dbPara.Add("SpeakEnglish", RelationEntry.SpeakEnglish, DbType.Boolean);
            dbPara.Add("Criteria", "UpdateRelation", DbType.String);
            dbPara.Add("AccID", RelationEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Update("StudentRelation_EntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> DeleteRelation(SchoolFamilyDetail RelationEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("AccountId", RelationEntry.AccountId, DbType.Int64);
            dbPara.Add("Criteria", "DeleteRelation", DbType.String);
            dbPara.Add("AccID", RelationEntry.Id, DbType.Int64);

            int newID = Convert.ToInt32(_dapperManager.Update("StudentRelation_EntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }
    }
}
