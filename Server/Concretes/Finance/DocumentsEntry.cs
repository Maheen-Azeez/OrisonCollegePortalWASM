using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class DocumentsEntry : IDocumentsEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public DocumentsEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<long> SaveDocument(SchoolDocument DocEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocumentType", DocEntry.DocumentType, DbType.String);
            dbPara.Add("AccountId", DocEntry.AccountId, DbType.Int32);
            dbPara.Add("DocumentNo", DocEntry.DocumentNo, DbType.String);
            dbPara.Add("IssueDate", DocEntry.IssueDate, DbType.DateTime);
            dbPara.Add("ExpiryDate", DocEntry.ExpiryDate, DbType.DateTime);
            dbPara.Add("IssuePlace", DocEntry.IssuePlace, DbType.String);
            dbPara.Add("Type", DocEntry.Type, DbType.String);
            dbPara.Add("Criteria", "InsertDocuments", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long NewID = _dapperManager.Insert("Student_DocumentEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return NewID;
        }

        public async Task<long> UpdateDocument(SchoolDocument DocEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocID", DocEntry.Id, DbType.Int32);
            dbPara.Add("DocumentType", DocEntry.DocumentType, DbType.String);
            dbPara.Add("AccountId", DocEntry.AccountId, DbType.Int32);
            dbPara.Add("DocumentNo", DocEntry.DocumentNo, DbType.String);
            dbPara.Add("IssueDate", DocEntry.IssueDate, DbType.DateTime);
            dbPara.Add("ExpiryDate", DocEntry.ExpiryDate, DbType.DateTime);
            dbPara.Add("IssuePlace", DocEntry.IssuePlace, DbType.String);
            dbPara.Add("Type", DocEntry.Type, DbType.String);
            dbPara.Add("Criteria", "UpdateDocuments", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long NewID = _dapperManager.Insert("Student_DocumentEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return NewID;
        }

        public async Task<long> DeleteDocument(SchoolDocument DocEntry, IDbConnection db, IDbTransaction tran, string key)
        {
            var dbPara = new DynamicParameters();
            //dbPara.Add("@DocID", DocId, DbType.Int32);
            dbPara.Add("AccountId", DocEntry.AccountId, DbType.Int64);
            dbPara.Add("Criteria", "DeleteDocument", DbType.String);
            dbPara.Add("DocID", DocEntry.Id, DbType.Int64);
            long NewID = _dapperManager.Update("Student_DocumentEntrySP", key, dbPara, commandType: CommandType.StoredProcedure);
            return NewID;
        }

        public async Task<long> SaveParentDocument(SchoolParentDocument DocEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocumentType", DocEntry.DocumentType, DbType.String);
            dbPara.Add("AccountId", DocEntry.AccountId, DbType.Int32);
            dbPara.Add("DocumentNo", DocEntry.DocumentNo, DbType.String);
            dbPara.Add("IssueDate", DocEntry.IssueDate, DbType.DateTime);
            dbPara.Add("ExpiryDate", DocEntry.ExpiryDate, DbType.DateTime);
            dbPara.Add("IssuePlace", DocEntry.IssuePlace, DbType.String);
            dbPara.Add("Type", DocEntry.Type, DbType.String);
            dbPara.Add("Criteria", "InsertParentDocuments", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long NewID = _dapperManager.Insert("Student_DocumentEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return NewID;
        }

        public async Task<long> UpdateParentDocument(SchoolParentDocument DocEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("DocID", DocEntry.Id, DbType.Int32);
            dbPara.Add("DocumentType", DocEntry.DocumentType, DbType.String);
            dbPara.Add("AccountId", DocEntry.AccountId, DbType.Int32);
            dbPara.Add("DocumentNo", DocEntry.DocumentNo, DbType.String);
            dbPara.Add("IssueDate", DocEntry.IssueDate, DbType.DateTime);
            dbPara.Add("ExpiryDate", DocEntry.ExpiryDate, DbType.DateTime);
            dbPara.Add("IssuePlace", DocEntry.IssuePlace, DbType.String);
            dbPara.Add("Type", DocEntry.Type, DbType.String);
            dbPara.Add("Criteria", "UpdateParentDocuments", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            long NewID = _dapperManager.Insert("Student_DocumentEntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            return NewID;
        }

        public async Task<long> DeleteParentDocument(SchoolParentDocument DocEntry, IDbConnection db, IDbTransaction tran, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountId", DocEntry.AccountId, DbType.Int64);
            dbPara.Add("Criteria", "DeleteParentDocument", DbType.String);
            dbPara.Add("DocID", DocEntry.Id, DbType.Int64);
            long NewID = _dapperManager.Update("Student_DocumentEntrySP", key, dbPara, commandType: CommandType.StoredProcedure);
            return NewID;
        }
    }
}
