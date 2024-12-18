using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface IClassMaster
    {
        public Task<List<SchoolClassMaster>?> Getdata(int? BranchID);
        public Task<List<SchoolClassMaster>?> Getdata(int? BranchID, string AcademicYear);
        public Task<SchoolClassMaster?> GetDTClassMaster(int Id);
        Task<bool> DeleteMaster(int Id);

        public Task<HttpResponseMessage> SaveMaster(SchoolClassMaster value);
        public Task<HttpResponseMessage> UpdateMaster(SchoolClassMaster value);
        public Task<List<SchoolStudentTran>?> GetDTStudentTrans(string Class, int? BranchID, string AcademicYear);
        public Task<HttpResponseMessage> SaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> AddSaveUserTrack(DtoUserTrack value);
        public Task<HttpResponseMessage> EditSaveUserTrack(DtoUserTrack value);

        public Task<HttpResponseMessage> SaveNewClassData(List<SchoolClassMaster> value);
    }
}
