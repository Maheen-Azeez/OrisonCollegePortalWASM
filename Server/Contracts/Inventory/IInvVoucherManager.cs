

using OrisonCollegePortal.Shared.Entities.Inventory;
using System.Data;

namespace OrisonCollegePortal.Server.Contracts.Inventory
{
    public interface IInvVoucherManager : IDisposable
    {
        Task<long> VoucherEvent(dtoVoucher InvVoucher, IDbConnection db, IDbTransaction tran,string key);
    }
}
