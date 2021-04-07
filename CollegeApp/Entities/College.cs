using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Entities
{
    public class College
    {
        public int ID { get; set; }

        public string CollegeName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public DateTime? StartDate { get; set; }

    }
}
