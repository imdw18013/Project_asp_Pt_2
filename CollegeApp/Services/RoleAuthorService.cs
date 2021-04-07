using CollegeApp.Entities;
using CollegeApp.IServices;
using CompanyApp.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeApp.Services
{
    public class RoleAuthorService: IRoleAuthorService
    {
        private readonly IDapperHelper _dapperHelper;

        public RoleAuthorService(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }
        public List<RoleAuthor> GetRoleAuthors()
        {
            var data = _dapperHelper.GetAll<RoleAuthor>("Select e.* from [RoleAuthor] e " , null, commandType: CommandType.Text);
            return data.ToList();
        }

        public RoleAuthor GetRoleAuthorByID(int ID)
        {
            var data = _dapperHelper.Get<RoleAuthor>("Select u.* from [RoleAuthor] u where ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }

        public RoleAuthor InsertRoleAuthor(RoleAuthor model)
        {
            var data = _dapperHelper.Insert<RoleAuthor>("Insert into [RoleAuthor](RoleName,[AccessPages]) values" +
                " ('" + model.RoleName + "','" + model.AccessPages + "')", null, commandType: CommandType.Text);
            return data;
        }

        public RoleAuthor UpdateRoleAuthor(RoleAuthor model)
        {
            var data = _dapperHelper.Update<RoleAuthor>("Update [RoleAuthor] set RoleName ='" + model.RoleName + "',[AccessPages]='" + model.AccessPages + "' where ID ='" + model.ID + "'", null, commandType: CommandType.Text);
            return data;
        }

        public int DeleteRoleAuthor(int ID)
        {
            var data = _dapperHelper.Execute("Delete [RoleAuthor] where ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }
    }
}
