using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string login, string password, string returnurl = null)
        {
            if (Membership.ValidateUser(login, password))
            {
                FormsAuthentication.SetAuthCookie(login, false);
                if (!string.IsNullOrEmpty(returnurl))
                {
                    Response.Redirect(returnurl);
                }
                return RedirectToAction("Index", "Home");
            }

            TempData["LoginError"] = "Chybné uživatelské jméno nebo heslo.";

            return RedirectToAction("Index", "Login");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}