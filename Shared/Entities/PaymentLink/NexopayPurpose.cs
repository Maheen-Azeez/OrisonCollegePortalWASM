namespace OrisonCollegePortal.Shared.Entities.PaymentLink
{
    public class NexopayPurpose
    {
        public int ID { get; set; }
        public string? SchoolCode { get; set; }
        public string? Purpose { get; set; }
        public decimal Amount { get; set; }
        public bool Locked { get; set; }
    }
}
