using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class DocumentImageEntry: IDocumentImageEntry
    {
        private readonly IDapperManager _dapperManager;

        public DocumentImageEntry(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public async Task<long> SaveDocumentImage(SchoolDocImage DocImgEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocID", DocImgEntry.DocId, DbType.Int64);
            dbPara.Add("Type", DocImgEntry.Type, DbType.String);
            dbPara.Add("Path", DocImgEntry.Path, DbType.String);
            dbPara.Add("FileName", DocImgEntry.FileName, DbType.String);
            dbPara.Add("Criteria", "InsertImages", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long newID = _dapperManager.Insert("Student_DocumentImageEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return newID;
        }

        public async Task<long> UpdateDocumentImage(SchoolDocImage DocImgEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocID", DocImgEntry.DocId, DbType.Int64);
            dbPara.Add("Type", DocImgEntry.Type, DbType.String);
            dbPara.Add("Path", DocImgEntry.Path, DbType.String);
            dbPara.Add("FileName", DocImgEntry.FileName, DbType.String);
            dbPara.Add("Criteria", "UpdateImages", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long newID = _dapperManager.Insert("Student_DocumentImageEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return newID;
        }

        public async Task<long> SaveParentDocumentImage(SchoolParentDocImage DocImgEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocID", DocImgEntry.DocId, DbType.Int64);
            dbPara.Add("Type", DocImgEntry.Type, DbType.String);
            dbPara.Add("Path", DocImgEntry.Path, DbType.String);
            dbPara.Add("FileName", DocImgEntry.FileName, DbType.String);
            dbPara.Add("Criteria", "InsertParentImages", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long newID = _dapperManager.Insert("Student_DocumentImageEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return newID;
        }

        public async Task<long> UpdateParentDocumentImage(SchoolParentDocImage DocImgEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocID", DocImgEntry.DocId, DbType.Int64);
            dbPara.Add("Type", DocImgEntry.Type, DbType.String);
            dbPara.Add("Path", DocImgEntry.Path, DbType.String);
            dbPara.Add("FileName", DocImgEntry.FileName, DbType.String);
            dbPara.Add("Criteria", "UpdateParentImages", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long newID = _dapperManager.Insert("Student_DocumentImageEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return newID;
        }
    }
}
