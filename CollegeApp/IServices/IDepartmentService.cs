using CompanyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.IServices
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        Department InsertDepartment(Department model);
        Department GetDepartmentByID(int ID);
        Department UpdateDepartment(Department model);
        int DeleteDepartment(int ID);
    }
}
