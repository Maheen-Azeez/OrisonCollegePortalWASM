using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    
    public class SchoolTaxInvoiceManager : ISchoolTaxInvoiceManager
    {
        private readonly IDapperManager _dapperManager;
        public SchoolTaxInvoiceManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }
        public async Task<List<SchoolTaxInvoicedt>> GetSchoolTaxInvoice(string AcademicYear, int BranchID, string Con)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            dbPara.Add("Criteria", "FillTaxInvoiceMaster");

            var StudentList = Task.FromResult(_dapperManager.GetAll<SchoolTaxInvoicedt>("[School_InvoiceTaxSPsp]", Con, dbPara,  commandType: CommandType.StoredProcedure));
            return await StudentList;
        }
        public async Task<List<SchoolTaxInvoicedt>> get(int id, string AcademicYear,int BranchID, string Con)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", id, DbType.Int32);
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);

                //dbPara.Add("Criteria", "FillTaxInvoiceTrans");
                dbPara.Add("Criteria", "TaxRegisterbyid");

                var StudentList = Task.FromResult(_dapperManager.GetAll<SchoolTaxInvoicedt>("[School_InvoiceTaxSPsp]", Con, dbPara, commandType: CommandType.StoredProcedure));
                return await StudentList;
            }
            catch (Exception e)
            {

                throw e;
            }

           
        }

        public async Task<SchoolTaxInvoicedt> Getdata(string AcademicYear, int id, string Con)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                dbPara.Add("@id", id, DbType.Int32);
                dbPara.Add("criteria", "getbyid", DbType.String);

                var Items = Task.FromResult(_dapperManager.Get<SchoolTaxInvoicedt>("[School_InvoiceTaxSPsp]", Con, dbPara, commandType: CommandType.StoredProcedure));
                return await Items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw ;
            }
        }

        public async Task<List<dtStudentStatement>> GetTaxInvoiceStatement(string AccountCode, string AcademicYear, string StartDate, string EndDate, int BranchID, string Con)
        {
            try
            {

                var dbPara = new DynamicParameters();
                dbPara.Add("@AccountCode", AccountCode, DbType.String);
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                dbPara.Add("@DateFrom", StartDate, DbType.String);
                dbPara.Add("@DateUpto", EndDate, DbType.String);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);

                var TaxStatmnt = Task.FromResult(_dapperManager.GetAll<dtStudentStatement>("[TaxInvoiceStatement]", Con, dbPara, commandType: CommandType.StoredProcedure));
                return await TaxStatmnt;
            }
            catch (Exception e) { Console.WriteLine(e.Message); return null!; }
        }
    }
}
