using Blazored.SessionStorage;
using Newtonsoft.Json;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using Syncfusion.Blazor.Diagrams;
using System.Dynamic;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Logics.Concrete.Students
{
    public class StudentManager : IStudentManager
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public StudentManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }

        public async Task<IEnumerable<Col_AccademicYear>> GetAcademicYear()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<Col_AccademicYear>>("api/Student/GetAccyear?Key=" + key);
        }
        public async Task<List<Student>> GetAll(int BranchId, string accyear)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var al = await httpClient.GetFromJsonAsync<List<Student>>("api/Student/GetAll?branchid=" + BranchId + "&Accyear=" + accyear + "&Key=" + key);
                return al;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> GetCombolist(string type )
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var al = await httpClient.GetFromJsonAsync<List<string>>("api/Student/GetComboBoxList?type=" + type + "&Key=" + key);
                return al;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Col_Intake> GetIntake(string name)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var al = await httpClient.GetFromJsonAsync<Col_Intake>("api/student/getintake?name=" + name + "&Key=" + key);
                return al;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetNextStudentCode(int branchid)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var all = await httpClient.GetStringAsync("api/Student/GetNextStudentCode?branchid=" + branchid + "&Key=" + key);

            return all;
        }

        public async Task<string> GetAbbr(int BranchID )
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Abbr = await httpClient.GetStringAsync("api/Student/Abbr?BranchID=" + BranchID + "&Key=" + key);
            return Abbr;
        }

        public async Task<Student> GetStudent(int id )
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var al = await httpClient.GetFromJsonAsync<Student>("api/Student/GetStudent?ID=" + id + "&Key=" + key);
                return al;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> InsertStudent(Student student )
        {
            HttpResponseMessage result = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                result = await httpClient.PostAsJsonAsync("api/Student/InsertStudent?Key=" + key, student);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<HttpResponseMessage> UpdateStudent(Student student)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                result = await httpClient.PostAsJsonAsync("api/Student/UpdateStudent?Key=" + key, student);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
            public async Task<IEnumerable<dtStudentRegister>?> GetStudents(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Student?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterAll(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Student/StudentAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentsDefault(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtoStudentRegisterDefault>>("api/Student/Default?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentRegisterAllDefault(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtoStudentRegisterDefault>>("api/Student/StudentDefaultAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterCustomized(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Student/StudentCustomized?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterCustomizedAll(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Student/StudentCustomizedAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterDetailed(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Student/StudentDetailed?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentRegisterDetailedAll(string AcademicYear, int? BranchID, string? Category, int? UserID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Student/StudentDetailedAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolAcademicYear>?> GetAcademicYear(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolAcademicYear>>("api/DB?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<string> GetCurrentAcademicYear(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AcademicYear = await httpClient.GetStringAsync("api/DB/CurrentYear?BranchID=" + BranchID + "&Key=" + key);
            return AcademicYear;
        }
        public async Task<string> GetSchool()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var School = await httpClient.GetStringAsync("api/DB/School?Key=" + key);
            return School;
        }

        public async Task<string> GetCompany(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var School = await httpClient.GetStringAsync("api/DB/Company?BranchID=" + BranchID + "&Key=" + key);
            return School;
        }

        public async Task<string> getHomeUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Logo = await httpClient.GetStringAsync("api/Home?Key=" + key);
            return Logo;
        }
        public async Task<string> getParentHomeUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var url = await httpClient.GetStringAsync("api/Home/ParentHome?Key=" + key);
            return url;
        }
        public async Task<string> getLogoutUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Logo = await httpClient.GetStringAsync("api/LogOut?Key=" + key);
            return Logo;
        }

        public async Task<string> getLogo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Logo = await httpClient.GetStringAsync("api/Home/Logo?BranchID=" + BranchID + "&Key=" + key);
            return Logo;
        }

        public async Task<string> getLogoUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Logo = await httpClient.GetStringAsync("api/Home/LogoUrl?Key=" + key);
            return Logo;
        }

        public async Task<HttpResponseMessage> SaveSyncData(dtSyncData Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/Student/BulkSync?Key=" + key, Student);
        }
        public async Task<HttpResponseMessage> SaveSyncDatawithparent(dtSyncData Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/Bulksync/BulkSyncs?Key=" + key, Student);
        }

        public async Task<IEnumerable<SchoolWebMenuSettings>?> EnableMenu(string Menu)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolWebMenuSettings>>("api/Bind/EnableMenu?Menu=" + Menu + "&Key=" + key);
        }
        public async Task<IEnumerable<dtCompany>?> GetCompanyDetails(long BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtCompany>>("api/DB/CompanyDetails?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<dtStudentRegister>?> GetPromoted(string AcademicYearTo, int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Student/GetPromoted?AcademicYearTo=" + AcademicYearTo + "&AccountID=" + AccountID + "&Key=" + key);
        }

        public async Task<string> GetGrade(int AccountID)
        {
            var Grade = await httpClient.GetStringAsync("api/Student/GetGrade?AccountID=" + AccountID + "&Key=" + key);
            return Grade;
        }

        public async Task<HttpResponseMessage> SavePromo(dtStudentRegister Promo)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            HttpResponseMessage promote = new HttpResponseMessage();
            try
            {
                promote = await httpClient.PostAsJsonAsync("api/Student/SavePromo?Key=" + key, Promo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return promote;
        }

        public async Task<List<ExpandoObject>> GetCombanyLogo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            try
            {
                List<ExpandoObject> Result = new List<ExpandoObject>();
                var report = await httpClient.GetFromJsonAsync<object>("api/DB/GetCombanyLogo?BranchID=" + BranchID + "&Key=" + key);

                Result = JsonConvert.DeserializeObject<List<ExpandoObject>>(report!.ToString()!)!;
                return Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
