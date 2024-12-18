using Blazored.SessionStorage;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities;
using Syncfusion.Blazor.Diagrams;
using System.Net.Http.Json;
using System.Web;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Logics.Concrete.Students
{
    public class ClassMaster : IClassMaster
    {
        private string? key;
        HttpClient httpClient = new HttpClient();
        private readonly ISessionStorageService SessionStorage;
        public ClassMaster(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }

        public async Task<List<SchoolClassMaster>?> Getdata(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolClassMaster>>("api/ClassMaster/Get?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<List<SchoolClassMaster>?> Getdata(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolClassMaster>>("api/ClassMaster/GetClassByAcademicYear?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<SchoolClassMaster?> GetDTClassMaster(int Id)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<SchoolClassMaster>("api/ClassMaster/ClassMaster?Id=" + Id + "&Key=" + key);
        }

        public async Task<HttpResponseMessage> SaveMaster(SchoolClassMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/ClassMaster/SaveMas?Key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> UpdateMaster(SchoolClassMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/ClassMaster/UpdateMas?Key=" + key, value);
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return res;
        }
        async Task<bool> IClassMaster.DeleteMaster(int Id)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                await httpClient.DeleteAsync("api/ClassMaster/Delete?Id=" + Id + "&Key=" + key);
                return true;
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<List<SchoolStudentTran>?> GetDTStudentTrans(string Class, int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<List<SchoolStudentTran>>("api/ClassMaster/GetStudentTrans?Class=" + Class + "&BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }

        public async Task<HttpResponseMessage> SaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/ClassMaster/SaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/ClassMaster/AddSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> EditSaveUserTrack(DtoUserTrack value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/ClassMaster/EditSaveUserTrack?Key=" + key, value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<HttpResponseMessage> SaveNewClassData(List<SchoolClassMaster> value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/ClassMaster/SaveClassDetails?Key=" + key, value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
    }
}
