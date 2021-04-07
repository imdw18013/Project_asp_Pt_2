using CompanyApp.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Models
{
    public class UserModel
    {
        [Key]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? HireDate { get; set; }

        public int? CollegeID { get; set; }
        public int? DepartmentID { get; set; }
        public int? RoleID { get; set; }
        public string CollegeName { get; set; }
        public string DeparmentName { get; set; }
        public string RoleName { get; set; }

        [NotMapped]
        public List<SelectListItem> CollegeList { get; set; }
        [NotMapped]
        public List<SelectListItem> DepartmentList { get; set; }
        [NotMapped]
        public List<SelectListItem> RoleList { get; set; }

    }


    public class RoleAuthorModel
    {
        [Key]
        public int ID { get; set; }        
        public string RoleName { get; set; }

        public string AccessPages { get; set; }
        public string hdnAccessPages { get; set; }
    }

    
}
