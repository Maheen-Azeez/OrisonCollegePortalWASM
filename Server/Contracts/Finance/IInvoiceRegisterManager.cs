using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Server.Contracts.Finance
{
    public interface IInvoiceRegisterManager
    {
        Task<List<dtInvoiceRegister>> GetInvoice(string AcademicYear, int BranchID, string fromdate, string todate, string Con);
        Task<List<dtAdvanceReceiptRegister>> Getadvance(string AcademicYear, int BranchID, string fromdate, string todate, string Con);
        Task<List<dtInvoiceRegister>> GetInvoices(string AcademicYear, int BranchID, string fromdate, string todate, string Con);
        //Task<List<dtInvoiceRegister>> collected(int BranchID, string fromdate, string todate,string invdate,int UserID,int AccountID);
        //public Task<dtInvoiceRegister> collected(int BranchID, string fromdate, string todate,string invdate,int UserID,int AccountID);
        public Task<int> collected(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string Con);
        public Task<int> collectedtax(int BranchID, string fromdate, string todate, string invdate, int UserID, int AccountID, string CmbAccYear, string Con);


        public Task<long> post(dtInvoiceRegister value, string Con);

    }
}
