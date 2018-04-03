using DependencyInjectionLearning.Helpers;
using DependencyInjectionLearning.Models;
using DependencyInjectionLearning.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DependencyInjectionLearning.Controllers
{
    public class AdminController : Controller
    {
        readonly IEmployeeRepository repo;
        public AdminController(IEmployeeRepository tempRepo)
        {
            this.repo = tempRepo;
        }

        [AuthorizeRole]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            var Islogin = repo.GetAll().FirstOrDefault(p => p.Email == model.UserName && p.Password == model.Password);
            if (Islogin != null)
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, Islogin.Name, DateTime.Now, DateTime.Now.AddDays(2), false, Islogin.Role.RoleType);
                String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                HttpContext.Response.Cookies.Add(authCookie);
                if (Islogin.Role.RoleID == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else { return RedirectToAction("Index", "Home"); }
            }
            else
            {

            }

            return View();
        }
    }
}