using OrisonCollegePortal.Shared.Entities.PaymentLink;
using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.PaymentLink
{
    public interface ILinkGeneration
    {
        public Task<IEnumerable<NexopayPurpose>?> GetPurpose();
        public Task<IEnumerable<dtStudentRegister>?> GetStudentListByClass(string Class, string AcademicYear, int BranchID);
        public Task<IEnumerable<StudentData>?> GetStudentData(int AccountID, string SchoolCode);
        public Task<HttpResponseMessage> SavePaymentRequest(Models.OrderRequest value, string SchoolCode);
    }
}
