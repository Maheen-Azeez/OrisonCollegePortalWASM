using Dapper;
using Microsoft.Data.SqlClient;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes
{
    public class DocumentManager : IDocumentManager
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;
        private readonly IDocImageEntry _docImageEntry;
        private readonly IDocumentEntry _documentEntry;

        public DocumentManager(IDapperManager dapperManager, IConfiguration config, IDocImageEntry docImageEntry, IDocumentEntry documentEntry)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _docImageEntry = docImageEntry;
            _documentEntry = documentEntry;
        }
        public async Task<bool> Delete(int ID, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DocID", ID, DbType.Int32);
            dbPara.Add("Criteria", "DeleteDocument", DbType.String);

            try
            {

                _dapperManager.Execute("[Col_DocumentSP]", Key,dbPara,  commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                return false;
                throw ex;
            }


            return true;
        }

        public async Task<List<Documents>> GetAllDocuments(int branchid, string Key)
        {
            var dbPara = new DynamicParameters();


            dbPara.Add("Criteria", "SelectAllDocuments", DbType.String);
            dbPara.Add("BranchId", branchid, DbType.Int32);
            var no = Task.FromResult(_dapperManager.GetAll<Documents>("[Col_DocumentSP]",Key, dbPara, commandType: CommandType.StoredProcedure));

            return await no;
        }

        public async Task<Documents> GetDocumentByDocId(int id, string Key)
        {
            var dbPara = new DynamicParameters();


            dbPara.Add("DocID", id, DbType.Int32);
            dbPara.Add("Criteria", "SelectDocumentsDocID", DbType.String);

            var no = Task.FromResult(_dapperManager.Get<Documents>("[Col_DocumentSP]",Key, dbPara, commandType: CommandType.StoredProcedure));

            return await no;
        }

        public async Task<List<Documents>> GetDocumentsById(int id, string Key)
        {
            var dbPara = new DynamicParameters();


            dbPara.Add("Criteria", "SelectDocumentsAccID", DbType.String);
            dbPara.Add("id", id, DbType.Int32);
            var no = Task.FromResult(_dapperManager.GetAll<Documents>("[Col_DocumentSP]",Key, dbPara, commandType: CommandType.StoredProcedure));

            return await no;
        }

        public async Task<bool> InsertDocuments(Documents documents, string Key)
        {
            long newID;
            using IDbConnection db = _dapperManager.GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    //dtDocument dc = document.docmaster;
                    newID = await _documentEntry.SaveDocument(documents, db, tran);
                    //DocImage dimg = document.docImage;
                    documents.Document_id = (int)newID;

                    string file = documents.FileName;
                    string[] files = file.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    foreach (string filename in files)
                    {
                        documents.FileName = filename;

                        newID = await _docImageEntry.SaveDocumentImage(documents, db, tran);
                    }

                    //UserTrack user = document.UserTrack;
                    //user.Reason = "Save Document, DocID -" + newID;
                    //user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    //user.ActionId = 1;
                    //user.RowId = 0;

                    //newID = await _UserTrackrepository.UserTrackUpdation(user, db, tran);


                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return true;
        }

        public async Task<bool> UpdateDocuments(Documents documents, string Key)
        {
            long newID;
            using IDbConnection db = _dapperManager.GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    //dtDocument dc = document.docmaster;
                    newID = await _documentEntry.UpdateDocument(documents, db, tran);
                    //DocImage dimg = document.docImage;
                    documents.Document_id = (int)newID;
                    if (documents.FileName != null && documents.FileName != "")
                    {
                        string file = documents.FileName;
                        string[] files = file.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        foreach (string filename in files)
                        {
                            documents.FileName = filename;

                            newID = await _docImageEntry.UpdateDocumentImage(documents, db, tran);
                        }
                    }

                    //UserTrack user = document.UserTrack;
                    //user.Reason = "Edit Document, DocID -" + newID + "";
                    //user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    //user.ActionId = 2;
                    //user.RowId = 0;

                    //newID = await _UserTrackrepository.UserTrackUpdation(user, db, tran);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return true;
        }
    }
}
