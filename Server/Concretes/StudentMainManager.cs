using Microsoft.Data.SqlClient;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Controllers;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes
{
    public class StudentMainManager : IStudentMainManager
    {
        private readonly IDapperManager _dapperManager;
        private readonly IAccountManager _accountsmanager;
        private readonly IStudentTransManager _studenttransmanager;
        private readonly IParentManager _parentmanager;
        private readonly IStudentManager _studentmanager;
        private readonly IConfiguration _config;




        public StudentMainManager(IDapperManager dapperManager, IConfiguration config, IStudentManager studentmanager, IParentManager parentmanager,
            IStudentTransManager studenttransmanager, IAccountManager accountsmanager)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _accountsmanager = accountsmanager;
            _studentmanager = studentmanager;
            _studenttransmanager = studenttransmanager;
            _parentmanager = parentmanager;

        }
        public async Task<bool> InsertStudent(Student student, string Key)
        {
            long p_id, stu_id, studentid, tranid, parentid;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = _dapperManager.GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {

                    p_id = await _accountsmanager.InsertParentAccount(student, db, tran);
                    student.P_Id = (int)p_id;
                    stu_id = await _accountsmanager.InsertStudentAccount(student, db, tran);
                    int stu_Id = (int)stu_id;
                    studentid = await _studentmanager.Insert(stu_Id, student, db, tran);
                    tranid = await _studenttransmanager.Insert(stu_Id, student, db, tran);
                    parentid = await _parentmanager.Insert(stu_Id, student, db, tran);
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

        public async Task<bool> UpdateStudent(Student student, string Con)
        {
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = _dapperManager.GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {

                    await _accountsmanager.UpdateParentAccount(student, db, tran);
                    await _accountsmanager.UpdateStudentAccount(student, db, tran);

                    await _studentmanager.Update(student, db, tran);
                    await _studenttransmanager.Update(student, db, tran);
                    await _parentmanager.Update(student, db, tran);
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
