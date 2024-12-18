using Dapper;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Shared.Entities;
using System.Data;

namespace OrisonCollegePortal.Server.Concretes
{
    public class FeeManager : IFeeManager
    {
        private readonly IDapperManager _dapperManager;
        public FeeManager(IDapperManager dapperManager)
        {
            _dapperManager = dapperManager;
        }

        public async Task<long> InsertPostedFee(FeeMaster feeMaster, string Key)
        {
            try
            {
                long newID = 0;
                var dbPara = new DynamicParameters();
                dbPara.Add("FeeSchedule", feeMaster.FeeSchedule, DbType.String);
                dbPara.Add("Type", feeMaster.Type, DbType.String);
                dbPara.Add("Amount", feeMaster.Amount, DbType.Decimal);
                dbPara.Add("Discount", feeMaster.Discount, DbType.String);
                dbPara.Add("StartDate", feeMaster.StartDate, DbType.DateTime);
                dbPara.Add("EndDate", feeMaster.EndDate, DbType.DateTime);
                dbPara.Add("AccountId", feeMaster.AccountId, DbType.Int32);
                dbPara.Add("VID", feeMaster.VID, DbType.Int64);
                dbPara.Add("Criteria", "InsertPostedFee", DbType.String);
                dbPara.Add("NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                newID = _dapperManager.Insert<long>("[Col_FeeMaster_SP]",Key, dbPara, commandType: CommandType.StoredProcedure);
                return newID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<FeeMaster> GetAcademicYear(string Key)
        {
            try
            {
                FeeMaster no = new FeeMaster();
                //string status = "current";
                no = _dapperManager.Get<FeeMaster>("select distinct AcademicYear from Col_AcademicYear where Status='current'",Key, null, commandType: CommandType.Text);
                return no;
            }
            catch (Exception E)
            {

                throw E;
            }
        }

        public async Task<List<FeeMaster>> GetFeeSchedule(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Criteria", "GetFeeSchedule", DbType.String);
            dbPara.Add("BranchId", BranchID, DbType.Int32);
            try
            {
                var no = Task.FromResult(_dapperManager.GetAll<FeeMaster>("Col_FeeMaster_SP",Key, dbPara,  commandType: CommandType.StoredProcedure));
                return await no;
            }
            catch (Exception E)
            {

                throw E;
            }

        }

        public async Task<List<FeeMaster>> GetPostedFee(int AccountId, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Criteria", "GetPostedFee", DbType.String);
            dbPara.Add("AccountId", AccountId, DbType.String);

            try
            {
                var no = Task.FromResult(_dapperManager.GetAll<FeeMaster>("Col_FeeMaster_SP", Key, dbPara, commandType: CommandType.StoredProcedure));
                return await no;
            }
            catch (Exception E)
            {

                throw E;
            }
        }

        public async Task<bool> DeleteDepostedRecords(int Id, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Criteria", "DeleteDepostedRecords", DbType.String);
                dbPara.Add("ID", Id, DbType.Int32);
                await Task.FromResult(_dapperManager.Execute("Col_FeeMaster_SP", Key, dbPara, commandType: CommandType.StoredProcedure));
                return true;
            }
            catch (Exception E)
            {

                throw E;
            }
        }

        public async Task<List<MastDesignation>> BindComboBox(string type, string Key)
        {
            try
            {


                var dbPara = new DynamicParameters();


                dbPara.Add("Criteria", type, DbType.String);

                var no = Task.FromResult(_dapperManager.GetAll<MastDesignation>("[Col_ComboBoxStudentSP]", Key, dbPara, commandType: CommandType.StoredProcedure));

                return await no;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> FeePostChecking(FeeMaster feeMaster, string Key)
        {
            try
            {
                var dbPara = new DynamicParameters();

                dbPara.Add("AccountId", feeMaster.AccountId, DbType.String);
                dbPara.Add("Vtype", feeMaster.vtype, DbType.String);
                dbPara.Add("Remark", feeMaster.FeeSchedule, DbType.String);
                dbPara.Add("Criteria", "GetPostedRecords", DbType.String);
                var feepost = Task.FromResult(_dapperManager.Get<int>("[Col_FeeMaster_SP]",Key, dbPara, commandType: CommandType.StoredProcedure));

                return feepost;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
