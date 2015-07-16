

using System.Web.Mvc;
using Site_Web.Class_Metier.Web_Common;
using System.IO;
using System;

namespace Site_Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Methode affichant l'accueil.
        /// </summary>
        /// <returns>La view index de l'accueil.</returns>
        public ActionResult Index()
        {
            InscritsController.homeView = this.View();
            return View();
        }

        /// <summary>
        /// Methode affichant l'accueil 2 (le CRUD pour developpeur).
        /// </summary>
        /// <returns>La view index de l'accueil 2 .</returns>
        public ActionResult Index2()
        {
            return View();
        }

        /// <summary>
        /// Methode affichant la page "A PROPOS".
        /// </summary>
        /// <returns>La view about.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Methode affichant la page "Contact".
        /// </summary>
        /// <returns>La view contact.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        /// <summary>
        /// Methode permettant de telecharger les formulaires d'inscription (club et coureur).
        /// </summary>
        /// <returns>La proposition de telechargement des formulaires</returns>
        public ActionResult Telecharge(string Fichier)
        {
            Console.Error.WriteLine(Path.GetFullPath("Resources"));
            Telechargement.telechargementLocal(Response, "InscriptionIndividu", Server.MapPath("../Resources/"+Fichier));
            return View();
        }

        /// <summary>
        /// Methodes de validation ou non des inscriptions.
        /// </summary>
        /// <returns>LEs vues de confirmation ou de fail.</returns>
        public ActionResult InscriptionClubFail() { return View(); }
        public ActionResult InscriptionClubOK() { return View(); }
        public ActionResult InscriptioDefiFail() { return View(); }
        public ActionResult InscriptionDefiOK() { return View(); }

    }

}