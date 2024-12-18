using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes
{
    public class DocImageEntry : IDocImageEntry
    {
        private readonly IDapperManager _dapperManager;

        public DocImageEntry(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public void Dispose()
        {

        }

        public async Task<long> SaveDocumentImage(Documents DocImgEntry, IDbConnection db, IDbTransaction tran)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("DocID", DocImgEntry.Document_id, DbType.String);
                dbPara.Add("Type", DocImgEntry.Type, DbType.String);
                dbPara.Add("Path", DocImgEntry.Path, DbType.String);
                //if (DocImgEntry.FileName.Contains(".PNG"))
                //{
                //    DocImgEntry.FileName = Path.ChangeExtension(DocImgEntry.FileName, ".png");
                //}
                dbPara.Add("FileSize", DocImgEntry.FileSize, DbType.Double);
                dbPara.Add("FileName", DocImgEntry.FileName, DbType.String);
                dbPara.Add("Criteria", "InsertDocumentFile", DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                long newID = _dapperManager.Insert("[Col_DocumentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                return newID;
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public async Task<long> UpdateDocumentImage(Documents DocImgEntry, IDbConnection db, IDbTransaction tran)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("DocID", DocImgEntry.Document_id, DbType.String);
                dbPara.Add("Type", DocImgEntry.Type, DbType.String);
                dbPara.Add("Path", DocImgEntry.Path, DbType.String);
                dbPara.Add("FileName", DocImgEntry.FileName, DbType.String);
                dbPara.Add("FileSize", DocImgEntry.FileSize, DbType.Double);
                dbPara.Add("Criteria", "UpdateDocumentFile", DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                long newID = _dapperManager.Insert("[Col_DocumentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                return newID;
            }
            catch (Exception EX)
            {

                throw EX;
            }

        }
    }
}
