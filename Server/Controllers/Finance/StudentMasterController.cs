using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMasterController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStudentMaster _repository;
        public StudentMasterController(IWebHostEnvironment environment, IStudentMaster repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("Accounts/{AccountID}")]
        public async Task<ActionResult<Accounts?>> GetDTAccount(int AccountID, string Key)
        {
            return await _repository.GetDTAccount(AccountID, Key);
        }

        [HttpGet]
        [Route("Student/{AccountID}")]
        public async Task<ActionResult<SchoolStudent?>> GetDTStudent(int AccountID, string Key)
        {
            return await _repository.GetDTStudent(AccountID, Key);
        }

        [HttpGet]
        [Route("StudentTrans/{AccountID}/{BranchID}/{AcademicYear}")]
        public async Task<ActionResult<SchoolStudentTran?>> GetDTStudentTrans(int AccountID, int BranchID, string AcademicYear, string Key)
        {
            return await _repository.GetDTStudentTrans(AccountID, BranchID, AcademicYear, Key);
        }

        [HttpGet]
        [Route("GetAdditionalDiscountbyid")]
        public async Task<ActionResult<SchoolAdditionalPayment>> GetAdditionalDiscountbyid(int AccountID, int ID, string Key)
        {
            return await _repository.GetAdditionalDiscountbyid(AccountID, ID, Key);
        }
        [HttpGet]
        [Route("GetAdditionalPaymentbyid")]
        public async Task<ActionResult<SchoolAdditionalPayment>> GetAdditionalPaymentbyid(int AccountID, int ID, string Key)
        {
            return await _repository.GetAdditionalPaymentbyid(AccountID, ID, Key);
        }

        [HttpGet]
        [Route("Parent/{AccountID}")]
        public async Task<ActionResult<SchoolParentMaster?>> GetDTParent(int AccountID, string Key)
        {
            return await _repository.GetDTParent(AccountID, Key);
        }

        [HttpGet]
        [Route("StudentsArabic/{AccountID}")]
        public async Task<ActionResult<SchoolStudentsArabic?>> GetDTStudentsArabic(int AccountID, string Key)
        {
            SchoolStudentsArabic Arabic = new SchoolStudentsArabic();
            //var Arabic = await _repository.GetDTStudentsArabic(AccountID);
            Arabic = await _repository.GetDTStudentsArabic(AccountID, Key);
            if (Arabic == null)
            {
                Arabic = new SchoolStudentsArabic() { Id = 0 };
            }
            return Arabic;
        }

        [HttpGet]
        [Route("StudentImage/{AccountID}")]
        public async Task<ActionResult<SchoolImage?>> GetDTStudentImage(int AccountID, string Key)
        {
            SchoolImage _SchoolImage = new SchoolImage();
            _SchoolImage = await _repository.GetDTStudentImage(AccountID, Key);
            if (_SchoolImage == null)
            {
                _SchoolImage = new SchoolImage() { Id = 0 };
            }
            return _SchoolImage;
        }

        [HttpGet]
        [Route("DocumentByID/{AccountID}")]
        public async Task<ActionResult<IEnumerable<SchoolDocument?>>> GetStudDocumentById(int AccountID, string Key)
        {
            return await _repository.GetStudDocumentById(AccountID, Key);
        }

        [HttpGet]
        [Route("DocumentByDocID/{DocID}")]
        public async Task<ActionResult<SchoolDocument>> GetDocumentByDocId(int DocID, string Key)
        {
            var Doc = await _repository.GetDocumentByDocId(DocID, Key);
            return Doc;
        }

        [HttpGet]
        [Route("ParentDocumentByID/{AccountID}")]
        public async Task<ActionResult<IEnumerable<SchoolParentDocument>>> GetParentDocumentById(int AccountID, string Key)
        {
            return await _repository.GetParentDocumentById(AccountID, Key);
        }

        [HttpGet]
        [Route("ParentDocumentByDocID/{DocID}")]
        public async Task<ActionResult<SchoolParentDocument>> GetParentDocumentByDocId(int DocID, string Key)
        {
            var Doc = await _repository.GetParentDocumentByDocId(DocID, Key);
            return Doc;
        }

        [HttpGet]
        [Route("AdditionalPayment/{AccountID}")]
        public async Task<ActionResult<IEnumerable<SchoolAdditionalPayment?>>> GetAdditionalPayment(int AccountID, string Key)
        {
            return await _repository.GetAdditionalPayment(AccountID, Key);
        }

        [HttpGet]
        [Route("AdditionalDiscount/{AccountID}")]
        public async Task<ActionResult<IEnumerable<SchoolAdditionalPayment?>>> GetAdditionalDiscount(int AccountID, string Key)
        {
            return await _repository.GetAdditionalDiscount(AccountID, Key);
        }

        [HttpGet]
        [Route("Relation/{AccountID}")]
        public async Task<ActionResult<IEnumerable<SchoolFamilyDetail?>>> GetRelation(int AccountID, string Key)
        {
            return await _repository.GetRelation(AccountID, Key);
        }

        [HttpGet]
        [Route("Notes/{AccountID}")]
        public async Task<ActionResult<IEnumerable<SchoolStudentNote?>>> GetNotes(int AccountID, string Key)
        {
            return await _repository.GetNotes(AccountID, Key);
        }

        [HttpGet]
        [Route("StudentStatement")]
        public async Task<ActionResult<IEnumerable<dtStudentStatement>>> GetStatement(string FromDate, string ToDate, int AccountID, int BranchID, string Key)
        {
            return await _repository.GetStatement(FromDate, ToDate, AccountID, BranchID, Key);
        }

        //[HttpPost("[action]")]
        //[Route("post")]
        //public async Task<HttpResponseMessage> AddData(dtMasterStudent value)
        //{
        //    long ID = 0;
        //    ID = await _repository.CreateNewStudent(value);
        //    HttpResponseMessage msg = new HttpResponseMessage();
        //    msg.StatusCode = (System.Net.HttpStatusCode)1;
        //    return msg;
        //}

        [HttpPost("[action]")]
        [Route("post")]
        public async Task<IActionResult> AddData(dtMasterStudent value, string Key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.CreateNewStudent(value, Key);
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
                //msg.StatusCode = (System.Net.HttpStatusCode)1;
                //return msg;
            }
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }

        //[HttpPost("[action]")]
        //[Route("AddSibling")]
        //public async Task<HttpResponseMessage> AddSibling(dtMasterStudent value)
        //{
        //    long ID = 0;
        //    ID = await _repository.CreateNewStudentSibling(value);
        //    HttpResponseMessage msg = new HttpResponseMessage();
        //    msg.StatusCode = (System.Net.HttpStatusCode)1;
        //    return msg;
        //}

        [HttpPost("[action]")]
        [Route("AddSibling")]
        public async Task<IActionResult> AddSibling(dtMasterStudent value, string Key)
        {
            try
            {
                long ID = 0;
                resultID result = new resultID();
                ID = await _repository.CreateNewStudentSibling(value, Key);
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
                //msg.StatusCode = (System.Net.HttpStatusCode)1;
                //return msg;
            }
            catch (Exception Ex)
            {
                ErrorResult Err = new ErrorResult();
                Err.Error = Ex.Message;
                return new JsonResult(Err);
            }
        }

        //[HttpPost("[action]")]
        //[Route("updatedata")]
        //public async Task<HttpResponseMessage> UpdateData(dtMasterStudent value)
        //{
        //    long ID;
        //    ID = await _repository.UpdateStudent(value);
        //    HttpResponseMessage msg = new HttpResponseMessage();
        //    msg.StatusCode = (System.Net.HttpStatusCode)1;
        //    return msg;

        //}

        [HttpPost("[action]")]
        [Route("updatedata")]
        public async Task<IActionResult> UpdateData(dtMasterStudent value, string Key)
        {
            try
            {
                long ID;
                resultID result = new resultID();
                ID = await _repository.UpdateStudent(value, Key);
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
            //msg.StatusCode = (System.Net.HttpStatusCode)1;
            //return msg;

        }

        [HttpPost("[action]")]
        [Route("UpdateStudent")]
        public async Task<HttpResponseMessage> UpdateStudent(dtMasterStudent value, string Key)
        {
            long ID;
            ID = await _repository.UpdateStudentOnly(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }

        [HttpPost("[action]")]
        [Route("AddParent")]
        public async Task<HttpResponseMessage> SaveParent(dtMasterStudent value, string Key)
        {
            long ID = 0;
            ID = await _repository.CreateNewParent(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("AddImage")]
        public async Task<HttpResponseMessage> AddImage(dtMasterStudent value, string Key)
        {
            long ID = 0;
            ID = await _repository.CreateImage(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateImage")]
        public async Task<HttpResponseMessage> UpdateImage(dtMasterStudent value, string Key)
        {
            long ID;
            ID = await _repository.UpdateImage(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }

        [HttpPost("[action]")]
        [Route("AddNote")]
        public async Task<HttpResponseMessage> AddNotes(dtMasterStudent value, string Key)
        {
            long ID = 0;
            ID = await _repository.CreateNotes(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateNote")]
        public async Task<HttpResponseMessage> UpdateNotes(dtMasterStudent value, string Key)
        {
            long ID;
            ID = await _repository.UpdateNotes(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }

        [HttpPost]
        [Route("DeleteNote")]
        public async Task<HttpResponseMessage> DeleteNotes(dtMasterStudent Note, string Key)
        {
            long ID;
            ID = await _repository.DeleteNote(Note, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("AddRelation")]
        public async Task<HttpResponseMessage> AddRelation(dtMasterStudent value, string Key)
        {
            long ID = 0;
            ID = await _repository.CreateRelation(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateRelation")]
        public async Task<HttpResponseMessage> UpdateRelation(dtMasterStudent value, string Key)
        {
            long ID;
            ID = await _repository.UpdateRelation(value, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;

        }

        [HttpPost]
        [Route("DeleteRelation")]
        public async Task<HttpResponseMessage> DeleteRelation(dtMasterStudent Note, string Key)
        {
            long ID;
            ID = await _repository.DeleteRelation(Note, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("AddDocument")]
        public async Task<HttpResponseMessage> SaveDocument(dtMasterStudent Document, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveDocument(Document, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateDocument")]
        public async Task<HttpResponseMessage> UpdateDocument(dtMasterStudent Document, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateDocument(Document, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("DeleteDocument")]
        public async Task<HttpResponseMessage> DeleteDocumentByDocId(dtMasterStudent Document, string Key)
        {
            long ID = 0;
            ID = await _repository.DeleteDocument(Document, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("AddParentDocument")]
        public async Task<HttpResponseMessage> SaveParentDocument(dtMasterStudent Document, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveParentDocument(Document, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("UpdateParentDocument")]
        public async Task<HttpResponseMessage> UpdateParentDocument(dtMasterStudent Document, string Key)
        {
            long ID = 0;
            ID = await _repository.UpdateParentDocument(Document, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpPost("[action]")]
        [Route("DeleteParentDocument")]
        public async Task<HttpResponseMessage> DeleteParentDocumentByDocId(dtMasterStudent Document, string Key)
        {
            long ID = 0;
            ID = await _repository.DeleteParentDocument(Document, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        [HttpGet]
        [Route("EnableTab")]
        public async Task<ActionResult<string>> GetEnableTab(string Tab, string Key)
        {
            return Ok(await _repository.GetEnableTab(Tab, Key));
        }


        [HttpPost("[action]")]
        [Route("ImportStudent")]
        public async Task<HttpResponseMessage> ImportStudent(Accounts value)
        {
            long ID = 0;
            ID = await _repository.ImportStudent(value);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
        }

        //[HttpGet]
        //[Route("ImportStudent/{Scode}/{BranchID}")]
        //public async Task<ActionResult<dtImportStudent>> GetDTImportStudent(string Scode, int BranchID, string Key)
        //{
        //    return await _repository.GetDTImportStudent(Scode, BranchID, Key);
        //}

        [HttpGet]
        [Route("StudentAge")]
        public async Task<ActionResult<string>> GetAge(int AccountID, string Key)
        {
            return Ok(await _repository.GetAge(AccountID, Key));
        }

        //[HttpGet]
        //[Route("StudentStatementReceipt")]
        //public async Task<ActionResult<IEnumerable<DtoStudentReceiptStatement>>> GetStatementReceipt(string FromDate, string ToDate, int AccountID, int BranchID, string Key)
        //{
        //    return await _repository.GetStatementReceipt(FromDate, ToDate, AccountID, BranchID, Key);
        //}
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
