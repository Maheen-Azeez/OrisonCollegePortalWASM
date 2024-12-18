using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using Dapper;
using System.Data;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeScheduleController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IFeeSchedule _repository;

        public FeeScheduleController(IWebHostEnvironment environment, IFeeSchedule repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ActionResult<IEnumerable<SchoolFeeSchedule>>> GetFeeScheduleList(int BranchID, string AcademicYear, string Key)
        {
            return await _repository.GetFeeScheduleList(BranchID, AcademicYear, Key);
        }

        [HttpGet]
        [Route("Schedule")]
        public async Task<ActionResult<string>> GetFeeSchedule(string ID, int BranchID, string Key)
        {
            return Ok(await _repository.GetFeeSchedule(ID, BranchID, Key));
        }

        [HttpGet]
        [Route("FeeScheduleList")]
        public async Task<ActionResult<IEnumerable<SchoolFeeScheduleTran>>> GetFeeScheduleList(string Fee, int BranchID, string AcademicYear, string Key)
        {
            return await _repository.GetFeeScheduleList(Fee, BranchID, AcademicYear, Key);
        }


        [HttpGet]
        [Route("FeeScheduleData/{ID}/{BranchID}")]
        public async Task<ActionResult<SchoolFeeSchedule>> GetDTFeeScheduleData(int ID, int BranchID, string AcademicYear, string Key)
        {
            return await _repository.GetDTFeeScheduleData(ID, BranchID, AcademicYear, Key);
        }

        [HttpGet]
        [Route("StudentCount")]
        public async Task<ActionResult<string>> GetStudCode(string CourseStream, string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCode(CourseStream, Class, Shift, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("StudentCountSecond")]
        public async Task<ActionResult<string>> GetStudCodeSecond(string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCodeSecond(Class, Shift, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("StudentCountThird")]
        public async Task<ActionResult<string>> GetStudCodeThird(string CourseStream, string Class, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCodeThird(CourseStream, Class, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("StudentCountFourth")]
        public async Task<ActionResult<string>> GetStudCodeFourth(string Class, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCodeFourth(Class, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("StudentCountTransport")]
        public async Task<ActionResult<string>> GetStudCountTransport(string BusNo, string BusMode, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCountTransport(BusNo, BusMode, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("StudentCountRegistration")]
        public async Task<ActionResult<string>> GetStudCountRegistration(string JoiningYear, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCountRegistration(JoiningYear, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("FeeCode")]
        public async Task<ActionResult<IEnumerable<SchoolFeeMaster>>> GetCode(int BranchID, string Key)
        {
            return await _repository.GetCode(BranchID, Key);
        }

        [HttpGet]
        [Route("Category")]
        public async Task<ActionResult<string>> GetCategory(string Code, int BranchID, string Key)
        {
            return Ok(await _repository.GetCategory(Code, BranchID, Key));
        }

        [HttpGet]
        [Route("ExistFeeSchedule")]
        public async Task<ActionResult<string>> GetExistFeeSchedule(string FeeSchedule, int BranchID, string AcademicYear, string Key)
        {
            return Ok(await _repository.GetExistFeeSchedule(FeeSchedule, BranchID, AcademicYear, Key));
        }

        [HttpGet]
        [Route("StudentTrans/{FeeSchedule}/{BranchID}/{AcademicYear}")]
        public async Task<ActionResult<IEnumerable<SchoolStudentTran>>> GetDTStudentTrans(string FeeSchedule, int BranchID, string AcademicYear, string Key)
        {
            return await _repository.GetDTStudentTrans(FeeSchedule, BranchID, AcademicYear, Key);
        }
        //[HttpGet]
        //[Route("ScheduleByDocID/{FeeID}")]
        //public async Task<ActionResult<SchoolFeeMaster>> GetDocumentByDocId(int FeeID)
        //{
        //    var Doc = await _repository.GetDocumentByDocId(FeeID);
        //    return Doc;
        //}
        //[HttpGet]
        //[Route("FeeDescription")]
        //public async Task<ActionResult<IEnumerable<SchoolFeeMaster>>> GetDescription(int BranchID)
        //{
        //    return await _repository.GetDescription(BranchID);
        //}

        //[HttpGet]
        //[Route("FeePost")]
        //public async Task<ActionResult<IEnumerable<SchoolFeeMaster>>> GetFeePost(int BranchID)
        //{
        //    return await _repository.GetFeePost(BranchID);
        //}

        [HttpPost("[action]")]
        [Route("UpdateStudentTrans")]
        public async Task<HttpResponseMessage> UpdateStudentTrans(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.EditStudentTrans(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateStudTrans")]
        public async Task<HttpResponseMessage> UpdateStudTrans(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.EditStudTrans(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("EditStudentTrans")]
        public async Task<HttpResponseMessage> EditStudentTrans(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateStudentTrans(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("EditStudTrans")]
        public async Task<HttpResponseMessage> EditStudTrans(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateStudTrans(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateStudentTransSchedule")]
        public async Task<HttpResponseMessage> UpdateStudentTransSchedule(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateStudentTransSchedule(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateStudentAdmissionSchedule")]
        public async Task<HttpResponseMessage> UpdateStudentAdmissionSchedule(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateStudentAdmissionSchedule(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("SaveFeeSchedule")]
        public async Task<HttpResponseMessage> SaveFeeSchedule(SchoolFeeSchedule value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveFeeSchedule(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("SaveFeeScheduleTran")]
        public async Task<HttpResponseMessage> SaveFeeScheduleTran(SchoolFeeScheduleTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveFeeScheduleTran(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }


        [HttpPost("[action]")]
        [Route("EditFeeSchedule")]
        public async Task<HttpResponseMessage> UpdateFeeSchedule(SchoolFeeSchedule value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateFeeSchedule(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("EditFeeScheduleTran")]
        public async Task<HttpResponseMessage> UpdateFeeScheduleTran(SchoolFeeScheduleTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateFeeScheduleTran(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }


        [HttpPost]
        [Route("DeleteFeeSchedule")]
        public async Task<HttpResponseMessage> DeleteFeeSchedule(SchoolFeeSchedule Fee, string Key)
        {
            long ID;
            ID = await _repository.DeleteFeeSchedule(Fee, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost]
        [Route("DeleteFeeScheduleTrans")]
        public async Task<HttpResponseMessage> DeleteFeeScheduleTrans(SchoolFeeScheduleTran Fee, string Key)
        {
            long ID;
            ID = await _repository.DeleteFeeScheduleTrans(Fee, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
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
        [Route("SaveFeeUserTrack")]
        public async Task<HttpResponseMessage> SaveFeeUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveFeeUserTrack(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("SaveFeeTranUserTrack")]
        public async Task<HttpResponseMessage> SaveFeeTranUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveFeeTranUserTrack(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdatedFeeUserTrack")]
        public async Task<HttpResponseMessage> SaveUpdateFeeUserTrack(DtoUserTrack value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveUpdateFeeUserTrack(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpGet]
        [Route("StudentCountAll")]
        public async Task<ActionResult<string>> GetStudCountAll(string Class, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCountAll(Class, AcademicYear, BranchID, Key));
        }


        [HttpGet]
        [Route("StudentCountOverwrite")]
        public async Task<ActionResult<string>> GetStudCodeOverwrite(string CourseStream, string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCodeOverwrite(CourseStream, Class, Shift, AcademicYear, BranchID, Key));
        }

        [HttpPost("[action]")]
        [Route("UpdateStudentTransOverwrite")]
        public async Task<HttpResponseMessage> UpdateStudentTransOverwrite(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.EditStudentTransOverwrite(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }
        [HttpPost("[action]")]
        [Route("EditStudentTransOverwrite")]
        public async Task<HttpResponseMessage> EditStudentTransOverwrite(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateStudentTransOverwrite(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateStudTransOverwrite")]
        public async Task<HttpResponseMessage> UpdateStudTransOverwrite(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.EditStudTransOverwrite(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }
        [HttpPost("[action]")]
        [Route("EditStudTransOverwrite")]
        public async Task<HttpResponseMessage> EditStudTransOverwrite(SchoolStudentTran value, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateStudTransOverwrite(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpGet]
        [Route("StudentCountSecondOverwrite")]
        public async Task<ActionResult<string>> GetStudCodeSecondOverwrite(string Class, string Shift, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCodeSecondOverwrite(Class, Shift, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("StudentCountThirdOverwrite")]
        public async Task<ActionResult<string>> GetStudCodeThirdOverwrite(string CourseStream, string Class, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCodeThirdOverwrite(CourseStream, Class, AcademicYear, BranchID, Key));
        }

        [HttpGet]
        [Route("StudentCountFourthOverwrite")]
        public async Task<ActionResult<string>> GetStudCodeFourthOverwrite(string Class, string AcademicYear, int BranchID, string Key)
        {
            return Ok(await _repository.GetStudCodeFourthOverwrite( Class,  AcademicYear,  BranchID,  Key));
        }
    }
}
