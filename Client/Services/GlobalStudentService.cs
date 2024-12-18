  using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Client.Services
{
    public class GlobalStudentService
    {
        public List<dtoStudentRegisterDefault> GlobalStudentList { get; set; } = new List<dtoStudentRegisterDefault>();
        public bool flagStudentRegRefreshed;
        public List<dtoStudentRegisterDefault> GlobalStudentListOthers { get; set; } = new List<dtoStudentRegisterDefault>();
        public bool flagStudentReceiptRefreshed;
        public List<dtoStudentRegisterDefault> GlobalParentName { get; set; } = new List<dtoStudentRegisterDefault>();
    }
}
