using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyApp.Entities;
using CompanyApp.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DepartmentController(IDepartmentService departmentService, IHostingEnvironment hostingEnvironment)
        {
            _departmentService = departmentService;
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
            var data = _departmentService.GetDepartments();
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
            var model = new Department();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Department model)
        {
            var obj = new Department();
            try
            {

                var result = _departmentService.InsertDepartment(model);
                TempData["SuccessMsg"] = "Data saved successfully";

            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message; 
                return View(obj);
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
            if (id != null)
            {
                var model = _departmentService.GetDepartmentByID(id);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Department model)
        {
            var obj = new Department();
            try
            {
                var result = _departmentService.UpdateDepartment(model);
                TempData["SuccessMsg"] = "Data saved successfully";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View(obj);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = _departmentService.DeleteDepartment(id);
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