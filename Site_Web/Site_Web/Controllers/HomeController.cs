using System.Web.Mvc;
using Site_Web.Class_Metier.Web_Common;

namespace Site_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Telechargement.telechargement(HttpContext.Response, "Toto.png", "http://www.ac-grenoble.fr/ien.vienne1-2/spip/IMG/bmp_Image004.bmp");
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