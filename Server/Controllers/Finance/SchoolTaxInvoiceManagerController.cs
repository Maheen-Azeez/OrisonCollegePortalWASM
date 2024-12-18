using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class SchoolTaxInvoiceManagerController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ISchoolTaxInvoiceManager _repository;
        public SchoolTaxInvoiceManagerController(IWebHostEnvironment environment, ISchoolTaxInvoiceManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        [Route("Gets")]
        public async Task<ActionResult<IEnumerable<SchoolTaxInvoicedt>>> GetSchoolTaxInvoice(string AcademicYear, int BranchID, string key)
        {
            return await _repository.GetSchoolTaxInvoice(AcademicYear, BranchID, key);
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<SchoolTaxInvoicedt>>> get(int id, string AcademicYear,int BranchID, string key)
        {
            return await _repository.get(id, AcademicYear, BranchID, key);
        }

        [HttpGet]
        [Route("Getdatas")]
        public async Task<ActionResult<SchoolTaxInvoicedt>> Getdata(string AcademicYear, int id, string key)
        {
            return await _repository.Getdata(AcademicYear, id, key);
        }
        [HttpGet]
        [Route("TaxInvoiceStatement")]
        public async Task<ActionResult<IEnumerable<dtStudentStatement>>> GetTaxInvoiceStatement(string AccountCode, string AcademicYear, string StartDate, string EndDate, int BranchID, string key)
        {
            return await _repository.GetTaxInvoiceStatement(AccountCode, AcademicYear, StartDate, EndDate, BranchID, key);
        }
    }
}

