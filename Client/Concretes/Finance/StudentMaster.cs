using System.Net.Http.Json;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities;
using System.Web;
using Blazored.SessionStorage;
using Newtonsoft.Json;
using System.Dynamic;
using System.Linq.Expressions;

namespace OrisonCollegePortal.Client.Concretes.Finance
{
    public class StudentMaster : IStudentMaster
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public StudentMaster(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }

        public async Task<IEnumerable<dtStudentRegister>?> GetStudentList(string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Bind/StudentList?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }
        //public async Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentListDefault(string AcademicYear, int? BranchID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtoStudentRegisterDefault>>("API/Bind/StudentListDefault?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        //}
        public async Task<IEnumerable<dtStudentRegister>?> GetStudentListByClass(string Class, string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/Bind/StudentListByClass?Class=" + Class + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<MastDesignation>?> BindComboBox(string type)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<MastDesignation>>("api/Bind?type=" + type + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolAcademicYear>?> GetAcademicYear(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolAcademicYear>>("api/DB?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolClassMaster>?> GetClass(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClassMaster>>("api/DB/Class?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolClassMaster>?> GetClass(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClassMaster>>("api/DB/ClassByAcademicYear?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolClass>?> GetDivision(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>("api/DB/Division?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolClass>?> GetDivision(int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>("api/DB/DivisionByAcademicYear?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolClass>?> GetDivisionByClass(int? BranchID, string Class)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>("api/DB/DivisionByClass?BranchID=" + BranchID + "&Class=" + Class + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolClassMaster>?> GetUserOwnClass(int? UserID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClassMaster>>("api/DB/UserOwnClass?UserID=" + UserID + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolClass>?> GetUserOwnDivision(int? UserID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>("api/DB/UserOwnDivision?UserID=" + UserID + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolFeeSchedule>?> GetFee(string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolFeeSchedule>>("api/DB/Fee?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolFeeSchedule>?> GetTransport(string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolFeeSchedule>>("api/DB/Transport?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<IEnumerable<SchoolFeeSchedule>?> GetAdmission(string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolFeeSchedule>>("api/DB/Admission?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<SchoolAdditionalPayment> GetAdditionalPaymentbyid(int AccountID, int ID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AdditionalDiscount = await httpClient.GetFromJsonAsync<SchoolAdditionalPayment>("api/StudentMaster/GetAdditionalPaymentbyid?AccountID=" + AccountID + "&ID=" + ID + "&Key=" + key);
            return AdditionalDiscount!;
        }
        public async Task<SchoolAdditionalPayment> GetAdditionalDiscountbyid(int AccountID, int ID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AdditionalDiscount = await httpClient.GetFromJsonAsync<SchoolAdditionalPayment>("api/StudentMaster/GetAdditionalDiscountbyid?AccountID=" + AccountID + "&ID=" + ID + "&Key=" + key);
            return AdditionalDiscount!;
        }
        public async Task<IEnumerable<SchoolDiscountSchedule>?> GetFeeDiscount(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolDiscountSchedule>>("api/DB/FeeDiscount?BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<IEnumerable<SchoolFeeSchedule>?> GetActivity(string AcademicYear, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolFeeSchedule>>("api/DB/Activity?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<IEnumerable<Accounts>?> GetStaff(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>("api/DB/Staff?BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<IEnumerable<dtStudentRegister>?> GetParent(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>("api/DB/Parent?BranchID=" + BranchID + "&Key=" + key);
        }
        //public async Task<IEnumerable<dtoStudentRegisterDefault>?> GetParent(int? BranchID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtoStudentRegisterDefault>>("API/DB/Parent?BranchID=" + BranchID + "&Key=" + key);
        //}

        //public async Task<IEnumerable<HrtransportationMast>?> GetBusDetails(int? BranchID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<IEnumerable<HrtransportationMast>>("API/DB/BusDetails?BranchID=" + BranchID + "&Key=" + key);
        //}

        public async Task<string> GetPLevel()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            //return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>(BaseUrl + "DB/PLevel");
            var Plevel = await httpClient.GetStringAsync("api/DB/PLevel?Key=" + key);
            return Plevel;
        }

        public async Task<string> GetPLevelID()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var PLevelID = await httpClient.GetStringAsync("api/DB/PLevelID?Key=" + key);
            return PLevelID;
        }

        public async Task<string> GetAccountGroup(int PID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccountGroup = await httpClient.GetStringAsync("api/DB/AccountGroup?PID=" + PID + "&Key=" + key);
            return AccountGroup;
        }

        public async Task<string> GetSubGroup(int PID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var SubGroup = await httpClient.GetStringAsync("api/DB/SubGroup?PID=" + PID + "&Key=" + key);
            return SubGroup;
        }

        public async Task<string> GetAccCategory(int PID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccCategory = await httpClient.GetStringAsync("api/DB/AccCategory?PID=" + PID + "&Key=" + key);
            return AccCategory;
        }

        public async Task<string> GetShowChild(int PID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var ShowChild = await httpClient.GetStringAsync("api/DB/ShowChild?PID=" + PID + "&Key=" + key);
            return ShowChild;
        }

        public async Task<string> GetAccCategoryMast()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AccCategoryMast = await httpClient.GetStringAsync("api/DB/AccCategoryMast?Key=" + key);
            return AccCategoryMast;
        }

        public async Task<string> GetAbbr(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Abbr = await httpClient.GetStringAsync("api/DB/Abbr?BranchID=" + BranchID + "&Key=" + key);
            return Abbr;
        }

        public async Task<string> BindSettingsValue(string Category)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Value = await httpClient.GetStringAsync("api/Bind/Setting?Category=" + Category + "&Key=" + key);
            return Value;
        }


        public async Task<Accounts?> GetDTAccount(int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Account = await httpClient.GetFromJsonAsync<Accounts?>("api/StudentMaster/Accounts/" + AccountID + "?Key=" + key);
            return Account!;
        }
        public async Task<SchoolStudent?> GetDTStudent(int AccountID)
        {
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var Student = await httpClient.GetFromJsonAsync<SchoolStudent?>("api/StudentMaster/Student/" + AccountID + "?Key=" + key);
                return Student!;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<SchoolStudentTran?> GetDTStudentTrans(int AccountID, int? BranchID, string AcademicYear)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var StudentTrans = await httpClient.GetFromJsonAsync<SchoolStudentTran?>("api/StudentMaster/StudentTrans/" + AccountID + "/" + BranchID + "/" + AcademicYear + "?Key=" + key);
            return StudentTrans!;
        }
        public async Task<SchoolParentMaster?> GetDTParent(int AccountID)
        {
            try { 
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Student = await httpClient.GetFromJsonAsync<SchoolParentMaster?>("api/StudentMaster/Parent/" + AccountID + "?Key=" + key);
            return Student!;
                }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<SchoolStudentsArabic?> GetDTStudentsArabic(int AccountID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var Student = await httpClient.GetFromJsonAsync<SchoolStudentsArabic?>("API/StudentMaster/StudentsArabic/" + AccountID + "?Key=" + key);
        //    return Student!;
        //}
        public async Task<SchoolImage?> GetDTStudentImage(int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Image = await httpClient.GetFromJsonAsync<SchoolImage?>("api/StudentMaster/StudentImage/" + AccountID + "?Key=" + key);
            return Image!;
        }

        public async Task<string> GetNextNo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var code = await httpClient.GetStringAsync("api/DB/NextStudentCode?BranchID=" + BranchID + "&Key=" + key);
            return code;
        }
        public async Task<string> GetSExistNo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var code = await httpClient.GetStringAsync("api/DB/ExistStudentCode?BranchID=" + BranchID + "&Key=" + key);
            return code;
        }

        public async Task<string> GetParentNextNo(int? BranchID, string Scode)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var code = await httpClient.GetStringAsync("api/DB/NextParentCode?BranchID=" + BranchID + "&Scode=" + Scode + "&Key=" + key); //AcademicYear = " + AcademicYear + " & BranchID = " + BranchID);
            return code;
        }

        //public async Task<IEnumerable<SchoolDocument?>> GetStudDocumentById(int AccountID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var Document = await httpClient.GetFromJsonAsync<IEnumerable<SchoolDocument?>>("API/StudentMaster/DocumentByID/" + AccountID + "?Key=" + key);
        //    return Document!;
        //}

        //public async Task<SchoolDocument> GetDocumentByDocId(int DocID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var File = await httpClient.GetFromJsonAsync<SchoolDocument>("API/StudentMaster/DocumentByDocID/" + DocID + "?Key=" + key);
        //    return File!;
        //}
        //public async Task<SchoolDocument?> GetValidationByDocType(string type)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    SchoolDocument? doc = await httpClient.GetFromJsonAsync<SchoolDocument>("API/Validation?Type=" + type + "&Key=" + key);
        //    return doc!;
        //}

        //public async Task<IEnumerable<SchoolParentDocument>> GetParentDocumentById(int AccountID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var Document = await httpClient.GetFromJsonAsync<IEnumerable<SchoolParentDocument>>("API/StudentMaster/ParentDocumentByID/" + AccountID + "?Key=" + key);
        //    return Document!;
        //}
        //public async Task<SchoolParentDocument> GetParentDocumentByDocId(int DocID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var File = await httpClient.GetFromJsonAsync<SchoolParentDocument>("API/StudentMaster/ParentDocumentByDocID/" + DocID + "?Key=" + key);
        //    return File!;
        //}
        public async Task<IEnumerable<SchoolAdditionalPayment?>> GetAdditionalPayment(int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AdditionalPayment = await httpClient.GetFromJsonAsync<IEnumerable<SchoolAdditionalPayment?>>("api/StudentMaster/AdditionalPayment/" + AccountID + "?Key=" + key);
            return AdditionalPayment!;
        }
        public async Task<IEnumerable<SchoolAdditionalPayment?>> GetAdditionalDiscount(int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AdditionalDiscount = await httpClient.GetFromJsonAsync<IEnumerable<SchoolAdditionalPayment?>>("api/StudentMaster/AdditionalDiscount/" + AccountID + "?Key=" + key);
            return AdditionalDiscount!;
        }
        //public async Task<IEnumerable<SchoolFamilyDetail?>> GetRelation(int AccountID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var Relation = await httpClient.GetFromJsonAsync<IEnumerable<SchoolFamilyDetail?>>("API/StudentMaster/Relation/" + AccountID + "?Key=" + key);
        //    return Relation!;
        //}
        //public async Task<IEnumerable<SchoolStudentNote?>> GetNotes(int AccountID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var Notes = await httpClient.GetFromJsonAsync<IEnumerable<SchoolStudentNote?>>("API/StudentMaster/Notes/" + AccountID + "?Key=" + key);
        //    return Notes!;
        //}

        public async Task<IEnumerable<dtStudentStatement>> GetStatement(string FromDate, string ToDate, int AccountID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Statement = await httpClient.GetFromJsonAsync<IEnumerable<dtStudentStatement>>("api/StudentMaster/StudentStatement?FromDate=" + FromDate + "&ToDate=" + ToDate + "&AccountID=" + AccountID + "&BranchID=" + BranchID + "&Key=" + key);
            return Statement!;
        }

        public async Task<string> GetStaffID(int? BranchID, string Code)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var code = await httpClient.GetStringAsync("api/DB/StaffID?BranchID=" + BranchID + "&Code=" + Code + "&Key=" + key);
            return code;
        }

        public async Task<HttpResponseMessage> SaveAdd(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/post?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> SaveSibling(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/AddSibling?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> SaveUpdate(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/updatedata?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> UpdateStudent(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/UpdateStudent?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> SaveImage(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/AddImage?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> SaveUpdateImage(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/UpdateImage?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> SaveNote(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/AddNote?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> UpdateNote(dtMasterStudent Student)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/UpdateNote?Key=" + key, Student);
        }

        public async Task<HttpResponseMessage> DeleteNoteById(dtMasterStudent Note)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/DeleteNote?Key=" + key, Note);
        }

        public async Task<HttpResponseMessage> SaveRelation(dtMasterStudent Relation)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/AddRelation?Key=" + key, Relation);
        }

        public async Task<HttpResponseMessage> UpdateRelation(dtMasterStudent Relation)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/UpdateRelation?Key=" + key, Relation);
        }

        public async Task<HttpResponseMessage> DeleteRelationByID(dtMasterStudent Relation)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/DeleteRelation?Key=" + key, Relation);
        }

        public async Task<HttpResponseMessage> SaveDocument(dtMasterStudent Document)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/AddDocument?Key=" + key, Document);
        }
        public async Task<HttpResponseMessage> UpdateDocument(dtMasterStudent Document)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/UpdateDocument?Key=" + key, Document);
        }
        public async Task<HttpResponseMessage> DeleteDocumentByDocId(dtMasterStudent Document)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/DeleteDocument?Key=" + key, Document);
        }
        public async Task<HttpResponseMessage> SaveParentDocument(dtMasterStudent Document)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/AddParentDocument?Key=" + key, Document);
        }
        public async Task<HttpResponseMessage> UpdateParentDocument(dtMasterStudent Document)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/UpdateParentDocument?Key=" + key, Document);
        }
        public async Task<HttpResponseMessage> DeleteParentDocumentByDocId(dtMasterStudent Document)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/DeleteParentDocument?Key=" + key, Document);
        }

        public async Task<HttpResponseMessage> SaveParent(dtMasterStudent Parent)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/AddParent?Key=" + key, Parent);
        }


        public async Task<string> GetEnableTab(string Tab)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var EnableTab = await httpClient.GetStringAsync("api/StudentMaster/EnableTab?Tab=" + Tab + "&Key=" + key);
            return EnableTab;
        }

        public async Task<string> GetExistStudent(string Scode, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var code = await httpClient.GetStringAsync("api/DB/ExistImportStudentCode?Scode=" + Scode + "&BranchID=" + BranchID + "&Key=" + key);
            return code;
        }

        public async Task<string> GetExistSyncStudent(string Scode, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var code = await httpClient.GetStringAsync("api/DB/ExistSyncStudentCode?Scode=" + Scode + "&BranchID=" + BranchID + "&Key=" + key);
            return code;
        }

        public async Task<string> GetExistParentID(string Pcode, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var code = await httpClient.GetStringAsync("api/DB/ExistParent?Pcode=" + Pcode + "&BranchID=" + BranchID + "&Key=" + key);
            return code;
        }

        public async Task<HttpResponseMessage> ImportStudent(Accounts Data)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.PostAsJsonAsync("api/StudentMaster/ImportStudent?Key=" + key, Data);
        }

        //public async Task<dtImportStudent> GetDTImportStudent(string Scode, int? BranchID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var Student = await httpClient.GetFromJsonAsync<dtImportStudent>("API/StudentMaster/ImportStudent/" + Scode + "/" + BranchID + "?Key=" + key);
        //    return Student!;
        //}

        public async Task<string> GetTeacherName(string Class, string Division, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Teacher = await httpClient.GetStringAsync("api/DB/GetTeacherName?Class=" + Class + "&Division=" + Division + "&BranchID=" + BranchID + "&Key=" + key);
            return Teacher;
        }

        public async Task<string> GetAge(int AccountID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Age = await httpClient.GetStringAsync("api/StudentMaster/StudentAge?AccountID=" + AccountID + "&Key=" + key);
            return Age;
        }

        //public async Task<IEnumerable<Student_DocTypeValidation>?> GetStudentDocumentType()
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<IEnumerable<Student_DocTypeValidation>>("API/DB/StudentDocumentType?Key=" + key);
        //}
        //public async Task<IEnumerable<Parent_DocTypeValidation>?> GetParentDocumentType()
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<IEnumerable<Parent_DocTypeValidation>>("API/DB/ParentDocumentType?Key=" + key);
        //}

        //public async Task<List<dtFeetype>?> GetFeetype(string type, string Academiyear, int? BranchID, string Criteria)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<List<dtFeetype>>("API/DB/GetFeetype?type=" + type + "&Academicyear=" + Academiyear + "&BranchID=" + BranchID + "&Criteria=" + Criteria + "&Key=" + key);
        //}

        //public async Task<List<dtFeetype>?> GetPaymentMode(string Criteria)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    return await httpClient.GetFromJsonAsync<List<dtFeetype>>("API/DB/GetPaymentMode?Criteria=" + Criteria + "&Key=" + key);
        //}

        public async Task<string> getDocUrl(string Path)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Abbr = await httpClient.GetStringAsync("api/DB/GetDocUrl?Path=" + Path + "&Key=" + key);
            return Abbr;
        }
        //public async Task<IEnumerable<DtoStudentReceiptStatement>> GetStatementReceipt(string FromDate, string ToDate, int AccountID, int? BranchID)
        //{
        //    key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
        //    var Statement = await httpClient.GetFromJsonAsync<IEnumerable<DtoStudentReceiptStatement>>("API/StudentMaster/StudentStatementReceipt?FromDate=" + FromDate + "&ToDate=" + ToDate + "&AccountID=" + AccountID + "&BranchID=" + BranchID + "&Key=" + key);
        //    return Statement!;
        //}
        public async Task<string> GetMailType(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var Abbr = await httpClient.GetStringAsync("api/DB/GetMailType?BranchID=" + BranchID + "&Key=" + key);
            return Abbr;
        }
        public async Task<List<ExpandoObject>> GetCombanyLogo(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            try
            {
                List<ExpandoObject> Result = new List<ExpandoObject>();
                var report = await httpClient.GetFromJsonAsync<object>("api/Values/GetCombanyLogo?BranchID=" + BranchID + "&Con=" + key);

                Result = JsonConvert.DeserializeObject<List<ExpandoObject>>(report!.ToString()!)!;
                return Result;


            }
            catch (Exception ex)
            {
                //this.ToastService.ShowToast(new ToastOption()
                //{
                //    Title = "Something went wrong...",
                //    Content = ex.Message,
                //    CssClass = "e-toast-danger",
                //    Icon = "e-error toast-icons",
                //    Timeout = 2000,
                //    X = "Right",
                //    Y = "Top",
                //    CloseButton = true
                //});
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<IEnumerable<HrtransportationMast>?> GetBusDetails(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<HrtransportationMast>>("api/DB/BusDetails?BranchID=" + BranchID + "&Key=" + key);
        }

    }
}
