using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogOutController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStudentManager _repository;

        public LogOutController(IWebHostEnvironment environment, IStudentManager repository)
        {
            _environment = environment;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<string> getLogoutUrl(string Key)
        {
            return await _repository.getLogoutUrl(Key);
        }
    }
}
