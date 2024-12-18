using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IUserLoginManager _repository;

        public UserLoginController(IUserLoginManager repository)
        {
            _repository = repository;
        }
        // GET: api/UserLogin?UserID=305&BranchID=31
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLogin>>> GetUserData(int UserID, int BranchID, string Key)
        {
            var UserData = await _repository.GetUserData(UserID, BranchID, Key);

            if (UserData == null)
            {
                return NotFound();
            }

            return UserData;
        }

        [HttpGet]
        [Route("Company")]
        public async Task<ActionResult<string>> GetCompany(int BranchID, string Key)
        {
            return Ok(await _repository.GetCompany(BranchID, Key));
        }
        [HttpGet]
        [Route("CompanyDetails")]
        public async Task<IEnumerable<object>> GetCompanyDetails(int BranchID, string Key)
        {
            try
            {
                return await _repository.GetCompanyDetails(BranchID, Key);

            }
            catch (Exception)
            {

                throw;
            }
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

        [HttpGet]
        [Route("LogOut")]
        public async Task<string> getLogoutUrl(string Key)
        {
            return await _repository.getLogoutUrl(Key);
        }
        [HttpGet]
        [Route("HomeUrl")]
        public async Task<string> getHomeUrl(string Key)
        {
            return await _repository.getHomeUrl(Key);
        }
        [HttpGet]
        [Route("AcademicYear")]
        public async Task<List<Col_AccademicYear>> GetAcademicYear(int BranchID, string Key)
        {
            return await _repository.GetAcademicYear(BranchID, Key);
        }
        [HttpGet]
        [Route("CurrentAcademicYear")]
        public async Task<string> GetCurrentAcademicYear(int BranchID, string Key)
        {
            return await _repository.GetCurrentAcademicYear(BranchID, Key);
        }
        [HttpGet]
        [Route("Geturl")]
        public async Task<string> Geturl(string source, string Key)
        {
            string url;
            return url = await _repository.GetUrl(source , Key);
        }
    }
}
