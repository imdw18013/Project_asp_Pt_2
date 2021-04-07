using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Entities
{
    public class Department
    {
        public int ID { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
