using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.PaymentLink;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.PaymentLink;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net;
using System.Text;
using System.Web;
using static OrisonCollegePortal.Shared.Entities.PaymentLink.Models;

namespace OrisonCollegePortal.Server.Controllers.PaymentLink
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkGenerationController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ILinkGeneration _repository;

        public LinkGenerationController(IWebHostEnvironment environment, ILinkGeneration repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("GetPurpose")]
        public async Task<ActionResult<IEnumerable<NexopayPurpose>>> GetPurpose(string Key)
        {
            return await _repository.GetPurpose(Key);
        }

        [HttpGet]
        [Route("StudentListByClass")]
        public async Task<ActionResult<IEnumerable<dtStudentRegister>>> GetStudentListByClass(string Class, string AcademicYear, int BranchID, string Key)
        {
            return await _repository.GetStudentListByClass(Class, AcademicYear, BranchID, Key);
        }

        [HttpGet]
        [Route("GetStudentData")]
        public async Task<ActionResult<IEnumerable<StudentData>>> GetStudentData(int AccountID, string SchoolCode, string Key)
        {
            return await _repository.GetStudentData(AccountID, SchoolCode, Key);
        }

        [HttpPost("[action]")]
        [Route("SavePaymentRequest")]
        public async Task<IActionResult> SavePaymentRequest(OrderRequest value, string SchoolCode, string Key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.SavePaymentRequest(value, SchoolCode, Key);
                HttpResponseMessage msg = new HttpResponseMessage();
                if (ID == 0)
                {
                    msg.StatusCode = (System.Net.HttpStatusCode)0;
                    result.ID = 0;
                    return new JsonResult(result);
                }
                else
                {
                    msg.StatusCode = (System.Net.HttpStatusCode)1;
                    result.ID = ID;
                    return new JsonResult(result);
                }
            }
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
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

        [HttpGet]
        [Route("WebRequest")]
        public async Task<IActionResult> webRequestCreate(string ApiUrl, string ApiKey, string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "POST";

            byte[] byteArray;
            WebResponse response;
            StreamReader reader;
            Stream dataStream;
            string responseFromServer;
            // jsonContent = "{\"landing\": {\"to\": \"fee-payment-summary\"},\"s2s\": {\"amount\": 1},\"parent\": {\"fullName\": \"Mevis\",\"emailId\": \"mevisjj@gmail.com\"},\"student\": {\"fullName\": \"Angelene Jennah Dikruz\"},\"merchant\": {\"confirmationURL\": \"http://localhost:51313//apihandler.aspx\"}}";
            // request.Headers.Add("apikey", "5");
            request.Headers.Add("apikey", ApiKey);
            byteArray = Encoding.UTF8.GetBytes(jsonContent);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            response = request.GetResponse();
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);
            responseFromServer = HttpUtility.UrlDecode(reader.ReadToEnd());

            reader.Close();
            dataStream.Close();
            response.Close();
            //return Ok(responseFromServer);
            dtError result = new dtError();
            result.Result = responseFromServer;
            return new JsonResult(result);
        }
    }
}
