using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeApp.IServices;
using CompanyApp.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyApp.Models;
using CollegeApp.Entities;

namespace CollegeApp.Controllers
{
    public class RoleAuthorizationController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IDepartmentService _departmentService;
        private readonly ICollegeService _companyService;
        private readonly IRoleAuthorService _roleAuthorService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RoleAuthorizationController(IUserService UserService, IDepartmentService departmentService,
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
            var data = _roleAuthorService.GetRoleAuthors();
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
            var model = new RoleAuthorModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(RoleAuthorModel model)
        {
            try
            {
                RoleAuthor obj = new RoleAuthor();
                obj.RoleName = model.RoleName;
                obj.AccessPages = model.AccessPages;
                var result = _roleAuthorService.InsertRoleAuthor(obj);
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
            var model = new RoleAuthorModel();
            var result = _roleAuthorService.GetRoleAuthorByID(id);
            model.ID = result.ID;
            model.RoleName = result.RoleName;
            model.AccessPages = result.AccessPages;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(RoleAuthorModel model)
        {
            try
            {
                RoleAuthor obj = new RoleAuthor();
                obj.ID = model.ID;
                obj.RoleName = model.RoleName;
                obj.AccessPages = model.AccessPages;
                var result = _roleAuthorService.UpdateRoleAuthor(obj);
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
                if (ModelState.IsValid)
                {
                    var result = _roleAuthorService.DeleteRoleAuthor(id);
                    TempData["SuccessMsg"] = "Data deleted successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
