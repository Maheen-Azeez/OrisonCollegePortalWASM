using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormLabelController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IDBOperation _repository;
        public FormLabelController(IWebHostEnvironment environment, IDBOperation repository)
        {
            _environment = environment;
            _repository = repository;
        }

        [HttpGet]
        [Route("GetLabels")]
        public async Task<List<dtoFormLabelSettings>?> GetAllLabels(string FormLabel, string Key)
        {
            return await _repository.GetFormLabels(FormLabel, Key);
        }
    }
}
