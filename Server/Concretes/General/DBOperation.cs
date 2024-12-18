using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.General
{
    public class DBOperation : IDBOperation
    {
        private readonly IConfiguration _config;
        private readonly IDapperManager _dapperManager;
        private bool disposedValue;
        public DBOperation(IConfiguration config, IDapperManager dapperManager)
        {
            _config = config;
            this._dapperManager = dapperManager;
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

        public async Task<List<SchoolAcademicYear>> GetAcademicYear(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var AcedemicYear = Task.FromResult(_dapperManager.GetAll<SchoolAcademicYear>("select * from COL_AcademicYear where BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return await AcedemicYear;
        }

        public Task<string> GetCurrentAcademicYear(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Company = Task.FromResult(_dapperManager.Get<string>("Select AcademicYear from COL_AcademicYear where Status='Current' and BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return Company;
        }

        public async Task<List<SchoolClassMaster>> GetClass(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Class = Task.FromResult(_dapperManager.GetAll<SchoolClassMaster>("SELECT Program FROM Col_ProgramMaster where BranchID=@BranchID ORDER BY ROW_NUMBER() over (order by ID)", key, dbPara, commandType: CommandType.Text));
            return await Class;
        }
        public async Task<List<SchoolClassMaster>> GetClass(int? BranchID, string AcademicYear, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var Class = Task.FromResult(_dapperManager.GetAll<SchoolClassMaster>("SELECT Program As Class FROM Col_ProgramMaster where BranchID=@BranchID ORDER BY ROW_NUMBER() over (order by ID)", key, dbPara, commandType: CommandType.Text));
            return await Class;
        }

        public async Task<List<SchoolClass>> GetDivision(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Division = Task.FromResult(_dapperManager.GetAll<SchoolClass>("Select Distinct ProgrammeYear As Division  from Col_StudentTrans where BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return await Division;
        }

        public async Task<List<SchoolClass>> GetDivision(int? BranchID, string AcademicYear, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var Division = Task.FromResult(_dapperManager.GetAll<SchoolClass>("Select Distinct  ProgrammeYear from Col_StudentTrans where BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return await Division;
        }

        public async Task<List<SchoolClass>> GetDivisionByClass(int? BranchID, string Class, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            dbPara.Add("@Class", Class, DbType.String);
            var Division = Task.FromResult(_dapperManager.GetAll<SchoolClass>("Select Distinct  Division from School_Class where BranchID=@BranchID and Class=@Class order by Division", key, dbPara, commandType: CommandType.Text));
            return await Division;
        }

        public async Task<List<SchoolClassMaster>> GetUserOwnClass(int UserID, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@UserID", UserID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Criteria", "GetUserOwnClass", DbType.String);
            var Class = Task.FromResult(_dapperManager.GetAll<SchoolClassMaster>("School_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Class;
        }
        public async Task<List<SchoolClass>> GetUserOwnDivision(int UserID, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@UserID", UserID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Criteria", "GetUserOwnDivision", DbType.String);
            var Division = Task.FromResult(_dapperManager.GetAll<SchoolClass>("School_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Division;
        }

        public async Task<List<SchoolFeeSchedule>> GetFee(string AcademicYear, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Fee = Task.FromResult(_dapperManager.GetAll<SchoolFeeSchedule>("SELECT ID,FeeSchedule FROM Col_FeeSchedule where type='CourseFee' and AcademicYear=@AcademicYear and BranchID=@BranchID  ORDER BY FeeSchedule", key, dbPara, commandType: CommandType.Text));
            return await Fee;
        }
        public async Task<List<SchoolFeeSchedule>> GetTransport(string AcademicYear, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Transport = Task.FromResult(_dapperManager.GetAll<SchoolFeeSchedule>("SELECT ID,FeeSchedule FROM Col_FeeSchedule where type='TransportationFee' and AcademicYear=@AcademicYear and BranchID=@BranchID  ORDER BY FeeSchedule", key, dbPara, commandType: CommandType.Text));
            return await Transport;
        }
        public async Task<List<SchoolFeeSchedule>> GetAdmission(string AcademicYear, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Admission = Task.FromResult(_dapperManager.GetAll<SchoolFeeSchedule>("SELECT ID,FeeSchedule FROM Col_FeeSchedule where type='AdmissionFee' and AcademicYear=@AcademicYear and BranchID=@BranchID  ORDER BY FeeSchedule", key, dbPara, commandType: CommandType.Text));
            return await Admission;
        }

       

        public async Task<List<SchoolDiscountSchedule>> GetFeeDiscount(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var FeeDiscount = Task.FromResult(_dapperManager.GetAll<SchoolDiscountSchedule>("SELECT ID, Schedule FROM Col_DiscountSchedule where type = 'Discount'   ORDER BY ID", key, dbPara, commandType: CommandType.Text));
            return await FeeDiscount;
        }
        public async Task<List<SchoolFeeSchedule>> GetActivity(string AcademicYear, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Activity = Task.FromResult(_dapperManager.GetAll<SchoolFeeSchedule>("SELECT ID,FeeSchedule FROM Col_FeeSchedule where type='Activity' and AcademicYear=@AcademicYear and BranchID=@BranchID  ORDER BY FeeSchedule", key, dbPara, commandType: CommandType.Text));
            return await Activity;
        }
        public async Task<List<Accounts>> GetStaff(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Staff = Task.FromResult(_dapperManager.GetAll<Accounts>("select AccountName,AccountCode from Accounts a inner join HREmployee h on a.ID=h.EmpID where AccCategory=(select ID from AccountCategoryMast where Description='STAFF') and BranchID=@BranchID and h.Status='Active'", key, dbPara, commandType: CommandType.Text));
            return await Staff;
        }
        //public async Task<List<dtStudentRegister>> GetParent(int? BranchID, string key)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("@BranchID", BranchID, DbType.String);
        //    var Parent = Task.FromResult(_dapperManager.GetAll<dtStudentRegister>("select a.ID AccountID,a.AccountCode,a.AccountName,pm.PerMobile as Mobile from accounts a inner join School_ParentMaster pm on a.ID=pm.AccountID where a.BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
        //    return await Parent;
        //}

        public async Task<List<dtoStudentRegisterDefault>> GetParent(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Parent = Task.FromResult(_dapperManager.GetAll<dtoStudentRegisterDefault>("select a.ID AccountID,a.AccountCode,a.AccountName,pm.PerMobile as Mobile from accounts a inner join School_ParentMaster pm on a.ID=pm.AccountID where a.BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return await Parent;
        }

        public async Task<List<HrtransportationMast>> GetBusDetails(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var BusDetails = Task.FromResult(_dapperManager.GetAll<HrtransportationMast>("SELECT VehicleNo,VehicleName,Route FROM HRTransportationMast where Status='Active' ORDER BY VehicleNo", key, dbPara, commandType: CommandType.Text));
            return await BusDetails;
        }

        public Task<string> GetPLevel(string key)
        {
            var dbPara = new DynamicParameters();
            //var PLevel = Task.FromResult(_dapperManager.Get<string>("Select ParentLevel  from Accounts where AccountName='Students'", key, dbPara, commandType: CommandType.Text));
            var PLevel = Task.FromResult(_dapperManager.Get<string>("Select ParentLevel from Accounts where ID=(Select AccID from UniqueAccounts where Keyword='STUDENT')", key, dbPara, commandType: CommandType.Text));
            return PLevel;
        }

        public async Task<string> GetPLevelID(string key)
        {
            var dbPara = new DynamicParameters();
            //var PLevelID = Task.FromResult(_dapperManager.Get<string>("Select ID from Accounts where AccountName='Students'", dbPara, Con, commandType: CommandType.Text));
            var PLevelID = Task.FromResult(_dapperManager.Get<string>("Select AccID from UniqueAccounts where Keyword='STUDENT'", key, dbPara, commandType: CommandType.Text));
            return await PLevelID;
        }

        public async Task<string> GetAccountGroup(int PID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@PID", PID, DbType.String);
            var AccountGroup = Task.FromResult(_dapperManager.Get<string>("Select AccountGroup from Accounts where ID='" + PID + "'", key, dbPara, commandType: CommandType.Text));
            return await AccountGroup;
        }

        public async Task<string> GetSubGroup(int PID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@PID", PID, DbType.String);
            var SubGroup = Task.FromResult(_dapperManager.Get<string>("Select SubGroup from Accounts where ID='" + PID + "'", key, dbPara, commandType: CommandType.Text));
            return await SubGroup;
        }

        public async Task<string> GetAccCategory(int PID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@PID", PID, DbType.String);
            //var AccCategory = Task.FromResult(_dapperManager.Get<string>("Select AccCategory from Accounts where Parent='" + PID + "'", dbPara, Con, commandType: CommandType.Text));
            var AccCategory = Task.FromResult(_dapperManager.Get<string>("Select ID from AccountCategoryMast where Description='PARENT'", key, dbPara, commandType: CommandType.Text));
            return await AccCategory;
        }

        public async Task<string> GetShowChild(int PID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@PID", PID, DbType.String);
            var ShowChild = Task.FromResult(_dapperManager.Get<string>("Select ShowChild from Accounts where ID='" + PID + "'", key, dbPara, commandType: CommandType.Text));
            return await ShowChild;
        }

        public async Task<string> GetAccCategoryMast(string key)
        {
            var dbPara = new DynamicParameters();
            var AccCategoryMast = Task.FromResult(_dapperManager.Get<string>("Select ID from AccountCategoryMast where Description='STUDENT'", key, dbPara, commandType: CommandType.Text));
            return await AccCategoryMast;
        }

        public async Task<string> GetAbbr(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var Abbr = Task.FromResult(_dapperManager.Get<string>("Select Abbr from Company where ID='" + BranchID + "'", key, dbPara, commandType: CommandType.Text));
            return await Abbr;
        }

        public Task<string> GetNextNo(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var code = Task.FromResult(_dapperManager.Get<string>("Select cast([dbo].[SchoolNextStudentCodeBranchWise](@BranchID) as nvarchar(100))", key, dbPara, commandType: CommandType.Text));
            return code;
        }

        public Task<string> GetSExistNo(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("Criteria", "GetNextStudentCode", DbType.String);
            //var code = Task.FromResult(_dapperManager.Get<string>("Select Top 1 code+1 From(select accountcode,SUBSTRING(accountcode,1,ISNULL(NULLIF(PATINDEX('%[^A-Za-'']%',LTRIM(RTRIM(accountcode))),0)-1,LEN(accountcode)))AS Prefix,SUBSTRING(accountcode,ISNULL(NULLIF(PATINDEX('%[^A-Za-'']%',LTRIM(RTRIM(accountcode))),0),LEN(accountcode)),LEN(accountcode))as Code	from accounts INNER JOIN accountcategorymast ON accounts.ACCCATEGORY=accountcategorymast.ID where accountcategorymast.description='STUDENT' and voucherentry='true' and branchid='" + BranchID + "' )T ORDER BY CAST(code as BIGINT) DESC ", dbPara, Con, commandType: CommandType.Text));
            var code = Task.FromResult(_dapperManager.Get<string>("Col_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            //var code = Task.FromResult(_dapperManager.Get<string>("Select ([dbo].[SchoolNextStudentCode]())", dbPara, Con, commandType: CommandType.Text));
            return code;
        }

        public Task<string> GetParentNextNo(int BranchID, string Scode, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Scode", Scode, DbType.String);
            var code = Task.FromResult(_dapperManager.Get<string>("Select cast([dbo].[SchoolNextParentCodeBranchWise](@BranchID,@Scode) as nvarchar(100))", key, dbPara, commandType: CommandType.Text));
            return code;
        }

        public Task<string> GetStaffID(int BranchID, string Code, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Code", Code, DbType.String);
            var code = Task.FromResult(_dapperManager.Get<string>("Select * from Accounts where AccountCode=@Code ", key, dbPara, commandType: CommandType.Text));
            return code;
        }

        public Task<string> GetSchool(string key)
        {
            var dbPara = new DynamicParameters();
            var School = Task.FromResult(_dapperManager.Get<string>("Select Value from Settings where Category= 'SchoolPortalFor'", key, dbPara, commandType: CommandType.Text));
            return School;
        }

        public Task<string> GetCompany(int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Company = Task.FromResult(_dapperManager.Get<string>("Select CompanyCode from Company where ID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return Company;
        }

        public Task<string> GetExistStudent(string Scode, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Code", Scode, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var code = Task.FromResult(_dapperManager.Get<string>("Select AccountCode from Accounts where AccountCode=@Code and BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return code;
        }

        public Task<string> GetExistSyncStudent(string Scode, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Code", Scode, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var code = Task.FromResult(_dapperManager.Get<string>("Select Memo from Col_Students where Memo=@Code ", key, dbPara, commandType: CommandType.Text));
            return code;
        }

        public Task<string> GetExistParentID(string Pcode, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Code", Pcode, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var code = Task.FromResult(_dapperManager.Get<string>("Select ID from Accounts where AccountCode=@Code and BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return code;
        }

        public Task<string> GetTeacherName(string Class, string Division, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@Division", Division, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("Criteria", "GetTeacherName", DbType.String);
            var Teacher = Task.FromResult(_dapperManager.Get<string>("Col_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return Teacher;
        }

        public Task<string> GetSMSTemplate(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Company = Task.FromResult(_dapperManager.Get<string>("Select Description from Col_SMSTemplate where Template='FeeBalanceSMS'", key, dbPara, commandType: CommandType.Text));
            return Company;
        }


        public async Task<List<dtCompany>> GetCompanyDetails(long BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@Criteria", "Company Details", DbType.String);
            var Company = Task.FromResult(_dapperManager.GetAll<dtCompany>("Receipt_PrintSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Company;
        }

        public async Task<List<object>> GetCombanyLogo(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("Criteria", "Company Details", DbType.String);
            var Logo = Task.FromResult(_dapperManager.GetAll<object>
                               ("[dbo].[Receipt_PrintSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Logo;
        }
        public Task<string> DocUrl(string Path, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Path", Path, DbType.String);
            var DocPath = Task.FromResult(_dapperManager.Get<string>("Select Value from Settings where Category=@Path", key, dbPara, commandType: CommandType.Text));
            return DocPath;
        }

        public Task<string> GetMailType(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Criteria", "GetMailType", DbType.String);
            var MailType = Task.FromResult(_dapperManager.Get<string>("[Col_StudentCommonSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return MailType;
        }

        public async Task<List<dtCompany>> GetEmirates(string key)
        {
            var dbPara = new DynamicParameters();

            var Emirates = Task.FromResult(_dapperManager.GetAll<dtCompany>("select description from EmiratesMast", key, dbPara, commandType: CommandType.Text));
            return await Emirates;
        }

        public async Task<List<SchoolMailTemplate>> GetMailTemplate(string Type, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Type", Type, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Template = Task.FromResult(_dapperManager.GetAll<SchoolMailTemplate>("SELECT * FROM Col_MailTemplate where BranchID=@BranchID and Template=@Type", key, dbPara, commandType: CommandType.Text));
            return await Template;
        }

        public async Task<string> GetDefEmirate(int branchid, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@branchid", branchid, DbType.String);
            var DefEmirate = Task.FromResult(_dapperManager.Get<string>("Select VATPlace from Company where ID=@branchid", key, dbPara, commandType: CommandType.Text));
            return await DefEmirate;
        }

        public Task<List<dtoFormLabelSettings>> GetFormLabels(string FormName, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@FormName", FormName, DbType.String);
            var LabelList = Task.FromResult(_dapperManager.GetAll<dtoFormLabelSettings>("FormLabelSettingsSP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return (LabelList);
        }
    }
}
