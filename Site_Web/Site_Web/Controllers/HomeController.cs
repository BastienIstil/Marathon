using System.Web.Mvc;
using Site_Web.Class_Metier.Web_Common;
using System.IO;
using System;

namespace Site_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Console.Error.WriteLine(Path.GetFullPath("Ressource")) ;


            Telechargement.telechargementLocal(Response, "InscriptionClub", "Ressource/FormulaireInscriptionClub.docx");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}