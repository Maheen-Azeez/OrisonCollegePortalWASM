using OrisonCollegePortal.Shared.Entities.BoldReport;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.BoldReport
{
    public interface IBoldReportManager : IDisposable
    {
        Task<MemoryStream> GetReport(DataSource Value);
        public Task<List<DtoReceiptPrint>?> MerrylandGetFeeRecieptByID(long? VID, string? AccYear, int? VNO);
        Task<List<DtoReceiptPrint>?> GetFeeRecieptByID(long? id, int? ONO, string? AccYear, int? BranchID);
        Task<List<DtoReceiptPrint>?> GetFeeRecieptNoAllocPreReg(long? id, int? ONO, string? AccYear, int? BranchID);
        Task<List<DtoReceiptPrint>?> GetFeeRecieptAcc(long? id, int? ONO, string? AccYear, int? BranchID);
        Task<List<DtoReceiptPrint>?> GetFeeRecieptPreReg(long? id, int? ONO, string? AccYear, int? BranchID);
        Task<List<DtoReceiptPrint>?> GetFeeRecieptReReg(long? id, int? ONO, string? AccYear, int? BranchID);
        Task<List<DtoReceiptPrint>?> GetFeeVtype(long? VID, int? BranchID, string? Criteria);
        Task<int> SendEmail(DtoEmail EmailDetails);
    }
}
