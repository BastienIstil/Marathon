using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site_Web.App_Data;
using System.Web.Security;

using Site_Web.Class_Metier.ViewCustomModels;

namespace Site_Web.Controllers
{
    public class InscritsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();
        private String salt = "100000.m1bP2tTpa/T8BjY/cfuV0kYSiK/Jq6K6Xvzkg+4W3Z3Atw==";

        public static ViewResult homeView;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(INSCRIT user)
        {
            if (IsValid(user.INS_LOGIN, user.INS_MDP))
            {
                FormsAuthentication.SetAuthCookie(user.INS_LOGIN, false);
                return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("", "Login details are wrong.");
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(InscritCustom user)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    SimpleCrypto.PBKDF2 crypto = new SimpleCrypto.PBKDF2();
                    string encrypPass = crypto.Compute(user.INS_MDP, salt);

                    INSCRIT newUser = new INSCRIT();
                    newUser.INS_LOGIN = user.INS_LOGIN;
                    newUser.INS_MDP = encrypPass;
                    newUser.INS_NIVEAUAUTHENTIFICATION = (int)user.INS_NIVEAUAUTHENTIFICATION;

                    db.INSCRITs.Add(newUser);
                    db.Entry(newUser).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }

            }
            catch (Exception e)
            {
                return new EmptyResult();
            }
           

            return View();

        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            var user = db.INSCRITs.FirstOrDefault(u => u.INS_LOGIN == email);

            if (user != null)
            {
                if (user.INS_MDP == crypto.Compute(password, salt))
                    IsValid = true;
            }

            return IsValid;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
