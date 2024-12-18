using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Finances
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassMasterController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IClassMaster _repository;
        public ClassMasterController(IWebHostEnvironment environment, IClassMaster repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<SchoolClassMaster>>> Getdata(int BranchID, string Key)
        {
            return await _repository.Getdata(BranchID, Key);
        }

        [HttpGet]
        [Route("GetClassByAcademicYear")]
        public async Task<ActionResult<IEnumerable<SchoolClassMaster>>> Getdata(int BranchID, string AcademicYear, string Key)
        {
            return await _repository.Getdata(BranchID, AcademicYear, Key);
        }

        [HttpGet]
        [Route("ClassMaster")]
        public async Task<ActionResult<SchoolClassMaster>> GetDTClassMaster(int Id, string Key)
        {
            return await _repository.GetDTClassMaster(Id, Key);
        }

        [HttpPost]
        [Route("UpdateMas")]
        public async Task<HttpResponseMessage> UpdateMas(SchoolClassMaster value, string Key)
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

        [HttpDelete("Delete")]
        [Route("Delete")]
        public async Task<int> DeleteMaster(int Id, string Key)
        {
            return await _repository.DeleteMaster(Id, Key);
        }

        [HttpPost("[action]")]
        [Route("SaveMas")]
        public async Task<HttpResponseMessage> SaveMaster(SchoolClassMaster value, string Key)
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

        [HttpGet]
        [Route("GetStudentTrans")]
        public async Task<ActionResult<IEnumerable<SchoolStudentTran>>> GetDTStudentTrans(string Class, int BranchID, string AcademicYear, string Key)
        {
            return await _repository.GetDTStudentTrans(Class, BranchID, AcademicYear, Key);
        }

        [HttpPost("[action]")]
        [Route("SaveUserTrack")]
        public async Task<HttpResponseMessage> SaveUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveUserTrack(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
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
        [Route("SaveClassDetails")]
        public async Task<IActionResult> SaveNewClassData(List<SchoolClassMaster> value, string Key)
        {
            long ID = 0;
            resultID result = new resultID();
            ID = await _repository.SaveNewClassData(value, Key);
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