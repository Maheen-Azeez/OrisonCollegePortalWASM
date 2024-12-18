using System.ComponentModel.DataAnnotations;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtDiscountSchedule
    {
        [Key]
        public string? Schedule  { get; set; }
        public string? Type { get; set; }
        public DateTime StartDate { get; set; }
        public int Discount  { get; set; }
        public string? Description { get; set; }
        public string? DiscountType { get; set; }
        public string? Child { get; set; }
        public int BranchId { get; set; }
        public int PostTo { get; set; }       
    }
}
