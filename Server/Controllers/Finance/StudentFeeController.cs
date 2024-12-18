using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentFeeController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStudentFeeManager _repository;
        public StudentFeeController(IWebHostEnvironment environment, IStudentFeeManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<dtStudentFeeRegister>>> GetStudentFeeRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            return await _repository.GetStudentFeeRegister(AcademicYear, BranchID, FromDate, ToDate, Status, Type, key);
        }

        [HttpGet]
        [Route("FeeWise")]
        public async Task<ActionResult<IEnumerable<dtfeewiseregister>>> GetFeeWiseRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            return await _repository.GetFeeWiseRegister(AcademicYear, BranchID, FromDate, ToDate, Status, Type, key);
        }
        [Route("FeeWiseclass")]
        public async Task<ActionResult<IEnumerable<dtfeewiseregister>>> GetFeeWiseRegisterbyclassanddivision(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type,string cls,string div,string des, string key)
        {
            return await _repository.GetFeeWiseRegisterbyclassanddivision(AcademicYear, BranchID, FromDate, ToDate, Status, Type,cls,div,des, key);
        }
        //ParentStudentFeeWise
        [HttpGet]
        [Route("ParentStudentFeeWise")]
        public async Task<ActionResult<IEnumerable<dtStudentFeeRegister>>> GetParentStudentFeeWise(string AcademicYear, int BranchID, string Criteria, int AccountId, DateTime FromDate, DateTime ToDate, string Status, string key)
        {
            return await _repository.GetParentStudentFeeWise(AcademicYear, BranchID, Criteria, AccountId, FromDate, ToDate, Status, key);
        }

        [HttpGet]
        [Route("TermWise")]
        public async Task<ActionResult<IEnumerable<dtStudentFeeRegister>>> GetTermWiseRegister(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            return await _repository.GetTermWiseRegister(AcademicYear, BranchID, FromDate, ToDate, Status, Type, key);
        }

        [HttpGet]
        [Route("ParentFees")]
        public async Task<ActionResult<IEnumerable<dtStudentFeeRegister>>> GetParentFee(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            return await _repository.GetParentFee(AcademicYear, BranchID, FromDate, ToDate, Status, Type, key);
        }

        [HttpGet]
        [Route("FeeConflict")]
        public async Task<ActionResult<IEnumerable<dtStudentFeeRegister>>> GetFeeConflict(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            return await _repository.GetFeeConflict(AcademicYear, BranchID, FromDate, ToDate, Status, Type, key);
        }

        [HttpGet]
        [Route("StudentAll")]
        public async Task<ActionResult<IEnumerable<dtStudentFeeRegister>>> GetStudentFeeRegisterAll(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string key)
        {
            return await _repository.GetStudentFeeRegisterAll(AcademicYear, BranchID, FromDate, ToDate, key);
        }


        [HttpDelete("DeleteVoucher")]
        [Route("DeleteVoucher")]
        public async Task<int> DeleteVoucher(int VID, int bvid, string key)
        {
            return await _repository.DeleteVoucher(VID, bvid, key);
        }

        [HttpDelete("DeleteAllVoucherallocation")]
        [Route("DeleteAllVoucherallocation")]
        public async Task<int> DeleteAllVoucherallocation(int AccountID, DateTime Dates, string key)
        {
            return await _repository.DeleteAllVoucherallocation(AccountID, Dates, key);
        }

        [HttpGet]
        [Route("Feedetails")]
        public async Task<ActionResult<IEnumerable<object>>> GetStudentFeeRegisters(string AcademicYear, int BranchID, DateTime FromDate, DateTime ToDate, string Status, string Type, string key)
        {
            return await _repository.GetStudentFeeRegisters(AcademicYear, BranchID, FromDate, ToDate, Status, Type, key);
        }
    }

}
