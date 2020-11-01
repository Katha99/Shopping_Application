
// A controller for interacting with users

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
        // GET: View on page with choice to register or log in
        public ActionResult Index()
        {
            return View();
        }

        // GET: View for logging in
        public ActionResult LogIn()
        {
            return View();
        }

        // GET: View for registering
        public ActionResult Register()
        {
            return View();
        }

        // function to log out 
        public ActionResult LogOut()
        {
            Session["userId"] = null;
            Session["userFirstName"] = null;
            Session["userLastName"] = null;
            return RedirectToAction("Index", "Home");
        }

        // Sending data of the registration to the ProductProcessor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Person model)
        {
            ViewBag.Message = "The sign up page.";

            if (ModelState.IsValid)
            {
                int recordsCreated = CreatePerson(model.FirstName, model.LastName, model.EmailAddress, model.Password);
                ViewBag.texts = "Du hast dich erfolgreich regestriert. Meld dich nun an.";
                return RedirectToAction("LogIn");
            }

            ViewBag.texts = "Es ist etwas schief gelaufen. Bitte überprüfe ob du alle Felder korrekt ausgefüllt hast und versuche es nochmal.";
            return View();
        }

        // Validating the data of the log in with the data we get from the PersonProcessor to log the user in
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Person model)
        {
            ViewBag.Message = "The sign up page.";
                var data = LoadPerson( model.EmailAddress );

                List<Person> person = new List<Person>();

                foreach (var row in data)
                {
                    person.Add(new Person
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        EmailAddress = row.EmailAddress,
                        Password = row.Password
                    });
                }

                if(model.EmailAddress == person[0].EmailAddress && model.Password == person[0].Password)
                {
                    Session["userId"] = person[0].Id;
                    Session["userFirstName"] = person[0].FirstName;
                    Session["userLastName"] = person[0].LastName;
                    ViewBag.texts = "";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.texts = "Email Addresse oder Passwort stimmen nicht. Bitte versuche es normal.";
                    return View();
                }
        }
    }
}
