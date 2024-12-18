using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Contracts.Finance
{
    interface IInvoiceRegisterManager
    {
        public Task<List<dtInvoiceRegister>?> GetInvoice(string AcademicYear, int BranchID, string fromdate, string todate);
        public Task<List<dtAdvanceReceiptRegister>?> Getadvance(string AcademicYear, int BranchID, string fromdate, string todate);

        public Task<List<dtInvoiceRegister>?> GetInvoices(string AcademicYear, int BranchID, string fromdate, string todate);
        Task<bool> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID);
        Task<bool> collectedtax(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string CmbAccYear);


        public Task<HttpResponseMessage> post(dtInvoiceRegister value);

    }
}
