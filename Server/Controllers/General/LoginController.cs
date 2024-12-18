using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.General;
using System.Data;

namespace OrisonCollegePortal.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private IWebHostEnvironment _environment;
        private readonly IDapperManager _dapperManager;
        public LoginController(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        [HttpGet]
        [Route("LoginUser")]
        public async Task<IEnumerable<DtoLoginModel>> LoginUser(string UserName, string Password, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@UserName", UserName, DbType.String);
                dbPara.Add("@Password", Password, DbType.String);
                dbPara.Add("Criteria", "LoginUser", DbType.String);
                //dtInvVoucher voucher = new dtInvVoucher();

                var UserData = Task.FromResult(_dapperManager.GetAll<DtoLoginModel>
                                                ("[Col_ReservationPortalUserLoginSP]", key, dbPara,
                                                commandType: CommandType.StoredProcedure));
                return await UserData;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
