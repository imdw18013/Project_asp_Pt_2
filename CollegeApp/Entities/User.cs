using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public DateTime? HireDate { get; set; }

        public int? CollegeID { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string AccessPages { get; set; }
    }

}
