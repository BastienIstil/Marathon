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
using Site_Web.Class_Metier;
using Site_Web.Class_Metier.ViewCustomModels;

namespace Site_Web.Controllers
{
    /// <summary>
    /// Inscrits controller est le controlleur gérant le CRUD et différente vues lié au model INSCRIT.
    /// </summary>
    public class InscritsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();
        private String salt = "100000.m1bP2tTpa/T8BjY/cfuV0kYSiK/Jq6K6Xvzkg+4W3Z3Atw==";

        public static ViewResult homeView;

        /// <summary>
        /// Login de l'inscrit passé en parametre GET.
        /// </summary>
        /// <returns> la view Login.</returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Log un inscrit passé en parametre POST
        /// </summary>
        /// <param name="user">L'objet inscrit correspondant à l'internaute.</param>
        /// <returns>La view user avec les informations de l'inscrit fournie en paramètre.</returns>
        [HttpPost]
        public ActionResult Login(INSCRIT user)
        {
            if (IsValid(user.INS_LOGIN, user.INS_MDP))
            {
                FormsAuthentication.SetAuthCookie(user.INS_LOGIN, false);

                int insID = (from i in db.INSCRITs.ToList()
                                 where i.INS_LOGIN == user.INS_LOGIN
                                 select i).FirstOrDefault().INS_ID;

                COUREUR courreur = (from c in  db.COUREURs.ToList()
                                    where c.INS_ID == insID
                                        select c).FirstOrDefault();

                if (courreur != null)
                {
                    int cat = UpdateCat.getCat(courreur.COU_DATENAISSANCE);
                    courreur.CAT_ID = cat;
                    db.Entry(courreur).State = EntityState.Modified;
                    db.SaveChanges();
                    // update cat id needed
                }

                return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("", "Identifiant ou mot de passe incorrect");
            return View(user);
        }

        /// <summary>
        /// Inscrit un internaute passé en parametre GET
        /// </summary>
        /// <returns>La view REgister avec les informations de l'inscrit fournie en paramètre.</returns>
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
                    ModelState.AddModelError("", "Données incorrect");
                }

            }
            catch (Exception)
            {
                return new EmptyResult();
            }
           

            return View();

        }


        /// <summary>
        /// Déconnecte un internaute passé en parametre GET
        /// </summary>
        /// <returns>La view Index de l'Accueil.</returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Vérifie les parametres entrés par l'internaute.
        /// </summary>
        /// <param name="email">l'Email de l'internaute.</param>
        /// <param name="password">Le mot de passe de l'internaute qui va être hashé.</param>
        /// <returns>La view Index de l'Accueil.</returns>
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
