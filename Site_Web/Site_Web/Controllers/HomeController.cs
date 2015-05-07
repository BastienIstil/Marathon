

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
            

            return View();
        }

        public ActionResult Index2()
        {
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

        public ActionResult Telecharge()
        {
            Console.Error.WriteLine(Path.GetFullPath("Resources"));
            Telechargement.telechargementLocal(Response, "InscriptionIndividu", Server.MapPath("../Resources/InscriptionMarathonAnnecy2015.pdf"));
            return View();
        }
    }

}