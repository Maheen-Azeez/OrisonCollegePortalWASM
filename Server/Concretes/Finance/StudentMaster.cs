using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.General;
using OrisonCollegePortal.Shared.Entities.Finance;
using SecurityService;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Security.Principal;
using OrisonCollegePortal.Shared.Entities;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class StudentMaster : IStudentMaster
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        private IStudentAccEntry _Acrepository;
        private IStudentEntry _Studentrepository;
        private IStudentTranEntry _StudentTranrepository;
        private IStudentArabicEntry _StudentArabicrepository;
        private IParentAccEntry _ParentAcrepository;
        private IParentEntry _Parentrepository;
        private IImageEntry _Imagerepository;
        private INoteEntry _Notesrepository;
        private IRelationEntry _Relationrepository;
        private readonly IDocumentsEntry _documentEntry;
        private readonly IDocumentImageEntry _docImageEntry;
        private IUserTrack _UserTrackrepository;

        public StudentMaster(IDapperManager dapperManager, IConfiguration config, IParentAccEntry ParentAcrepository, IParentEntry Parentrepository, IStudentAccEntry Acrepository, IStudentEntry Studentrepository, IStudentTranEntry StudentTranrepository, IStudentArabicEntry StudentArabicrepository, IImageEntry Imagerepository, INoteEntry Noterepository, IRelationEntry Relationrepository, IDocumentsEntry documentEntry, IDocumentImageEntry docImageEntry, IUserTrack UserTrackrepository)
        {
            this._dapperManager = dapperManager;
            _config = config;
            _ParentAcrepository = ParentAcrepository;
            _Parentrepository = Parentrepository;
            _Acrepository = Acrepository;
            _Studentrepository = Studentrepository;
            _StudentTranrepository = StudentTranrepository;
            _StudentArabicrepository = StudentArabicrepository;
            _Imagerepository = Imagerepository;
            _Notesrepository = Noterepository;
            _Relationrepository = Relationrepository;
            _documentEntry = documentEntry;
            _docImageEntry = docImageEntry;
            _UserTrackrepository = UserTrackrepository;
        }

        public async Task<List<dtStudentRegister>> GetStudentList(string AcademicYear, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("Criteria", "GetStudentSearchList", DbType.String);

            var StudentList = Task.FromResult(_dapperManager.GetAll<dtStudentRegister>("Col_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<List<dtoStudentRegisterDefault>> GetStudentListDefault(string AcademicYear, int? BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("Criteria", "GetStudentSearchList", DbType.String);

            var StudentList = Task.FromResult(_dapperManager.GetAll<dtoStudentRegisterDefault>("Col_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<List<dtStudentRegister>> GetStudentListByClass(string Class, string AcademicYear, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Class", Class, DbType.String);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("Criteria", "GetStudentSearchListByClass", DbType.String);

            var StudentList = Task.FromResult(_dapperManager.GetAll<dtStudentRegister>("Col_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<List<dtStudentRegister>> GetStudentListTeacher(string AcademicYear, int BranchID, int UserID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            dbPara.Add("@UserID", UserID, DbType.Int32);
            dbPara.Add("Criteria", "GetStudentSearchListOwnClass", DbType.String);

            var StudentList = Task.FromResult(_dapperManager.GetAll<dtStudentRegister>("Col_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public async Task<List<MastDesignation>> BindComboBox(string type, string key)
        {

            var dbPara = new DynamicParameters();
            dbPara.Add("@type", type, DbType.String);
            var Description = Task.FromResult(_dapperManager.GetAll<MastDesignation>("[COLStudent_BindDataSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Description;
        }

        public Task<string> BindSettingsValue(string Category, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Category", Category, DbType.String);
            var code = Task.FromResult(_dapperManager.Get<string>("[Student_BindSettingsSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return code;
        }

        public async Task<Accounts> GetDTAccount(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var Account = Task.FromResult(_dapperManager.Get<Accounts>("Select * from Accounts where ID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await Account;
        }

      
        public async Task<SchoolStudent> GetDTStudent(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var SchoolStudent = Task.FromResult(_dapperManager.Get<SchoolStudent>("Select * from Col_Students where AccountID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await SchoolStudent;
        }
        public async Task<SchoolStudentTran> GetDTStudentTrans(int AccountID, int BranchID, string AcademicYear, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            dbPara.Add("@AcademicYear", AcademicYear, DbType.String);
            var SchoolStudentTrans = Task.FromResult(_dapperManager.Get<SchoolStudentTran>("Select *,ProgrammeCode As Class,ProgrammeYear as Division,(SELECT Route FROM HRTransportationMast where BranchID=@BranchID and VehicleNo=(select AllotedBusNo from Col_StudentTrans where AccountID=@AccountID and AcademicYear=@AcademicYear))BusRoute from Col_StudentTrans where AccountID=@AccountID and AcademicYear=(select academicyear from Col_academicyear where AcademicYear=@AcademicYear and BranchID=@BranchID)", key, dbPara, commandType: CommandType.Text));
            return await SchoolStudentTrans;
        }
        public async Task<SchoolParentMaster> GetDTParent(int AccountID, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@AccountID", AccountID, DbType.Int32);
                var Parent = Task.FromResult(_dapperManager.Get<SchoolParentMaster>("Select * from Col_ParentMaster where AccountID=@AccountID", key, dbPara, commandType: CommandType.Text));
                return await Parent;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<SchoolStudentsArabic> GetDTStudentsArabic(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var StudentsArabic = Task.FromResult(_dapperManager.Get<SchoolStudentsArabic>("Select * from School_StudentsArabic where AccountID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await StudentsArabic;
        }
        public async Task<SchoolImage> GetDTStudentImage(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var StudentImage = Task.FromResult(_dapperManager.Get<SchoolImage>("select * from School_Images where StudentID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await StudentImage;
        }

        public async Task<List<SchoolDocument>> GetStudDocumentById(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var StudentDoc = Task.FromResult(_dapperManager.GetAll<SchoolDocument>("Select * from School_Documents where AccountID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await StudentDoc;
        }

        public async Task<SchoolDocument> GetDocumentByDocId(int DocID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@ID", DocID, DbType.Int32);
            var Doc = Task.FromResult(_dapperManager.Get<SchoolDocument>("Select * from School_Documents where ID=@ID", key, dbPara, commandType: CommandType.Text));
            return await Doc;
        }
        public async Task<List<SchoolParentDocument>> GetParentDocumentById(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var StudentDoc = Task.FromResult(_dapperManager.GetAll<SchoolParentDocument>("Select * from School_ParentDocuments where AccountID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await StudentDoc;
        }
        public async Task<SchoolParentDocument> GetParentDocumentByDocId(int DocID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@ID", DocID, DbType.Int32);
            var Doc = Task.FromResult(_dapperManager.Get<SchoolParentDocument>("Select * from School_ParentDocuments where ID=@ID", key, dbPara, commandType: CommandType.Text));
            return await Doc;
        }

        public async Task<List<SchoolAdditionalPayment>> GetAdditionalPayment(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var StudAdditionalPayment = Task.FromResult(_dapperManager.GetAll<SchoolAdditionalPayment>("select ID,FromDate,Activity,Repeat,Amount,SupEndDate,Posted from School_AdditionalPayment where AccountID=@AccountID and Type='AdditionalPayment'", key, dbPara, commandType: CommandType.Text));
            return await StudAdditionalPayment;
        }

        public async Task<List<SchoolAdditionalPayment>> GetAdditionalDiscount(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var StudAdditionalDiscount = Task.FromResult(_dapperManager.GetAll<SchoolAdditionalPayment>("select ID,FromDate,Activity,Repeat,Amount,SupEndDate,Posted from School_AdditionalPayment where AccountID=@AccountID and Type='AdditionalDiscount'", key, dbPara, commandType: CommandType.Text));
            return await StudAdditionalDiscount;
        }

        public async Task<List<SchoolFamilyDetail>> GetRelation(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var Relation = Task.FromResult(_dapperManager.GetAll<SchoolFamilyDetail>("Select ID,AccountId,Name,Relation,Address,Mobile,StudentId,ParentId,Rel,Gender,OfficePhone,Mobile2,Fax,Email,pobox,Emirate,FamilyId,WorkingPlace,Nationality,HomePhone,SpeakEnglish from School_FamilyDetails where AccountID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await Relation;
        }

        public async Task<List<SchoolStudentNote>> GetNotes(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            var Notes = Task.FromResult(_dapperManager.GetAll<SchoolStudentNote>("select ID,NoteDate,Category,Remarks,NatureOfOffense,ActionTaken,OffenseLocation,TeacherName,Subject from School_StudentNotes where AccountID=@AccountID", key, dbPara, commandType: CommandType.Text));
            return await Notes;
        }

        public async Task<List<dtStudentStatement>> GetStatement(string FromDate, string ToDate, int AccountID, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@DateFrom", FromDate, DbType.String);
            dbPara.Add("@DateUpto", ToDate, DbType.String);
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Statement = Task.FromResult(_dapperManager.GetAll<dtStudentStatement>("[AccountStmtStudentSP ORG]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Statement;
        }



        public async Task<SchoolAdditionalPayment> GetAdditionalDiscountbyid(int AccountID, int ID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            dbPara.Add("@ID", ID, DbType.Int32);

            var StudAdditionalDiscountS = Task.FromResult(_dapperManager.Get<SchoolAdditionalPayment>("select FromDate,Activity,Repeat,Amount,SupEndDate,Posted from School_AdditionalPayment where AccountID=@AccountID and ID=@ID and Type='AdditionalDiscount'", key, dbPara, commandType: CommandType.Text));
            return await StudAdditionalDiscountS;
        }
        public async Task<SchoolAdditionalPayment> GetAdditionalPaymentbyid(int AccountID, int ID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            dbPara.Add("@ID", ID, DbType.Int32);

            var StudAdditionalDiscountS = Task.FromResult(_dapperManager.Get<SchoolAdditionalPayment>("select FromDate,Activity,Repeat,Amount,SupEndDate,Posted from School_AdditionalPayment where AccountID=@AccountID and ID=@ID and Type='AdditionalPayment'", key, dbPara, commandType: CommandType.Text));
            return await StudAdditionalDiscountS;
        }



        public async Task<long> CreateNewStudent(dtMasterStudent student, string Key)
        {
            int newID, AccountID;
            //Key = Key.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Key, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    Accounts pac = student.ParentAccentry!;
                    newID = await _ParentAcrepository.CreateParentAc(pac, db, tran);

                    SchoolParentMaster p = student.Parententry!;
                    p.AccountId = newID;
                    newID = await _Parentrepository.CreateParent(p, db, tran);

                    Accounts ac = student.accentry!;
                    ac.Parent = p.AccountId;
                    newID = await _Acrepository.CreateStudentAc(ac, db, tran);

                    SchoolStudent ss = student.Studententry!;
                    ss.AccountId = newID;
                    newID = await _Studentrepository.CreateStudent(ss, db, tran);
                    AccountID = ss.AccountId;

                    SchoolStudentTran st = student.Studenttranentry!;
                    //st.AccountId = newID;
                    st.AccountId = ss.AccountId;
                    newID = await _StudentTranrepository.CreateStudentTran(st, db, tran);

                    SchoolStudentsArabic sa = student.Studentarabicentry!;
                    //sa.AccountId = newID;
                    sa.AccountId = ss.AccountId;
                    newID = await _StudentArabicrepository.CreateStudentArabic(sa, db, tran);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Account, P Account,Student,Student Tran,Parent - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID = AccountID;
        }

        public async Task<long> CreateNewStudentSibling(dtMasterStudent student, string Key)
        {
            int newID;
            //Key = Key.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Key, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    Accounts ac = student.accentry!;
                    newID = await _Acrepository.CreateStudentAc(ac, db, tran);

                    SchoolStudent ss = student.Studententry!;
                    ss.AccountId = newID;
                    newID = await _Studentrepository.CreateStudent(ss, db, tran);

                    SchoolStudentTran st = student.Studenttranentry!;
                    //st.AccountId = newID;
                    st.AccountId = ss.AccountId;
                    newID = await _StudentTranrepository.CreateStudentTran(st, db, tran);

                    SchoolStudentsArabic sa = student.Studentarabicentry!;
                    //sa.AccountId = newID;
                    sa.AccountId = ss.AccountId; ;
                    newID = await _StudentArabicrepository.CreateStudentArabic(sa, db, tran);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Account, P Account,Student,Student Tran,Parent - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }


        public async Task<long> UpdateStudent(dtMasterStudent student, string key)
        {
            long newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    Accounts pac = student.ParentAccentry!;
                    newID = await _ParentAcrepository.UpdateParentAc(pac, db, tran, key);

                    SchoolParentMaster p = student.Parententry!;
                    p.AccountId = Convert.ToInt32(newID);
                    newID = await _Parentrepository.UpdateParent(p, db, tran, key);

                    Accounts ac = student.accentry!;
                    newID = await _Acrepository.UpdateStudentAc(ac, db, tran, key);

                    SchoolStudent ss = student.Studententry!;
                    ss.AccountId = Convert.ToInt32(newID);
                    newID = await _Studentrepository.UpdateStudent(ss, db, tran, key);

                    SchoolStudentTran st = student.Studenttranentry!;
                    st.AccountId = Convert.ToInt32(newID);
                    newID = await _StudentTranrepository.UpdateStudentTran(st, db, tran, key);

                    SchoolStudentsArabic sa = student.Studentarabicentry!;
                    sa.AccountId = Convert.ToInt32(newID);
                    newID = await _StudentArabicrepository.UpdateStudentArabic(sa, db, tran, key);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Edit Student,StudentTran,Student - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 2;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> UpdateStudentOnly(dtMasterStudent student, string Key)
        {
            long newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolStudent ss = student.Studententry!;
                    //ss.AccountId = Convert.ToInt32(newID);
                    newID = await _Studentrepository.UpdateStudent(ss, db, tran, Key);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> CreateNewParent(dtMasterStudent student, string Key)
        {
            int newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    Accounts pac = student.ParentAccentry!;
                    newID = await _ParentAcrepository.CreateParentAc(pac, db, tran);

                    SchoolParentMaster p = student.Parententry!;
                    p.AccountId = newID;
                    newID = await _Parentrepository.CreateParent(p, db, tran);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "P Account,Parent - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }


        public async Task<long> CreateImage(dtMasterStudent student, string Key)
        {
            int newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolImage img = student.Imageentry!;
                    newID = await _Imagerepository.CreateImage(img, db, tran);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Save Student Image - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> UpdateImage(dtMasterStudent student, string Key)
        {
            long newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolImage img = student.Imageentry!;
                    newID = await _Imagerepository.UpdateImage(img, db, tran, Key);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Edit Image - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> CreateNotes(dtMasterStudent student, string Key)
        {
            int newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolStudentNote note = student.Notesentry!;
                    newID = await _Notesrepository.CreateNotes(note, db, tran);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Save Notes - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> UpdateNotes(dtMasterStudent student, string Key)
        {
            long newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolStudentNote note = student.Notesentry!;
                    newID = await _Notesrepository.UpdateNotes(note, db, tran, Key);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Edit Notes - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 2;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> DeleteNote(dtMasterStudent student, string Key)
        {
            int newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolStudentNote note = student.Notesentry!;
                    newID = await _Notesrepository.DeleteNote(note, db, tran, Key);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Delete Note - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 3;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> CreateRelation(dtMasterStudent student, string Key)
        {
            int newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolFamilyDetail relation = student.Relationentry!;
                    newID = await _Relationrepository.CreateRelation(relation, db, tran);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Save Relation - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> UpdateRelation(dtMasterStudent student, string Key)
        {
            long newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolFamilyDetail relation = student.Relationentry!;
                    newID = await _Relationrepository.UpdateRelation(relation, db, tran, Key);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Edit Relation - " + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 2;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> DeleteRelation(dtMasterStudent student, string Key)
        {
            int newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolFamilyDetail relation = student.Relationentry!;
                    newID = await _Relationrepository.DeleteRelation(relation, db, tran, Key);

                    DtoUserTrack user = student.UserTrack!;
                    user.Reason = "Delete Relation, ID -" + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 3;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> SaveDocument(dtMasterStudent Document, string Key)
        {
            long newID;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolDocument dc = Document.docmaster!;
                    newID = await _documentEntry.SaveDocument(dc, db, tran);
                    if (Document.docImage != null)
                    {
                        SchoolDocImage dimg = Document.docImage;
                        dimg.DocId = (int)newID;

                        string file = dimg.FileName!;
                        string[] files = file.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        foreach (string filename in files)
                        {
                            dimg.FileName = filename;

                            newID = await _docImageEntry.SaveDocumentImage(dimg, db, tran);
                        }
                    }

                    DtoUserTrack user = Document.UserTrack!;
                    user.Reason = "Save Document, DocID -" + newID;
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = await _UserTrackrepository.UserTrackUpdation(user, db, tran);


                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> UpdateDocument(dtMasterStudent Document, string Key)
        {
            long newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolDocument dc = Document.docmaster!;
                    newID = await _documentEntry.UpdateDocument(dc, db, tran);
                    if (Document.docImage != null)
                    {
                        SchoolDocImage dimg = Document.docImage;
                        dimg.DocId = (int)newID;

                        string file = dimg.FileName!;
                        string[] files = file.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        foreach (string filename in files)
                        {
                            dimg.FileName = filename;

                            newID = await _docImageEntry.UpdateDocumentImage(dimg, db, tran);
                        }
                    }

                    DtoUserTrack user = Document.UserTrack!;
                    user.Reason = "Edit Document, DocID -" + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 2;
                    user.RowId = 0;

                    newID = await _UserTrackrepository.UserTrackUpdation(user, db, tran);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> DeleteDocument(dtMasterStudent Document, string Key)
        {
            int newID;
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolDocument Doc = Document.docmaster!;
                    newID = Convert.ToInt32(await _documentEntry.DeleteDocument(Doc, db, tran, Key));

                    DtoUserTrack user = Document.UserTrack!;
                    user.Reason = "Delete Document, DocID -" + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 3;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public async Task<long> SaveParentDocument(dtMasterStudent Document, string Key)
        {
            long newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolParentDocument dc = Document.Parentdocmaster!;
                    newID = await _documentEntry.SaveParentDocument(dc, db, tran);
                    if (Document.ParentdocImage != null)
                    {
                        SchoolParentDocImage dimg = Document.ParentdocImage;
                        dimg.DocId = (int)newID;

                        string file = dimg.FileName!;
                        string[] files = file.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        foreach (string filename in files)
                        {
                            dimg.FileName = filename;

                            newID = await _docImageEntry.SaveParentDocumentImage(dimg, db, tran);
                        }
                    }

                    DtoUserTrack user = Document.UserTrack!;
                    user.Reason = "Save Document, DocID -" + newID;
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 1;
                    user.RowId = 0;

                    newID = await _UserTrackrepository.UserTrackUpdation(user, db, tran);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> UpdateParentDocument(dtMasterStudent Document, string Key)
        {
            long newID;
            //Con = Con.Replace(" ", "+");
            //using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(Con, "", true));
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolParentDocument dc = Document.Parentdocmaster!;
                    newID = await _documentEntry.UpdateParentDocument(dc, db, tran);
                    if (Document.ParentdocImage != null)
                    {
                        SchoolParentDocImage dimg = Document.ParentdocImage;
                        dimg.DocId = (int)newID;

                        string file = dimg.FileName!;
                        string[] files = file.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        foreach (string filename in files)
                        {
                            dimg.FileName = filename;

                            newID = await _docImageEntry.UpdateParentDocumentImage(dimg, db, tran);
                        }
                    }

                    DtoUserTrack user = Document.UserTrack!;
                    user.Reason = "Edit Document, DocID -" + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 2;
                    user.RowId = 0;

                    newID = await _UserTrackrepository.UserTrackUpdation(user, db, tran);

                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }

        public async Task<long> DeleteParentDocument(dtMasterStudent Document, string Key)
        {
            int newID;
            using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    SchoolParentDocument Doc = Document.Parentdocmaster!;
                    newID = Convert.ToInt32(await _documentEntry.DeleteParentDocument(Doc, db, tran, Key));

                    DtoUserTrack user = Document.UserTrack!;
                    user.Reason = "Delete Document, DocID -" + newID + "";
                    user.MachineName = WindowsIdentity.GetCurrent().Name.ToString() + " IP : " + GetLocalIPAddress();
                    user.ActionId = 3;
                    user.RowId = 0;

                    newID = Convert.ToInt32(await _UserTrackrepository.UserTrackUpdation(user, db, tran));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return newID;
        }

        public static string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }

        public Task<string> GetEnableTab(string Tab, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Tab", Tab, DbType.String);
            var School = Task.FromResult(_dapperManager.Get<string>("Select Value from Settings where Category= @Tab", key, dbPara, commandType: CommandType.Text));
            return School;
        }

        public async Task<long> ImportStudent(Accounts dt)
        {
            long newID;
            using IDbConnection db = new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString("DefaultConnection"), "", true));
            //using IDbConnection db = GetConnection(Key);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var dbPara = new DynamicParameters();
                    dbPara.Add("studentcode", dt.AccountCode, DbType.String);
                    dbPara.Add("BranchId", dt.BranchId, DbType.Int32);
                    //newID = _dapperManager.Insert("[School_syncinsertstudents]", dbPara, db, tran, commandType: CommandType.StoredProcedure);
                    newID = _dapperManager.Execute("School_syncinsertstudents", db.ToString()!, dbPara, commandType: CommandType.StoredProcedure);
                    //return newID;
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return newID;
        }


        public async Task<dtImportStudent> GetDTImportStudent(string Scode, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Code", Scode, DbType.String);
            dbPara.Add("BranchID", BranchID, DbType.Int32);
            var StudentList = Task.FromResult(_dapperManager.Get<dtImportStudent>("[SYNC_STUDENTINFO]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await StudentList;
        }

        public Task<string> GetAge(int AccountID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            dbPara.Add("Criteria", "GetStudentAge", DbType.String);
            var Teacher = Task.FromResult(_dapperManager.Get<string>("Col_StudentCommonSP", key, dbPara, commandType: CommandType.StoredProcedure));
            return Teacher;
        }

        public async Task<List<SchoolWebMenuSettings>?> EnableMenu(string Menu, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@type", Menu, DbType.String);
            dbPara.Add("Criteria", "GetMenuEnable", DbType.String);
            var Description = Task.FromResult(_dapperManager.GetAll<SchoolWebMenuSettings>("[Col_StudentCommonSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Description;
        }
        public async Task<List<DtoStudentReceiptStatement>> GetStatementReceipt(string FromDate, string ToDate, int AccountID, int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@DateFrom", FromDate, DbType.String);
            dbPara.Add("@DateUpto", ToDate, DbType.String);
            dbPara.Add("@AccountID", AccountID, DbType.Int32);
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Statement = Task.FromResult(_dapperManager.GetAll<DtoStudentReceiptStatement>("[AccountStmtStudentReceiptSP]", key, dbPara, commandType: CommandType.StoredProcedure));
            return await Statement;
        }
        public DbConnection GetConnection(string key)
        {
            Security security = new Security();
            return new SqlConnection(ClsEncrypt.Decrypt(_config.GetConnectionString(security.Decrypt(key)), "", true));
        }
    }
}
