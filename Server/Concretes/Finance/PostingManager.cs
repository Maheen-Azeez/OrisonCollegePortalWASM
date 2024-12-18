using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using SecurityService;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using OrisonCollegePortal.Server.Contracts;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class PostingManager : IPostingManager
    {
        private IVoucherManager _Vrepository;
        private IVoucherEntryManager _VErepository;
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;
        ObservableCollection<dtVoucherEntry> objvoucher = new ObservableCollection<dtVoucherEntry>();

        public PostingManager(IDapperManager dapperManager, IConfiguration config, IVoucherManager vrepository, IVoucherEntryManager VErepository)
        {
            this._dapperManager = dapperManager;
            _Vrepository = vrepository;
            _VErepository = VErepository;
            _config = config;

        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task<int> GetVtype(string vtype, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Vtype", vtype, DbType.String);
            var Vouchertype = Task.FromResult(_dapperManager.Get<int>($"SELECT ID FROM VTypeTran WHERE VType=@Vtype", key, dbPara, commandType: CommandType.Text));
            return Vouchertype;

        }
        public async Task<long> poststudentdata(dtPostClass value, string Key)
        {
            long newID;
            //using IDbConnection db = GetConnection(Con);

            try
            {


                dtStudentParam Param = value.ParamEnrty!;

                //if (db.State == ConnectionState.Closed) db.Open();

                //using var tran = db.BeginTransaction();
                try
                {


                    var dbPara = new DynamicParameters();
                    //dbPara.Add("@Criteria", Param.Criteria);
                    dbPara.Add("@AcademicYear", Param.AcademicYear, DbType.String);
                    dbPara.Add("@Branchid", Param.Branchid, DbType.Int32);

                    dbPara.Add("@AccountID", Param.AccountID, DbType.Int32);

                    dbPara.Add("@Amount", Param.Amount, DbType.Decimal);

                    dbPara.Add("@UserID", Param.Description, DbType.Int32);


                    dbPara.Add("@Type", Param.Criteria, DbType.String);

                    //dbPara.Add("@FromDate", Param.FromDate, DbType.DateTime);
                    //dbPara.Add("@ToDate", Param.ToDate, DbType.DateTime);
                    dbPara.Add("@PostingDate", Param.VDate, DbType.DateTime);



                    dbPara.Add("@ScheduleName", Param.Schedule, DbType.String);

                    //newID = await db.ExecuteAsync("[SchoolWeb_StudentPost]", dbPara, tran, null, CommandType.StoredProcedure);
                    _dapperManager.Execute("[Col_StudentPost]", Key, dbPara, commandType: CommandType.StoredProcedure);

                    //tran.Commit();
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                //if (db.State == ConnectionState.Open)
                //    db.Close();
            }
            return 0;
        }

        public Task<int> getUniqueAccID(string Value, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Value", Value, DbType.String);
            var ack = Task.FromResult(_dapperManager.Get<int>($"SELECT AccID FROM  UniqueAccounts  WHERE Keyword=@Value", Key, dbPara, commandType: CommandType.Text));
            return ack;

        }

        public async Task<long>? Postallindividual(int AccountID, int BranchID, string Criteria, string CmbAccYear, string StatementFromDate, string StatementEndDate, string Key)
        {
            try
            {
                long newID = 0;
                var dbPara = new DynamicParameters();
                dbPara.Add("@AccountId", AccountID);
                dbPara.Add("@Branchid", BranchID, DbType.Int32);

                dbPara.Add("@Criteria", Criteria);
                dbPara.Add("@AcademicYear", CmbAccYear);

                dbPara.Add("@FromDate", StatementFromDate, DbType.DateTime);

                dbPara.Add("@ToDate", StatementEndDate, DbType.DateTime);



                newID = _dapperManager.Execute("[Col_IndividualPost]", Key, dbPara, commandType: CommandType.StoredProcedure);


                return newID;
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        public async Task<long>? Bulkpost(int UserID, int BranchID, string Type, string Class, string CmbAccYear, string FromDate, string ToDate, string Key)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            dbPara.Add("@UserID", UserID);
            dbPara.Add("@Branchid", BranchID, DbType.Int32);

            dbPara.Add("@Type", Type);
            dbPara.Add("@Class", Class);

            dbPara.Add("@AcademicYear", CmbAccYear);

            dbPara.Add("@FromDate", FromDate, DbType.DateTime);

            dbPara.Add("@ToDate", ToDate, DbType.DateTime);



            newID = _dapperManager.Execute("[]", Key, dbPara, commandType: CommandType.StoredProcedure);


            return newID;
        }

        public async Task<List<SchoolTaxInvoicedt>?> Getdatas(int BranchID, string AcademicYear, int AccountID, string Key)
        {
            var dbPara = new DynamicParameters();
            //dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@AccountID", AccountID, DbType.String);

            var StudentList = Task.FromResult(_dapperManager.GetAll<SchoolTaxInvoicedt>("[School_InvoiceTaxSPspbyid]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<List<SchoolTaxInvoicedt>?> Getdatass(int BranchID, string AcademicYear, int AccountID, string Key)
        {
            var dbPara = new DynamicParameters();
            //dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@AccountID", AccountID, DbType.String);
            dbPara.Add("Criteria", "FillTaxInvoiceMasters");


            var StudentList = Task.FromResult(_dapperManager.GetAll<SchoolTaxInvoicedt>("[School_InvoiceTaxSPsp]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }
        public async Task<long> Invoicegeneration(int AccountID, int BranchID, string CmbAccYear, string Taxvoicedate, string StatementFromDate, string StatementEndDate, string Key)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            dbPara.Add("@Studentid", AccountID);
            dbPara.Add("@Branchid", BranchID, DbType.Int32);

            dbPara.Add("@AcademicYear", CmbAccYear);
            dbPara.Add("@InvoiceDate", Taxvoicedate, DbType.DateTime);

            dbPara.Add("@DateFrom", StatementFromDate, DbType.DateTime);

            dbPara.Add("@DateUpto", StatementEndDate, DbType.DateTime);



            newID = _dapperManager.Execute("[SchoolWeb_InvoiceGenerationSPStudent]", Key, dbPara, commandType: CommandType.StoredProcedure);


            return newID;
        }
        public Task<int> FeePostChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string FeeSchedule, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@AccountId", AccountId, DbType.String);
            dbPara.Add("@Vtype", vtype, DbType.String);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@Schedule", FeeSchedule, DbType.String);

            var feepost = Task.FromResult(_dapperManager.Get<int>("[SchoolWeb_FeePostChecking]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return feepost;
        }
        public Task<int> FeeAllocChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@AccountId", AccountId, DbType.Int32);
            dbPara.Add("@Vtype", vtype, DbType.Int32);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            var allocexist = Task.FromResult(_dapperManager.Get<int>("[Col_FeeAllocChecking]", Key, dbPara, commandType: CommandType.StoredProcedure));

            return allocexist;
        }
        public Task<int> FeeAllocCheckingClassWise(string Class, int vtype, string fromdate, string todate, string Type, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@Vtype", vtype, DbType.Int32);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var allocexist = Task.FromResult(_dapperManager.Get<int>("[SchoolWeb_FeeAllocCheckingClassWise]", Key, dbPara, commandType: CommandType.StoredProcedure));

            return allocexist;
        }

        public async Task<List<dtFeeSchedule>?> GetFeeSchedule(string AcademicYear, int BranchID, String Code, string fromdate, string todate, string Type, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Code", Code, DbType.String);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            var FeeScheduleList = Task.FromResult(_dapperManager.GetAll<dtFeeSchedule>("[Col_GetFeeSchedule]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await FeeScheduleList;
        }

        public async Task<List<dtStudentRegister>?> GetStudentsDetails(string AcademicYear, int BranchID, string Class, string Type, string fromdate, string todate, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            var List = Task.FromResult(_dapperManager.GetAll<dtStudentRegister>("[SchoolWeb_GetPostingStudents]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await List;
        }



        public async Task<dtFeeSchedule> GetAddFees(int FeeId, string AcademicYear, int BranchID, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@FeeId", FeeId, DbType.Int32);
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                var FeeScheduleList = Task.FromResult(_dapperManager.Get<dtFeeSchedule>("[SchoolWeb_GetAddFees]", Key, dbPara, commandType: CommandType.StoredProcedure));
                return await FeeScheduleList;
            }

            catch (Exception e)

            {
                Console.WriteLine(e);
                throw ; }

        }


        public async Task<List<dtAdditionalFee>?> GetAdditionalFee(string AcademicYear, string Type, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var FeeScheduleList = Task.FromResult(_dapperManager.GetAll<dtAdditionalFee>("[Col_AdditionalFees]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await FeeScheduleList;
        }
        public async Task<dtStudentFeeSummary> GetFeeSummary(int AccountId, int BranchID, String AcademicYear, string Key)
        {

            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@AccountId", AccountId, DbType.Int32);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                var FeeSummary = Task.FromResult(_dapperManager.Get<dtStudentFeeSummary>("[Col_FeeSummary]", Key, dbPara, commandType: CommandType.StoredProcedure));
                return await FeeSummary;
            }
            catch (Exception e)

            {
                Console.WriteLine(e);
                throw; }
        }
        public async Task<List<AdditionalSchedule>?> GetAdditionalSchedules(int BranchID, string AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var Fee = Task.FromResult(_dapperManager.GetAll<AdditionalSchedule>("SELECT ID,FeeSchedule FROM School_FeeSchedule where type='General' and AcademicYear=@AcademicYear and BranchID=@BranchID  ORDER BY FeeSchedule", Key, dbPara, commandType: CommandType.Text));
            return await Fee;
        }
        public async Task<List<dtStudentFeeDetails>?> GetFeeDetails(int AccountId, int BranchID, String AcademicYear, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@AccountId", AccountId, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var FeeDetails = Task.FromResult(_dapperManager.GetAll<dtStudentFeeDetails>("[SchoolWeb_FeeDetails]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await FeeDetails;
        }
        public async Task<List<SchoolDiscountSchedule>?> GetDiscountSchedule(int BranchID, String Schedule, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Schedule", Schedule, DbType.String);
            var DiscountcheduleList = Task.FromResult(_dapperManager.GetAll<SchoolDiscountSchedule>("[School_GetDiscountSchedule]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await DiscountcheduleList;
        }



        public async Task<long> CreatePostingVoucher(dtsVoucher v, string Con)
        {
            long newID = 0;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    foreach (dtPostingVoucher dt in v.objpostvoucherTemp!)
                    {
                        dtVoucher vou = new dtVoucher();
                        vou.EffectiveDate = dt.DueDate;
                        vou.VDate = dt.DueDate;
                        vou.DueDate = dt.DueDate;
                        vou.CreatedDate = DateTime.Today;
                        vou.ModifiedDate = DateTime.Today;
                        vou.Remark = dt.Remark;
                        vou.VType = dt.VType;
                        vou.BranchID = dt.BranchID;
                        vou.RefNo = dt.RefNo;
                        vou.AccountID = dt.AccountID;
                        vou.CommonNarration = dt.Description;
                        vou.VoucherAgainst = dt.VoucherAgainst;
                        vou.PreparedBy = dt.PreparedBy;
                        vou.VATAmt = Math.Round(dt.VATAmt ?? 0m, 2); ;
                        if (!(dt.DisApplicable == true) && dt.VatApplicable == true && !(dt.VatInc == true))
                        {
                            vou.Amount = dt.Amount + dt.VATAmt;
                        }
                        else
                        {

                            vou.Amount = Math.Round(dt.Amount ?? 0m, 2);


                        }
                        //vou.Amount = dt.Amount;
                        vou.IsCanceled = Convert.ToBoolean(0);
                        vou.Posted = Convert.ToBoolean(1);
                        vou.CreatedUserID = dt.CreatedUserID;
                        vou.ModifiedUserID = dt.ModifiedUserID;
                        vou.ExchangeRate = dt.ExchangeRate;
                        vou.Currency = dt.Currency;
                        vou.RowState = dt.RowState;
                        newID = await _Vrepository.VoucherEvent(vou, db, tran);
                        objvoucher.Clear();

                        dtVoucherEntry objVEntCr = new dtVoucherEntry();
                        objVEntCr.VID = newID;
                        objVEntCr.RowType = "Cr";
                        objVEntCr.Description = dt.Description;
                        if (dt.DisApplicable == true)
                        //{ objVEntDr.Reference = "StudentFeeDiscount"; }
                        { objVEntCr.Reference = "StudentFeeDiscount"; }
                        else
                        {
                            objVEntCr.Reference = dt.Amount.ToString();
                        }
                        objVEntCr.AccountID = dt.VECAccountID;
                        objVEntCr.PostingSubCode = dt.VEDAccountID.ToString();
                        objVEntCr.TaxCode = dt.TaxCode;
                        objVEntCr.DocSubNo = dt.DocSubNo;
                        if (!(dt.DisApplicable == true) && dt.VatApplicable == true && (dt.VatInc == true))
                        {
                            objVEntCr.Credit = Math.Round(dt.Amount ?? 0m, 2) - Math.Round(dt.VEVAmount ?? 0m, 2);
                        }
                        else
                        {
                            objVEntCr.Credit = Math.Round(dt.Amount ?? 0m, 2);
                        }

                        objVEntCr.Debit = 0;
                        objVEntCr.TranType = "Sub";
                        objVEntCr.Action = "C";
                        objVEntCr.VisibleonPrint = Convert.ToBoolean(1);
                        objVEntCr.Reconciled = Convert.ToBoolean(0);
                        objVEntCr.Active = Convert.ToBoolean(1);
                        objVEntCr.RowState = "Insert";

                        objVEntCr.SlNo = 1;
                        objvoucher.Add(objVEntCr);
                        dtVoucherEntry objVEntDr = new dtVoucherEntry();
                        objVEntDr.VID = newID;
                        objVEntDr.RowType = "Dr";
                        objVEntDr.Description = dt.Description;

                        objVEntDr.AccountID = dt.VEDAccountID;
                        objVEntDr.PostingSubCode = dt.VECAccountID.ToString();
                        objVEntDr.TaxCode = dt.TaxCode;
                        if (dt.DisApplicable == true)
                        { objVEntDr.Reference = "StudentFeeDiscount"; }
                        else
                        {
                            objVEntDr.Reference = dt.Amount.ToString();
                        }
                        objVEntDr.DocSubNo = dt.DocSubNo;


                        objVEntDr.Credit = 0;
                        if (!(dt.DisApplicable == true) && dt.VatApplicable == true && !(dt.VatInc == true))
                        {
                            objVEntDr.Debit = Math.Round(dt.Amount ?? 0m, 2) + Math.Round(dt.VATAmt ?? 0m, 2);
                        }
                        else
                        {
                            objVEntDr.Debit = Math.Round(dt.Amount ?? 0m, 2);
                        }
                        //objVEntDr.Debit = dt.Amount;
                        if (dt.DisApplicable == true)
                        { objVEntDr.TranType = "Main"; }
                        else { objVEntDr.TranType = "Normal"; }
                        objVEntDr.Action = "C";
                        objVEntDr.VisibleonPrint = Convert.ToBoolean(1);
                        objVEntDr.Reconciled = Convert.ToBoolean(0);
                        objVEntDr.Active = Convert.ToBoolean(1);
                        objVEntDr.RowState = "Insert";

                        objVEntDr.SlNo = 0;

                        objvoucher.Add(objVEntDr);

                        if (dt.VatApplicable == true)
                        {
                            dtVoucherEntry objVEntVat = new dtVoucherEntry();
                            objVEntVat.VID = newID;
                            objVEntVat.RowType = "Cr";
                            objVEntVat.Description = dt.Description;
                            objVEntVat.AccountID = dt.VEVAccountID;
                            objVEntVat.Credit = Math.Round(dt.VEVAmount ?? 0m, 2);
                            objVEntVat.Debit = 0;

                            objVEntVat.TranType = "Normal";
                            objVEntVat.Reference = "Vat";
                            objVEntVat.Action = "C";
                            objVEntVat.VisibleonPrint = Convert.ToBoolean(1);
                            objVEntVat.Reconciled = Convert.ToBoolean(0);
                            objVEntVat.Active = Convert.ToBoolean(1);
                            objVEntVat.TaxCode = dt.TaxCode;
                            objVEntVat.DocSubNo = dt.DocSubNo;
                            objVEntVat.RowState = "Insert";

                            objVEntVat.SlNo = 2;

                            objvoucher.Add(objVEntVat);
                        }
                        long VEntryID = 0;
                        foreach (dtVoucherEntry dtv in objvoucher)
                        {
                            if (VEntryID == 0)
                            {
                                dtv.RefID = null;
                            }
                            else
                            {
                                dtv.RefID = VEntryID;
                            }

                            VEntryID = await _VErepository.VoucherEntryEvents(dtv, db, tran);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
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

        public async Task<long> DeletePostingVoucher(dtsVoucher v, string Con)
        {
            long newID = 0;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    dtDeleteVoucher vd = v.objdepostvoucherTemp!;
                    await _Vrepository.DepostVoucher(vd, db, tran, Con);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);

                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
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
        public async Task<long> DeletePostingVoucherClass(dtsVoucher v, string Con)
        {
            long newID = 0;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    dtDeleteVoucher vd = v.objdepostvoucherTemp!;
                    await _Vrepository.DepostVoucherClass(vd!, db, tran);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }



        public Task<List<SchoolDiscountSchedule>> GetDiscountchedule(int BranchID, string Schedule)
        {
            throw new NotImplementedException();
        }


        //Update FeeAmount
        public void UpdateFeeAmount(dtsVoucher vo, string Con)
        {
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    dtVoucher bm = vo.voucher!;
                    //voucher
                    _Vrepository.UpdateFeeAmount(bm!, db, tran);
                    //voucher entry
                    dtVoucherEntry VE = vo.voucherentry!;
                    VE.VID = bm.ID;
                    _VErepository.UpdateFeeAmountVE(VE, db, tran);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            //return newID;
        }

        public async Task<bool>? DeleteFeeAmount(int ID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", ID, DbType.Int32);
            dbPara.Add("Criteria", "DeleteVoucher", DbType.String);

            using IDbConnection db = GetConnection(Key);
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
                try
                {
                    _dapperManager.Execute("[VoucherUpdate]", Key, dbPara, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw ;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return true;


        }
        //
        //save AdditionalFee
        public async Task<long>? CreateAdditionalFee(SchoolAdditionalPayment dt, string Con)
        {
            long newID;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("AccountId", dt.AccountId, DbType.Int32);
                    dbPara.Add("Activity", dt.Activity, DbType.String);
                    dbPara.Add("FromDate", dt.FromDate, DbType.DateTime);
                    dbPara.Add("ToDate", dt.ToDate, DbType.DateTime);
                    dbPara.Add("Amount", dt.Amount, DbType.Decimal);
                    dbPara.Add("Posted", dt.Posted, DbType.Binary);
                    dbPara.Add("PostTo", dt.PostTo, DbType.Int32);
                    dbPara.Add("Remarks", dt.Remarks, DbType.String);
                    dbPara.Add("Repeat", dt.Repeat, DbType.Int32);
                    dbPara.Add("VoucherId", dt.VoucherId, DbType.String);
                    dbPara.Add("Type", dt.Type, DbType.String);
                    dbPara.Add("SupEndDate", dt.SupEndDate, DbType.DateTime);

                    dbPara.Add("Criteria", "InsertAdditionalFee", DbType.String);
                    dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    newID = _dapperManager.Insert("[VoucherUpdate]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;

        }

        public void UpdateAdditionalFee(SchoolAdditionalPayment dt, string Con)
        {
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {

                    var dbPara = new DynamicParameters();

                    dbPara.Add("ID", dt.Id, DbType.Int64);
                    dbPara.Add("Amount", dt.Amount, DbType.Decimal);

                    dbPara.Add("Criteria", "UpdateAdditionalFee", DbType.String);

                    _dapperManager.UpdateTablev("[VoucherUpdate]", dbPara, db, tran, commandType: CommandType.StoredProcedure);


                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

        }

        public async Task<List<SchoolTaxInvoicedt>?> GetSchoolTaxInvoice(string AcademicYear, int ID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@Accountid", ID, DbType.Int32);

            dbPara.Add("Criteria", "FillTaxInvoiceMasterStudent");

            var StudentList = Task.FromResult(_dapperManager.GetAll<SchoolTaxInvoicedt>("[School_InvoiceTaxSP]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }
        public void UpdateCollection(SchoolTaxInvoicedt Collected, string Con)
        {
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {

                    var dbPara = new DynamicParameters();

                    dbPara.Add("@UserID", Collected.UserID, DbType.Int32);
                    dbPara.Add("@StudentID", Collected.id, DbType.Int32);
                    dbPara.Add("@BranchID", Collected.BranchID, DbType.Int32);
                    dbPara.Add("@invdate", Collected.invoicedate, DbType.DateTime);
                    dbPara.Add("@DateFrom", Collected.FromDate, DbType.DateTime);
                    dbPara.Add("@DateTo", Collected.ToDate, DbType.DateTime);

                    _dapperManager.Execute("[SchoolWeb_CollectionInvoiceSPStudent]", Con, dbPara, commandType: CommandType.StoredProcedure);


                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public void UpdateInvoice(SchoolTaxInvoicedt Invoice, string Con)
        {
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {

                    var dbPara = new DynamicParameters();

                    dbPara.Add("@Studentid", Invoice.id, DbType.Int32);
                    dbPara.Add("@Branchid", Invoice.BranchID, DbType.Int32);
                    dbPara.Add("@InvoiceDate", Invoice.invoicedate, DbType.DateTime);
                    dbPara.Add("@DateFrom", Invoice.FromDate, DbType.DateTime);
                    dbPara.Add("@DateUpto", Invoice.ToDate, DbType.DateTime);
                    dbPara.Add("@AcademicYear", Invoice.AcademicYear, DbType.String);

                    _dapperManager.Execute("[SchoolWeb_InvoiceGenerationSPStudent]", Con, dbPara, commandType: CommandType.StoredProcedure);


                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }


        //
        public async Task<long> PostBulkData(dtPostClass value, string Key)
        {
            long newID;
            //using IDbConnection db = GetConnection(Con);

            try
            {

                List<dtBulkPost> StudentList = value.BulkPostEnrty!;
                dtStudentParam Param = value.ParamEnrty!;
                DataTable dt = ToDataTable(StudentList);

                //if (db.State == ConnectionState.Closed) db.Open();

                //using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("@Criteria", Param.Criteria);
                    dbPara.Add("@AcademicYear", Param.Remark, DbType.String);
                    dbPara.Add("@Branchid", Param.Branchid, DbType.Int32);
                    dbPara.Add("@Date", Param.VDate, DbType.DateTime);
                    dbPara.Add("@Amount", Param.Amount, DbType.Decimal);
                    dbPara.Add("@FeeType", Param.CommonNarration, DbType.String);
                    dbPara.Add("@Description", Param.Description, DbType.String);
                    dbPara.Add("@PaymentmodeCode", Param.PaymentmodeCode, DbType.String);
                    dbPara.Add("@FeetypeCode", Param.FeetypeCode, DbType.String);
                    dbPara.Add("@Student", dt.AsTableValuedParameter("BulkPostStudent"));

                   // newID = await db.ExecuteAsync("[SchoolWeb_BulkpostStudents]", dbPara, tran, null, CommandType.StoredProcedure);
                    _dapperManager.Execute("[SchoolWeb_BulkpostStudents]", Key, dbPara, commandType: CommandType.StoredProcedure);

                    //tran.Commit();
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                //if (db.State == ConnectionState.Open)
                //    db.Close();
            }
            return 0;
        }

        public async Task<long> postallbulkdata(dtPostClass value, string Key)
        {
            long newID;
            //using IDbConnection db = GetConnection(Con);

            try
            {

                List<dtBulkPost> StudentList = value.BulkUnallocated!;
                dtStudentParam Param = value.ParamEnrty!;
                DataTable dt = ToDataTable(StudentList);

                //if (db.State == ConnectionState.Closed) db.Open();

                //using var tran = db.BeginTransaction();
                try
                {


                    var dbPara = new DynamicParameters();
                    //dbPara.Add("@Criteria", Param.Criteria);
                    dbPara.Add("@AcademicYear", Param.AcademicYear, DbType.String);
                    dbPara.Add("@Branchid", Param.Branchid, DbType.Int32);

                    dbPara.Add("@Type", Param.Criteria, DbType.String);

                    dbPara.Add("@FromDate", Param.FromDate, DbType.DateTime);
                    dbPara.Add("@ToDate", Param.ToDate, DbType.DateTime);
                    dbPara.Add("@PostingDate", Param.VDate, DbType.DateTime);

                    dbPara.Add("@Class", Param.Remark, DbType.String);
                    dbPara.Add("@Amount", Param.Amount, DbType.Decimal);


                    dbPara.Add("@UserID", Param.Description, DbType.Int32);

                    dbPara.Add("@ScheduleName", Param.Schedule, DbType.String);
                    dbPara.Add("@Student", dt.AsTableValuedParameter("BulkPostStudent"));

                    //newID = await db.ExecuteAsync("[SchoolWeb_BulkGeneralPost]", dbPara, tran, null, CommandType.StoredProcedure);
                    _dapperManager.Execute("[SchoolWeb_BulkGeneralPost]", Key, dbPara, commandType: CommandType.StoredProcedure);

                    //tran.Commit();
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                //if (db.State == ConnectionState.Open)
                //    db.Close();
            }
            return 0;
        }



        public async Task<long> PostUnallocateData(dtPostClass value, string Con)
        {
            long newID;
            using IDbConnection db = GetConnection(Con);

            try
            {

                List<dtBulkPost> StudentList = value.BulkUnallocated!;
                dtStudentParam Param = value.ParamEnrty!;
                DataTable dt = ToDataTable(StudentList);

                if (db.State == ConnectionState.Closed) db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("@Branchid", Param.Branchid, DbType.Int32);
                    dbPara.Add("@FromDate", Param.FromDate, DbType.DateTime);
                    dbPara.Add("@ToDate", Param.ToDate, DbType.DateTime);
                    dbPara.Add("@AcademicYear", Param.AcademicYear, DbType.String);
                    dbPara.Add("@Schedule", Param.Schedule, DbType.String);
                    dbPara.Add("@Type", Param.Criteria);
                    dbPara.Add("@Student", dt.AsTableValuedParameter("BulkPostStudentUnallocate"));

                    newID = await db.ExecuteAsync("[SchoolWEB_VoucherDepostUnallocated]", dbPara, tran, null, CommandType.StoredProcedure);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return 0;
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null)!;
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public async Task<List<dtBulkPost>?> GetMassPosting(int BranchID, string AcademicYear, string FromDate, string ToDate, string Schedule, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@StartDate", FromDate, DbType.DateTime);
            dbPara.Add("@EndDate", ToDate, DbType.DateTime);
            dbPara.Add("@Schedule", Schedule, DbType.String);
            dbPara.Add("@Type", "GetMassPosting");
            var FeeScheduleList = Task.FromResult(_dapperManager.GetAll<dtBulkPost>("[SchoolWEB_VoucherDepostSPClass]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await FeeScheduleList;
        }

        public async Task<long>? BulkPostAll(dtsVoucher v, string Key)
        {
            long newID = 0;
            //using IDbConnection db = GetConnection(Key);


            try
            {
                //if (db.State == ConnectionState.Closed)
                //    db.Open();
                dtParam Param = v.ParamEnrty!;

                //using var tran = db.BeginTransaction();
                try
                {

                    var dbPara = new DynamicParameters();
                    dbPara.Add("FromDate", Param.FromDate, DbType.String);
                    dbPara.Add("ToDate", Param.ToDate, DbType.String);
                    dbPara.Add("Type", Param.Type, DbType.String);
                    dbPara.Add("Class", Param.Class, DbType.String);

                    dbPara.Add("BranchId", Param.BranchID, DbType.Int32);
                    dbPara.Add("UserID", Param.UserID, DbType.Int32);
                    dbPara.Add("AcademicYear", Param.AcademicYear, DbType.String);
                    _dapperManager.Execute("[SchoolWeb_BulkPost]", Key, dbPara, commandType: CommandType.StoredProcedure);


                    //tran.Commit();
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                //if (db.State == ConnectionState.Open)
                //    db.Close();
            }
            return newID;
        }
        public async Task<long>? MassDepost(dtsVoucher value, string Con)
        {
            long newID = 0;
            using IDbConnection db = GetConnection(Con);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    List<dtBulkPost> Md = value.MassDepost!;
                    dtDeleteVoucher vd = value.objdepostvoucherTemp!;
                    DataTable dt = ToDataTable(Md);


                    var dbPara = new DynamicParameters();
                    dbPara.Add("ID", vd.AccountId, DbType.Int32);
                    dbPara.Add("AcademicYear", vd.AcademicYear, DbType.Int32);
                    dbPara.Add("StartDate", vd.StartDate, DbType.String);
                    dbPara.Add("EndDate", vd.EndDate, DbType.String);
                    dbPara.Add("Type", vd.Schedule, DbType.String);
                    dbPara.Add("BranchID", vd.BranchID, DbType.String);

                    _dapperManager.Execute("[]", Con, dbPara, commandType: CommandType.StoredProcedure);
                    return newID;


                    //tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }
    }
}
