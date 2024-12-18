using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolParentDocImage
    {
        public int Id { get; set; }
        public int? SlNo { get; set; }
        public string? Type { get; set; }
        public int DocId { get; set; }
        public string? FileName { get; set; }
        public string? Path { get; set; }
        public byte[]? DocFile { get; set; }
    }
}
