using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyApp.Entities;
using CompanyApp.IServices;
using CompanyApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CollegeApp.IServices;

namespace CompanyApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IDepartmentService _departmentService;
        private readonly ICollegeService _companyService;
        private readonly IRoleAuthorService _roleAuthorService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UserController(IUserService UserService, IDepartmentService departmentService,
            ICollegeService companyService, IRoleAuthorService roleAuthorService, IHostingEnvironment hostingEnvironment)
        {
            _departmentService = departmentService;
            _UserService = UserService;
            _companyService = companyService;
            _roleAuthorService = roleAuthorService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["Email"] = HttpContext.Session.GetString("Email");
            ViewData["AccessPages"] = HttpContext.Session.GetString("AccessPages");
            var data = _UserService.GetUsers();
            return View(data);
        }


        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["Email"] = HttpContext.Session.GetString("Email");
            ViewData["AccessPages"] = HttpContext.Session.GetString("AccessPages");
            var model = new UserModel();
            model.CollegeList = _companyService.GetCompanies().Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = d.CollegeName,
                Value = d.ID.ToString()
            }).ToList();
            model.DepartmentList = _departmentService.GetDepartments().Where(d => d.Status == true).Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = d.DepartmentName,
                Value = d.ID.ToString()
            }).ToList();

            model.RoleList = _roleAuthorService.GetRoleAuthors().Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = d.RoleName,
                Value = d.ID.ToString()
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            try
            {
                var result = _UserService.InsertUser(model);
                TempData["SuccessMsg"] = "Data saved successfully";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["Email"] = HttpContext.Session.GetString("Email");
            ViewData["AccessPages"] = HttpContext.Session.GetString("AccessPages");
            var model = new UserModel();
            var item = _UserService.GetUserByID(id);
            model.ID = item.ID;
            model.UserName = item.UserName;
            model.PhoneNo = item.PhoneNo;
            model.Email = item.Email;
            model.Address = item.Address;
            model.CollegeID = item.CollegeID;
            model.DepartmentID = item.DepartmentID;
            model.HireDate = item.HireDate;
            model.RoleID = item.RoleId;
            model.CollegeList = _companyService.GetCompanies().Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = d.CollegeName,
                Value = d.ID.ToString()
            }).ToList();
            model.DepartmentList = _departmentService.GetDepartments().Where(d => d.Status == true).Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = d.DepartmentName,
                Value = d.ID.ToString()
            }).ToList();
            model.RoleList = _roleAuthorService.GetRoleAuthors().Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = d.RoleName,
                Value = d.ID.ToString()
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            try
            {
                var result = _UserService.UpdateUser(model);
                TempData["SuccessMsg"] = "Data saved successfully";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = _UserService.DeleteUser(id);
                TempData["SuccessMsg"] = "Data deleted successfully";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
