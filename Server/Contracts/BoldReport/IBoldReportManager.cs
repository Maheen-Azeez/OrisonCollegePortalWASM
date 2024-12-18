using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Shared.Entities.BoldReport;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.BoldReport
{
    public interface IBoldReportManager : IDisposable
    {
        Task<FileStreamResult> GetReport(DataSource Data);
        public Task<List<DtoReceiptPrint>> MerrylandGetFeeRecieptByID(long VID, string AccYear, int VNO, string key);
        public Task<List<DtoReceiptPrint>> GetFeeRecieptByID(long VID, string AccYear, int VNO, long BranchID, string key);
        public Task<List<DtoReceiptPrint>> GetFeeRecieptAcc(long VID, string AccYear, int VNO, long BranchID, string key);
        public Task<List<DtoReceiptPrint>> GetFeeVtype(long VID, long BranchID, string key, string Criteria);
        public Task<List<DtoReceiptPrint>> GetFeeRecieptPreReg(long VID, string AccYear, int VNO, long BranchID, string key);
        public Task<List<DtoReceiptPrint>> GetFeeRecieptReReg(long VID, string AccYear, int VNO, long BranchID, string key);
        public Task<List<DtoReceiptPrint>> GetFeeRecieptNoAllocPreReg(long VID, string AccYear, int VNO, long BranchID, string key);
        public Task<int> sendEmail(DtoEmail dtoEmail, string key);
    }
}
