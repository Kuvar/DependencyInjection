using DependencyInjectionLearning.CF;
using DependencyInjectionLearning.Models;
using DependencyInjectionLearning.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependencyInjectionLearning.Controllers
{
    public class HomeController : Controller
    {
        readonly ICompanyRepository repo;
        DatabaseContext context;


        public HomeController(ICompanyRepository tempProduct)
        {
            this.repo = tempProduct;
            
        }
        public ActionResult Index()
        {
            try
            {
                context = new DatabaseContext();

                var emp = context.Employees.ToList();

                return View(repo.GetAll());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}