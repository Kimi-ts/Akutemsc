using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using AkuteSinglePage.Utils;

namespace AkuteSinglePage.Controllers
{
    public class AccountController:Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }

        [AkuteSinglePage.Utils.AllowAnonymousAttribute]
        [System.Web.Mvc.HttpPost]
        public ActionResult LogOn(string login, string password, string returnUrl)
        {
            if (!ValidateLogOn(login, password))
                return View("LogOn");

            FormsAuthentication.SetAuthCookie(login, false);
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private bool ValidateLogOn(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                ModelState.AddModelError("username", "User name required");

            if (string.IsNullOrEmpty(password))
                ModelState.AddModelError("password", "Password required");

            if (FormsAuthentication.Authenticate(login, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}