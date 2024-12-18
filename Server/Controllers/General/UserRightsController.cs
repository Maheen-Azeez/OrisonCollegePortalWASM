using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortalServer.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRightsController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IUserRightsManager _repository;

        public UserRightsController(IWebHostEnvironment environment, IUserRightsManager repository)
        {
            _environment = environment;
            _repository = repository;
        }

        [HttpGet]
        [Route("Rights")]
        public async Task<ActionResult<UserRights?>> GetUserRights(int? ID, string Keyword, string Module, int? BranchId, string Key)
        {
            var UserRights = await _repository.GetUserRights(ID, Keyword, Module, BranchId, Key);

            if (UserRights == null)
            {
                return NotFound();
            }

            return UserRights;
        }
    }
}
