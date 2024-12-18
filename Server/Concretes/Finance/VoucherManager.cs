using OrisonCollegePortal.Shared.Entities.Finance;
using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using System.Data;


namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class VoucherManager : IVoucherManager
    {
        private readonly IDapperManager _dapperManager;

        public VoucherManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;

        }

        public async Task<long> VoucherEvent(dtVoucher Voucher, IDbConnection db, IDbTransaction tran)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            if (Voucher.RowState == "Insert")
            {
                dbPara.Add("VType", Voucher.VType, DbType.Int32);
                dbPara.Add("BranchID", Voucher.BranchID, DbType.Int32);
                dbPara.Add("AccountID", Voucher.AccountID, DbType.Int32);
                dbPara.Add("StaffId", Voucher.StaffID, DbType.Int32);
                dbPara.Add("VDate", Voucher.VDate.Date, DbType.DateTime);
                dbPara.Add("RefNo", Voucher.RefNo, DbType.String);
                dbPara.Add("EffectiveDate", Voucher.EffectiveDate.Date, DbType.DateTime);
                dbPara.Add("DueDate", Voucher.DueDate.Date, DbType.DateTime);
                dbPara.Add("CommonNarration", Voucher.CommonNarration, DbType.String);
                dbPara.Add("VoucherAgainst", Voucher.VoucherAgainst, DbType.String);
                dbPara.Add("Remark", Voucher.Remark, DbType.String);
                dbPara.Add("UserID", Voucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("Posted", Voucher.Posted, DbType.Boolean);
                dbPara.Add("Currency", Voucher.Currency, DbType.Int32);
                dbPara.Add("CreatedUserID", Voucher.CreatedUserID, DbType.Int32);
                dbPara.Add("ModifiedUserID", Voucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("VATAmt", Voucher.VATAmt, DbType.Decimal);
                dbPara.Add("VATPaid", Voucher.VATPaid, DbType.Decimal);
                dbPara.Add("VRound", Voucher.VRound, DbType.Decimal);
                dbPara.Add("Amount", Voucher.Amount, DbType.Decimal);
                dbPara.Add("SubTotal", Voucher.SubTotal, DbType.Decimal);
                dbPara.Add("ExchangeRate", Voucher.ExchangeRate, DbType.Decimal);
                dbPara.Add("Criteria", "Insert", DbType.String);

                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                newID = _dapperManager.Insert("[Col_VoucherSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            }
            else if (Voucher.RowState == "Update")
            {
                dbPara.Add("VType", Voucher.VType, DbType.Int32);
                dbPara.Add("BranchID", Voucher.BranchID, DbType.Int32);
                dbPara.Add("AccountID", Voucher.AccountID, DbType.Int32);
                dbPara.Add("StaffId", Voucher.StaffID, DbType.Int32);
                dbPara.Add("VDate", Voucher.VDate, DbType.DateTime);
                dbPara.Add("RefNo", Voucher.RefNo, DbType.String);
                dbPara.Add("EffectiveDate", Voucher.EffectiveDate, DbType.DateTime);
                dbPara.Add("ModifiedDate", Voucher.ModifiedDate, DbType.DateTime);
                dbPara.Add("DueDate", Voucher.DueDate, DbType.DateTime);
                dbPara.Add("CommonNarration", Voucher.CommonNarration, DbType.String);
                dbPara.Add("UserID", Voucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("Posted", Voucher.Posted, DbType.Boolean);
                dbPara.Add("Currency", Voucher.Currency, DbType.Int32);
                dbPara.Add("CreatedUserID", Voucher.CreatedUserID, DbType.Int32);
                dbPara.Add("ModifiedUserID", Voucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("VATAmt", Voucher.VATAmt, DbType.Decimal);
                dbPara.Add("VATPaid", Voucher.VATPaid, DbType.Decimal);
                dbPara.Add("VRound", Voucher.VRound, DbType.Decimal);
                dbPara.Add("Amount", Voucher.Amount, DbType.Decimal);
                dbPara.Add("SubTotal", Voucher.SubTotal, DbType.Decimal);
                dbPara.Add("ExchangeRate", Voucher.ExchangeRate, DbType.Decimal);
                dbPara.Add("RefNo", Voucher.RefNo, DbType.String);
                dbPara.Add("Criteria", "Update", DbType.String);
                dbPara.Add("ID", Voucher.ID, DbType.Int32);

                _dapperManager.UpdateTable("[Col_VoucherSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                newID = Voucher.ID;
            }
            else if (Voucher.RowState == "Update")
            {
                dbPara.Add("Vid", Voucher.ID, DbType.Int64);
                _dapperManager.Execute("delete from voucher where id=@Vid", db.ToString(), dbPara, commandType: CommandType.Text);
            }
            return newID;

        }
        public async Task<long> DepostVoucher(dtDeleteVoucher Voucher, IDbConnection db, IDbTransaction tran, string Con)
        {
            try
            {
                long newID = 0;
                var dbPara = new DynamicParameters();
                dbPara.Add("AccountId", Voucher.AccountId, DbType.Int32);
                dbPara.Add("Vtype", Voucher.VType, DbType.Int32);
                dbPara.Add("StartDate", Voucher.StartDate, DbType.String);
                dbPara.Add("EndDate", Voucher.EndDate, DbType.String);
                dbPara.Add("Type", Voucher.Type, DbType.String);
                dbPara.Add("Discount", Voucher.Discount, DbType.String);


                _dapperManager.Execute("[Col_VoucherDepostSP]", Con, dbPara, commandType: CommandType.StoredProcedure);
                return newID;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw ;
            }
        }
        public async Task<long> DepostVoucherClass(dtDeleteVoucher Voucher, IDbConnection db, IDbTransaction tran)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            dbPara.Add("Class", Voucher.Class, DbType.Int32);
            dbPara.Add("Vtype", Voucher.VType, DbType.Int32);
            dbPara.Add("StartDate", Voucher.StartDate, DbType.String);
            dbPara.Add("EndDate", Voucher.EndDate, DbType.String);
            dbPara.Add("Type", Voucher.Type, DbType.String);
            dbPara.Add("AcademicYear", Voucher.AcademicYear, DbType.String);

            _dapperManager.Execute("[SchoolWEB_VoucherDepostClassSP]", db.ToString()!, dbPara, commandType: CommandType.StoredProcedure);
            return newID;
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<dtVoucher> GetVoucher(long VId, string Con)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("VId", VId, DbType.Int32);
            dbPara.Add("Criteria", "Voucher", DbType.String);
            var voucher = Task.FromResult(_dapperManager.Get<dtVoucher>
                                ("[SchoolWEB_TestVoucherSP]", Con, dbPara,
                                commandType: CommandType.StoredProcedure));
            return await voucher;
        }
        public async Task<List<dtVoucher>> VoucherList(int vtype, int BranchID, int userid, string Con)
        {
            List<dtVoucher> _dtvoucher = new List<dtVoucher>();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@VType", vtype, DbType.Int32);
                dbPara.Add("@BranchId", BranchID, DbType.Int32);
                dbPara.Add("@userId", userid, DbType.Int32);
                dbPara.Add("@Criteria", "VoucherMaster", DbType.String);
                _dtvoucher = await Task.FromResult(_dapperManager.GetAll<dtVoucher>
                                    ("[dbo].[SchoolWEB_ListVouchers]", Con, dbPara,
                                    commandType: CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return _dtvoucher;
        }

        //Update FeeAmount
        public void UpdateFeeAmount(dtVoucher trans, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", trans.ID, DbType.Int64);
            dbPara.Add("Amount", trans.Amount, DbType.Decimal);
            dbPara.Add("ModifiedDate", trans.ModifiedDate, DbType.DateTime);
            dbPara.Add("ModifiedUserID", trans.ModifiedUserID, DbType.Int64);
            dbPara.Add("Criteria", "UpdateVoucher", DbType.String);
            _dapperManager.UpdateTablev("[VoucherUpdate]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
        }
    }
}
