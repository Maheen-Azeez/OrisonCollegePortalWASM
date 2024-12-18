using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IFeeSchedule
    {
        public Task<IEnumerable<SchoolFeeSchedule>?> GetFeeScheduleList(int? BranchID, string AcademicYear);
        public Task<string> GetFeeSchedule(string ID, int? BranchID);
        public Task<IEnumerable<SchoolFeeScheduleTran>?> GetFeeScheduleFeeList(string Fee, int? BranchID, string AcademicYear);

        public Task<SchoolFeeSchedule> GetDTFeeScheduleData(string ID, int? BranchID, string AcademicYear);
        public Task<string> GetStudCode(string CourseStream, string Class, string Shift, string AcademicYear, int? BranchID);
        public Task<string> GetStudCodeSecond(string Class, string Shift, string AcademicYear, int? BranchID);
        public Task<string> GetStudCodeThird(string CourseStream, string Class, string AcademicYear, int? BranchID);
        public Task<string> GetStudCodeFourth(string Class, string AcademicYear, int? BranchID);
        public Task<string> GetStudCountTransport(string BusNo, string BusMode, string AcademicYear, int? BranchID);
        public Task<string> GetStudCountRegistration(string JoiningYear, string AcademicYear, int? BranchID);

        public Task<List<SchoolFeeMaster>?> GetCode(int? BranchID);
        public Task<string> GetCategory(string Code, int? BranchID);
        public Task<string> GetExistFeeSchedule(string FeeSchedule, int? BranchID, string AcademicYear);
        public Task<IEnumerable<SchoolStudentTran>?> GetStudentFeeSchedule(string FeeSchedule, int? BranchID, string AcademicYear);
        public Task<IEnumerable<SchoolClassMaster>?> GetRoute(int? BranchID, string AcademicYear);
        public Task<HttpResponseMessage> UpdateStudentTrans(SchoolStudentTran value);
        public Task<HttpResponseMessage> UpdateStudTrans(SchoolStudentTran value);
        public Task<HttpResponseMessage> EditStudentTrans(SchoolStudentTran value);
        public Task<HttpResponseMessage> EditStudTrans(SchoolStudentTran value);
        public Task<HttpResponseMessage> UpdateStudentTransSchedule(SchoolStudentTran value);
        public Task<HttpResponseMessage> UpdateStudentAdmissionSchedule(SchoolStudentTran value);

        public Task<HttpResponseMessage> SaveFeeSchedule(SchoolFeeSchedule value);
        public Task<HttpResponseMessage> SaveFeeScheduleTran(SchoolFeeScheduleTran value);

        public Task<HttpResponseMessage> UpdateFeeSchedule(SchoolFeeSchedule value);
        public Task<HttpResponseMessage> UpdateFeeScheduleTran(SchoolFeeScheduleTran value);
        public Task<HttpResponseMessage> DeleteFeeSchedule(SchoolFeeSchedule Fee);
        public Task<HttpResponseMessage> DeleteFeeScheduleTrans(SchoolFeeScheduleTran Fee);

        public Task<HttpResponseMessage> SaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> SaveFeeUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> SaveFeeTranUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> SaveUpdateFeeUserTrack(DtoUserTrack value);
        public Task<List<SchoolFeeMaster>?> GetCode(int? BranchID, string AcademicYear);
        public Task<string> GetStudCountAll(string Class, string AcademicYear, int? BranchID);
        public Task<string> GetStudCodeOverwrite(string CourseStream, string Class, string Shift, string AcademicYear, int? BranchID);
        public Task<HttpResponseMessage> UpdateStudTransOverwrite(SchoolStudentTran dt);
        public Task<HttpResponseMessage> EditStudTransOverwrite(SchoolStudentTran dt);
        public Task<HttpResponseMessage> EditStudentTransOverwrite(SchoolStudentTran dt);
        public Task<HttpResponseMessage> UpdateStudentTransOverwrite(SchoolStudentTran dt);
        public Task<string> GetStudCodeSecondOverwrite(string Class, string Shift, string AcademicYear, int? BranchID);
        public Task<string> GetStudCodeThirdOverwrite(string CourseStream, string Class, string AcademicYear, int? BranchID);
        public Task<string> GetStudCodeFourthOverwrite(string Class, string AcademicYear, int? BranchID);
    }
}
