using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.General
{
    public class UserLoginManager : IUserLoginManager
    {
        private readonly IDapperManager _dapperManager;

        public UserLoginManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }
        public async Task<List<UserLogin>> GetUserData(int UserID, int BranchID, string Key)
        {
            List<UserLogin> UData = new List<UserLogin>();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("userid", UserID, DbType.Int32);
                dbPara.Add("BranchId", BranchID, DbType.Int32);
                dbPara.Add("Criteria", "Autologin", DbType.String);
                //dtInvVoucher voucher = new dtInvVoucher();
                UData = await Task.FromResult(_dapperManager.GetAll<UserLogin>
                                    ("[Col_ReservationPortalUserLoginSP]", Key, dbPara, 
                                    commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {

            }

            //[Blazor_UserSP] for server
            // [FINWEB_INVENTORYVoucherSP] for local
            return UData;
        }

        public Task<string> GetCompany(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Company = Task.FromResult(_dapperManager.Get<string>("Select CompanyCode from Company where ID=@BranchID",Key, dbPara, commandType: CommandType.Text));
            return Company;
        }

        public Task<string> getLogo(int BranchID, string Key)
        {
            try
            {
                var code = Task.FromResult(_dapperManager.Get<string>("Select LogoName from Company where ID='" + BranchID + "'", Key, null, commandType: CommandType.Text));
                return code;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public Task<string> getLogoUrl(string Key)
        {
            var code = Task.FromResult(_dapperManager.Get<string>("select Description from mastermisc where source='LogoPath'", Key, null, commandType: CommandType.Text));
            return code;
        }

        public Task<string> getLogoutUrl(string Key)
        {
            var code = Task.FromResult(_dapperManager.Get<string>("select top 1 Description from MasterMisc where Source='Logout'", Key, null, commandType: CommandType.Text));
            return code;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task<List<object>> GetCompanyDetails(int BranchID, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                var Company = Task.FromResult(_dapperManager.GetAll<object>("select C.*,M.Description from company C cross join mastermisc M where M.Source='LogoPath' and C.ID=@BranchID", Key, dbPara, commandType: CommandType.Text));
                return Company;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<Col_AccademicYear>> GetAcademicYear(int branchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", branchID, DbType.String);
           var AcedemicYear = Task.FromResult(_dapperManager.GetAll<Col_AccademicYear>("select * from Col_AcademicYear where BranchID=@BranchID", Key, dbPara, commandType: CommandType.Text));
            return await AcedemicYear;
        }
        public async Task<string> GetCurrentAcademicYear(int branchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", branchID, DbType.String);
            var AcedemicYear = Task.FromResult(_dapperManager.Get<string>("select AcademicYear from Col_AcademicYear where BranchID=@BranchID and status='current'", Key, dbPara,  commandType: CommandType.Text));
            return await AcedemicYear;
        }

        public Task<string> getHomeUrl(string Key)
        {
            var code = Task.FromResult(_dapperManager.Get<string>("select top 1 Description from MasterMisc where Source='Home'", Key, null, commandType: CommandType.Text));
            return code;
        }
        public Task<string> GetUrl(string source,string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@source", source, DbType.String);
            var code = Task.FromResult(_dapperManager.Get<string>("select Description from MasterMisc where Source =@source", Key, dbPara, commandType: CommandType.Text));
            return code;
        }
    }
}
