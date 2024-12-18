using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountManagerController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IDiscountManager _repository;
        public DiscountManagerController(IWebHostEnvironment environment, IDiscountManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<SchoolDiscountSchedule>>> Getdata(int BranchID, string Key)
        {
            return await _repository.Getdata(BranchID, Key);
        }

        [HttpGet]
        [Route("Discount")]
        public async Task<ActionResult<SchoolDiscountSchedule>> GetDTDiscount(int Id, int BranchID, string Key)
        {
            return await _repository.GetDTDiscount(Id, BranchID, Key);
        }

        [HttpGet]
        [Route("Getdt")]
        public async Task<ActionResult<SchoolDiscountSchedule>> Getdt(int BranchID, string Key)
        {
            return await _repository.Getdt(BranchID, Key);
        }

        [Route("SaveMas")]
        public async Task<HttpResponseMessage> SaveMaster(SchoolDiscountSchedule value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveMaster(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            if (ID != 0)
            {
                msg.StatusCode = (System.Net.HttpStatusCode)1;
            }
            else
            {
                msg.StatusCode = (System.Net.HttpStatusCode)0;
            }
            return msg;
        }

        [HttpDelete("Deletes")]
        [Route("Deletes")]
        public async Task<int> DeleteDiscount(int Id, string Key)
        {
            return await _repository.DeleteDiscount(Id, Key);
        }

        [HttpPost]
        [Route("UpdateMas")]
        public async Task<HttpResponseMessage> UpdateMas(SchoolDiscountSchedule value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateMaster(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            if (ID != 0)
            {
                msg.StatusCode = (System.Net.HttpStatusCode)1;
            }
            else
            {
                msg.StatusCode = (System.Net.HttpStatusCode)0;
            }
            return msg;
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
        [Route("EditSaveUserTrack")]
        public async Task<HttpResponseMessage> DeleteSaveUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.DeleteSaveUserTrack(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpGet]
        [Route("AccountID")]
        public async Task<ActionResult<string>> GetID(string AccountCode, string Key)
        {
            return Ok(await _repository.GetID(AccountCode, Key));
        }

        [HttpGet]
        [Route("PostTo")]
        public async Task<ActionResult<IEnumerable<Accounts>>> GetPostTo(int BranchID, string Key)
        {
            return await _repository.GetPostTo(BranchID, Key);
        }
    }
}
