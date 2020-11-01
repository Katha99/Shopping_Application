using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.Logic.PersonProcessor;
using Shopping_Application.Models;

namespace Shopping_Application.Views.SignIn
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Person model)
        {
            ViewBag.Message = "The sign up page.";

            if (ModelState.IsValid)
            {
                int recordsCreated = CreatePerson(model.FirstName, model.LastName, model.EmailAddress, model.Password);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Person model)
        {
            ViewBag.Message = "The sign up page.";

            if (ModelState.IsValid)
            {
                int recordsCreated = CreatePerson(model.FirstName, model.LastName, model.EmailAddress, model.Password);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
