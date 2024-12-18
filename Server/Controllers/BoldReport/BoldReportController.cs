using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.BoldReport;
using OrisonCollegePortal.Shared.Entities.BoldReport;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Net.Mime;
using System.Text.Json;

namespace OrisonCollegePortal.Server.Controllers.BoldReport
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoldReportController : ControllerBase, IDisposable
    {
        private IBoldReportManager _repository;
        public BoldReportController(IBoldReportManager repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // Dispose method to release resources
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any managed resources here
                _repository.Dispose();
            }
        }

        [HttpPost]
        [Route("GetReport")]
        public async Task<IActionResult> GetReport(DataSource Value)
        {
            var fileStreamResult = await _repository.GetReport(Value);
            return File(fileStreamResult.FileStream, MediaTypeNames.Application.Pdf, $"{Value.ReportName}.pdf");
        }
        [Route("GetFeeRecieptByID")]
        [HttpGet]
        public async Task<ActionResult<List<DtoReceiptPrint>>> GetFeeRecieptByID(long VID, int ONO, string AccYear, long BranchID, string Key)
        {
            return await _repository.GetFeeRecieptByID(VID, AccYear, ONO, BranchID, Key);
        }
        [Route("MerrylandGetFeeRecieptByID")]
        [HttpGet]
        public async Task<ActionResult<List<DtoReceiptPrint>>> GetFeeRecieptByID(long VID, int ONO, string AccYear, string Key)
        {
            return await _repository.MerrylandGetFeeRecieptByID(VID, AccYear, ONO, Key);
        }
        [Route("GetVtype")]
        [HttpGet]
        public async Task<ActionResult<List<DtoReceiptPrint>>> GetFeeVtype(long VID, long BranchID, string Key, string Criteria)
        {
            return await _repository.GetFeeVtype(VID, BranchID, Key, Criteria);
        }
        [Route("GetFeeRecieptAcc")]
        [HttpGet]
        public async Task<ActionResult<List<DtoReceiptPrint>>> GetFeeRecieptNoall(long VID, int ONO, string AccYear, long BranchID, string Key)
        {
            return await _repository.GetFeeRecieptAcc(VID, AccYear, ONO, BranchID, Key);
        }
        [Route("GetFeeRecieptPreReg")]
        [HttpGet]
        public async Task<ActionResult<List<DtoReceiptPrint>>> GetFeeRecieptPreReg(long VID, int ONO, string AccYear, long BranchID, string Key)
        {
            return await _repository.GetFeeRecieptPreReg(VID, AccYear, ONO, BranchID, Key);
        }
        [Route("GetFeeRecieptReReg")]
        [HttpGet]
        public async Task<ActionResult<List<DtoReceiptPrint>>> GetFeeRecieptReReg(long VID, int ONO, string AccYear, long BranchID, string Key)
        {
            return await _repository.GetFeeRecieptReReg(VID, AccYear, ONO, BranchID, Key);
        }
        [Route("GetFeeRecieptNoAllocPreReg")]
        [HttpGet]
        public async Task<ActionResult<List<DtoReceiptPrint>>> GetFeeRecieptNoAllocPreReg(long VID, int ONO, string AccYear, long BranchID, string Key)
        {
            return await _repository.GetFeeRecieptNoAllocPreReg(VID, AccYear, ONO, BranchID, Key);
        }
        [Route("EmailDetail")]
        [HttpPost]
        public async Task<ActionResult> SendEmail(DtoEmail EmailDetails)
        {
            var key = "";
            DtoResultID result = new DtoResultID();
            var ID = await _repository.sendEmail(EmailDetails, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            if (ID == 0)
            {
                msg.StatusCode = (System.Net.HttpStatusCode)0;
                result.ID = 0;
                return new JsonResult(result);
            }
            else
            {
                msg.StatusCode = (System.Net.HttpStatusCode)1;
                result.ID = ID;
                return new JsonResult(result);
            }
        }
    }
}
