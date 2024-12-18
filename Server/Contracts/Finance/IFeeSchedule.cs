using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IFeeSchedule
    {
        Task<List<SchoolFeeSchedule>> GetFeeScheduleList(int BranchID, string AcademicYear, string Key);
        Task<string> GetFeeSchedule(string ID, int BranchID, string Key);
        Task<List<SchoolFeeScheduleTran>> GetFeeScheduleList(string Fee, int BranchID, string AcademicYear,  string Key);
        Task<SchoolFeeSchedule> GetDTFeeScheduleData(int ID, int BranchID, string AcademicYear, string Key);

        Task<string> GetStudCode(string CourseStream, string Class, string Shift, string AcademicYear, int BranchID, string Key);
        Task<string> GetStudCodeSecond(string Class, string Shift, string AcademicYear, int BranchID, string Key);
        Task<string> GetStudCodeThird(string CourseStream, string Class, string AcademicYear, int BranchID, string Key);
        Task<string> GetStudCodeFourth(string Class, string AcademicYear, int BranchID, string Key);
        Task<string> GetStudCountTransport(string BusNo, string BusMode, string AcademicYear, int BranchID, string Key);
        Task<string> GetStudCountRegistration(string JoiningYear, string AcademicYear, int BranchID, string Key);
        Task<List<SchoolFeeMaster>> GetCode(int BranchID, string Key);
        Task<string> GetCategory(string Code, int BranchID, string Key);
        Task<string> GetExistFeeSchedule(string FeeSchedule, int BranchID, string AcademicYear, string Key);
        Task<List<SchoolStudentTran>> GetDTStudentTrans(string FeeSchedule, int BranchID, string AcademicYear, string Key);

        Task<long> EditStudentTrans(SchoolStudentTran student, string Key);
        Task<long> EditStudTrans(SchoolStudentTran student, string Key);
        Task<long> UpdateStudentTrans(SchoolStudentTran student, string Key);
        Task<long> UpdateStudTrans(SchoolStudentTran student, string Key);
        Task<long> UpdateStudentTransSchedule(SchoolStudentTran student, string Key);
        Task<long> UpdateStudentAdmissionSchedule(SchoolStudentTran student, string Key);

        Task<long> SaveFeeSchedule(SchoolFeeSchedule Fee, string Key);
        Task<long> SaveFeeScheduleTran(SchoolFeeScheduleTran Fee, string Key);
        Task<long> UpdateFeeSchedule(SchoolFeeSchedule Fee, string Key);
        Task<long> UpdateFeeScheduleTran(SchoolFeeScheduleTran Fee, string Key);
        Task<long> DeleteFeeSchedule(SchoolFeeSchedule Fee, string Key);
        Task<long> DeleteFeeScheduleTrans(SchoolFeeScheduleTran Fee, string Key);
        Task<long> SaveUserTrack(DtoUserTrack User, string Key);
        Task<long> SaveFeeUserTrack(DtoUserTrack User, string Key);
        Task<long> SaveFeeTranUserTrack(DtoUserTrack User, string Key);
        Task<long> SaveUpdateFeeUserTrack(DtoUserTrack User, string Key);
        public Task<string> GetStudCountAll(string Class, string AcademicYear, int BranchID, string Key);
        public Task<string> GetStudCodeOverwrite(string CourseStream, string Class, string Shift, string AcademicYear, int BranchID, string Key);
        public Task<long> UpdateStudTransOverwrite(SchoolStudentTran dt, string Key);
        public Task<long> EditStudTransOverwrite(SchoolStudentTran dt, string Key);
        public Task<long> EditStudentTransOverwrite(SchoolStudentTran dt, string Key);
        public Task<long> UpdateStudentTransOverwrite(SchoolStudentTran dt, string Key);
        public Task<string> GetStudCodeSecondOverwrite(string Class, string Shift, string AcademicYear, int BranchID, string Key);
        public Task<string> GetStudCodeThirdOverwrite(string CourseStream, string Class, string AcademicYear, int BranchID, string Key);
        public Task<string> GetStudCodeFourthOverwrite(string Class, string AcademicYear, int BranchID, string Key);
    }
}
