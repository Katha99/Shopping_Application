using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping_Application.Models;

namespace Shopping_Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult SignUp()
        {
            ViewBag.Message = "The sign up page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Person person)
        {
            ViewBag.Message = "The sign up page.";

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}