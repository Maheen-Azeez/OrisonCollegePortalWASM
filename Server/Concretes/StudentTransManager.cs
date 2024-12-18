using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes
{
    public class StudentTransManager : IStudentTransManager
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public StudentTransManager(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;


        }
        public async Task<long> Insert(int id, Student student, IDbConnection db, IDbTransaction tran)
        {
            try
            {

                long newID;

                var dbPara = new DynamicParameters();

                dbPara.Add("Criteria", "Insert_Student_Tran", DbType.String);
                dbPara.Add("AccountId", id, DbType.String);
                dbPara.Add("branchid", student.BranchId, DbType.String);
                dbPara.Add("AcademicYear", student.AcademicYear, DbType.String);
                dbPara.Add("Status", student.Status, DbType.String);
                dbPara.Add("ProgrammeCode", student.ProgrammeCode, DbType.String);
                dbPara.Add("ProgrammeYear", student.ProgrammeYear, DbType.String);
                //dbPara.Add("EnrollmentDate", student.EnrollmentDate, DbType.String);
                dbPara.Add("EnrollmentDate", student.EnrollmentDate?.ToString("MM/dd/yyyy"), DbType.String);
                dbPara.Add("LevelCode", student.Level, DbType.String);
                dbPara.Add("ModeOfStudyCode", student.Modeofstudy, DbType.String);
                dbPara.Add("University", student.University, DbType.String);
                dbPara.Add("EnrollmentStatus", student.EnrollmentStatus, DbType.String);
                dbPara.Add("Subjects", student.Subjects, DbType.String);
                dbPara.Add("OptionalSubject", student.OptSubjects, DbType.String);
                dbPara.Add("SecondLanguage", student.SecondLanguage, DbType.String);
                dbPara.Add("Qualification", student.Qualification, DbType.String);
                dbPara.Add("AttendedUniversity", student.Attendeduniversity, DbType.String);
                dbPara.Add("AttendedSchool", student.Attendedschool, DbType.String);
                dbPara.Add("Straem", student.Stream, DbType.String);
                dbPara.Add("Photo", student.Photo, DbType.Binary);
                dbPara.Add("BusNo", student.AllotedBusNo, DbType.String);
                dbPara.Add("Area", student.Area, DbType.String);
                dbPara.Add("Emirate", student.Emirate, DbType.String);
                dbPara.Add("PickupPoint", student.PickupPoint, DbType.String);
                dbPara.Add("DropoffPoint", student.DropOffPoint, DbType.String);
                dbPara.Add("BuildingName", student.BuildingName, DbType.String);
                dbPara.Add("FlatNo", student.FlatNo, DbType.String);
                dbPara.Add("SubStatus", student.SubStatus, DbType.String);
                dbPara.Add("MobileNo1", student.MobileNo1, DbType.String);
                dbPara.Add("MobileNo2", student.MobileNo2, DbType.String);
                dbPara.Add("StreetName", student.StreetName, DbType.String);
                newID = _dapperManager.Insert("[Col_StudentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

                return newID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(Student student, IDbConnection db, IDbTransaction tran)
        {
            try
            {


                var dbPara = new DynamicParameters();

                dbPara.Add("Criteria", "Update_Student_Tran", DbType.String);
                dbPara.Add("id", student.AccountId, DbType.String);
                dbPara.Add("branchid", student.BranchId, DbType.String);
                dbPara.Add("Status", student.Status, DbType.String);
                dbPara.Add("ProgrammeCode", student.ProgrammeCode, DbType.String);
                dbPara.Add("ProgrammeYear", student.ProgrammeYear, DbType.String);
                // dbPara.Add("EnrollmentDate", student.EnrollmentDate, DbType.String);
                dbPara.Add("EnrollmentDate", student.EnrollmentDate?.ToString("MM/dd/yyyy"), DbType.String);
                dbPara.Add("LevelCode", student.Level, DbType.String);
                dbPara.Add("ModeOfStudyCode", student.Modeofstudy, DbType.String);
                dbPara.Add("University", student.University, DbType.String);
                dbPara.Add("EnrollmentStatus", student.EnrollmentStatus, DbType.String);
                dbPara.Add("Subjects", student.Subjects, DbType.String);
                dbPara.Add("OptionalSubject", student.OptSubjects, DbType.String);
                dbPara.Add("SecondLanguage", student.SecondLanguage, DbType.String);
                dbPara.Add("Qualification", student.Qualification, DbType.String);
                dbPara.Add("AttendedUniversity", student.Attendeduniversity, DbType.String);
                dbPara.Add("AttendedSchool", student.Attendedschool, DbType.String);
                dbPara.Add("Straem", student.Stream, DbType.String);
                dbPara.Add("Photo", student.Photo, DbType.Binary);
                dbPara.Add("BusNo", student.AllotedBusNo, DbType.String);
                dbPara.Add("Area", student.Area, DbType.String);
                dbPara.Add("Emirate", student.Emirate, DbType.String);
                dbPara.Add("PickupPoint", student.PickupPoint, DbType.String);
                dbPara.Add("DropoffPoint", student.DropOffPoint, DbType.String);
                dbPara.Add("BuildingName", student.BuildingName, DbType.String);
                dbPara.Add("FlatNo", student.FlatNo, DbType.String);
                dbPara.Add("SubStatus", student.SubStatus, DbType.String);
                dbPara.Add("MobileNo1", student.MobileNo1, DbType.String);
                dbPara.Add("MobileNo2", student.MobileNo2, DbType.String);
                dbPara.Add("StreetName", student.StreetName, DbType.String);
                _dapperManager.UpdateTable("[Col_StudentSP]", dbPara, db, tran, commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
