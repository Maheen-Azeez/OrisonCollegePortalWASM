using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalFeeController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IAdditionalFeeMaster _repository;
        public AdditionalFeeController(IWebHostEnvironment environment, IAdditionalFeeMaster repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        [Route("GetFee")]
        public async Task<ActionResult<IEnumerable<SchoolFeeMaster>>> Getdata(int BranchID, string AcademicYear, string Key)
        {
            return await _repository.Getdata(BranchID, AcademicYear, Key);

        }
        [HttpGet]
        [Route("Additional")]
        public async Task<ActionResult<SchoolFeeMaster>> GetAdditional(int ID, int BranchID, string Key)
        {
            return await _repository.GetAdditional(BranchID, ID, Key);
        }
        [HttpGet]
        [Route("AccountID")]
        public async Task<ActionResult<string>> GetID(string AccountCode, string Key)
        {
            return Ok(await _repository.GetID(AccountCode, Key));
        }

        [HttpPost("[action]")]
        [Route("AddSaveUserTrack")]
        public async Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.AddSaveUserTrack(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("EditSaveUserTrack")]
        public async Task<HttpResponseMessage> EditSaveUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.EditSaveUserTrack(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("SaveMas")]
        public async Task<IActionResult> SaveMaster(SchoolFeeMaster value, string Key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.SaveMaster(value, Key);
                HttpResponseMessage msg = new HttpResponseMessage();
                if (ID != 0)
                {
                    msg.StatusCode = (System.Net.HttpStatusCode)1;
                    result.ID = ID;
                    return new JsonResult(result);
                }
                else
                {
                    msg.StatusCode = (System.Net.HttpStatusCode)0;
                    result.ID = 0;
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
        [Route("Receipt")]
        public async Task<ActionResult<IEnumerable<VtypeTrans>>> GetReceipt(string Key)
        {
            return await _repository.GetReceipt(Key);
        }

        [HttpGet]
        [Route("PostTo")]
        public async Task<ActionResult<IEnumerable<Accounts>>> GetPostTo(int BranchID, string Key)
        {
            return await _repository.GetPostTo(BranchID, Key);
        }

        [HttpPost]
        [Route("UpdateMas")]
        public async Task<IActionResult> UpdateMas(SchoolFeeMaster value, string Key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.UpdateMaster(value, Key);
                HttpResponseMessage msg = new HttpResponseMessage();
                if (ID != 0)
                {
                    msg.StatusCode = (System.Net.HttpStatusCode)1;
                    result.ID = ID;
                    return new JsonResult(result);
                }
                else
                {
                    msg.StatusCode = (System.Net.HttpStatusCode)0;
                    result.ID = 0;
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

        [HttpDelete("Deletes")]
        [Route("Deletes")]
        public async Task<int> DeleteAdditional(int ID, string Key)
        {
            return await _repository.DeleteAdditional(ID, Key);
        }

        [HttpPost("[action]")]
        [Route("DeleteSaveUserTrack")]
        public async Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.DeleteSaveUserTrack(value, Key);
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
