using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherAllocationManagersController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IVoucherAllocationManagers _repository;
        public VoucherAllocationManagersController(IWebHostEnvironment environment, IVoucherAllocationManagers repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        [Route("StudentStatements")]
        public async Task<ActionResult<IEnumerable<dtStudentStatement>>> GetStatement(int Vid, int AccountID, int BranchID, string key)
        {
            return await _repository.GetStatements(Vid, AccountID, BranchID, key);
        }

        [HttpGet]
        [Route("Getallo")]
        public async Task<ActionResult<IEnumerable<dtStudentStatement>>> Getallo(int Vid, int AccountID, int BranchID, string key)
        {
            return await _repository.Getallo(Vid, AccountID, BranchID, key);
        }
        [HttpDelete("Delete")]
        [Route("Delete")]
        public async Task<int> Delete(int Vids, string key)
        {
            return await _repository.Delete(Vids, key);


        }

        [HttpDelete("Autoallo")]
        [Route("Autoallo")]
        public async Task<int> Autoallo(DateTime Dateauto, int AccountID, int BranchID, string key)
        {
            return await _repository.Autoallo(Dateauto, AccountID, BranchID, key);


        }
        [HttpPost("[action]")]
        [Route("Save")]
        public async Task<HttpResponseMessage> Savestatement(dtStudentStatement value, string key)
        {
            long ID = 0;
            ID = await _repository.Savestatement(value, key);
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
        [Route("Savefees")]
        public async Task<HttpResponseMessage> Savefee(SchoolStudentTran value, string? key)
        {
            long ID = 0;
            ID = await _repository.Savefee(value, key);
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
        [Route("Update")]
        public async Task<HttpResponseMessage> Updatestatement(dtStudentStatement value, string key)
        {
            long ID = 0;
            ID = await _repository.Updatestatement(value, key);
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
    }
}
