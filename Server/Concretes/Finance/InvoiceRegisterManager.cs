using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    

    public class InvoiceRegisterManager : IInvoiceRegisterManager
    {
        private readonly IDapperManager _dapperManager;
        public InvoiceRegisterManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }
        public async Task<List<dtInvoiceRegister>> GetInvoice(string AcademicYear, int BranchID, string fromdate, string todate, string Con)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Datefrom", fromdate);
            dbPara.Add("@Dateto", todate);

            dbPara.Add("Criteria", "InvoiceMaster");

            var StudentList = Task.FromResult(_dapperManager.GetAll<dtInvoiceRegister>("[Col_InvoiceSPs]", Con, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }
        public async Task<long> post(dtInvoiceRegister value, string Con)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            dbPara.Add("DateFrom", value.From, DbType.DateTime);
            dbPara.Add("DateUpto", value.To, DbType.DateTime);
            dbPara.Add("InvoiceDate", value.Taxvoicedate, DbType.DateTime);
            dbPara.Add("AcademicYear", value.AcademicYear, DbType.String);
            dbPara.Add("Branchid", value.BranchID, DbType.Int32);
            newID = _dapperManager.Execute("[SchoolWeb_InvoiceGenerationSP]", Con, dbPara, commandType: CommandType.StoredProcedure);
            return newID;
        }

        public async Task<List<dtAdvanceReceiptRegister>> Getadvance(string AcademicYear, int BranchID, string fromdate, string todate, string Con)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            //dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Datefrom", fromdate);
            dbPara.Add("@Dateto", todate);
            var StudentList = Task.FromResult(_dapperManager.GetAll<dtAdvanceReceiptRegister>("[School_AdvanceReceiptReportSPnew]", Con, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }
        //public async Task<List<dtInvoiceRegister>> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("@BranchID", BranchID, DbType.Int32);
        //    dbPara.Add("@DateFrom", fromdate);
        //    dbPara.Add("@DateTo", todate);
        //    dbPara.Add("@invdate", invdate);
        //    dbPara.Add("@UserId", UserID, DbType.Int32);
        //    //dbPara.Add("@StudentID", AccountID, DbType.Int32);



        //    var StudentList = Task.FromResult(_dapperManager.GetAll<dtInvoiceRegister>("[SchoolWeb_CollectionInvoiceSP]", dbPara, commandType: CommandType.StoredProcedure));
        //    return await StudentList;
        //}
        public async Task<int> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string Con)
        {
            int newID = 0;
            var dbPara = new DynamicParameters();
            dbPara.Add("@Branchid", BranchID, DbType.Int32);
            dbPara.Add("@DateFrom", fromdate);
            dbPara.Add("@DateUpto", todate);
            dbPara.Add("@InvoiceDate", invdate);


            dbPara.Add("@UserId", UserID, DbType.Int32);
            //dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            //if (AccountID == 0)
            //{

            _dapperManager.Execute("[SchoolWeb_CollectionInvoiceSP]", Con, dbPara, commandType: CommandType.StoredProcedure);
            //}
            //else {

            //    _dapperManager.Execute("[SchoolWeb_CollectionInvoiceSPByastudent]", dbPara, Con, commandType: CommandType.StoredProcedure);

            //}
            return newID;
        }
        public async Task<int> collectedtax(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string CmbAccYear, string Key)
        {
            int newID = 0;
            var dbPara = new DynamicParameters();
            dbPara.Add("@Branchid", BranchID, DbType.Int32);
            dbPara.Add("@DateFrom", fromdate);
            dbPara.Add("@DateUpto", todate);
            dbPara.Add("@InvoiceDate", invdate);
            dbPara.Add("AcademicYear", CmbAccYear, DbType.String);


            ////dbPara.Add("@UserId", UserID, DbType.Int32);
            //dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            //if (AccountID == 0)
            //{
            _dapperManager.Execute("[SchoolWeb_InvoiceGenerationSP]", Key, dbPara, commandType: CommandType.StoredProcedure);

            ////_dapperManager.Execute("[SchoolWeb_CollectionInvoiceSP]", Con, dbPara, commandType: CommandType.StoredProcedure);
            //}
            //else {

            //    _dapperManager.Execute("[SchoolWeb_CollectionInvoiceSPByastudent]", dbPara, Con, commandType: CommandType.StoredProcedure);

            //}
            return newID;
            //public  Task<CceElectiveSubjectChild> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID)
            //{
            //    try
            //    {
            //        var dbPara = new DynamicParameters();
            //        dbPara.Add("@BranchID", BranchID, DbType.Int32);
            //        dbPara.Add("@DateFrom", fromdate);
            //        dbPara.Add("@DateTo", todate);
            //        dbPara.Add("@invdate", invdate);
            //        dbPara.Add("@UserId", UserID, DbType.Int32);

            //        var Items = Task.FromResult(_dapperManager.Get<dtInvoiceRegister>("[SchoolWeb_CollectionInvoiceSP]", dbPara, commandType: CommandType.StoredProcedure));
            //        //return await Items;
            //    }
            //    catch (Exception e)
            //    {
            //        throw e;
            //    }
            //}

        }

            public async Task<List<dtInvoiceRegister>> GetInvoices(string AcademicYear, int BranchID, string fromdate, string todate, string Con)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Datefrom", fromdate);
            dbPara.Add("@Dateto", todate);
            dbPara.Add("Criteria", "InvoiceMasters");

            var StudentList = Task.FromResult(_dapperManager.GetAll<dtInvoiceRegister>("[Col_InvoiceSPs]", Con, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

       
    }
}


