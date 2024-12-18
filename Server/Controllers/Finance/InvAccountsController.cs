
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvAccountsController : ControllerBase, IDisposable
    {
        private IWebHostEnvironment _environment;
        private IInvAccounts _repository;
        public InvAccountsController(IWebHostEnvironment environment, IInvAccounts repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // Dispose method to release resources
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
                _repository.Dispose();
            }
        }
        [HttpGet]
        [Route("PreReg")]
        public async Task<ActionResult<IEnumerable<DtoInvAccounts>>> GetPreReceipt(int BranchID, string Key)
        {
            return await _repository.GetPreRegisterStudents(BranchID, Key);

        }
        [HttpGet]
        [Route("AccountName")]
        public async Task<ActionResult<DtoInvAccounts>> GetAccountDetails(string value, int BranchID, string Key)
        {
            var dtInvAccounts = await _repository.GetAccountsDetails(value, BranchID, Key);
            if (dtInvAccounts == null)
            {
                return NotFound();
            }

            return dtInvAccounts;

        }
        [HttpGet]
        [Route("GetStudent")]
        public async Task<ActionResult<DtoInvAccounts>?> GetStudentAccount(int? AccountID, string? AccountCode,string? Criteria, int BranchID, string Key)
        {
            var dtInvAccounts = await _repository.GetDTAccount(AccountID,AccountCode,Criteria, BranchID,Key);
            if (dtInvAccounts == null)
            {
                return NotFound();
            }

            return dtInvAccounts;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoInvAccounts>>> GetdtInvAccountsCategory(string AccCategory, string AccSubCategory, string Key)
        {
            return await _repository.GetAccountsByCategory(AccCategory, AccSubCategory, Key);

        }
        [HttpGet]
        [Route("GetStudents")]
        public async Task<ActionResult<IEnumerable<DtoInvAccounts>>> GetStudentsAccounts(int BranchID, string Key, string? receiptType)
        {
            return await _repository.GetStudentsAccounts(BranchID, Key, receiptType);
        }
        [Route("GetAllStudentsGlobal")]
        public async Task<ActionResult<IEnumerable<dtoStudentRegisterDefault>>> GetStudentsAccountsGlobal(int BranchID, string Key, string? receiptType)
        {
            return await _repository.GetStudentsAccountsGlobal(BranchID, Key, receiptType);
        }

        [HttpGet]
        [Route("GetCustomers")]
        
        public async Task<ActionResult<IEnumerable<DtoInvAccounts>>> GetAccounts(string AccCategory, int BranchID, string Key)
        {
            return await _repository.GetAccounts(AccCategory, BranchID, Key);

        }
        //Parent Portal

        [HttpGet]
        [Route("ParentPortalStudent")]
        public async Task<ActionResult<DtoInvAccounts>> GetStudent(int BranchID, long AccID, string Key)
        {
            return await _repository.GetStudent(BranchID, AccID, Key);

        }
    }
}
