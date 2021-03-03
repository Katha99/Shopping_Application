
using System.Collections.Generic;
using System.Web.Mvc;
using netzkern.MyBookstore.BusinessLogic;
using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class SignInController : Controller
    {
        UserService _userService;

        public SignInController()
        {
            _userService = new UserService();
        }

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
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(model);

                ViewBag.texts = "Du hast dich erfolgreich regestriert. Meld dich nun an.";
                return RedirectToAction("LogIn");
            }

            ViewBag.texts = "Es ist etwas schief gelaufen. Bitte überprüfe ob du alle Felder korrekt ausgefüllt hast und versuche es nochmal.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User model)
        {
            var user = _userService.LoadUser(model.EmailAddress);

            if (model.EmailAddress == user.EmailAddress && user.Password == user.Password)
            {
                Session["userId"] = user.Id;
                Session["userFirstName"] = user.FirstName;
                Session["userLastName"] = user.LastName;
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
