using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStudentManager _repository;

        public HomeController(IWebHostEnvironment environment, IStudentManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<string> getHomeUrl(string Key)
        {
            return await _repository.getHomeUrl(Key);
        }

        [HttpGet]
        [Route("ParentHome")]
        public async Task<string> getParentHomeUrl(string Key)
        {
            return await _repository.getParentHomeUrl(Key);
        }

        [HttpGet]
        [Route("Logo")]
        public async Task<string> getLogo(int BranchID, string Key)
        {
            return await _repository.getLogo(BranchID, Key);
        }

        [HttpGet]
        [Route("LogoUrl")]
        public async Task<string> getLogoUrl(string Key)
        {
            return await _repository.getLogoUrl(Key);
        }
    }
}
