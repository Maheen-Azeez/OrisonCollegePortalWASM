using System;
using System.Collections.Generic;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IDiscountManager
    {
        public Task<long> SaveMaster(SchoolDiscountSchedule value, string Key);
        public Task<long> UpdateMaster(SchoolDiscountSchedule value, string Key);
        Task<SchoolDiscountSchedule> GetDTDiscount(int Id, int BranchID, string Key);
        public Task<int> DeleteDiscount(int Id, string Key);
        Task<long> AddSaveUserTrack(DtoUserTrack User, string Key);
        Task<long> EditSaveUserTrack(DtoUserTrack User, string Key);
        Task<long> DeleteSaveUserTrack(DtoUserTrack User, string Key);

        Task<List<SchoolDiscountSchedule>> Getdata(int BranchID, string Key);
        public Task<SchoolDiscountSchedule> Getdt(int BranchID, string Key);
        Task<string> GetID(string AccountCode, string Key);
        Task<List<Accounts>> GetPostTo(int BranchID, string Key);
    }
}
