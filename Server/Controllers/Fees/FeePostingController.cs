using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Server.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OrisonCollegePortal.Server.Controllers.Fees
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeePostingController : ControllerBase
    {
        private readonly IFeePostingManager _feePostingManager;
        private readonly IFeeManager _feeManager;
        public FeePostingController(IFeePostingManager feePostingManager, IFeeManager feeManager)
        {
            _feePostingManager = feePostingManager;
            _feeManager = feeManager;

        }

        [HttpGet]
        [Route("Fee")]
        public async Task<ActionResult<IEnumerable<CollegeClass>>> GetFee(string AcademicYear, int BranchID,string Key)
        {
            return await _feePostingManager.GetFee(AcademicYear, BranchID, Key);
        }
        [HttpGet(nameof(GetAcademicYear))]
        public async Task<FeeMaster> GetAcademicYear(string Key)
        {
            try
            {
                FeeMaster AcademicYear = new FeeMaster();
                AcademicYear = await _feeManager.GetAcademicYear(Key);
                return AcademicYear;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("Transport")]
        public async Task<ActionResult<IEnumerable<CollegeClass>>> GetTransport(string AcademicYear, int BranchID, string Key)
        {
            return await _feePostingManager.GetTransport(AcademicYear, BranchID, Key);
        }

        [HttpGet]
        [Route("Admission")]
        public async Task<ActionResult<IEnumerable<CollegeClass>>> GetAdmission(string AcademicYear, int BranchID, string Key)
        {
            return await _feePostingManager.GetAdmission(AcademicYear, BranchID, Key);
        }

        [HttpGet]
        [Route("FeeDiscount")]
        public async Task<ActionResult<IEnumerable<CollegeClass>>> GetFeeDiscount(int BranchID, string Key)
        {
            return await _feePostingManager.GetFeeDiscount(BranchID, Key);
        }

        [HttpGet]
        [Route("vtype")]

        public async Task<int> GetVtype(string FeeType, string Key)
        {
            return await _feePostingManager.GetVtype(FeeType, Key);
        }
        [HttpGet]
        [Route("keyword")]

        public async Task<int> getUniqueAccID(string Value, string Key)
        {
            return await _feePostingManager.getUniqueAccID(Value, Key);
        }
        [HttpGet]
        [Route("feexist")]

        public async Task<int> FeePostChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Remark, string Key)
        {
            return await _feePostingManager.FeePostChecking(AccountId, vtype, fromdate, todate, Type, Remark, Key);
        }
        [HttpGet]
        [Route("Discountexist")]

        public async Task<int> FeeDiscountChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Remark, string Key)
        {
            return await _feePostingManager.FeeDiscountChecking(AccountId, vtype, fromdate, todate, Type, Remark, Key);
        }
        [HttpGet]
        [Route("FeeSchedule")]
        public async Task<ActionResult<IEnumerable<dtFeeSchedule>>> GetFeeSchedule(string AcademicYear, int BranchID, String Code, DateTime fromdate, DateTime todate, string Type, string Key)
        {
            return await _feePostingManager.GetFeeSchedule(AcademicYear, BranchID, Code, fromdate, todate, Type, Key);
        }
        [HttpGet]
        [Route("DiscountSchedule")]
        public async Task<ActionResult<IEnumerable<dtDiscountSchedule>>> GetDiscountSchedule(int BranchID, String Schedule, string Key)
        {
            return await _feePostingManager.GetDiscountSchedule(BranchID, Schedule, Key);
        }
        [HttpPost("[action]")]
        [Route("post")]
        public async Task<HttpResponseMessage> AddData(dtsVoucher value, string Key)
        {
            long ID = 0;
            ID = await _feePostingManager.CreatePostingVoucher(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }
        [HttpPost("[action]")]
        [Route("postDiscount")]
        public async Task<HttpResponseMessage> PostingDiscount(dtsVoucher value, string Key)
        {
            long ID = 0;
            ID = await _feePostingManager.PostingDiscount(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }
        [HttpGet]
        [Route("FeeSummary")]
        public async Task<ActionResult<dtStudentFeeSummary>> GetFeeSummary(int AccountId, int BranchID, String AcademicYear, string Key)
        {
            return await _feePostingManager.GetFeeSummary(AccountId, BranchID, AcademicYear, Key);
        }
        [HttpGet]
        [Route("FeeDetails")]
        public async Task<ActionResult<IEnumerable<dtStudentFeeDetails>>> GetFeeDetails(int AccountId, int BranchID, String AcademicYear, string Key)
        {
            return await _feePostingManager.GetFeeDetails(AccountId, BranchID, AcademicYear, Key);
        }
        [HttpGet]
        [Route("allocexist")]

        public async Task<int> FeeAllocChecking(int AccountId, int vtype, DateTime fromdate, DateTime todate, string Type, string Key)
        {
            return await _feePostingManager.FeeAllocChecking(AccountId, vtype, fromdate, todate, Type, Key);
        }
        [HttpGet]
        [Route("StudentStatement")]

        public async Task<ActionResult<IEnumerable<dtStudentStatement>>> GetStatement(int BranchID, int AccountID, DateTime SDate, DateTime EDate, string Key)
        {
            return await _feePostingManager.GetStatement(BranchID, AccountID, SDate, EDate, Key);
        }
        [HttpPost("[action]")]
        [Route("depost")]
        public async Task<HttpResponseMessage> DeleteData(dtsVoucher value, string Key)
        {
            long ID = 0;
            ID = await _feePostingManager.DeletePostingVoucher(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }
        [HttpGet(nameof(GetFeeSchedule))]
        public async Task<List<FeeMaster>> GetFeeSchedule(int BranchID, string Key)
        {
            try
            {
                var Result = await _feeManager.GetFeeSchedule(BranchID, Key);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet(nameof(GetPostedFee))]
        public async Task<List<FeeMaster>> GetPostedFee(int AccountId, string Key)
        {
            try
            {
                var Result = await _feeManager.GetPostedFee(AccountId, Key);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("[action]")]
        [Route("InsertPostedFee")]
        public async Task<bool> InsertPostedFee(FeeMaster feemaster, string Key)
        {
            long ID = 0;
            ID = await _feeManager.InsertPostedFee(feemaster, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return true;

        }

        //[HttpDelete(nameof(DeleteDepostedRecords))]
        [Route("DeleteDepostedRecords")]
        public async Task<HttpResponseMessage> DeleteDepostedRecords(int Id, string Key)
        {
            await _feeManager.DeleteDepostedRecords(Id, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }

        [Route("feexist")]
        public async Task<int> FeePostChecking(FeeMaster feeMaster, string Key)
        {
            return await _feeManager.FeePostChecking(feeMaster, Key);
        }

        [HttpGet]
        [Route("BindComboBox")]
        public async Task<ActionResult<IEnumerable<MastDesignation>>> BindComboBox(string type, string Key)
        {
            return await _feeManager.BindComboBox(type, Key);
        }
        [HttpGet]
        [Route("OtherFee")]
        public async Task<ActionResult<IEnumerable<CollegeClass>>> GetOtherFee(string AcademicYear, int BranchID, string Key)
        {
            return await _feePostingManager.GetOtherFee(AcademicYear, BranchID,Key);
        }
    }
}
