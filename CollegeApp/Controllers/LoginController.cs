using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeApp.Models;
using CompanyApp.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using CompanyApp.Entities;

namespace CollegeApp.Controllers
{
    public class LoginController : Controller
    {
       

        private readonly IUserService _UserService;
        
        public LoginController(IUserService UserService)
        {
            _UserService = UserService;
            
        }

        public ActionResult Index()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        public  ActionResult Index(LoginModel model)
        {
            var item = _UserService.CheckLogin(model.Email, model.Password);
            if (item != null)
            {
                HttpContext.Session.SetInt32("UserId", item.ID);
                HttpContext.Session.SetInt32("RoleId", item.RoleId);
                HttpContext.Session.SetString("Email", item.Email);
                HttpContext.Session.SetString("RoleName", item.RoleName);
                HttpContext.Session.SetString("AccessPages", item.AccessPages);
                //var test= HttpContext.Session.GetInt32("UserId");
                //var test2 = HttpContext.Session.GetString("Email");
                

                return RedirectToAction("Index", "Home");
            }
            TempData["ErrorMsg"] = "your login credintials are invalid.";
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}