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

        public ActionResult LogOut()
        {
            Session["userId"] = null;
            Session["userFirstName"] = null;
            Session["userLastName"] = null;
            return RedirectToAction("Index", "Home");
        }


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
