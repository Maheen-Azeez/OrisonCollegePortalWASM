using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Shared.Entities.Finance;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes.Finance
{
    public class ParentEntry : IParentEntry
    {
        private readonly IDapperManager _dapperManager;
        private readonly IConfiguration _config;

        public ParentEntry(IDapperManager dapperManager, IConfiguration config)
        {
            this._dapperManager = dapperManager;
            _config = config;
        }

        public async Task<int> CreateParent(SchoolParentMaster ParentEntry, IDbConnection db, IDbTransaction tran)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccountId", ParentEntry.AccountId, DbType.Int64);
            dbPara.Add("IsGuardian", ParentEntry.IsGuardian, DbType.String);
            dbPara.Add("Address1", ParentEntry.Address1, DbType.String);
            dbPara.Add("PerAddress1", ParentEntry.PerAddress1, DbType.String);
            dbPara.Add("Pobox", ParentEntry.Pobox, DbType.String);
            dbPara.Add("StreetName", ParentEntry.StreetName, DbType.String);
            dbPara.Add("Company", ParentEntry.Company, DbType.String);
            dbPara.Add("Profession", ParentEntry.Profession, DbType.String);
            dbPara.Add("PlaceOfWork", ParentEntry.PlaceOfWork, DbType.String);
            dbPara.Add("GuardianRemarks", ParentEntry.GuardianRemarks, DbType.String);
            dbPara.Add("Qualification", ParentEntry.Qualification, DbType.String);
            dbPara.Add("Muncipality", ParentEntry.Muncipality, DbType.String);
            dbPara.Add("ParentType", ParentEntry.ParentType, DbType.String);
            dbPara.Add("ParentNationality", ParentEntry.ParentNationality, DbType.String);
            dbPara.Add("PerTelOff", ParentEntry.PerTelOff, DbType.String);
            dbPara.Add("PerTel", ParentEntry.PerTel, DbType.String);
            dbPara.Add("PerMobile", ParentEntry.PerMobile, DbType.String);
            dbPara.Add("PerMobile2", ParentEntry.PerMobile2, DbType.String);
            dbPara.Add("SmsNumber", ParentEntry.SmsNumber, DbType.String);
            dbPara.Add("PerEmail2", ParentEntry.PerEmail2, DbType.String);
            dbPara.Add("Fax", ParentEntry.Fax, DbType.String);
            dbPara.Add("Email", ParentEntry.Email, DbType.String);
            dbPara.Add("Emirates", ParentEntry.Emirates, DbType.String);
            dbPara.Add("SecondRelation", ParentEntry.SecondRelation, DbType.String);
            dbPara.Add("Mother", ParentEntry.Mother, DbType.String);
            dbPara.Add("Address3", ParentEntry.Address3, DbType.String);
            dbPara.Add("MotherTelOff", ParentEntry.MotherTelOff, DbType.String);
            dbPara.Add("MotherMobile", ParentEntry.MotherMobile, DbType.String);
            dbPara.Add("MotherMobile2", ParentEntry.MotherMobile2, DbType.String);
            dbPara.Add("MotherEmail", ParentEntry.MotherEmail, DbType.String);
            dbPara.Add("Country", ParentEntry.Country, DbType.String);
            dbPara.Add("City", ParentEntry.City, DbType.String);
            dbPara.Add("PerPobox", ParentEntry.PerPobox, DbType.String);
            dbPara.Add("MotherEmail2", ParentEntry.MotherEmail2, DbType.String);
            dbPara.Add("MotherProfession", ParentEntry.MotherProfession, DbType.String);
            dbPara.Add("MotherHomeTel", ParentEntry.MotherHomeTel, DbType.String);
            dbPara.Add("MotherWorkingPlace", ParentEntry.MotherWorkingPlace, DbType.String);
            dbPara.Add("MotherCompany", ParentEntry.MotherCompany, DbType.String);
            dbPara.Add("RelationContacts", ParentEntry.RelationContacts, DbType.String);
            dbPara.Add("MotherQualification", ParentEntry.MotherQualification, DbType.String);
            dbPara.Add("MotherNationality", ParentEntry.MotherNationality, DbType.String);
            dbPara.Add("Guardian", ParentEntry.Guardian, DbType.String);
            dbPara.Add("PermMobile", ParentEntry.PermMobile, DbType.String);
            dbPara.Add("TelOff", ParentEntry.TelOff, DbType.String);
            dbPara.Add("Mobile", ParentEntry.Mobile, DbType.String);
            dbPara.Add("GuardianRelation", ParentEntry.GuardianRelation, DbType.String);
            dbPara.Add("PerAddress2", ParentEntry.PerAddress2, DbType.String);
            dbPara.Add("PerCity", ParentEntry.PerCity, DbType.String);
            dbPara.Add("PerPhone", ParentEntry.PerPhone, DbType.String);
            dbPara.Add("ThirdPerEmiratesid", ParentEntry.ThirdPerEmiratesid, DbType.String);
            dbPara.Add("PerCountry", ParentEntry.PerCountry, DbType.String);
            dbPara.Add("PerState", ParentEntry.PerState, DbType.String);
            dbPara.Add("SpeakEnglish", ParentEntry.SpeakEnglish, DbType.Boolean);
            dbPara.Add("SpeakEnglishMother", ParentEntry.SpeakEnglishMother, DbType.Boolean);
            dbPara.Add("StaffParent", ParentEntry.StaffParent, DbType.Int64);
            dbPara.Add("FatherPhoto", ParentEntry.FatherPhoto, DbType.Binary);
            dbPara.Add("MotherPhoto", ParentEntry.MotherPhoto, DbType.Binary);
            dbPara.Add("ThirdContactPhoto", ParentEntry.ThirdContactPhoto, DbType.Binary);
            dbPara.Add("WhatsAppNo", ParentEntry.WhatsAppNo, DbType.String);
            //dbPara.Add("PrimaryContact", ParentEntry.PrimaryContact, DbType.String);
            dbPara.Add("ParentMDate", ParentEntry.ParentMDate, DbType.DateTime);
            dbPara.Add("InvoiceAgainst", ParentEntry.InvoiceAgainst, DbType.String);
            dbPara.Add("Criteria", "InsertParent", DbType.String);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Insert("z", dbPara, db, tran, commandType: CommandType.StoredProcedure));
            return newID;
        }

        public async Task<int> UpdateParent(SchoolParentMaster ParentEntry, IDbConnection db, IDbTransaction tran, string Key)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("AccountId", ParentEntry.AccountId, DbType.Int64);
            dbPara.Add("IsGuardian", ParentEntry.IsGuardian, DbType.String);
            dbPara.Add("Address1", ParentEntry.Address1, DbType.String);
            dbPara.Add("PerAddress1", ParentEntry.PerAddress1, DbType.String);
            dbPara.Add("Pobox", ParentEntry.Pobox, DbType.String);
            dbPara.Add("StreetName", ParentEntry.StreetName, DbType.String);
            dbPara.Add("Company", ParentEntry.Company, DbType.String);
            dbPara.Add("Profession", ParentEntry.Profession, DbType.String);
            dbPara.Add("PlaceOfWork", ParentEntry.PlaceOfWork, DbType.String);
            dbPara.Add("GuardianRemarks", ParentEntry.GuardianRemarks, DbType.String);
            dbPara.Add("Qualification", ParentEntry.Qualification, DbType.String);
            dbPara.Add("Muncipality", ParentEntry.Muncipality, DbType.String);
            dbPara.Add("ParentType", ParentEntry.ParentType, DbType.String);
            dbPara.Add("ParentNationality", ParentEntry.ParentNationality, DbType.String);
            dbPara.Add("PerTelOff", ParentEntry.PerTelOff, DbType.String);
            dbPara.Add("PerTel", ParentEntry.PerTel, DbType.String);
            dbPara.Add("PerMobile", ParentEntry.PerMobile, DbType.String);
            dbPara.Add("PerMobile2", ParentEntry.PerMobile2, DbType.String);
            dbPara.Add("SmsNumber", ParentEntry.SmsNumber, DbType.String);
            dbPara.Add("PerEmail2", ParentEntry.PerEmail2, DbType.String);
            dbPara.Add("Fax", ParentEntry.Fax, DbType.String);
            dbPara.Add("Email", ParentEntry.Email, DbType.String);
            dbPara.Add("Emirates", ParentEntry.Emirates, DbType.String);
            dbPara.Add("SecondRelation", ParentEntry.SecondRelation, DbType.String);
            dbPara.Add("Mother", ParentEntry.Mother, DbType.String);
            dbPara.Add("Address3", ParentEntry.Address3, DbType.String);
            dbPara.Add("MotherTelOff", ParentEntry.MotherTelOff, DbType.String);
            dbPara.Add("MotherMobile", ParentEntry.MotherMobile, DbType.String);
            dbPara.Add("MotherMobile2", ParentEntry.MotherMobile2, DbType.String);
            dbPara.Add("MotherEmail", ParentEntry.MotherEmail, DbType.String);
            dbPara.Add("Country", ParentEntry.Country, DbType.String);
            dbPara.Add("City", ParentEntry.City, DbType.String);
            dbPara.Add("PerPobox", ParentEntry.PerPobox, DbType.String);
            dbPara.Add("MotherEmail2", ParentEntry.MotherEmail2, DbType.String);
            dbPara.Add("MotherProfession", ParentEntry.MotherProfession, DbType.String);
            dbPara.Add("MotherHomeTel", ParentEntry.MotherHomeTel, DbType.String);
            dbPara.Add("MotherWorkingPlace", ParentEntry.MotherWorkingPlace, DbType.String);
            dbPara.Add("MotherCompany", ParentEntry.MotherCompany, DbType.String);
            dbPara.Add("RelationContacts", ParentEntry.RelationContacts, DbType.String);
            dbPara.Add("MotherQualification", ParentEntry.MotherQualification, DbType.String);
            dbPara.Add("MotherNationality", ParentEntry.MotherNationality, DbType.String);
            dbPara.Add("Guardian", ParentEntry.Guardian, DbType.String);
            dbPara.Add("PermMobile", ParentEntry.PermMobile, DbType.String);
            dbPara.Add("TelOff", ParentEntry.TelOff, DbType.String);
            dbPara.Add("Mobile", ParentEntry.Mobile, DbType.String);
            dbPara.Add("GuardianRelation", ParentEntry.GuardianRelation, DbType.String);
            dbPara.Add("PerAddress2", ParentEntry.PerAddress2, DbType.String);
            dbPara.Add("PerCity", ParentEntry.PerCity, DbType.String);
            dbPara.Add("PerPhone", ParentEntry.PerPhone, DbType.String);
            dbPara.Add("ThirdPerEmiratesid", ParentEntry.ThirdPerEmiratesid, DbType.String);
            dbPara.Add("PerCountry", ParentEntry.PerCountry, DbType.String);
            dbPara.Add("PerState", ParentEntry.PerState, DbType.String);
            //dbPara.Add("GuardianRemarks", ParentEntry.GuardianRemarks, DbType.String);
            dbPara.Add("SpeakEnglish", ParentEntry.SpeakEnglish, DbType.Boolean);
            dbPara.Add("SpeakEnglishMother", ParentEntry.SpeakEnglishMother, DbType.Boolean);
            dbPara.Add("StaffParent", ParentEntry.StaffParent, DbType.Int64);
            dbPara.Add("FatherPhoto", ParentEntry.FatherPhoto, DbType.Binary);
            dbPara.Add("MotherPhoto", ParentEntry.MotherPhoto, DbType.Binary);
            dbPara.Add("ThirdContactPhoto", ParentEntry.ThirdContactPhoto, DbType.Binary);
            dbPara.Add("WhatsAppNo", ParentEntry.WhatsAppNo, DbType.String);
            //dbPara.Add("PrimaryContact", ParentEntry.PrimaryContact, DbType.String);
            dbPara.Add("ParentMDate", ParentEntry.ParentMDate, DbType.DateTime);
            dbPara.Add("InvoiceAgainst", ParentEntry.InvoiceAgainst, DbType.String);
            dbPara.Add("Criteria", "UpdateParent", DbType.String);
            dbPara.Add("AccID", ParentEntry.Id, DbType.Int64);
            dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

            int newID = Convert.ToInt32(_dapperManager.Update("Parent_EntrySP", Key, dbPara, commandType: CommandType.StoredProcedure));
            return newID;
        }

    }
}
