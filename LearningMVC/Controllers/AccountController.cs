using LearningMVC.Models;
using LearningMVC.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LearningMVC.Controllers
{
    public class AccountController : Controller
    {

        private IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            var usermanager = new UserManager<UserModel>(new UserStore());
            var identity = usermanager.CreateIdentity(model, DefaultAuthenticationTypes.ApplicationCookie);
            Authentication.SignIn(identity);
            return View(model);
        }

        public ActionResult Register(UserModel model) {

            //TODO  :implement some validation
            return View(model);
        }

        public ActionResult SignOut()
        {
            Authentication.SignOut();
            return RedirectToAction("login");
        }
    }
}