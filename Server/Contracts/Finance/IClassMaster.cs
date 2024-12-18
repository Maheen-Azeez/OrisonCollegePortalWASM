using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IClassMaster
    {
        Task<List<SchoolClassMaster>> Getdata(int BranchID, string Key);
        Task<List<SchoolClassMaster>> Getdata(int BranchID, string AcademicYear, string Key);
        Task<SchoolClassMaster> GetDTClassMaster(int Id, string Key);
        public Task<long> SaveMaster(SchoolClassMaster value, string Key);
        public Task<long> UpdateMaster(SchoolClassMaster value, string Key);
        public Task<int> DeleteMaster(int Id, string Key);
        Task<List<SchoolStudentTran>> GetDTStudentTrans(string Class, int BranchID, string AcademicYear, string Key);
        Task<long> SaveUserTrack(DtoUserTrack User, string Key);
        Task<long> AddSaveUserTrack(DtoUserTrack User, string Key);
        Task<long> EditSaveUserTrack(DtoUserTrack User, string Key);
        public Task<long> SaveNewClassData(List<SchoolClassMaster> value, string Key);
    }
}
