//using OrisonSchoolWeb.Entities;
using OrisonCollegePortal.Shared.Entities;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IStudentMaster
    {
        public Task<IEnumerable<dtStudentRegister>?> GetStudentList(string AcademicYear, int? BranchID);
        //public Task<IEnumerable<dtoStudentRegisterDefault>?> GetStudentListDefault(string AcademicYear, int? BranchID);
        public Task<IEnumerable<dtStudentRegister>?> GetStudentListByClass(string Class, string AcademicYear, int? BranchID);
        public Task<IEnumerable<MastDesignation>?> BindComboBox(string type);
        public Task<IEnumerable<SchoolClassMaster>?> GetClass(int? BranchID);
        public Task<IEnumerable<SchoolClassMaster>?> GetClass(int? BranchID, string AcademicYear);
        public Task<IEnumerable<SchoolClass>?> GetDivision(int? BranchID);
        public Task<IEnumerable<SchoolClass>?> GetDivision(int? BranchID, string AcademicYear);
        public Task<IEnumerable<SchoolClass>?> GetDivisionByClass(int? BranchID, string Class);
        public Task<IEnumerable<SchoolClassMaster>?> GetUserOwnClass(int? UserID, int? BranchID);
        public Task<IEnumerable<SchoolClass>?> GetUserOwnDivision(int? UserID, int? BranchID);
        public Task<IEnumerable<SchoolAcademicYear>?> GetAcademicYear(int? BranchID);
        public Task<IEnumerable<SchoolFeeSchedule>?> GetFee(string AcademicYear, int? BranchID);
        public Task<IEnumerable<SchoolFeeSchedule>?> GetTransport(string AcademicYear, int? BranchID);
        public Task<IEnumerable<SchoolFeeSchedule>?> GetAdmission(string AcademicYear, int? BranchID);
        public Task<IEnumerable<SchoolDiscountSchedule>?> GetFeeDiscount(int? BranchID);
        public Task<IEnumerable<SchoolFeeSchedule>?> GetActivity(string AcademicYear, int? BranchID);
        public Task<IEnumerable<Accounts>?> GetStaff(int? BranchID);
        public Task<IEnumerable<dtStudentRegister>?> GetParent(int? BranchID);
       // public Task<IEnumerable<dtoStudentRegisterDefault>?> GetParent(int? BranchID);
       // public Task<IEnumerable<HrtransportationMast>?> GetBusDetails(int? BranchID);
       // public Task<IEnumerable<Accounts>> GetPLevel();
        public Task<string> GetPLevel();

        public Task<string> GetPLevelID();
        public Task<string> GetAccountGroup(int PID);
        public Task<string> GetSubGroup(int PID);
        public Task<string> GetAccCategory(int PID);
        public Task<string> GetShowChild(int PID);
        public Task<string> GetAccCategoryMast();
        //public Task<IEnumerable<dtCompany>> GetAbbr(int BranchID);
        public Task<string> GetAbbr(int? BranchID);
        public Task<string> BindSettingsValue(string Category);
      //  public Task<List<dtFeetype>?> GetFeetype(string type, string Academiyear, int? BranchID, string Criteria);
       // public Task<List<dtFeetype>?> GetPaymentMode(string Criteria);

        public Task<SchoolAdditionalPayment> GetAdditionalDiscountbyid(int AccountID, int ID);
        public Task<SchoolAdditionalPayment> GetAdditionalPaymentbyid(int AccountID, int ID);


        public Task<Accounts?> GetDTAccount(int AccountID);
        public Task<SchoolStudent?> GetDTStudent(int AccountID);
        public Task<SchoolStudentTran?> GetDTStudentTrans(int AccountID, int? BranchID, string AcademicYear);
        public Task<SchoolParentMaster?> GetDTParent(int AccountID);
      //  public Task<SchoolStudentsArabic?> GetDTStudentsArabic(int AccountID);
        public Task<SchoolImage?> GetDTStudentImage(int AccountID);

        public Task<string> GetSExistNo(int? BranchID);
        public Task<string> GetNextNo(int? BranchID);
        public Task<string> GetParentNextNo(int? BranchID, string SCode);

        //public Task<IEnumerable<SchoolDocument?>> GetStudDocumentById(int AccountID);
        //public Task<SchoolDocument> GetDocumentByDocId(int DocID);
        //Task<SchoolDocument?> GetValidationByDocType(string type);
        //public Task<IEnumerable<SchoolParentDocument>> GetParentDocumentById(int AccountID);
        //public Task<SchoolParentDocument> GetParentDocumentByDocId(int DocID);
        public Task<IEnumerable<SchoolAdditionalPayment?>> GetAdditionalPayment(int AccountID);
        public Task<IEnumerable<SchoolAdditionalPayment?>> GetAdditionalDiscount(int AccountID);
       // public Task<IEnumerable<SchoolFamilyDetail?>> GetRelation(int AccountID);
       // public Task<IEnumerable<SchoolStudentNote?>> GetNotes(int AccountID);
        public Task<IEnumerable<dtStudentStatement>> GetStatement(string FromDate, string ToDate, int AccountID, int? BranchID);
      
        public Task<string> GetStaffID(int? BranchID, String Code);




        public Task<HttpResponseMessage> SaveAdd(dtMasterStudent Student);
        public Task<HttpResponseMessage> SaveSibling(dtMasterStudent Student);
        public Task<HttpResponseMessage> SaveUpdate(dtMasterStudent Student);
        public Task<HttpResponseMessage> UpdateStudent(dtMasterStudent Student);
        public Task<HttpResponseMessage> SaveParent(dtMasterStudent Parent);

        public Task<HttpResponseMessage> SaveImage(dtMasterStudent Student);
        public Task<HttpResponseMessage> SaveUpdateImage(dtMasterStudent Student);

        public Task<HttpResponseMessage> SaveNote(dtMasterStudent Student);
        public Task<HttpResponseMessage> UpdateNote(dtMasterStudent Student);
        public Task<HttpResponseMessage> DeleteNoteById(dtMasterStudent Note);

        public Task<HttpResponseMessage> SaveRelation(dtMasterStudent Relation);
        public Task<HttpResponseMessage> UpdateRelation(dtMasterStudent Relation);
        public Task<HttpResponseMessage> DeleteRelationByID(dtMasterStudent Relation);

        public Task<HttpResponseMessage> SaveDocument(dtMasterStudent Document);
        public Task<HttpResponseMessage> UpdateDocument(dtMasterStudent Document);
        public Task<HttpResponseMessage> DeleteDocumentByDocId(dtMasterStudent Document);
        public Task<HttpResponseMessage> SaveParentDocument(dtMasterStudent Document);
        public Task<HttpResponseMessage> UpdateParentDocument(dtMasterStudent Document);
        public Task<HttpResponseMessage> DeleteParentDocumentByDocId(dtMasterStudent Document);

        public Task<string> GetEnableTab(string Tab);

        public Task<string> GetExistStudent(string Scode, int? BranchID);
        public Task<string> GetExistSyncStudent(string Scode, int? BranchID);
        public Task<string> GetExistParentID(string Pcode, int? BranchID);

        public Task<HttpResponseMessage> ImportStudent(Accounts Data);
       // public Task<dtImportStudent> GetDTImportStudent(string Scode, int? BranchID);
        public Task<string> GetTeacherName(string Class, string Division, int? BranchID);
        public Task<string> GetAge(int AccountID);

       // public Task<IEnumerable<Student_DocTypeValidation>?> GetStudentDocumentType();
       // public Task<IEnumerable<Parent_DocTypeValidation>?> GetParentDocumentType();
        public Task<string> getDocUrl(string Path);
       // public Task<IEnumerable<DtoStudentReceiptStatement>> GetStatementReceipt(string FromDate, string ToDate, int AccountID, int? BranchID);
        public  Task<List<ExpandoObject>> GetCombanyLogo(int? BranchID);
        public Task<string> GetMailType(int? BranchID);
        public Task<IEnumerable<HrtransportationMast>?> GetBusDetails(int? BranchID);
    }
}
