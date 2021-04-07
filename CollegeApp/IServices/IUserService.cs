using CompanyApp.Entities;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
        User InsertUser(UserModel model);
        User GetUserByID(int ID);
        User CheckLogin(string Email, string password);
        User UpdateUser(UserModel model);
        int DeleteUser(int ID);
    }
}
