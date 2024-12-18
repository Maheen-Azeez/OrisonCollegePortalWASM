using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IVoucherManager
    {
        Task<long> VoucherEvent(dtVoucher Voucher, IDbConnection db, IDbTransaction tran);
        Task<long> DepostVoucher(dtDeleteVoucher DeleteVoucher, IDbConnection db, IDbTransaction tran, string Con);
        Task<long> DepostVoucherClass(dtDeleteVoucher DeleteVoucher, IDbConnection db, IDbTransaction tran);
        Task<dtVoucher> GetVoucher(long VId, string Con);
        Task<List<dtVoucher>> VoucherList(int vtype, int BranchID, int userid, string Con);

        //Update FeeAmount
        void UpdateFeeAmount(dtVoucher trans, IDbConnection db, IDbTransaction tran);
    }
}
