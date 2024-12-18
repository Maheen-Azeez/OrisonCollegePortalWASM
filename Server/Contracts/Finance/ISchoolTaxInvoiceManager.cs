using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface ISchoolTaxInvoiceManager
    {
        public Task<List<dtStudentStatement>> GetTaxInvoiceStatement(string AccountCode, string AcademicYear, string StartDate, string Enddate, int BranchID, string Con);
        Task<List<SchoolTaxInvoicedt>> GetSchoolTaxInvoice(string AcademicYear, int BranchID, string Con);
        Task<List<SchoolTaxInvoicedt>> get(int id, string AcademicYear,int BranchID, string Con);
        public Task<SchoolTaxInvoicedt> Getdata(string AcademicYear, int id, string Con);
    }
}
