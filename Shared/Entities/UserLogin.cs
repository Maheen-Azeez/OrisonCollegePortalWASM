using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Shared.Entities
{
    public class UserLogin
    {
        public int UserID { get; set; }
        public int ID { get; set; }
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string AccountName { get; set; }

        public string New { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Balance { get; set; }


        public string AccountCode { get; set; }
        public string Stmt { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
        public int ProfileID { get; set; }
        public int BranchID { get; set; }
    }
}
