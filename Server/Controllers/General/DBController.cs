using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase, IDisposable
    {
        private IWebHostEnvironment _environment;
        private IDBOperation _dBOperation;
        public DBController(IWebHostEnvironment environment, IDBOperation dBOperation )
        {
            _environment = environment;
            this._dBOperation = dBOperation ?? throw new ArgumentNullException(nameof(dBOperation));
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any managed resources here
                _dBOperation.Dispose();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolAcademicYear>>> GetAcademicYear(int BranchID, string key)
        {
            return await _dBOperation.GetAcademicYear(BranchID, key);
        }

        [HttpGet]
        [Route("CurrentYear")]
        public async Task<ActionResult<string>> GetCurrentAcademicYear(int? BranchID, string key)
        {
            return Ok(await _dBOperation.GetCurrentAcademicYear(BranchID, key));
        }

        [HttpGet]
        [Route("Class")]
        public async Task<ActionResult<IEnumerable<SchoolClassMaster>?>> GetClass(int? BranchID, string key)
        {
            return await _dBOperation.GetClass(BranchID, key);
        }

        [HttpGet]
        [Route("ClassByAcademicYear")]
        public async Task<ActionResult<IEnumerable<SchoolClassMaster>?>> GetClass(int? BranchID, string AcademicYear, string key)
        {
            return await _dBOperation.GetClass(BranchID, AcademicYear, key);
        }

        [HttpGet]
        [Route("Division")]
        public async Task<ActionResult<IEnumerable<SchoolClass>?>> GetDivision(int? BranchID, string key)
        {
            return await _dBOperation.GetDivision(BranchID, key);
        }

        [HttpGet]
        [Route("DivisionByAcademicYear")]
        public async Task<ActionResult<IEnumerable<SchoolClass>?>> GetDivision(int? BranchID, string AcademicYear, string key)
        {
            return await _dBOperation.GetDivision(BranchID, AcademicYear, key);
        }

        [HttpGet]
        [Route("DivisionByClass")]
        public async Task<ActionResult<IEnumerable<SchoolClass>?>> GetDivisionByClass(int? BranchID, string Class, string key)
        {
            return await _dBOperation.GetDivisionByClass(BranchID, Class, key);
        }

        [HttpGet]
        [Route("UserOwnClass")]
        public async Task<ActionResult<IEnumerable<SchoolClassMaster>?>> GetUserOwnClass(int UserID, int? BranchID, string key)
        {
            return await _dBOperation.GetUserOwnClass(UserID, BranchID, key);
        }

        [HttpGet]
        [Route("UserOwnDivision")]
        public async Task<ActionResult<IEnumerable<SchoolClass>?>> GetUserOwnDivision(int UserID, int? BranchID, string key)
        {
            return await _dBOperation.GetUserOwnDivision(UserID, BranchID, key);
        }

        [HttpGet]
        [Route("Fee")]
        public async Task<ActionResult<IEnumerable<SchoolFeeSchedule>?>> GetFee(string AcademicYear, int? BranchID, string key)
        {
            return await _dBOperation.GetFee(AcademicYear, BranchID, key);
        }

        [HttpGet]
        [Route("Transport")]
        public async Task<ActionResult<IEnumerable<SchoolFeeSchedule>?>> GetTransport(string AcademicYear, int? BranchID, string key)
        {
            return await _dBOperation.GetTransport(AcademicYear, BranchID, key);
        }

        [HttpGet]
        [Route("Admission")]
        public async Task<ActionResult<IEnumerable<SchoolFeeSchedule>?>> GetAdmission(string AcademicYear, int? BranchID, string key)
        {
            return await _dBOperation.GetAdmission(AcademicYear, BranchID, key);
        }

        [HttpGet]
        [Route("FeeDiscount")]
        public async Task<ActionResult<IEnumerable<SchoolDiscountSchedule>?>> GetFeeDiscount(int? BranchID, string key)
        {
            return await _dBOperation.GetFeeDiscount(BranchID, key);
        }

        [HttpGet]
        [Route("Activity")]
        public async Task<ActionResult<IEnumerable<SchoolFeeSchedule>?>> GetActivity(string AcademicYear, int? BranchID, string key)
        {
            return await _dBOperation.GetActivity(AcademicYear, BranchID, key);
        }


        [HttpGet]
        [Route("Staff")]
        public async Task<ActionResult<IEnumerable<Accounts>?>> GetStaff(int? BranchID, string key)
        {
            return await _dBOperation.GetStaff(BranchID, key);
        }

        //[HttpGet]
        //[Route("Parent")]
        //public async Task<ActionResult<IEnumerable<dtStudentRegister>?>> GetParent(int? BranchID, string key)
        //{
        //    return await _dBOperation.GetParent(BranchID, key);
        //}

        [HttpGet]
        [Route("Parent")]
        public async Task<ActionResult<IEnumerable<dtoStudentRegisterDefault>?>> GetParent(int? BranchID, string key)
        {
            return await _dBOperation.GetParent(BranchID, key);
        }

        [HttpGet]
        [Route("BusDetails")]
        public async Task<ActionResult<IEnumerable<HrtransportationMast>?>> GetBusDetails(int? BranchID, string key)
        {
            return await _dBOperation.GetBusDetails(BranchID, key);
        }


        [HttpGet]
        [Route("PLevel")]
        public async Task<ActionResult<string>> GetPLevel(string key)
        {
            return Ok(await _dBOperation.GetPLevel(key));
        }


        [HttpGet]
        [Route("PLevelID")]
        public async Task<ActionResult<string>> GetPLevelID(string key)
        {
            return Ok(await _dBOperation.GetPLevelID(key));
        }

        [HttpGet]
        [Route("AccountGroup")]
        public async Task<ActionResult<string>> GetAccountGroup(int PID, string key)
        {
            return Ok(await _dBOperation.GetAccountGroup(PID, key));
        }

        [HttpGet]
        [Route("SubGroup")]
        public async Task<ActionResult<string>> GetSubGroup(int PID, string key)
        {
            return Ok(await _dBOperation.GetSubGroup(PID, key));
        }

        [HttpGet]
        [Route("AccCategory")]
        public async Task<ActionResult<string>> GetAccCategory(int PID, string key)
        {
            return Ok(await _dBOperation.GetAccCategory(PID, key));
        }

        [HttpGet]
        [Route("ShowChild")]
        public async Task<ActionResult<string>> GetShowChild(int PID, string key)
        {
            return Ok(await _dBOperation.GetShowChild(PID, key));
        }

        [HttpGet]
        [Route("AccCategoryMast")]
        public async Task<ActionResult<string>> GetAccCategoryMast(string key)
        {
            return Ok(await _dBOperation.GetAccCategoryMast(key));
        }

        [HttpGet]
        [Route("Abbr")]
        public async Task<ActionResult<string>> GetAbbr(int BranchID, string key)
        {
            return Ok(await _dBOperation.GetAbbr(BranchID, key));
        }

        [HttpGet]
        [Route("ExistStudentCode")]

        public async Task<ActionResult<string>> GetSExistNo(int BranchID, string key)
        {
            return Ok(await _dBOperation.GetSExistNo(BranchID, key));
        }

        [HttpGet]
        [Route("NextStudentCode")]

        public async Task<ActionResult<string>> GetNextNo(int BranchID, string key)
        {
            return Ok(await _dBOperation.GetNextNo(BranchID, key));
        }

        [HttpGet]
        [Route("NextParentCode")]

        public async Task<ActionResult<string>> GetParentNextNo(int BranchId, string Scode, string key)
        {
            return Ok(await _dBOperation.GetParentNextNo(BranchId, Scode, key));
        }


        [HttpGet]
        [Route("StaffID")]

        public async Task<ActionResult<string>> GetStaffID(int BranchID, string Code, string key)
        {
            return Ok(await _dBOperation.GetStaffID(BranchID, Code, key));
        }

        [HttpGet]
        [Route("School")]
        public async Task<ActionResult<string>> GetSchool(string key)
        {
            return Ok(await _dBOperation.GetSchool(key));
        }

        [HttpGet]
        [Route("Company")]
        public async Task<ActionResult<string>> GetCompany(int? BranchID, string key)
        {
            return Ok(await _dBOperation.GetCompany(BranchID, key));
        }

        [HttpGet]
        [Route("ExistImportStudentCode")]
        public async Task<ActionResult<string>> GetExistStudent(string Scode, int BranchID, string key)
        {
            return Ok(await _dBOperation.GetExistStudent(Scode, BranchID, key));
        }

        [HttpGet]
        [Route("ExistSyncStudentCode")]
        public async Task<ActionResult<string>> GetExistSyncStudent(string Scode, int BranchID, string key)
        {
            return Ok(await _dBOperation.GetExistSyncStudent(Scode, BranchID, key));
        }

        [HttpGet]
        [Route("ExistParent")]
        public async Task<ActionResult<int>> GetExistParentID(string Pcode, int BranchID, string key)
        {
            return Ok(await _dBOperation.GetExistParentID(Pcode, BranchID, key));
        }

        [HttpGet]
        [Route("GetTeacherName")]
        public async Task<ActionResult<string>> GetTeacherName(string Class, string Division, int BranchID, string key)
        {
            return Ok(await _dBOperation.GetTeacherName(Class, Division, BranchID, key));
        }

        [HttpGet]
        [Route("MailTemplate")]
        public async Task<ActionResult<IEnumerable<SchoolMailTemplate>>> GetMailTemplate(string Type, int BranchID, string key)
        {
            return await _dBOperation.GetMailTemplate(Type, BranchID, key);
        }


        [HttpGet]
        [Route("SMSTemplate")]
        public async Task<ActionResult<string>> GetSMSTemplate(int BranchID, string key)
        {
            return Ok(await _dBOperation.GetSMSTemplate(BranchID, key));
        }
     
     
        [HttpGet]
        [Route("CompanyDetails")]
        public async Task<List<dtCompany>> GetCompanyDetails(long BranchID, string key)
        {
            return await _dBOperation.GetCompanyDetails(BranchID, key);
        }

        [HttpGet]
        [Route("GetCombanyLogo")]
        public async Task<List<object>> GetCombanyLogo(int BranchID, string key)
        {
            return await _dBOperation.GetCombanyLogo(BranchID, key);
        }


        [HttpGet]
        [Route("GetDocUrl")]
        public async Task<ActionResult<string>> DocUrl(string Path, string key)
        {
            return Ok(await _dBOperation.DocUrl(Path, key));
        }

        [HttpGet]
        [Route("GetMailType")]
        public async Task<ActionResult<string>> GetMailType(int BranchID, string key)
        {
            return Ok(await _dBOperation.GetMailType(BranchID, key));
        }


      
        [HttpGet]
        [Route("Emirate")]
        public async Task<ActionResult<string>> GetDefEmirate(int BranchID, string key)
        {
            return Ok(await _dBOperation.GetDefEmirate(BranchID, key));
        }
    }
}
