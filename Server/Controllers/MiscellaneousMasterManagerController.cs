using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Concretes;
using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Concretes
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiscellaneousMasterManagerController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IMiscellaneousMasterManager _repository;
        public MiscellaneousMasterManagerController(IWebHostEnvironment environment, IMiscellaneousMasterManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("GetMasters")]
        public async Task<ActionResult<IEnumerable<MiscellaneousMasterdata>>> GetMaster(string Key)
        {
            return await _repository.GetMaster(Key);
        }

        [HttpGet]
        [Route("GetComb")]
        public async Task<ActionResult<IEnumerable<MiscellaneousMasterdata>>> ComboMaster(string Source, string Key)
        {
            return await _repository.ComboMaster(Source, Key);
        }

        [HttpPost]
        [Route("SaveMas")]
        public async Task<HttpResponseMessage> SaveMaster(MiscellaneousMasterdata value, string Key)
        {
            long ID = 0;
            ID = await _repository.SaveMaster(value, Key);
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

        [HttpDelete("Delete")]
        [Route("Delete/(id)")]
        public async Task<int> DeleteFeeMaster(int id, string Key)
        {
            return await _repository.DeleteMaster(id, Key);

            //int ID;
            //ID = await _repository.DeleteMaster(id);
            //HttpResponseMessage msg = new HttpResponseMessage();
            //msg.StatusCode = (System.Net.HttpStatusCode)1;
            //return msg;
        }
    }
}
