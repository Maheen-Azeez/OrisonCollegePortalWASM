using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class InvoiceRegisterController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IInvoiceRegisterManager _repository;
        public InvoiceRegisterController(IWebHostEnvironment environment, IInvoiceRegisterManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("Getadvance")]
        public async Task<ActionResult<IEnumerable<dtAdvanceReceiptRegister>>> Getadvance(string AcademicYear, int BranchID, string fromdate, string todate, string key)
        {
            return await _repository.Getadvance(AcademicYear, BranchID, fromdate, todate, key);
        }
        public class resultID
        {
            public long ID { get; set; }
        }

        public class ErrorResult
        {
            public String? Error { get; set; }
        }

        [HttpGet]
        [Route("GetInvoice")]
        public async Task<ActionResult<IEnumerable<dtInvoiceRegister>>> GetInvoice(string AcademicYear, int BranchID, string fromdate, string todate, string key)
        {
            return await _repository.GetInvoice(AcademicYear, BranchID, fromdate, todate, key);
        }
        [HttpGet]
        [Route("GetInvoices")]
        public async Task<ActionResult<IEnumerable<dtInvoiceRegister>>> GetInvoices(string AcademicYear, int BranchID, string fromdate, string todate, string key)
        {
            return await _repository.GetInvoices(AcademicYear, BranchID, fromdate, todate, key);
        }
        //[HttpGet]
        //[Route("collection")]
        //public async Task<ActionResult<IEnumerable<dtInvoiceRegister>>> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID)
        //{
        //    return await _repository.collected(BranchID, fromdate, todate, invdate, UserID, AccountID);
        //}
        [HttpDelete("collection")]
        [Route("collection")]
        public async Task<int> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string key)
        {
            return await _repository.collected(BranchID, fromdate, todate, invdate, UserID, AccountID, key);
        }
        [HttpDelete("collectiontax")]
        [Route("collectiontax")]
        public async Task<int> collectedtax(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string CmbAccYear, string key)
        {
            return await _repository.collectedtax(BranchID, fromdate, todate, invdate, UserID, AccountID, CmbAccYear, key);
        }


        //[HttpGet]
        //[Route("collection")]
        //public async Task<ActionResult<IEnumerable<dtInvoiceRegister>>> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID)
        //{
        //    return await _repository.collected(BranchID, fromdate, todate, invdate, UserID, AccountID);
        //}


    }
}
