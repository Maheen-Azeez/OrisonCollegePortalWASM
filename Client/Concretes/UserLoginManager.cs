using Blazored.SessionStorage;
using Newtonsoft.Json;
using OrisonCollegePortal.Client.Contracts;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.General;
using Syncfusion.Blazor.Diagrams;
using System.Dynamic;
using System.Net.Http.Json;
using System.Web;
using static System.Net.WebRequestMethods;

namespace OrisonCollegePortal.Client.Concretes
{
    public class UserLoginManager : IUserLoginManager
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public UserLoginManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any managed resources here
            }
            // Dispose of any unmanaged resources here
        }
        //public async Task<IEnumerable<UserLogin>> GetUserData(int UserID, int BranchID, string Con)
        //{
        //    return await httpClient.GetFromJsonAsync<UserLogin[]>("api/UserLogin?UserID=" + UserID + "&BranchID=" + BranchID + "&Con=" + Con);
        //}

        public async Task<IEnumerable<DtoLoginModel>?> GetUserData(int? UserID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<DtoLoginModel[]>("api/UserLogin?UserID=" + UserID + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<string> GetCompany(int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("api/UserLogin/Company?BranchID=" + BranchID + "&Key=" + key);           
        }
        public async Task<string> getLogo(int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Logo = await httpClient.GetStringAsync("api/UserLogin/Logo?BranchID=" + BranchID + "&Key=" + key);
            return Logo;
        }

        public async Task<string> getLogoUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Logo = await httpClient.GetStringAsync("api/UserLogin/LogoUrl?Key=" + key);
            return Logo;
        }

        public async Task<string> getLogoutUrl()
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var Logo = await httpClient.GetStringAsync("api/UserLogin/LogOut?Key=" + key);
                return Logo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ExpandoObject>> GetCompanyDetails(int BranchID)
        {

            List<ExpandoObject> Result = new List<ExpandoObject>();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var company = await httpClient.GetFromJsonAsync<IEnumerable<object>>("api/UserLogin/CompanyDetails?BranchID=" + BranchID + "&Key=" + key);
                foreach (var dt in company)
                Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

        public async Task<IEnumerable<Col_AccademicYear>> GetAcademicYear(int BranchID)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.GetFromJsonAsync<IEnumerable<Col_AccademicYear>>("api/UserLogin/AcademicYear?BranchID=" + BranchID + "&Key=" + key);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> getHomeUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var home = await httpClient.GetStringAsync("api/UserLogin/HomeUrl?Key=" + key);
            return home;
        }

        public async Task<string> GetCurrentAcademicYear(int BranchID)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.GetStringAsync("api/UserLogin/CurrentAcademicYear?BranchID=" + BranchID + "&Key=" + key);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> getBranchSettings(string source)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var url = await httpClient.GetStringAsync("api/UserLogin/Geturl?source=" + source + "&Key=" + key);
            return url;
        }

        public async Task<IEnumerable<DtoLoginModel>?> LoginUser(string UserName, string Password)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.GetFromJsonAsync<DtoLoginModel[]>("api/Login/LoginUser?UserName=" + UserName + "&Password=" + Password + "&Key=" + key);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
