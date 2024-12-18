using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    public interface ISchoolTaxInvoiceManager
    {
        public Task<List<dtStudentStatement>?> GetTaxInvoiceStatement(string AccountCode, string AcademicYear, string StartDate, string EndDate, int BranchID);
        public Task<List<SchoolTaxInvoicedt>?> GetSchoolTaxInvoice(string AcademicYear, int BranchID);
        public Task<SchoolTaxInvoicedt>? Getdata(string AcademicYear, int id);
        public Task<List<SchoolTaxInvoicedt>?> get(int id, string AcademicYear,int BranchID);
        public Task<IEnumerable<SchoolMailTemplate>?> GetMailTemplate(string Type, int BranchID);
    }
}
