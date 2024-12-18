using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.BoldReport;
using Microsoft.AspNetCore.Mvc;
using OrisonCollegePortal.Shared.Entities.BoldReport;
using BoldReports.Writer;
using BoldReports.Web;
using System.Data;
using System.Web;
using Dapper;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Net.Mail;
using System.Net;
using OrisonCollegePortal.Server.Contracts.Inventory;

namespace OrisonCollegePortal.Server.Concretes.BoldReport
{
    public class BoldReportManager : IBoldReportManager
    {
        private readonly IDapperManager _dapperManager;
        private bool disposedValue;
        IInvVoucherManager _IInvVoucherManager;
       

        public BoldReportManager(IDapperManager dapperManager, IInvVoucherManager iInvVoucherManager)
        {
            this._dapperManager = dapperManager;
            _IInvVoucherManager = iInvVoucherManager;
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        public async Task<FileStreamResult> GetReport(DataSource Data)
        {
            string HostPath = await GetReportPath(HttpUtility.UrlDecode(Data.Con!));
             //string HostPath = @"C:\\Users\\femee";
            
            string PathWithCustom = Path.Combine(HostPath, @$"Students\Custom\{Data.CompanyCode}", $"{Data.ReportName}.rdl");
            string PathWithoutCustom = Path.Combine(HostPath, @"Students\", $"{Data.ReportName}.rdl");

            string filePath = File.Exists(PathWithCustom) ? PathWithCustom : PathWithoutCustom;

            using (FileStream inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (MemoryStream reportStream = new MemoryStream())
            {
                inputStream.CopyTo(reportStream);
                reportStream.Position = 0;
                inputStream.Close();
                ReportWriter writer = new ReportWriter(reportStream);
               
                writer.ReportProcessingMode = ProcessingMode.Local;
                writer.DataSources.Clear();

                var dataSets = new List<IEnumerable<object>>
                {
                     Data.DataSet1!, Data.DataSet2!, Data.DataSet3!, Data.DataSet4!, Data.DataSet5!,
                     Data.DataSet6!, Data.DataSet7!, Data.DataSet8!, Data.DataSet9!, Data.DataSet10!
                };

                for (int i = 0; i < dataSets.Count; i++)
                {
                    if (dataSets[i] != null)
                    {
                        writer.DataSources.Add(new ReportDataSource
                        {
                            Name = $"DataSet{i + 1}",
                            Value = dataSets[i].ToList()
                        });
                      
                    }
                    else
                    {
                        break;
                    }
                }
                //qrcode generation

                if (!string.IsNullOrEmpty(Data!.QrCodeData))
                {
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        writer.ReportPath = filePath;

                        if (writer.ReportPath.Contains(filePath))
                        {
                            List<ReportParameter> userParameters = new List<ReportParameter>
                        {
                            new ReportParameter()
                            {
                                Name = "QRCodeData",
                                Values = new List<string>() { Data!.QrCodeData }
                            }
                        };
                            writer.SetParameters(userParameters);

                        }
                    }

                }

                string fileName = $"{Data.ReportName}.pdf";
                WriterFormat format = WriterFormat.PDF;
                string contentType = "application/pdf";

                MemoryStream memoryStream = new MemoryStream();
                writer.Save(memoryStream, format);

                memoryStream.Position = 0;
                FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, contentType);
                fileStreamResult.FileDownloadName = fileName;
                return fileStreamResult;
            }
        }
        public async Task<string> GetReportPath(string Con)
        {
            var Result = Task.FromResult(_dapperManager.Get<string>
                ("select Description from MasterMisc where Source='Report Path'", Con, null, commandType: CommandType.Text));
            return await Result;
        }

        public async Task<List<DtoReceiptPrint>> GetFeeRecieptAcc(long VID, string AccYear, int VNO, long BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", VID, DbType.Int32);
            dbPara.Add("ONO", VNO, DbType.Int32);
            dbPara.Add("BranchId", BranchID, DbType.Int32);
            dbPara.Add("AcademicYear", AccYear, DbType.String);
            dbPara.Add("Criteria", "No Allocation", DbType.String);
            var Bill = Task.FromResult(_dapperManager.GetAll<DtoReceiptPrint>
                               ("[dbo].[Receipt_PrintSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Bill;
        }

        public async Task<List<DtoReceiptPrint>> GetFeeRecieptByID(long VID, string AccYear, int VNO, long BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", VID, DbType.Int32);
            dbPara.Add("ONO", VNO, DbType.Int32);
            dbPara.Add("BranchId", BranchID, DbType.Int32);
            dbPara.Add("AcademicYear", AccYear, DbType.String);
            dbPara.Add("Criteria", "VoucherRecieptPrintNew", DbType.String);
            var Bill = Task.FromResult(_dapperManager.GetAll<DtoReceiptPrint>
                               ("[dbo].[Receipt_PrintSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Bill;
        }
        public async Task<List<DtoReceiptPrint>> MerrylandGetFeeRecieptByID(long VID, string AccYear, int VNO, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("ID", VID, DbType.Int32);
                dbPara.Add("ONO", VNO, DbType.Int32);
                dbPara.Add("AcademicYear", AccYear, DbType.String);
                dbPara.Add("Criteria", "VoucherRecieptPrintNew", DbType.String);
                var Bill = Task.FromResult(_dapperManager.GetAll<DtoReceiptPrint>
                                   ("[dbo].[FeeAnalysis_RegisterSP]", key, dbPara, commandType: CommandType.StoredProcedure));
                return await Bill;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task<List<DtoReceiptPrint>> GetFeeRecieptNoAllocPreReg(long VID, string AccYear, int VNO, long BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", VID, DbType.Int32);
            dbPara.Add("ONO", VNO, DbType.Int32);
            dbPara.Add("BranchId", BranchID, DbType.Int32);
            dbPara.Add("AcademicYear", AccYear, DbType.String);
            dbPara.Add("Criteria", "PreRegistrationNoAllocation", DbType.String);
            var Bill = Task.FromResult(_dapperManager.GetAll<DtoReceiptPrint>
                               ("[dbo].[Receipt_PrintSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Bill;

        }

        public async Task<List<DtoReceiptPrint>> GetFeeRecieptPreReg(long VID, string AccYear, int VNO, long BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", VID, DbType.Int32);
            dbPara.Add("ONO", VNO, DbType.Int32);
            dbPara.Add("BranchId", BranchID, DbType.Int32);
            dbPara.Add("AcademicYear", AccYear, DbType.String);
            dbPara.Add("Criteria", "PreRegistration Reservation", DbType.String);
            var Bill = Task.FromResult(_dapperManager.GetAll<DtoReceiptPrint>
                               ("[dbo].[Receipt_PrintSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Bill;
        }

        public async Task<List<DtoReceiptPrint>> GetFeeRecieptReReg(long VID, string AccYear, int VNO, long BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", VID, DbType.Int32);
            dbPara.Add("ONO", VNO, DbType.Int32);
            dbPara.Add("BranchId", BranchID, DbType.Int32);
            dbPara.Add("AcademicYear", AccYear, DbType.String);
            dbPara.Add("Criteria", "ReRegistration", DbType.String);
            var Bill = Task.FromResult(_dapperManager.GetAll<DtoReceiptPrint>
                               ("[dbo].[Receipt_PrintSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Bill;
        }

        public async Task<List<DtoReceiptPrint>> GetFeeVtype(long VID, long BranchID, string key, string Criteria)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", VID, DbType.Int32);
            dbPara.Add("BranchId", BranchID, DbType.Int32);
            dbPara.Add("Criteria", Criteria, DbType.String);
            var vtype = Task.FromResult(_dapperManager.GetAll<DtoReceiptPrint>
                                ("[dbo].[Receipt_PrintSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await vtype;
        }

        public async Task<int> sendEmail(DtoEmail dtoEmail, string key)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient SmtpClient = new System.Net.Mail.SmtpClient();
                object HOST = dtoEmail.GetHost;

                mail.IsBodyHtml = true;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                SmtpClient.UseDefaultCredentials = true;
                SmtpClient.Port = Convert.ToInt32(dtoEmail.GetPort);
                SmtpClient.Host = HOST.ToString();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
               | SecurityProtocolType.Tls11
               | SecurityProtocolType.Tls12;

                mail.From = new System.Net.Mail.MailAddress(dtoEmail.GetFromUser, dtoEmail.GetCompanyName);
                // mail.From = new System.Net.Mail.MailAddress("roshanorison@outlook.com");
                if (dtoEmail.ToMail != null)
                    mail.To.Add(dtoEmail.ToMail);
                FileStreamResult fileStream = await GetReport(dtoEmail.dt);
                mail.Attachments.Add(new Attachment(fileStream.FileStream, "Fee Receipt.pdf"));
                mail.Subject = " (no-reply) Fee Receipt ";
                mail.Body = "<h3 style='color: #0104a3;font-size:12px;'>Dear " + dtoEmail.Recievr + ",</h3>" +
                            "<div>    <span style='color: #171717;'>Please find our payment receipt attached to this email.</span>     </div>" +
                            " <br>" +
                            "<span style='color: #171717;'>Thank You.</span>" + "<br>" + "<br>" + "<span style='color: #171717;'>Have a great day!</span><br><span style='color: #171717;'>" + dtoEmail.GetCompanyName + "</span>";

                using (var client = new System.Net.Mail.SmtpClient(HOST.ToString(), Convert.ToInt32(dtoEmail.GetPort)))
                {
                    System.Net.NetworkCredential netCredential = new System.Net.NetworkCredential(dtoEmail.GetFromUser, dtoEmail.Pwd);
                    //System.Net.NetworkCredential netCredential = new System.Net.NetworkCredential("roshanorison@outlook.com", "Roshan@orison");
                    client.Credentials = netCredential;
                    client.EnableSsl = true;
                    client.Send(mail);
                }


                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return 0;
            }

        }
      
    }
}
