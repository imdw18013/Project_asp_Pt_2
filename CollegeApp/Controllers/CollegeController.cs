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
    public class CollegeController : Controller
    {
        private readonly ICollegeService _collegeService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CollegeController(ICollegeService collegeService, IHostingEnvironment hostingEnvironment)
        {
            _collegeService = collegeService;
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
            var data = _collegeService.GetCompanies();
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
            var model = new College();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(College model)
        {
            var obj = new College();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _collegeService.InsertCompany(model);
                    TempData["SuccessMsg"] = "Data saved successfully";
                }
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
            ViewData["AccessPages"] = HttpContext.Session.GetString("AccessPages");
            ViewData["Email"] = HttpContext.Session.GetString("Email");
            if (id != null)
            {
                var model = _collegeService.GetCompanyByID(id);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(College model)
        {
            var obj = new College();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _collegeService.UpdateCompany(model);
                    TempData["SuccessMsg"] = "Data saved successfully";
                }
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
                if (ModelState.IsValid)
                {
                    var result = _collegeService.DeleteCompany(id);
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
