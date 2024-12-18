using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Data;
using System.Globalization;
using Microsoft.Identity.Client;

namespace OrisonCollegePortal.Server.Concretes
{
    public class DocumentEntry : IDocumentEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;
        public string formattedExpiryDate="", formattedIssueDate="";
        public DocumentEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public void Dispose()
        {

        }

        public async Task<long> SaveDocument(Documents docEntry, IDbConnection db, IDbTransaction tran)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Criteria", "InsertDocuments", DbType.String);
                dbPara.Add("AccountId", docEntry.Account_id, DbType.Int32);
                dbPara.Add("Type", docEntry.Type, DbType.String);
                dbPara.Add("DocumentNo", docEntry.DocumentNo, DbType.String);
                dbPara.Add("IssuePlace", docEntry.IssuePlace, DbType.String);
                dbPara.Add("IssueDate", docEntry.IssueDate, DbType.DateTime);
                dbPara.Add("ExpiryDate", docEntry.ExpiryDate, DbType.DateTime);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                long NewID = _dapperManager.Insert("[Col_DocumentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                return NewID;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<long> UpdateDocument(Documents docEntry, IDbConnection db, IDbTransaction tran)
        {
            try
            {
               
                if (docEntry.IssueDate.HasValue)
                {
                     formattedIssueDate = docEntry.IssueDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                if (docEntry.ExpiryDate.HasValue)
                {
                     formattedExpiryDate = docEntry.ExpiryDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                var dbPara = new DynamicParameters();

                dbPara.Add("Criteria", "UpdateDocuments", DbType.String);
                dbPara.Add("DocID", docEntry.Document_id, DbType.Int32);
                dbPara.Add("AccountID", docEntry.Account_id, DbType.Int32);
                dbPara.Add("Type", docEntry.Type, DbType.String);
                dbPara.Add("DocumentNo", docEntry.DocumentNo, DbType.String);
                dbPara.Add("IssuePlace", docEntry.IssuePlace, DbType.String);
                dbPara.Add("IssueDate", formattedIssueDate, DbType.DateTime);
                dbPara.Add("ExpiryDate", formattedExpiryDate, DbType.DateTime);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                long NewID = _dapperManager.Insert("[Col_DocumentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                return NewID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
