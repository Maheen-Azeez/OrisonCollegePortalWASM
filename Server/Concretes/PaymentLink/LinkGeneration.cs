using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.PaymentLink;
using OrisonCollegePortal.Shared.Entities.PaymentLink;
using OrisonCollegePortal.Shared.Entities.Finance;
using SecurityService;
using System.Data;
using System.Data.Common;
using static OrisonCollegePortal.Shared.Entities.PaymentLink.Models;

namespace OrisonCollegePortal.Server.Concretes.PaymentLink
{
    public class LinkGeneration : ILinkGeneration
    {
        private readonly IConfiguration _config;
        private readonly IDapperManager _dapperManager;
        public LinkGeneration(IConfiguration config, IDapperManager dapperManager)
        {
            _config = config;
            this._dapperManager = dapperManager;
        }
        public async Task<List<NexopayPurpose>> GetPurpose(string Key)
        {
            var dbPara = new DynamicParameters();
            var Purpose = Task.FromResult(_dapperManager.GetAll<NexopayPurpose>("Select * from Nexopay_Purpose", Key, dbPara, commandType: CommandType.Text));
            return await Purpose;
        }

        public async Task<List<dtStudentRegister>> GetStudentListByClass(string Class, string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("Criteria", "GetPaymentStudentSearchListByClass", DbType.String);

            var StudentList = Task.FromResult(_dapperManager.GetAll<dtStudentRegister>("School_StudentCommonSP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<List<StudentData>> GetStudentData(int AccountID, string SchoolCode, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@ID", AccountID, DbType.Int32);
                var StudentFeeList = Task.FromResult(_dapperManager.GetAll<StudentData>("[OP_ReRegStudentData]", Key, dbPara, commandType: CommandType.StoredProcedure));
                return await StudentFeeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<long> SavePaymentRequest(OrderRequest orderReq, string SchoolCode, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("@schoolcode", orderReq.SchoolCode);
                    dbPara.Add("@student_id", orderReq.StudentID);
                    dbPara.Add("@order_date", (orderReq.OrderDate));
                    dbPara.Add("@parent_name", orderReq.Pt!.PFullName);
                    dbPara.Add("@parent_firstname", orderReq.Pt.PFirstName);
                    dbPara.Add("@parent_lastName", orderReq.Pt.PLastName);
                    dbPara.Add("@parent_email", orderReq.Pt.Email);
                    dbPara.Add("@parent_phoneno", orderReq.Pt.Phone);
                    dbPara.Add("@parent_dob", null);
                    dbPara.Add("@student_name", orderReq.St!.SFullName);
                    dbPara.Add("@student_firstname", orderReq.St.SFirstName);
                    dbPara.Add("@student_lastname", orderReq.St.SLastName);
                    dbPara.Add("@gender", orderReq.St.Gender);
                    dbPara.Add("@current_class", orderReq.St.CurrentClass);
                    dbPara.Add("@joining_grade", orderReq.St.JoiningGrade);
                    dbPara.Add("@registerno", orderReq.St.RegisterNo);
                    if (orderReq.St.DateOfJoin != DBNull.Value.ToString() || orderReq.St.DateOfJoin != "" || orderReq.St.DateOfJoin != "NULL")
                    {
                        dbPara.Add("@date_of_join", (orderReq.St.DateOfJoin));
                    }
                    else
                    {
                        dbPara.Add("@date_of_join", null);
                    }
                    if (orderReq.St.AdmissionDate != DBNull.Value.ToString() || orderReq.St.AdmissionDate != "" || orderReq.St.AdmissionDate != "NULL")
                    {
                        dbPara.Add("@admission_date", (orderReq.St.AdmissionDate));
                    }
                    else
                    {
                        dbPara.Add("@admission_date", null);
                    }

                    dbPara.Add("@nationality", orderReq.St.Nationality);
                    dbPara.Add("@invoice_number", null);
                    dbPara.Add("@invoice_amount", orderReq.Amount);
                    dbPara.Add("@request_str", orderReq.RequestStr);
                    dbPara.Add("@session_id", orderReq.SessionID);
                    dbPara.Add("@resp_session", orderReq.RespSession);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                    newID = _dapperManager.Insert("[NexoPay_InsertRequest]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public DbConnection GetConnection(string key)
        {
            Security security = new Security();
            return new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString(security.Decrypt(key)), "", true));
        }
    }
}
