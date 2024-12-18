using OrisonCollegePortal.Shared.Entities.PaymentLink;
using OrisonCollegePortal.Shared.Entities.Finance;
using static OrisonCollegePortal.Shared.Entities.PaymentLink.Models;

namespace OrisonCollegePortal.Server.Contracts.PaymentLink
{
    public interface ILinkGeneration
    {
        Task<List<NexopayPurpose>> GetPurpose(string Key);
        Task<List<dtStudentRegister>> GetStudentListByClass(string Class, string AcademicYear, int BranchID, string Key);
        Task<List<StudentData>> GetStudentData(int AccountID, string SchoolCode, string Key);
        public Task<long> SavePaymentRequest(OrderRequest value, string SchoolCode, string Key);
    }
}
