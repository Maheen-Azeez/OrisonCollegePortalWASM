using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts
{
    public interface IVoucherEntryManager
    {
        Task<long> VoucherEvent(dtVoucher Voucher, string Key, IDbConnection db, IDbTransaction tran);
      //  public Task<long> VoucherEntryEvents(dtVoucherEntry dtInvVoucherEntry, string Key, IDbConnection db, IDbTransaction tran);
        public Task<long> VoucherEntryEvents(dtVoucherEntry dtInvVoucherEntry, IDbConnection db, IDbTransaction tran);
        void UpdateFeeAmountVE(dtVoucherEntry trans, IDbConnection db, IDbTransaction tran);

        Task<long> DepostVoucher(dtDeleteVoucher DeleteVoucher, string Key, IDbConnection db, IDbTransaction tran);
    }
}
