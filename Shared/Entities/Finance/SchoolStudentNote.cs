using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class SchoolStudentNote
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public DateTime? NoteDate { get; set; }
        public DateTime? Mdate { get; set; }
        public string? Muser { get; set; }
        public string? TeacherName { get; set; }
        public string? Subject { get; set; }
        public string? NatureOfOffense { get; set; }
        public string? ActionTaken { get; set; }
        public string? OffenseLocation { get; set; }
    }
}
