using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Http.Json;
using System.Web;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class FeeSchedule : IFeeSchedule
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public FeeSchedule(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }

        public async Task<IEnumerable<SchoolFeeSchedule>?> GetFeeScheduleList(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolFeeSchedule>>("api/FeeSchedule?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<string> GetFeeSchedule(string ID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Schedule = await httpClient.GetStringAsync("api/FeeSchedule/Schedule?ID=" + ID + "&BranchID=" + BranchID + "&Key=" + key);
            return Schedule;
        }

        public async Task<IEnumerable<SchoolFeeScheduleTran>?> GetFeeScheduleFeeList(string Fee, int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolFeeScheduleTran>>("api/FeeSchedule/FeeScheduleList?Fee=" + Fee + "&BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<SchoolFeeSchedule> GetDTFeeScheduleData(string ID, int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Fee = await httpClient.GetFromJsonAsync<SchoolFeeSchedule>("api/FeeSchedule/FeeScheduleData/" + ID + "/" + BranchID + "?AcademicYear=" + AcademicYear + "&Key=" + key);
            return Fee!;
        }

        public async Task<string> GetStudCode(string CourseStream, string Class, string Shift, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCount?CourseStream=" + CourseStream + "&Class=" + Class + "&Shift=" + Shift + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<string> GetStudCodeSecond(string Class, string Shift, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountSecond?Class=" + Class + "&Shift=" + Shift + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<string> GetStudCodeThird(string CourseStream, string Class, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountThird?CourseStream=" + CourseStream + "&Class=" + Class + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<string> GetStudCodeFourth(string Class, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountFourth?Class=" + Class + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<string> GetStudCountTransport(string BusNo, string BusMode, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountTransport?BusNo=" + BusNo + "&BusMode=" + BusMode + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<string> GetStudCountRegistration(string JoiningYear, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountRegistration?Year=" + JoiningYear + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<List<SchoolFeeMaster>?> GetCode(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolFeeMaster>>("api/FeeSchedule/FeeCode?BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<string> GetCategory(string Code, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Schedule = await httpClient.GetStringAsync("api/FeeSchedule/Category?Code=" + Code + "&BranchID=" + BranchID + "&Key=" + key);
            return Schedule;
        }

        public async Task<string> GetExistFeeSchedule(string FeeSchedule, int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Schedule = await httpClient.GetStringAsync("api/FeeSchedule/ExistFeeSchedule?FeeSchedule=" + FeeSchedule + "&BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
            return Schedule;
        }
        public async Task<IEnumerable<SchoolStudentTran>?> GetStudentFeeSchedule(string FeeSchedule, int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolStudentTran>>("api/FeeSchedule/StudentTrans/" + FeeSchedule + "/" + BranchID + "/" + AcademicYear + "?Key=" + key);
        }
        public async Task<IEnumerable<SchoolClassMaster>?> GetRoute(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClassMaster>>("api/DB/Route?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<HttpResponseMessage> UpdateStudentTrans(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/UpdateStudentTrans?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateStudTrans(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/UpdateStudTrans?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> EditStudentTrans(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/EditStudentTrans?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> EditStudTrans(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/EditStudTrans?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateStudentTransSchedule(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/UpdateStudentTransSchedule?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateStudentAdmissionSchedule(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/UpdateStudentAdmissionSchedule?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> SaveFeeSchedule(SchoolFeeSchedule value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/SaveFeeSchedule?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> SaveFeeScheduleTran(SchoolFeeScheduleTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/SaveFeeScheduleTran?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateFeeSchedule(SchoolFeeSchedule value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/EditFeeSchedule?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateFeeScheduleTran(SchoolFeeScheduleTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/EditFeeScheduleTran?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> DeleteFeeSchedule(SchoolFeeSchedule Fee)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/FeeSchedule/DeleteFeeSchedule?Key=" + key, Fee);
        }

        public async Task<HttpResponseMessage> DeleteFeeScheduleTrans(SchoolFeeScheduleTran Fee)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/FeeSchedule/DeleteFeeScheduleTrans?Key=" + key, Fee);
        }

        public async Task<HttpResponseMessage> SaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/SaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> SaveFeeUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/SaveFeeUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> SaveFeeTranUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/SaveFeeTranUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> SaveUpdateFeeUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/UpdatedFeeUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<List<SchoolFeeMaster>?> GetCode(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolFeeMaster>>("api/FeeSchedule/FeeCode?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<string> GetStudCountAll(string Class, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountAll?Class=" + Class + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<string> GetStudCodeOverwrite(string CourseStream, string Class, string Shift, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountOverwrite?CourseStream=" + CourseStream + "&Class=" + Class + "&Shift=" + Shift + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<HttpResponseMessage> UpdateStudentTransOverwrite(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/UpdateStudentTransOverwrite?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }
        public async Task<string> GetStudCodeSecondOverwrite(string Class, string Shift, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountSecondOverwrite?Class=" + Class + "&Shift=" + Shift + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }
        public async Task<string> GetStudCodeThirdOverwrite(string CourseStream, string Class, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountThirdOverwrite?CourseStream=" + CourseStream + "&Class=" + Class + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<string> GetStudCodeFourthOverwrite(string Class, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentCount = await httpClient.GetStringAsync("api/FeeSchedule/StudentCountFourthOverwrite?Class=" + Class + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
            return StudentCount;
        }

        public async Task<HttpResponseMessage> UpdateStudTransOverwrite(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/UpdateStudTransOverwrite?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> EditStudentTransOverwrite(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/EditStudentTransOverwrite?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> EditStudTransOverwrite(SchoolStudentTran value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/FeeSchedule/EditStudTransOverwrite?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

    }
}
