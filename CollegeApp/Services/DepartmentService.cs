using CompanyApp.Entities;
using CompanyApp.Interface;
using CompanyApp.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDapperHelper _dapperHelper;

        public DepartmentService(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }
        public List<Department> GetDepartments()
        {
            var data = _dapperHelper.GetAll<Department>("Select * from Department", null, commandType: CommandType.Text);
            return data.ToList();
        }

        public Department GetDepartmentByID(int ID)
        {
            var data = _dapperHelper.Get<Department>("Select * from Department where ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }

        public Department InsertDepartment(Department model)
        {
            
            var data = _dapperHelper.Insert<Department>("Insert into Department(DepartmentName,[Description],[Status],[CreatedDate]) values" +
                " ('" + model.DepartmentName + "','" + model.Description + "','" + model.Status + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "')", null, commandType: CommandType.Text);
            return data;
        }

        public Department UpdateDepartment(Department model)
        {
            var data = _dapperHelper.Update<Department>("Update Department set DepartmentName ='" + model.DepartmentName + "',[Description]='" + model.Description + "',[Status]='" + model.Status + "'" +
                " where ID ='" + model.ID + "'", null, commandType: CommandType.Text);
            return data;
        }

        public int DeleteDepartment(int ID)
        {
            var data = _dapperHelper.Execute("Delete Department where ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }
    }
}
