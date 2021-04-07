using CompanyApp.Entities;
using CompanyApp.Interface;
using CompanyApp.IServices;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Services
{
    public class UserService : IUserService
    {
        private readonly IDapperHelper _dapperHelper;

        public UserService(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }
        public List<User> GetUsers()
        {
            var data = _dapperHelper.GetAll<User>("Select e.*, c.CollegeName,d.DepartmentName, r.RoleName from [User] e " +
                "Left join RoleAuthor r on r.ID= e.RoleID " +
                 "Left join College c on c.ID= e.CollegeID " +
                "Left join Department d on d.ID= e.DepartmentID ", null, commandType: CommandType.Text);
            return data.ToList();
        }

        public User GetUserByID(int ID)
        {
            var data = _dapperHelper.Get<User>("Select u.*, ra.RoleName, ra.AccessPages from [User] u Inner join RoleAuthor ra on u.RoleId = ra.Id where u.ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }


        public User CheckLogin(string Email,string password)
        {
            var data = _dapperHelper.Get<User>("Select u.*, ra.RoleName, ra.AccessPages from [User] u inner join RoleAuthor ra on u.RoleID = ra.Id where Email ='" + Email + "' and Password ='" + password + "'  ", null, commandType: CommandType.Text);
            return data;
        }

        public User InsertUser(UserModel model)
        {
            var data = _dapperHelper.Insert<User>("Insert into [User](UserName,[Email], Password, [PhoneNo],[Address],[HireDate],CollegeID, DepartmentID, RoleID) values" +
                " ('" + model.UserName + "','" + model.Email + "','" + model.Password + "','" + model.PhoneNo + "','" + model.Address + "','" + Convert.ToDateTime(model.HireDate).ToString("MM/dd/yyyy") + "','" + model.CollegeID + "','" + model.DepartmentID + "', "+model.RoleID+")", null, commandType: CommandType.Text);
            return data;
        }

        public User UpdateUser(UserModel model)
        {
            var data = _dapperHelper.Update<User>("Update [User] set UserName ='" + model.UserName + "',[Email]='" + model.Email + "',[PhoneNo]='" + model.PhoneNo + "'," +
                "[Address]='" + model.Address + "', [HireDate]='" + Convert.ToDateTime(model.HireDate).ToString("MM/dd/yyyy") + "', [CollegeID]='" + model.CollegeID + "', [DepartmentID]='" + model.DepartmentID + "',[RoleID]='" + model.RoleID + "' where ID ='" + model.ID + "'", null, commandType: CommandType.Text);
            return data;
        }

        public int DeleteUser(int ID)
        {
            var data = _dapperHelper.Execute("Delete [User] where ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }
    }
}
