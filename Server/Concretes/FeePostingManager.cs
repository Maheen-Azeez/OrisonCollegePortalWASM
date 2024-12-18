using Dapper;
using Microsoft.Data.SqlClient;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities;
using System.Collections.ObjectModel;
using System.Data;
using OrisonCollegePortal.Server.Contracts;

namespace OrisonCollegePortal.Server.Concretes
{
    public class FeePostingManager : IFeePostingManager
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;
        private IVoucherEntryManager _VErepository;
        ObservableCollection<dtVoucherEntry> objvoucher = new ObservableCollection<dtVoucherEntry>();

        public FeePostingManager(IDapperManager dapperManager, IConfiguration configuration, IVoucherEntryManager voucherEntry)
        {
            _dapperManager = dapperManager;
            _config = configuration;
            _VErepository = voucherEntry;
        }
        public async Task<List<CollegeClass>> GetOtherFee(string AcademicYear, int BranchID,string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Admission = Task.FromResult(_dapperManager.GetAll<CollegeClass>("SELECT * FROM COL_FeeSchedule where Type <> 'CourseFee' and Type <> 'Transportation'  and Type <> 'TransportationFee' and Type <> 'Admission' and Type <> 'AdmissionFee' and Branchid=@branchid ORDER BY FeeSchedule", Key, dbPara, commandType: CommandType.Text));
            return await Admission;
        }
        public async Task<long> CreatePostingVoucher(dtsVoucher v,string Key)
        {
            long newID = 0;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = _dapperManager.GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    foreach (dtPostingVoucher dt in v.objpostvoucherTemp)
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
                        vou.VATAmt = dt.VATAmt;
                        if (!(dt.DisApplicable == true) && dt.VatApplicable == true && !(dt.VatInc == true))
                        {
                            vou.Amount = dt.Amount + dt.VATAmt;
                        }
                        else
                        {
                            vou.Amount = dt.Amount;
                        }
                        //vou.Amount = dt.Amount;
                        vou.IsCanceled = Convert.ToBoolean(0);
                        vou.Posted = Convert.ToBoolean(1);
                        vou.CreatedUserID = dt.CreatedUserID;
                        vou.ModifiedUserID = dt.ModifiedUserID;
                        vou.ExchangeRate = dt.ExchangeRate;
                        vou.Currency = dt.Currency;
                        vou.RowState = dt.RowState;
                        newID = await _VErepository.VoucherEvent(vou,Key, db, tran);
                        objvoucher.Clear();


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
                            objVEntDr.Debit = dt.Amount + dt.VATAmt;
                        }
                        else
                        {
                            objVEntDr.Debit = dt.Amount;
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
                        dtVoucherEntry objVEntCr = new dtVoucherEntry();
                        objVEntCr.VID = newID;
                        objVEntCr.RowType = "Cr";
                        objVEntCr.Description = dt.Description;
                        if (dt.DisApplicable == true)
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
                            objVEntCr.Credit = dt.Amount - dt.VEVAmount;
                        }
                        else
                        {
                            objVEntCr.Credit = dt.Amount;
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
                        if (dt.VatApplicable == true)
                        {
                            dtVoucherEntry objVEntVat = new dtVoucherEntry();
                            objVEntVat.VID = newID;
                            objVEntVat.RowType = "Cr";
                            objVEntVat.Description = dt.Description;
                            objVEntVat.AccountID = dt.VEVAccountID;
                            objVEntVat.Credit = dt.VEVAmount;
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

            return newID;
        }

        public async Task<long> DeletePostingVoucher(dtsVoucher v, string Key)
        {
            long newID = 0;
            using IDbConnection db = _dapperManager.GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    dtDeleteVoucher vd = v.objdepostvoucherTemp;
                    await _VErepository.DepostVoucher(vd,Key, db, tran);


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

            return newID;
        }

        public Task<int> FeeAllocChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type,string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@AccountId", AccountId, DbType.Int32);
            dbPara.Add("@Vtype", vtype, DbType.Int32);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            var allocexist = Task.FromResult(_dapperManager.Get<int>("[COL_FeeAllocChecking]", Key, dbPara, commandType: CommandType.StoredProcedure));

            return allocexist;
        }

        public Task<int> FeePostChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Remark, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@AccountId", AccountId, DbType.String);
            dbPara.Add("@Vtype", vtype, DbType.String);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@Remark", Remark, DbType.String);
            var feepost = Task.FromResult(_dapperManager.Get<int>("[COL_FeePostChecking]", Key, dbPara, commandType: CommandType.StoredProcedure));

            return feepost;
        }
        public Task<int> FeeDiscountChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Remark, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@AccountId", AccountId, DbType.String);
            dbPara.Add("@Vtype", vtype, DbType.String);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@Remark", Remark, DbType.String);
            var feepost = Task.FromResult(_dapperManager.Get<int>("[COL_FeeDiscountChecking]", Key, dbPara, commandType: CommandType.StoredProcedure));

            return feepost;
        }

        public async Task<List<CollegeClass>> GetAdmission(string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Admission = Task.FromResult(_dapperManager.GetAll<CollegeClass>("SELECT ID,FeeSchedule FROM COL_FeeSchedule where Type='Admission' and Branchid=@branchid ORDER BY FeeSchedule",Key, dbPara, commandType: CommandType.Text));
            return await Admission;
        }

        public async Task<List<dtDiscountSchedule>> GetDiscountSchedule(int BranchID, string Schedule, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Schedule", Schedule, DbType.String);
            var DiscountcheduleList = Task.FromResult(_dapperManager.GetAll<dtDiscountSchedule>("[COL_GetDiscountSchedule]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await DiscountcheduleList;
        }

        public async Task<List<CollegeClass>> GetFee(string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Fee = Task.FromResult(_dapperManager.GetAll<CollegeClass>("SELECT ID,FeeSchedule FROM COL_FeeSchedule where Type='CourseFee' and branchid=@branchid ORDER BY FeeSchedule", Key, dbPara, commandType: CommandType.Text));
            return await Fee;
        }

        public async Task<List<dtStudentFeeDetails>> GetFeeDetails(int AccountId, int BranchID, string AcademicYear,string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("@AccountId", AccountId, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var FeeDetails = Task.FromResult(_dapperManager.GetAll<dtStudentFeeDetails>("[COL_FeeDetails]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await FeeDetails;
        }

        public async Task<List<CollegeClass>> GetFeeDiscount(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var FeeDiscount = Task.FromResult(_dapperManager.GetAll<CollegeClass>("SELECT ID, Schedule FROM COL_DiscountSchedule where type = 'Discount' ORDER BY ID", Key, dbPara, commandType: CommandType.Text));
            return await FeeDiscount;
        }

        public async Task<List<dtFeeSchedule>> GetFeeSchedule(string AcademicYear, int BranchID, string Code, DateTime fromdate, DateTime todate, string Type, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Code", Code, DbType.String);
            dbPara.Add("@fromdate", fromdate, DbType.DateTime);
            dbPara.Add("@todate", todate, DbType.DateTime);
            dbPara.Add("@Type", Type, DbType.String);
            var FeeScheduleList = Task.FromResult(_dapperManager.GetAll<dtFeeSchedule>("[COL_GetFeeSchedule]", Key, dbPara, commandType: CommandType.StoredProcedure));
            return await FeeScheduleList;
        }

        public async Task<dtStudentFeeSummary> GetFeeSummary(int AccountId, int BranchID, string AcademicYear, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@AccountId", AccountId, DbType.Int32);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
                var FeeSummary = Task.FromResult(_dapperManager.Get<dtStudentFeeSummary>("[COL_FeeSummary]", Key, dbPara, commandType: CommandType.StoredProcedure));
                return await FeeSummary;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<dtStudentStatement>> GetStatement(int BranchID, int AccountID, DateTime SDate, DateTime EDate, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@DateFrom", SDate, DbType.DateTime);
                dbPara.Add("@DateUpto", EDate, DbType.DateTime);
                dbPara.Add("@AccountID", AccountID, DbType.Int32);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                var Statement = Task.FromResult(_dapperManager.GetAll<dtStudentStatement>("[COL_AccountStmtStudentSP ORG]", Key, dbPara, commandType: CommandType.StoredProcedure));
                return await Statement;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<CollegeClass>> GetTransport(string AcademicYear, int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Transport = Task.FromResult(_dapperManager.GetAll<CollegeClass>("SELECT ID,FeeSchedule FROM COL_FeeSchedule where type='Transportation' and branchid=@branchid  ORDER BY FeeSchedule", Key, dbPara, commandType: CommandType.Text));
            return await Transport;
        }

        public Task<int> getUniqueAccID(string Value, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Value", Value, DbType.String);
            var ack = Task.FromResult(_dapperManager.Get<int>($"SELECT ID FROM  Accounts  WHERE AccountName=@Value", Key, dbPara, commandType: CommandType.Text));
            return ack;
        }

        public Task<int> GetVtype(string vtype, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Vtype", vtype, DbType.String);
            var Vouchertype = Task.FromResult(_dapperManager.Get<int>($"SELECT ID FROM VTypeTran WHERE VType=@Vtype", Key, dbPara, commandType: CommandType.Text));
            return Vouchertype;
        }

        public async Task<long> PostingDiscount(dtsVoucher Voucher, string Key)
        {
            long newID = 0;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            using IDbConnection db = _dapperManager.GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {



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

            return newID;
        }
    }
}
