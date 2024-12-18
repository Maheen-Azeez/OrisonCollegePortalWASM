using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStudentManager _repository;
        private IStudentMainManager _mainManager;

        public StudentController( IWebHostEnvironment environment, IStudentManager repository, IStudentMainManager mainManager)
        {
            _environment = environment;
            _repository = repository;
            _mainManager = mainManager;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Student>> GetAll(int branchid, string Accyear, string Key)
        {
           
                return await _repository.GetAll(branchid, Accyear, Key);
                
        }

        [HttpPost(nameof(InsertStudent))]
        public async Task<HttpResponseMessage> InsertStudent(string Key, Student student)
        {
            bool v = false;
            try
            {
                v = await _mainManager.InsertStudent(student, Key);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }
        [HttpPost(nameof(UpdateStudent))]
        public async Task<HttpResponseMessage> UpdateStudent(string Key, Student student)
        {
            bool v = false;
            try
            {
                v = await _mainManager.UpdateStudent(student, Key);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }
        [HttpGet(nameof(GetStudent))]
        // [HttpGet(nameof(GetLGSItem))]
        public async Task<Student> GetStudent(string ID, string Key)
        {

            return await _repository.GetStudent(ID,Key);
        }
        [HttpGet(nameof(GetInTake))]
        //[HttpGet(nameof(GetLGSItem))]
        public async Task<Col_Intake> GetInTake(string Name, string Key)
        {

            var result = await _repository.GetIntake(Name, Key);
            if (result == null)
            {
                result = new Col_Intake();
                return result;
            }
            else
                return result;
        }
        [HttpGet(nameof(GetComboBoxList))]
        // [HttpGet(nameof(GetLGSItem))]
        public async Task<List<string>> GetComboBoxList(string type, string Key)
        {


            return await _repository.GetComboList(type, Key);
        }
        [HttpGet(nameof(GetAccyear))]
        public async Task<List<Col_AccademicYear>> GetAccyear(string Key)
        {
            return await _repository.GetAccyear(Key);
        }
        [HttpGet(nameof(GetNextStudentCode))]
        public async Task<string> GetNextStudentCode(int branchid, string Key)
        {
            var re = "";
            try
            {
                re = await _repository.GetNextStudentCode(branchid, Key);
                return re;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return re;
        }

        [HttpGet]
        [Route("Abbr")]
        public async Task<ActionResult<string>> GetAbbr(int BranchID, string Key)
        {
            return Ok(await _repository.GetAbbr(BranchID, Key));
        }

        [HttpGet]
        [Route("Default")]
        public async Task<ActionResult<IEnumerable<dtoStudentRegisterDefault>?>> GetStudentsDefault(string AcademicYear, int? BranchID, string? Category, int? UserID, string Key)
        {
            return await _repository.GetStudentsDefault(AcademicYear, BranchID, Category, UserID, Key);
        }
    }

}
