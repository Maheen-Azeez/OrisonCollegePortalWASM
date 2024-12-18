using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class StudentEntry : IStudentEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public StudentEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateStudent(SchoolStudent StudentEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("PrevClass", StudentEntry.PrevClass, DbType.String);
            dbPara.Add("PrevDivision", StudentEntry.PrevDivision, DbType.String);
            dbPara.Add("Programme", StudentEntry.Programme, DbType.String);
            dbPara.Add("DateOfBirth", StudentEntry.DateOfBirth, DbType.DateTime);
            dbPara.Add("Sex", StudentEntry.Sex, DbType.String);
            dbPara.Add("TestingDate", StudentEntry.TestingDate, DbType.DateTime);
            dbPara.Add("Religion", StudentEntry.Religion, DbType.String);
            dbPara.Add("MotherTongue", StudentEntry.MotherTongue, DbType.String);
            dbPara.Add("PlaceOfbirth", StudentEntry.PlaceOfbirth, DbType.String);
            dbPara.Add("MinistryStatus", StudentEntry.MinistryStatus, DbType.String);
            dbPara.Add("ApprovalDate", StudentEntry.ApprovalDate, DbType.DateTime);
            dbPara.Add("RegisterNo", StudentEntry.RegisterNo, DbType.String);
            dbPara.Add("JoiningClass", StudentEntry.JoiningClass, DbType.String);
            dbPara.Add("JoiningDivision", StudentEntry.JoiningDivision, DbType.String);
            dbPara.Add("JoiningAcademicYear", StudentEntry.JoiningAcademicYear, DbType.String);
            dbPara.Add("VisaNo", StudentEntry.VisaNo, DbType.String);
            dbPara.Add("StudentStatus", StudentEntry.StudentStatus, DbType.String);
            dbPara.Add("Nationality", StudentEntry.Nationality, DbType.String);
            dbPara.Add("AccountId", StudentEntry.AccountId, DbType.Int64);
            dbPara.Add("Emirates", StudentEntry.Emirates, DbType.String);
            dbPara.Add("FeeSchedule", StudentEntry.FeeSchedule, DbType.String);
            dbPara.Add("TransSchedule", StudentEntry.TransSchedule, DbType.String);
            dbPara.Add("ActivitySchedule", StudentEntry.ActivitySchedule, DbType.String);
            dbPara.Add("SportsHouse", StudentEntry.SportsHouse, DbType.String);
            dbPara.Add("Remarks", StudentEntry.Remarks, DbType.String);
            dbPara.Add("PdcRemarks", StudentEntry.PdcRemarks, DbType.String);
            dbPara.Add("StudMobile", StudentEntry.StudMobile, DbType.String);
            dbPara.Add("LivingWith", StudentEntry.LivingWith, DbType.String);
            dbPara.Add("Custody", StudentEntry.Custody, DbType.String);
            dbPara.Add("Memo", StudentEntry.Memo, DbType.String);
            dbPara.Add("CourtAccess", StudentEntry.CourtAccess, DbType.String);
            dbPara.Add("FeePayment", StudentEntry.FeePayment, DbType.String);
            dbPara.Add("Senstatus", StudentEntry.Senstatus, DbType.String);
            dbPara.Add("Country", StudentEntry.Country, DbType.String);
            dbPara.Add("ArabNonArab", StudentEntry.ArabNonArab, DbType.String);
            dbPara.Add("Slanguage", StudentEntry.Slanguage, DbType.String);
            dbPara.Add("DocTc", StudentEntry.DocTc, DbType.Boolean);
            dbPara.Add("DocBirthCertificate", StudentEntry.DocBirthCertificate, DbType.Boolean);
            dbPara.Add("DocPassport", StudentEntry.DocPassport, DbType.Boolean);
            dbPara.Add("DocSponsorPassport", StudentEntry.DocSponsorPassport, DbType.Boolean);
            dbPara.Add("DocPhoto", StudentEntry.DocPhoto, DbType.Boolean);
            dbPara.Add("DocVaccinationCard", StudentEntry.DocVaccinationCard, DbType.Boolean);
            dbPara.Add("DocEmiratesId", StudentEntry.DocEmiratesId, DbType.Boolean);
            dbPara.Add("DocVisa", StudentEntry.DocVisa, DbType.Boolean);
            dbPara.Add("DocSponsorVisa", StudentEntry.DocSponsorVisa, DbType.Boolean);
            dbPara.Add("DocReportCard", StudentEntry.DocReportCard, DbType.Boolean);
            dbPara.Add("DocMedicalReport", StudentEntry.DocMedicalReport, DbType.Boolean);
            dbPara.Add("DocSponsorId", StudentEntry.DocSponsorId, DbType.Boolean);
            dbPara.Add("DocFamilyBook", StudentEntry.DocFamilyBook, DbType.Boolean);
            dbPara.Add("EntranceExam", StudentEntry.EntranceExam, DbType.Boolean);
            dbPara.Add("Termwise", StudentEntry.Termwise, DbType.Boolean);
            dbPara.Add("Blocked", StudentEntry.Blocked, DbType.Boolean);
            dbPara.Add("PrevStatus", StudentEntry.PrevStatus, DbType.String);
            dbPara.Add("LeavingDate", StudentEntry.LeavingDate, DbType.DateTime);
            dbPara.Add("ProcessedDate", StudentEntry.ProcessedDate, DbType.DateTime);
            dbPara.Add("Processedby", StudentEntry.Processedby, DbType.String);
            dbPara.Add("PrevSchool", StudentEntry.PrevSchool, DbType.String);
            dbPara.Add("PrevPlace", StudentEntry.PrevPlace, DbType.String);
            dbPara.Add("Tcto", StudentEntry.Tcto, DbType.String);
            dbPara.Add("TcType", StudentEntry.TcType, DbType.String);
            dbPara.Add("TcDetails", StudentEntry.TcDetails, DbType.String);
            dbPara.Add("PrevTcType", StudentEntry.PrevTcType, DbType.String);
            dbPara.Add("TcDate", StudentEntry.TcDate, DbType.DateTime);
            dbPara.Add("OpLanguage1", StudentEntry.OpLanguage1, DbType.String);
            dbPara.Add("OpLanguage2", StudentEntry.OpLanguage2, DbType.String);
            dbPara.Add("NameInArabic", StudentEntry.NameInArabic, DbType.String);
            dbPara.Add("FirstName", StudentEntry.FirstName, DbType.String);
            dbPara.Add("MiddleName", StudentEntry.MiddleName, DbType.String);
            dbPara.Add("LastName", StudentEntry.LastName, DbType.String);
            dbPara.Add("FirstNameInArabic", StudentEntry.FirstNameInArabic, DbType.String);
            dbPara.Add("MiddleNameInArabic", StudentEntry.MiddleNameInArabic, DbType.String);
            dbPara.Add("LastNameInArabic", StudentEntry.LastNameInArabic, DbType.String);
            dbPara.Add("Email", StudentEntry.Email, DbType.String);
            dbPara.Add("Criteria", "InsertStudents", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("Student_EntrySP", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> UpdateStudent(SchoolStudent StudentEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("PrevClass", StudentEntry.PrevClass, DbType.String);
            dbPara.Add("PrevDivision", StudentEntry.PrevDivision, DbType.String);
            dbPara.Add("Programme", StudentEntry.Programme, DbType.String);
            dbPara.Add("DateOfBirth", StudentEntry.DateOfBirth, DbType.DateTime);
            dbPara.Add("Sex", StudentEntry.Sex, DbType.String);
            dbPara.Add("TestingDate", StudentEntry.TestingDate, DbType.DateTime);
            dbPara.Add("Religion", StudentEntry.Religion, DbType.String);
            dbPara.Add("MotherTongue", StudentEntry.MotherTongue, DbType.String);
            dbPara.Add("PlaceOfbirth", StudentEntry.PlaceOfbirth, DbType.String);
            dbPara.Add("MinistryStatus", StudentEntry.MinistryStatus, DbType.String);
            dbPara.Add("ApprovalDate", StudentEntry.ApprovalDate, DbType.DateTime);
            dbPara.Add("RegisterNo", StudentEntry.RegisterNo, DbType.String);
            dbPara.Add("JoiningClass", StudentEntry.JoiningClass, DbType.String);
            dbPara.Add("JoiningDivision", StudentEntry.JoiningDivision, DbType.String);
            dbPara.Add("JoiningAcademicYear", StudentEntry.JoiningAcademicYear, DbType.String);
            dbPara.Add("VisaNo", StudentEntry.VisaNo, DbType.String);
            dbPara.Add("StudentStatus", StudentEntry.StudentStatus, DbType.String);
            dbPara.Add("Nationality", StudentEntry.Nationality, DbType.String);
            dbPara.Add("AccountId", StudentEntry.AccountId, DbType.Int64);
            dbPara.Add("Emirates", StudentEntry.Emirates, DbType.String);
            dbPara.Add("FeeSchedule", StudentEntry.FeeSchedule, DbType.String);
            dbPara.Add("TransSchedule", StudentEntry.TransSchedule, DbType.String);
            dbPara.Add("ActivitySchedule", StudentEntry.ActivitySchedule, DbType.String);
            dbPara.Add("SportsHouse", StudentEntry.SportsHouse, DbType.String);
            dbPara.Add("Remarks", StudentEntry.Remarks, DbType.String);
            dbPara.Add("PdcRemarks", StudentEntry.PdcRemarks, DbType.String);
            dbPara.Add("StudMobile", StudentEntry.StudMobile, DbType.String);
            dbPara.Add("LivingWith", StudentEntry.LivingWith, DbType.String);
            dbPara.Add("Custody", StudentEntry.Custody, DbType.String);
            dbPara.Add("Memo", StudentEntry.Memo, DbType.String);
            dbPara.Add("CourtAccess", StudentEntry.CourtAccess, DbType.String);
            dbPara.Add("FeePayment", StudentEntry.FeePayment, DbType.String);
            dbPara.Add("Senstatus", StudentEntry.Senstatus, DbType.String);
            dbPara.Add("Country", StudentEntry.Country, DbType.String);
            dbPara.Add("ArabNonArab", StudentEntry.ArabNonArab, DbType.String);
            dbPara.Add("Slanguage", StudentEntry.Slanguage, DbType.String);
            dbPara.Add("DocTc", StudentEntry.DocTc, DbType.Boolean);
            dbPara.Add("DocBirthCertificate", StudentEntry.DocBirthCertificate, DbType.Boolean);
            dbPara.Add("DocPassport", StudentEntry.DocPassport, DbType.Boolean);
            dbPara.Add("DocSponsorPassport", StudentEntry.DocSponsorPassport, DbType.Boolean);
            dbPara.Add("DocPhoto", StudentEntry.DocPhoto, DbType.Boolean);
            dbPara.Add("DocVaccinationCard", StudentEntry.DocVaccinationCard, DbType.Boolean);
            dbPara.Add("DocEmiratesId", StudentEntry.DocEmiratesId, DbType.Boolean);
            dbPara.Add("DocVisa", StudentEntry.DocVisa, DbType.Boolean);
            dbPara.Add("DocSponsorVisa", StudentEntry.DocSponsorVisa, DbType.Boolean);
            dbPara.Add("DocReportCard", StudentEntry.DocReportCard, DbType.Boolean);
            dbPara.Add("DocMedicalReport", StudentEntry.DocMedicalReport, DbType.Boolean);
            dbPara.Add("DocSponsorId", StudentEntry.DocSponsorId, DbType.Boolean);
            dbPara.Add("DocFamilyBook", StudentEntry.DocFamilyBook, DbType.Boolean);
            dbPara.Add("EntranceExam", StudentEntry.EntranceExam, DbType.Boolean);
            dbPara.Add("Termwise", StudentEntry.Termwise, DbType.Boolean);
            dbPara.Add("Blocked", StudentEntry.Blocked, DbType.Boolean);
            dbPara.Add("PrevStatus", StudentEntry.PrevStatus, DbType.String);
            dbPara.Add("LeavingDate", StudentEntry.LeavingDate, DbType.DateTime);
            dbPara.Add("ProcessedDate", StudentEntry.ProcessedDate, DbType.DateTime);
            dbPara.Add("Processedby", StudentEntry.Processedby, DbType.String);
            dbPara.Add("PrevSchool", StudentEntry.PrevSchool, DbType.String);
            dbPara.Add("PrevPlace", StudentEntry.PrevPlace, DbType.String);
            dbPara.Add("Tcto", StudentEntry.Tcto, DbType.String);
            dbPara.Add("TcType", StudentEntry.TcType, DbType.String);
            dbPara.Add("TcDetails", StudentEntry.TcDetails, DbType.String);
            dbPara.Add("PrevTcType", StudentEntry.PrevTcType, DbType.String);
            dbPara.Add("TcDate", StudentEntry.TcDate, DbType.DateTime);
            dbPara.Add("OpLanguage1", StudentEntry.OpLanguage1, DbType.String);
            dbPara.Add("OpLanguage2", StudentEntry.OpLanguage2, DbType.String);
            dbPara.Add("NameInArabic", StudentEntry.NameInArabic, DbType.String);
            dbPara.Add("FirstName", StudentEntry.FirstName, DbType.String);
            dbPara.Add("MiddleName", StudentEntry.MiddleName, DbType.String);
            dbPara.Add("LastName", StudentEntry.LastName, DbType.String);
            dbPara.Add("FirstNameInArabic", StudentEntry.FirstNameInArabic, DbType.String);
            dbPara.Add("MiddleNameInArabic", StudentEntry.MiddleNameInArabic, DbType.String);
            dbPara.Add("LastNameInArabic", StudentEntry.LastNameInArabic, DbType.String);
            dbPara.Add("Email", StudentEntry.Email, DbType.String);
            dbPara.Add("Criteria", "UpdateStudents", DbType.String);
            dbPara.Add("AccID", StudentEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Update("Student_EntrySP",Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

    }
}
