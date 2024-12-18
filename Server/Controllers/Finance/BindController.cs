using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStudentMaster _repository;
        public BindController(IWebHostEnvironment environment, IStudentMaster repository)
        {
            _environment = environment;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MastDesignation>>> BindComboBox(string type, string Key)
        {
            return await _repository.BindComboBox(type, Key);
        }

        [HttpGet]
        [Route("Setting")]
        public async Task<ActionResult<string>> BindSettingsValue(string Category, string Key)
        {
            return Ok(await _repository.BindSettingsValue(Category, Key));
        }

        [HttpGet]
        [Route("StudentList")]
        public async Task<ActionResult<IEnumerable<dtStudentRegister>?>> GetStudentList(string AcademicYear, int? BranchID, string Key)
        {
            return await _repository.GetStudentList(AcademicYear, BranchID, Key);
        }

        [HttpGet]
        [Route("StudentListDefault")]
        public async Task<ActionResult<IEnumerable<dtoStudentRegisterDefault>?>> GetStudentListDefault(string AcademicYear, int? BranchID, string Key)
        {
            return await _repository.GetStudentListDefault(AcademicYear, BranchID, Key);
        }

        [HttpGet]
        [Route("StudentListByClass")]
        public async Task<ActionResult<IEnumerable<dtStudentRegister>>> GetStudentListByClass(string Class, string AcademicYear, int BranchID, string Key)
        {
            return await _repository.GetStudentListByClass(Class, AcademicYear, BranchID, Key);
        }

        [HttpGet]
        [Route("StudentListOwnClass")]
        public async Task<ActionResult<IEnumerable<dtStudentRegister>>> GetStudentListTeacher(string AcademicYear, int BranchID, int UserID, string Key)
        {
            return await _repository.GetStudentListTeacher(AcademicYear, BranchID, UserID, Key);
        }

        [HttpGet]
        [Route("EnableMenu")]
        public async Task<ActionResult<IEnumerable<SchoolWebMenuSettings>?>> EnableMenu(string Menu, string Key)
        {
            return await _repository.EnableMenu(Menu, Key);
        }
    }
}
