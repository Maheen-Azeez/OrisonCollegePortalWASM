using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IStudentMaster
    {
        Task<List<dtStudentRegister>> GetStudentList(string AcademicYear, int? BranchID, string Key);
        Task<List<dtoStudentRegisterDefault>> GetStudentListDefault(string AcademicYear, int? BranchID, string Key);
        Task<List<dtStudentRegister>> GetStudentListByClass(string Class, string AcademicYear, int BranchID, string Key);
        Task<List<dtStudentRegister>> GetStudentListTeacher(string AcademicYear, int BranchID, int UserID, string Key);
        Task<List<MastDesignation>> BindComboBox(string type, string Key);
        Task<string> BindSettingsValue(string Category, string Key);
        Task<Accounts> GetDTAccount(int AccountID, string Key);
        Task<SchoolStudent> GetDTStudent(int AccountID, string Key);
        Task<SchoolStudentTran> GetDTStudentTrans(int AccountID, int BranchID, string AcademicYear, string Key);
        Task<SchoolParentMaster> GetDTParent(int AccountID, string Key);
        Task<SchoolStudentsArabic> GetDTStudentsArabic(int AccountID, string Key);
        Task<SchoolImage> GetDTStudentImage(int AccountID, string Key);

        Task<List<SchoolDocument>> GetStudDocumentById(int AccountID, string Key);
        Task<SchoolDocument> GetDocumentByDocId(int DocID, string Key);
        Task<List<SchoolParentDocument>> GetParentDocumentById(int AccountID, string Key);
        Task<SchoolParentDocument> GetParentDocumentByDocId(int DocID, string Key);
        Task<List<SchoolAdditionalPayment>> GetAdditionalPayment(int AccountID, string Key);
        Task<List<SchoolAdditionalPayment>> GetAdditionalDiscount(int AccountID, string Key);
        Task<List<SchoolFamilyDetail>> GetRelation(int AccountID, string Key);
        Task<List<SchoolStudentNote>> GetNotes(int AccountID, string Key);
        Task<List<dtStudentStatement>> GetStatement(string FromDate, string ToDate, int AccountID, int BranchID, string Key);


        Task<long> CreateNewStudent(dtMasterStudent student, string Key);
        Task<long> CreateNewStudentSibling(dtMasterStudent student, string Key);
        Task<long> UpdateStudent(dtMasterStudent student, string Key);
        Task<long> UpdateStudentOnly(dtMasterStudent student, string Key);
        Task<long> CreateNewParent(dtMasterStudent Parent, string Key);
        Task<long> CreateImage(dtMasterStudent student, string Key);
        Task<long> UpdateImage(dtMasterStudent student, string Key);
        Task<long> CreateNotes(dtMasterStudent student, string Key);
        Task<long> UpdateNotes(dtMasterStudent student, string Key);
        Task<long> DeleteNote(dtMasterStudent student, string Key);

        Task<SchoolAdditionalPayment> GetAdditionalDiscountbyid(int AccountID, int ID, string Key);
        Task<SchoolAdditionalPayment> GetAdditionalPaymentbyid(int AccountID, int ID, string Key);

        Task<long> CreateRelation(dtMasterStudent student, string Key);
        Task<long> UpdateRelation(dtMasterStudent student, string Key);
        Task<long> DeleteRelation(dtMasterStudent student, string Key);

        Task<long> SaveDocument(dtMasterStudent Document, string Key);
        Task<long> UpdateDocument(dtMasterStudent Document, string Key);
        Task<long> DeleteDocument(dtMasterStudent Document, string Key);
        Task<long> SaveParentDocument(dtMasterStudent Document, string Key);
        Task<long> UpdateParentDocument(dtMasterStudent Document, string Key);
        Task<long> DeleteParentDocument(dtMasterStudent Document, string Key);

        Task<string> GetEnableTab(string Tab, string Key);

        Task<long> ImportStudent(Accounts student);
        Task<dtImportStudent> GetDTImportStudent(string Scode, int BranchID, string Key);
        Task<string> GetAge(int AccountID, string Key);
        Task<List<SchoolWebMenuSettings>?> EnableMenu(string Menu, string Key);
        Task<List<DtoStudentReceiptStatement>> GetStatementReceipt(string FromDate, string ToDate, int AccountID, int BranchID, string Key);
    }
}
