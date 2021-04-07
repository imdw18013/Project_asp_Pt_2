using CollegeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeApp.IServices
{
    public interface IRoleAuthorService
    {
        List<RoleAuthor> GetRoleAuthors();
        RoleAuthor InsertRoleAuthor(RoleAuthor model);
        RoleAuthor GetRoleAuthorByID(int ID);
        RoleAuthor UpdateRoleAuthor(RoleAuthor model);
        int DeleteRoleAuthor(int ID);
    }
}
