using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Inventory;
using OrisonCollegePortal.Shared.Entities.Inventory;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Inventory
{
    public class InvVoucherManager : IInvVoucherManager
    {
        private readonly IDapperManager _dapperManager;

        public InvVoucherManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        public async Task<long> VoucherEvent(dtoVoucher InvVoucher, IDbConnection db, IDbTransaction tran,string key)
        {
            long newID = 0;
            var dbPara = new DynamicParameters();
            if (InvVoucher.RowState == "Insert")
            {
                dbPara.Add("VType", InvVoucher.VType, DbType.Int32);
                dbPara.Add("BranchID", InvVoucher.BranchID, DbType.Int32);
                dbPara.Add("AccountID", InvVoucher.AccountID, DbType.Int32);
                dbPara.Add("StaffId", InvVoucher.StaffID, DbType.Int32);
                dbPara.Add("VDate", InvVoucher.VDate?.Date, DbType.DateTime);
                dbPara.Add("RefNo", InvVoucher.RefNo, DbType.String);
                dbPara.Add("EffectiveDate", InvVoucher.EffectiveDate?.Date, DbType.DateTime);
                dbPara.Add("DueDate", InvVoucher.DueDate?.Date, DbType.DateTime);
                dbPara.Add("CommonNarration", InvVoucher.CommonNarration, DbType.String);
                dbPara.Add("Remark", "Insert from Web App", DbType.String);
                dbPara.Add("UserID", InvVoucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("Posted", InvVoucher.Posted, DbType.Boolean);
                dbPara.Add("Currency", InvVoucher.Currency, DbType.Int32);
                dbPara.Add("CreatedUserID", InvVoucher.CreatedUserID, DbType.Int32);
                dbPara.Add("ModifiedUserID", InvVoucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("VATAmt", InvVoucher.VATAmt, DbType.Decimal);
                dbPara.Add("VATPaid", InvVoucher.VATPaid, DbType.Decimal);
                dbPara.Add("VRound", InvVoucher.VRound, DbType.Decimal);
                dbPara.Add("Amount", InvVoucher.Amount, DbType.Decimal);
                dbPara.Add("SubTotal", InvVoucher.SubTotal, DbType.Decimal);
                dbPara.Add("PreparedBy", InvVoucher.PreparedBy, DbType.String);
                dbPara.Add("ExchangeRate", InvVoucher.ExchangeRate, DbType.Decimal);
                dbPara.Add("Criteria", "Insert", DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                newID = _dapperManager.Insert("[FINWEB_DMLVoucherSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
            }
            else if (InvVoucher.RowState == "Update")
            {
                dbPara.Add("VNo", InvVoucher.VNo, DbType.String);
                dbPara.Add("VNoInt", InvVoucher?.VNoint, DbType.Int64);
                dbPara.Add("VType", InvVoucher.VType, DbType.Int32);
                dbPara.Add("BranchID", InvVoucher.BranchID, DbType.Int32);
                dbPara.Add("AccountID", InvVoucher.AccountID, DbType.Int32);
                dbPara.Add("StaffId", InvVoucher.StaffID, DbType.Int32);
                dbPara.Add("VDate", InvVoucher.VDate, DbType.DateTime);
                dbPara.Add("RefNo", InvVoucher.RefNo, DbType.String);
                dbPara.Add("EffectiveDate", InvVoucher.EffectiveDate, DbType.DateTime);
                dbPara.Add("ModifiedDate", InvVoucher.ModifiedDate, DbType.DateTime);
                dbPara.Add("DueDate", InvVoucher.DueDate, DbType.DateTime);
                dbPara.Add("CommonNarration", InvVoucher.CommonNarration, DbType.String);
                dbPara.Add("Remark", "Update from Web App", DbType.String);
                dbPara.Add("UserID", InvVoucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("Posted", InvVoucher.Posted, DbType.Boolean);
                dbPara.Add("Currency", InvVoucher.Currency, DbType.Int32);
                dbPara.Add("CreatedUserID", InvVoucher.CreatedUserID, DbType.Int32);
                dbPara.Add("ModifiedUserID", InvVoucher.ModifiedUserID, DbType.Int32);
                dbPara.Add("VATAmt", InvVoucher.VATAmt, DbType.Decimal);
                dbPara.Add("VATPaid", InvVoucher.VATPaid, DbType.Decimal);
                dbPara.Add("VRound", InvVoucher.VRound, DbType.Decimal);
                dbPara.Add("Amount", InvVoucher.Amount, DbType.Decimal);
                dbPara.Add("SubTotal", InvVoucher.SubTotal, DbType.Decimal);
                dbPara.Add("ExchangeRate", InvVoucher.ExchangeRate, DbType.Decimal);
                dbPara.Add("RefNo", InvVoucher.RefNo, DbType.String);
                dbPara.Add("Criteria", "Update", DbType.String);
                dbPara.Add("ID", InvVoucher.ID, DbType.Int32);

                _dapperManager.UpdateTable("[FINWEB_DMLVoucherSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                newID = InvVoucher.ID;
            }
            else if (InvVoucher.RowState == "Delete")
            {
                dbPara.Add("Vid", InvVoucher.ID, DbType.Int64);
                _dapperManager.Execute("delete from voucher where id=@Vid",key, dbPara, commandType: CommandType.Text);
            }
            return newID;

        }

        
        public async Task<dtoVoucher> GetVoucher(long VId,string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("VId", VId, DbType.Int32);
            dbPara.Add("Criteria", "Voucher", DbType.String);
            var voucher = Task.FromResult(_dapperManager.Get<dtoVoucher>
                                ("[FINWEB_INVENTORYVoucherSP]", key,dbPara,
                                commandType: CommandType.StoredProcedure));
            return await voucher;
        }
        public async Task<long> DeleteVoucher(long VId,string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("VId", VId, DbType.Int64);
            _dapperManager.Execute("delete from voucher where id=@Vid",key, dbPara, commandType: CommandType.Text);
            return 0;
        }

        public async Task<List<dtoVoucher>> VoucherList(int vtype, int BranchID, int userid,string key)
        {
            List<dtoVoucher> _dtvoucher = new List<dtoVoucher>();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@VType", vtype, DbType.Int32);
                dbPara.Add("@BranchId", BranchID, DbType.Int32);
                dbPara.Add("@userId", userid, DbType.Int32);
                dbPara.Add("@Criteria", "VoucherMaster", DbType.String);
                _dtvoucher = await Task.FromResult(_dapperManager.GetAll<dtoVoucher>
                                    ("[dbo].[FINWEB_ListVouchers]",key, dbPara,
                                    commandType: CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {
            }
            return _dtvoucher;
        }

        public async Task<List<dtoVoucher>> VoucherListUserWise(int vtype, int BranchID, int userid, string key)
        {
            List<dtoVoucher> _dtvoucher = new List<dtoVoucher>();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@VType", vtype, DbType.Int32);
                dbPara.Add("@BranchId", BranchID, DbType.Int32);
                dbPara.Add("@userId", userid, DbType.Int32);
                dbPara.Add("@Criteria", "VoucherMasterUserWise", DbType.String);
                _dtvoucher = await Task.FromResult(_dapperManager.GetAll<dtoVoucher>
                                    ("[dbo].[FINWEB_ListVouchers]",key, dbPara,
                                    commandType: CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {

            }
            return _dtvoucher;
        }

        public async Task CancelVoucher(long VId, int AccID, string key)
        {

            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@ID", VId, DbType.Int32);
                dbPara.Add("@UserID", AccID, DbType.Int32);

                dbPara.Add("@Criteria", "Cancel", DbType.String);
                await Task.FromResult(_dapperManager.Execute("[FINWEB_DMLVoucherSP]", key,dbPara, commandType: CommandType.StoredProcedure));

            }
            catch (Exception ex)
            {

            }
        }
    }
}
