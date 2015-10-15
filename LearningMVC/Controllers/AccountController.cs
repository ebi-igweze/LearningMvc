using DataRepository = LearningMVC.Core.DataAccess.DataRepository;
using DataEntities = LearningMVC.Core.DataAccess.DataEntities;
using UManager = LearningMVC.Core.Managers.UserManager;
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
        private UserManager<User> _usermanager;

        private IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        public AccountController()
        {
            //NOTE: Integration Point
            _usermanager = new UserManager<User>(new UserStore(new UManager(new DataRepository(new DataEntities()))));
            _usermanager.PasswordHasher = new MD5Hasher();
        }


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {

            var iden = new ClaimsIdentity("Google");
            iden.AddClaim(new Claim(ClaimTypes.Email, model.Email));
            iden.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            //var identity = _usermanager.CreateIdentity(model, DefaultAuthenticationTypes.ApplicationCookie);
            Authentication.SignIn(iden);
            return View(model);
        }

        public ActionResult Register(User model)
        {
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