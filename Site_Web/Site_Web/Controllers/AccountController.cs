using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Site_Web.Models;

namespace Site_Web.Controllers
{
    public class AccountController : Controller
    {
        [ActionName("_Login")]
        public ActionResult Login()
        {
            LoginViewModel modelLogin = new LoginViewModel();
            modelLogin.Password = "toto";
            modelLogin.Email = "test0";
            // Convertir Model pour la view
            return PartialView("_Login",modelLogin);
        }

    }
}