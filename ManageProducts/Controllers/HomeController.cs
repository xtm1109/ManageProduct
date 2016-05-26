using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageProducts.Models;

namespace ManageProducts.Controllers {
    public class HomeController : Controller {
        private ProductContext db = new ProductContext();

        public ActionResult Index() {
            var departments = db.Departments.ToList();

            return View(departments);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}