using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortCutsController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IShortCutManager _repository;

        public ShortCutsController(IWebHostEnvironment environment, IShortCutManager repository)
        {
            _environment = environment;
            _repository = repository;
        }
        // GET: api/Shortcuts?ModuleName=Student&BranchID=31
        [HttpGet]
        public async Task<List<ShortCuts>> GetShortCuts(string ModuleName,int BranchID, string key)
        {
            return await _repository.GetShortCuts(ModuleName, BranchID, key);

        }
    }
}
