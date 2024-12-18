using System;

namespace OrisonCollegePortal.Shared.Entities.General
{
    public class DtoUserTrack
    {
        public long? Id { get; set; }
        public int? UserId { get; set; }
        public string? TableName { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? Reason { get; set; }
        public int? ActionId { get; set; }
        public long? RowId { get; set; }
        public string? MachineName { get; set; }
        public string? ModuleName { get; set; }
        public string? Reference { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Vdate { get; set; }
        public int? AccountId { get; set; }
        public string? Partyname { get; set; }
        public string? Remarks { get; set; }
        public decimal? OldAmount { get; set; }
        public string? Version { get; set; }
        public decimal? NetAmount { get; set; }
        public string? AccountCode { get; set; }
        public string? vtypeAbbr { get; set; }
        public string? Company { get; set; }
        public string? VNO { get; set; }
    }
}
