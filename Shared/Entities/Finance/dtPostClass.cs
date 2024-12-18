namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtPostClass
    {
        public List<dtMassPost>? PostEnrty { get; set; }
        public dtStudentParam? ParamEnrty { get; set; }

        public List<dtBulkPost>? BulkPostEnrty { get; set; }

        public List<dtBulkPost>? BulkUnallocated { get; set; }
    }
}
