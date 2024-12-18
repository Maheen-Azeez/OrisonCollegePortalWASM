using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Finances
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostingController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IPostingManager _repository;
        private IVoucherManager _vrepository;

        public PostingController(IWebHostEnvironment environment, IPostingManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        // POST api/Inventory
        [HttpPost("[action]")]
        [Route("post")]
        public async Task<HttpResponseMessage> AddData(dtsVoucher value, string key)
        {
            long ID = 0;
            ID = await _repository.CreatePostingVoucher(value, key)!;
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("depost")]
        public async Task<HttpResponseMessage> DeleteData(dtsVoucher value, string key)
        {
            long ID = 0;
            ID = await _repository.DeletePostingVoucher(value, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }
        [HttpPost("[action]")]
        [Route("poststudentdata")]
        public async Task<IActionResult> poststudentdata(dtPostClass value, string key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.poststudentdata(value, key)!;
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
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }

        

        [HttpDelete("Postallindividual")]
        [Route("Postallindividual")]

        public async Task<IActionResult> Postallindividual(int AccountID, int BranchID, string Criteria, string CmbAccYear, string StatementFromDate, string StatementEndDate, string key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.Postallindividual(AccountID, BranchID, Criteria, CmbAccYear, StatementFromDate, StatementEndDate, key)!;
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
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }


        [HttpDelete("Invoicegeneration")]
        [Route("Invoicegeneration")]

        public async Task<IActionResult> Invoicegeneration(int AccountID, int BranchID, string CmbAccYear, string Taxvoicedate, string StatementFromDate, string StatementEndDate, string key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.Invoicegeneration(AccountID, BranchID, CmbAccYear, Taxvoicedate, StatementFromDate, StatementEndDate, key)!;
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
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }


        [HttpGet]
        [Route("vtype")]

        public async Task<int> GetVtype(string FeeType, string key)
        {
            return await _repository.GetVtype(FeeType, key)!;
        }
        [HttpGet]
        [Route("Getdatas")]
        public async Task<ActionResult<IEnumerable<SchoolTaxInvoicedt>?>> Getdatas(int BranchID, string AcademicYear, int AccountID, string key)
        {
            return await _repository.Getdatas(BranchID, AcademicYear, AccountID, key)!;
        }
        [HttpGet]
        [Route("Getdatass")]
        public async Task<ActionResult<IEnumerable<SchoolTaxInvoicedt>?>> Getdatass(int BranchID, string AcademicYear, int AccountID, string key)
        {
            return await _repository.Getdatass(BranchID, AcademicYear, AccountID, key)!;
        }

        [HttpGet]
        [Route("keyword")]

        public async Task<int> getUniqueAccID(string Value, string key)
        {
            return await _repository.getUniqueAccID(Value, key)!;
        }

        [HttpPost("[action]")]
        [Route("BulkData")]
        public async Task<IActionResult> PostBulkData(dtPostClass value, string key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.PostBulkData(value, key)!;
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
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }

        [HttpPost("[action]")]
        [Route("postallbulkdata")]
        public async Task<IActionResult> postallbulkdata(dtPostClass value, string key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.postallbulkdata(value, key)!;
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
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
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
        [Route("feexist")]

        public async Task<int> FeePostChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string FeeSchedule, string key)
        {
            return await _repository.FeePostChecking(AccountId, vtype, fromdate, todate, Type, FeeSchedule, key)!;
        }
        [HttpGet]
        [Route("allocexist")]

        public async Task<int> FeeAllocChecking(int AccountId, int vtype, string fromdate, string todate, string Type, string key)
        {
            return await _repository.FeeAllocChecking(AccountId, vtype, fromdate, todate, Type, key)!;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long VId, string key)

        {
            return Ok(await _vrepository.GetVoucher(VId, key));
        }
        [HttpPost("[action]")]
        [Route("UnallocateData")]
        public async Task<HttpResponseMessage> PostUnallocateData(dtPostClass value,string key)
        {
            long ID = 0;
            ID = await _repository.PostUnallocateData(value, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }
        [HttpGet]
        [Route("FeeSchedule")]
        public async Task<ActionResult<IEnumerable<dtFeeSchedule>>> GetFeeSchedule(string AcademicYear, int BranchID, String Code, string fromdate, string todate, string Type, string key)
        {
            return await _repository.GetFeeSchedule(AcademicYear, BranchID, Code, fromdate, todate, Type, key)!;
        }
        [HttpGet]
        [Route("AddFees")]
        public async Task<ActionResult<dtFeeSchedule>> GetAddFees(int FeeId, string AcademicYear, int BranchID, string key)
        {
            return await _repository.GetAddFees(FeeId, AcademicYear, BranchID, key)!;
        }
        [HttpGet]
        [Route("AdditionalFee")]
        public async Task<ActionResult<IEnumerable<dtAdditionalFee>>> GetAdditionalFee(string AcademicYear, String Type, int BranchId, string key)
        {
            return await _repository.GetAdditionalFee(AcademicYear, Type, BranchId, key)!;
        }
        [HttpGet]
        [Route("Students")]
        public async Task<ActionResult<IEnumerable<dtStudentRegister>>> GetStudentsDetails(string AcademicYear, int BranchID, string Class, string Type, string fromdate, string todate, string key)
        {
            return await _repository.GetStudentsDetails(AcademicYear, BranchID, Class, Type, fromdate, todate, key)!;
        }
        [HttpGet]
        [Route("AdditionalSchedule")]
        public async Task<ActionResult<IEnumerable<AdditionalSchedule>>> GetAdditionalSchedules(int BranchID, string AcademicYear, string key)
        {
            return await _repository.GetAdditionalSchedules(BranchID, AcademicYear, key)!;
        }


        [HttpGet]
        [Route("FeeSummary")]
        public async Task<ActionResult<dtStudentFeeSummary>> GetFeeSummary(int AccountId, int BranchID, String AcademicYear, string key)
        {
            return await _repository.GetFeeSummary(AccountId, BranchID, AcademicYear, key)!;
        }
        [HttpGet]
        [Route("FeeDetails")]
        public async Task<ActionResult<IEnumerable<dtStudentFeeDetails>?>> GetFeeDetails(int AccountId, int BranchID, String AcademicYear, string key)
        {
            return await _repository.GetFeeDetails(AccountId, BranchID, AcademicYear, key)!;
        }
        [HttpGet]
        [Route("DiscountSchedule")]
        public async Task<ActionResult<IEnumerable<SchoolDiscountSchedule>?>> GetDiscountSchedule(int BranchID, String Schedule, string key)
        {
            return await _repository.GetDiscountSchedule(BranchID, Schedule, key)!;
        }

        //Update FeeAmount
        [HttpPost("[action]")]
        [Route("UpdateFeeAmount")]

        public async Task<HttpResponseMessage> Edit(dtsVoucher value, string key)
        {
            _repository.UpdateFeeAmount(value, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return   msg;
        }
        [HttpDelete]
        [Route("DeleteFeeAmount")]
        public async Task<HttpResponseMessage> DeleteFeeAmount(int ID, string key)
        {
            await _repository.DeleteFeeAmount(ID, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }
        [HttpGet]
        [Route("Gets")]
        public async Task<ActionResult<IEnumerable<SchoolTaxInvoicedt>?>> GetSchoolTaxInvoice(string AcademicYear, int ID, string key)
        {
            return await _repository.GetSchoolTaxInvoice(AcademicYear, ID, key);
        }
        //
        //save AdditionalFee
        [HttpPost("[action]")]
        [Route("AddAdditionalFee")]
        public async Task<IActionResult> AddAdditionalFee(SchoolAdditionalPayment AdFee, string key)
        {
            //long ID = 0;
            //ID = await _repository.CreateAdditionalFee(AdFee);
            //HttpResponseMessage msg = new HttpResponseMessage();
            //msg.StatusCode = (System.Net.HttpStatusCode)1;
            //return msg;

            long ID = 0;
            ID = await _repository.CreateAdditionalFee(AdFee, key);
            if (ID != 0)
            {
                return new ContentResult() { Content = ID.ToString(), StatusCode = 200 };
                //return StatusCode(200,aa);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        [Route("updateAdditionalFee")]
        public async Task<HttpResponseMessage> UpdateAdditionalFee(SchoolAdditionalPayment value, string key)
        {
            _repository.UpdateAdditionalFee(value, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }
        [HttpPost("[action]")]
        [Route("GenerateCollected")]
        public async Task<HttpResponseMessage> UpdateCollection(SchoolTaxInvoicedt Collected, string key)
        {
            _repository.UpdateCollection(Collected, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpDelete("Bulkpost")]
        [Route("Bulkpost")]

        public async Task<IActionResult> Bulkpost(int UserID, int BranchID, string Type, string Class, string CmbAccYear, string FromDate, string ToDate, string key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.Bulkpost(UserID, BranchID, Type, Class, CmbAccYear, FromDate, ToDate, key)!;
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
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }
        [HttpPost("[action]")]
        [Route("GenerateInvoices")]
        public async Task<HttpResponseMessage> UpdateInvoice(SchoolTaxInvoicedt Invoice, string key)
        {
            _repository.UpdateInvoice(Invoice, key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpGet]
        [Route("GetMassPost")]
        public async Task<ActionResult<List<dtBulkPost>?>> GetMassPosting(int BranchID, string AcademicYear, string FromDate, string ToDate, string Schedule, string key)
        {
            return await _repository.GetMassPosting(BranchID, AcademicYear, FromDate, ToDate, Schedule, key)!;
        }
        [HttpPost("[action]")]
        [Route("BulkPostAll")]
        public async Task<IActionResult> BulkPostAll(dtsVoucher value, string key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.BulkPostAll(value, key)!;
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
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }
    }
}
