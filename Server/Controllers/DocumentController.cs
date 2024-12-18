using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
       
        private IWebHostEnvironment _environment;
        private IDocumentManager _repository;
        public DocumentController(IWebHostEnvironment environment, IDocumentManager repository)
        {
            _environment = environment;
            _repository = repository;

        }
        [HttpGet(nameof(GetAllDocuments))]
        public async Task<List<Documents>> GetAllDocuments(int branchid,string Key)
        {
           
                return await _repository.GetAllDocuments(branchid, Key);
            
        }
        [HttpGet(nameof(GetAllDocumentsbyId))]
        public async Task<List<Documents>> GetAllDocumentsbyId(int id, string Key)
        {
           

            return await _repository.GetDocumentsById(id, Key);
        }
        [HttpGet(nameof(GetDocumentByDocId))]
        public async Task<Documents> GetDocumentByDocId(int id, string Key)
        {
           
            return await _repository.GetDocumentByDocId(id, Key);
        }
        
        [HttpPost(nameof(InsertDocuments))]
        public async Task<HttpResponseMessage> InsertDocuments(Documents documents, string Key)
        {
            try
            {

                await _repository.InsertDocuments(documents, Key);
                HttpResponseMessage msg = new HttpResponseMessage();
                msg.StatusCode = (System.Net.HttpStatusCode)1;
                return msg;

            }
            catch (Exception e)
            {

                throw e;
            }



        }
        //public async Task<HttpResponseMessage> InsertDocuments(Documents document)
        //{
        //    long ID = 0;
        //    ID = await _repository.InsertDocuments(document);
        //HttpResponseMessage msg = new HttpResponseMessage();
        //if (ID == 0)
        //{
        //    msg.StatusCode = (System.Net.HttpStatusCode)0;
        //    result.Document_id = 0;
        //    return new JsonResult(result);
        //}
        //else
        //{
        //    msg.StatusCode = (System.Net.HttpStatusCode)1;
        //    result.Document_id = Convert.ToInt32(ID);
        //    return new JsonResult(result.Document_id);
        //}

        //}
        [HttpPost(nameof(UpdateDocuments))]

        public async Task<HttpResponseMessage> UpdateDocuments(Documents document, string Key)
        {
            try
            {
                await _repository.UpdateDocuments(document, Key);
                HttpResponseMessage msg = new HttpResponseMessage();
                msg.StatusCode = (System.Net.HttpStatusCode)1;
                return msg;
            }
            catch (Exception e)
            {

                throw e;
            }


        }
        [HttpDelete(nameof(Delete))]
        public async Task<HttpResponseMessage> Delete(int ID, string Key)
        {
            //long ID = 0;
            await _repository.Delete(ID, Key);
            HttpResponseMessage msg = new HttpResponseMessage();
            msg.StatusCode = (System.Net.HttpStatusCode)1;
            return msg;
            //await _repository.DeleteMasterMiscAsync(ID);    
        }
    }
}
