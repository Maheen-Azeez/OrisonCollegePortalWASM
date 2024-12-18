using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IFeeMaster _repository;

        public FeeController(IWebHostEnvironment environment, IFeeMaster repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ActionResult<IEnumerable<Accounts>>> GetPostTo(int BranchID, string Key)
        {
            return await _repository.GetPostTo(BranchID, Key);
        }

        [HttpGet]
        [Route("Receipt")]
        public async Task<ActionResult<IEnumerable<VtypeTrans>>> GetReceipt(string Key)
        {
            return await _repository.GetReceipt(Key);
        }

        [HttpGet]
        [Route("FeeMasterList")]
        public async Task<ActionResult<IEnumerable<SchoolFeeMaster>>> GetFeeMasterList(string AcademicYear, int BranchID, string Key)
        {
            return await _repository.GetFeeMasterList(AcademicYear, BranchID, Key);
        }

        [HttpGet]
        [Route("FeeMaster/{ID}/{BranchID}")]
        public async Task<ActionResult<SchoolFeeMaster>> GetDTFeeMaster(int ID, int BranchID, string Key)
        {
            return await _repository.GetDTFeeMaster(ID, BranchID, Key);
        }


        [HttpGet]
        [Route("AccountID")]
        public async Task<ActionResult<string>> GetID(string AccountCode, string Key)
        {
            return Ok(await _repository.GetID(AccountCode, Key));
        }

        [HttpGet]
        [Route("ReceiptTypeID")]
        public async Task<ActionResult<string>> GetReceiptTypeID(string Key)
        {
            return Ok(await _repository.GetReceiptTypeID(Key));
        }

        [HttpPost("[action]")]
        [Route("SaveFeeMaster")]
        public async Task<IActionResult> SaveFeeMaster(SchoolFeeMaster value, string Key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.CreateFeeMaster(value, Key);
                HttpResponseMessage msg = new HttpResponseMessage();
                msg.StatusCode = (System.Net.HttpStatusCode)1;
                return new JsonResult(result);
            }
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }


        [HttpPost("[action]")]
        [Route("UpdateFeeMaster")]
        public async Task<IActionResult> UpdateFeeMaster(SchoolFeeMaster value, string Key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.EditFeeMaster(value, Key);
                HttpResponseMessage msg = new HttpResponseMessage();
                msg.StatusCode = (System.Net.HttpStatusCode)1;
                return new JsonResult(result);
            }
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }

        [HttpGet]
        [Route("ExistFeeMaster/{FeeID}/{BranchID}")]
        public async Task<ActionResult<SchoolFeeMaster>> GetExistFeeMaster(int FeeID, int BranchID, string Key)
        {
            SchoolFeeMaster SchoolFee = new SchoolFeeMaster();

            SchoolFee = await _repository.GetExistFeeMaster(FeeID, BranchID, Key);
            if (SchoolFee == null)
            {
                SchoolFee = new SchoolFeeMaster() { Id = 0 };
            }
            return SchoolFee;
        }

        [HttpPost]
        [Route("DeleteFeeMaster")]
        public async Task<HttpResponseMessage> DeleteFeeMaster(dtMasterStudent Fee, string Key)
        {
            long ID;
            ID = await _repository.DeleteFeeMaster(Fee, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        public class resultID
        {
            public long ID { get; set; }
        }

        public class ErrorResult
        {
            public String? Error { get; set; }
        }
    }
}
