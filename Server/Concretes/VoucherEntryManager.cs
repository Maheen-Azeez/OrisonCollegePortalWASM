using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts;
using System.Data;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Concretes
{
    public class VoucherEntryManager : IVoucherEntryManager
    {
        private readonly IDapperManager _dapperManager;

        public VoucherEntryManager(IDapperManager dapperManager)
        {
            _dapperManager = dapperManager;
        }

        public async Task<long> DepostVoucher(dtDeleteVoucher Voucher,string Key, IDbConnection db, IDbTransaction tran)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountId", Voucher.AccountId, DbType.Int32);
            dbPara.Add("Vtype", Voucher.VType, DbType.Int32);
            dbPara.Add("StartDate", Voucher.StartDate, DbType.String);
            dbPara.Add("EndDate", Voucher.EndDate, DbType.String);
            dbPara.Add("Type", Voucher.Type, DbType.String);


            _dapperManager.Execute("[COL_VoucherDepostSP]", Key, dbPara , commandType: CommandType.StoredProcedure);

            return newID;
        }

        public async Task<long> VoucherEntryEvents(dtVoucherEntry dtVoucherEntry, IDbConnection db, IDbTransaction tran)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            if (dtVoucherEntry.RowState == "Insert")
            {
                dbPara.Add("VId", dtVoucherEntry.VID, DbType.Int64);
                dbPara.Add("AccountID", dtVoucherEntry.AccountID, DbType.Decimal);
                dbPara.Add("RowType", dtVoucherEntry.RowType, DbType.String);
                dbPara.Add("Description", dtVoucherEntry.Description, DbType.String);
                dbPara.Add("Debit", dtVoucherEntry.Debit, DbType.Decimal);
                dbPara.Add("Credit", dtVoucherEntry.Credit, DbType.Decimal);
                dbPara.Add("VisibleonPrint", dtVoucherEntry.VisibleonPrint, DbType.Boolean);
                dbPara.Add("Reconciled", dtVoucherEntry.Reconciled, DbType.Boolean);
                dbPara.Add("Active", dtVoucherEntry.Active, DbType.Boolean);
                dbPara.Add("Criteria", "Insert", DbType.String);
                dbPara.Add("Action", dtVoucherEntry.Action, DbType.String);
                dbPara.Add("TranType", dtVoucherEntry.TranType, DbType.String);
                dbPara.Add("SlNo", dtVoucherEntry.SlNo, DbType.Int64);
                dbPara.Add("Reference", dtVoucherEntry.Reference, DbType.String);
                dbPara.Add("RefID", dtVoucherEntry.RefID, DbType.String);
                dbPara.Add("PostingSubCode", dtVoucherEntry.PostingSubCode, DbType.String);
                dbPara.Add("TaxCode", dtVoucherEntry.TaxCode, DbType.String);
                dbPara.Add("DocSubNo", dtVoucherEntry.DocSubNo, DbType.String);
                dbPara.Add("UserId", 62, DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                newID = _dapperManager.Insert("[Col_VoucherEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            }
            else if (dtVoucherEntry.RowState == "Update")
            {
                dbPara.Add("VId", dtVoucherEntry.VID, DbType.Int64);
                dbPara.Add("AccountID", dtVoucherEntry.AccountID, DbType.Decimal);
                dbPara.Add("RowType", dtVoucherEntry.RowType, DbType.String);
                dbPara.Add("Description", dtVoucherEntry.Description, DbType.String);
                dbPara.Add("Debit", dtVoucherEntry.Debit, DbType.Decimal);
                dbPara.Add("Credit", dtVoucherEntry.Credit, DbType.Decimal);
                dbPara.Add("VisibleonPrint", dtVoucherEntry.VisibleonPrint, DbType.Boolean);
                dbPara.Add("Reconciled", dtVoucherEntry.Reconciled, DbType.Boolean);
                dbPara.Add("Active", dtVoucherEntry.Active, DbType.Boolean);
                dbPara.Add("Action", dtVoucherEntry.Action, DbType.String);
                dbPara.Add("TranType", dtVoucherEntry.TranType, DbType.String);
                dbPara.Add("ID", dtVoucherEntry.ID, DbType.Int32);
                dbPara.Add("Criteria", "Update", DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                newID = _dapperManager.UpdateTable("[Col_VoucherEntrySP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            }
            else if (dtVoucherEntry.RowState == "Delete")
            {
                dbPara.Add("VEID", dtVoucherEntry.ID, DbType.Int64);
                _dapperManager.Execute("delete from VoucherEntry where id=@VEID", db.ToString()!, dbPara, commandType: CommandType.Text);
            }
            return newID;
        }

        public async Task<long> VoucherEvent(dtVoucher Voucher, string Key, IDbConnection db, IDbTransaction tran)
        {
            try
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

                    newID = _dapperManager.Insert("[COL_VoucherSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
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

                    _dapperManager.UpdateTable("[COL_VoucherSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    newID = Voucher.ID;
                }
                else if (Voucher.RowState == "Delete")
                {
                    dbPara.Add("Vid", Voucher.ID, DbType.Int64);
                    _dapperManager.Execute("delete from voucher where id=@Vid",Key, dbPara, commandType: CommandType.Text);
                }
                return newID;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public void UpdateFeeAmountVE(dtVoucherEntry trans, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", trans.ID, DbType.Int64);
            dbPara.Add("Amount", trans.Amount, DbType.Decimal);

            dbPara.Add("Criteria", "UpdateVoucherEntry", DbType.String);
            _dapperManager.UpdateTablev("[VoucherUpdate]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
        }
    }
}
