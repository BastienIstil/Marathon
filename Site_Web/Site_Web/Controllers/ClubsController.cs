using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site_Web.App_Data;
using System.Net.Mail;
using Site_Web.Class_Metier.Web_Common;
using System.Data.Entity.Validation;
using Site_Web.Class_Metier.ViewCustomModels;

namespace Site_Web.Controllers
{
    /// <summary>
    /// Clubs controller est le controlleur gérant le CRUD et différente vues lié au model CLUB.
    /// </summary>
    public class ClubsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des clubs.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {

            var cLUBs = db.CLUBs.Include(c => c.T_E_INSCRIT_INS).Include(c => c.T_R_FEDERATION_FED);
            return View(cLUBs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'un club
        /// </summary>
        /// <param name="id">L'id correspondant au club devant être détaillé.</param>
        /// <returns>La view detail avec les informations du club fourni en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLUB cLUB = db.CLUBs.Find(id);
            if (cLUB == null)
            {
                return HttpNotFound();
            }
            return View(cLUB);
        }

        /// <summary>
        /// Permet la création d'un club.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera un nouveau club.
        /// </returns>
        public ActionResult Create()
        {
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN");
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM");
            return View();
        }

        /// <summary>
        /// Permet la création d'une borne en POST.
        /// </summary>
        /// <param name="cLUB">Le club correspondant au formulaire rempli par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CLUB cLUB)
        {
            if (ModelState.IsValid)
            {
                db.CLUBs.Add(cLUB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cLUB.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cLUB.FED_ID);
            return View(cLUB);
        }

        /// <summary>
        /// Permet la modification d'un club en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au club devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ledit club.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLUB cLUB = db.CLUBs.Find(id);
            if (cLUB == null)
            {
                return HttpNotFound();
            }
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cLUB.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cLUB.FED_ID);
            return View(cLUB);
        }

        /// <summary>
        /// Permet la modification d'un club en POST.
        /// </summary>
        /// <param name="cLUB">Le club correspondant au formulaire rempli par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CLUB cLUB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLUB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cLUB.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cLUB.FED_ID);
            return View(cLUB);
        }

        /// <summary>
        /// Permet la suppression d'un club en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au club devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLUB cLUB = db.CLUBs.Find(id);
            if (cLUB == null)
            {
                return HttpNotFound();
            }
            return View(cLUB);
        }

        /// <summary>
        /// Permet la suppression d'un club en POST.
        /// </summary>
        /// <param name="id">L'id correspondant au club devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLUB cLUB = db.CLUBs.Find(id);
            db.CLUBs.Remove(cLUB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Destructeur de l'objet
        /// </summary>
        /// <param name="disposing">Le paramètre disposing est un booléen qui indique si l'appel de la méthode provient d'une méthode Dispose (sa valeur est true) ou d'un Finalize (sa valeur est false).</param>
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Permet l'edition d'un coureur pour l'inscrire à un club.
        /// </summary>
        /// <returns>La view index si la validation est bonne.</returns>
        public ActionResult EditProfile()
        {
            INSCRIT inscrit = (from u in db.INSCRITs
                               where u.INS_LOGIN == User.Identity.Name
                               select u).First();

            int idInscrit = inscrit.INS_ID;

            List<CLUB> listClub = (from c in db.CLUBs
                                   where c.INS_ID == idInscrit
                                   select c).ToList();

            CLUB club;

            if (listClub.Count() == 0)
            {
                club = new CLUB();
                club.CLU_EMAIL = User.Identity.Name;
            }
            else
                club = listClub.ElementAt(0);

            club.INS_ID = idInscrit; 
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", club.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", club.FED_ID);
            return View(club);
        }

        /// <summary>
        /// Permet l'edition d'un club pour l'ajout d'un coureur.
        /// </summary>
        /// <param name="club">L'id du club dont les adhérents vont être modérés</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(CLUB club)
        {
            if (ModelState.IsValid)
            {
                if (!db.COUREURs.Any(d => d.CLU_ID == club.CLU_ID))
                {
                    INSCRIT inscrit = (from u in db.INSCRITs
                                       where u.INS_LOGIN == User.Identity.Name
                                       select u).First();

                    club.INS_ID = inscrit.INS_ID;
                    db.CLUBs.Add(club);
                }
                else
                {
                    db.Entry(club).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", club.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", club.FED_ID);
            return View(club);
        }




        /// <summary>
        /// Permet l'ajout d'un coureur par le club
        /// </summary>
        /// <returns>La view index si la validation est bonne.</returns>
        public ActionResult AddCoureur()
        {
            CoureurInscriptions coureurInscription = new CoureurInscriptions();
            coureurInscription.listCoureur = (from c in db.COUREURs
                                              where c.CLU_ID == null
                                              select c).ToList();  // TODO UPGRADE VERIFICATION APPARTENANCE A UN CLUB
            coureurInscription.listEtat = new List<bool>();

            if (InscritCustom.getLevelAutenticate(User.Identity.Name) == NiveauAuthentification.CLUB)
            {
                INSCRIT inscrit = db.INSCRITs.FirstOrDefault(i => i.INS_LOGIN == User.Identity.Name);
                CLUB club = db.CLUBs.FirstOrDefault(c => c.INS_ID == inscrit.INS_ID);

                if (club == null)
                    return RedirectToAction("EditProfile");

                coureurInscription.CLU_ID = club.CLU_ID;
            }

            foreach (COUREUR c in coureurInscription.listCoureur)
            {
                coureurInscription.listEtat.Add(false);
            }

            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_ID", coureurInscription.CLU_ID);
            return View(coureurInscription);
        }

        /// <summary>
        /// Permet l'ajout d'un ou plusieurs coureurs au club.
        /// </summary>
        /// <param name="ListJoueurViewModel"> Une liste des ViewModel des coureurs</param>
        /// <param name="coureurInscription">La liste des coureurs inscrits sans club</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("AddCoureur")]
        public ActionResult AddCoureur(FormCollection ListJoueurViewModel, CoureurInscriptions coureurInscription)
        {
            int i;
            int count = coureurInscription.listCoureur.Count();

            string sender = "dylan.btx.test@gmail.com";
            string mdp = "marathon@02";
            string receiver = "dylan.btx.test@gmail.com";
            string subject = "Adhérer au club Marathon 2015";

            for (i = 0; i < count; i++)
            {
                if (coureurInscription.listEtat[i] == true)
                {
                    int id = coureurInscription.listCoureur[i].COU_ID;
                    string body;

                    string link = "<a href=\"http://localhost:2409/Clubs/ValidCoureurToClub?idClub=" +
                        coureurInscription.CLU_ID.ToString() + "&idCoureur=" +
                        coureurInscription.listCoureur[i].COU_ID.ToString() + "\">cliquer pour validation</a>";


                    try
                    {
                        body = "Le club " + db.CLUBs.Find(coureurInscription.CLU_ID).CLU_NOM + " souhaite vous inscrire en tant que participant " + link;
                    }
                    catch (Exception)
                    {
                        body = link;
                    }
                    // receiver = coureurInscription.listCoureur[i].COU_EMAIL;
                    Email.SendEmail(sender, mdp, receiver, subject, body);   
                }
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Test la validation d'une inscription d'un coureur à un club.
        /// </summary>
        /// <param name="idClub"> l'id du club dont le coureur doit etre inscrit</param>
        /// <param name="idCoureur">l'id du coureur qui va être inscrit au club</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpGet, ActionName("ValidCoureurToClub")]
        public ActionResult ValidCoureurToClub(int? idClub, int? idCoureur)
        {
            try
            {
                CLUB club = db.CLUBs.Find(idClub);
               // COUREUR coureur = db.COUREURs.Find(idCoureur);
                List<COUREUR> coureurs = db.COUREURs.ToList();

                COUREUR cou = (from c in db.COUREURs
                               where c.COU_ID == idCoureur
                               select c).First();

                cou.CLU_ID = club.CLU_ID;

                db.Entry(cou).State = EntityState.Modified;

                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("InscriptionClubFail","Home");
            }

            return RedirectToAction("InscriptionClubOK", "Home");
        }

        /// <summary>
        /// Ajoute un inscrit du club à un defi
        /// </summary>
        /// <returns>La view index si la validation est bonne.</returns>
        public ActionResult AddInscritDefi()
        {
            InscriptionClubCourreurDefie coureurInscription = new InscriptionClubCourreurDefie();

            if (InscritCustom.getLevelAutenticate(User.Identity.Name) == NiveauAuthentification.CLUB)
            {
                INSCRIT inscrit = db.INSCRITs.FirstOrDefault(i => i.INS_LOGIN == User.Identity.Name);
                CLUB club = db.CLUBs.FirstOrDefault(c => c.INS_ID == inscrit.INS_ID);

                if (club == null)
                    return RedirectToAction("EditProfile");

                coureurInscription.listCoureur = (from c in db.COUREURs
                                                  where c.CLU_ID == club.CLU_ID
                                                  select c).ToList();  // TODO UPGRADE VERIFICATION APPARTENANCE A UN CLUB

                
                coureurInscription.listEtat = new List<bool>();
            }

            if (coureurInscription.listCoureur == null)
                coureurInscription.listCoureur = new List<COUREUR>();

            foreach (COUREUR c in coureurInscription.listCoureur)
            {
                coureurInscription.listEtat.Add(false);
            }

            coureurInscription.defi = db.DEFIs.FirstOrDefault();

            ViewBag.DEF_ID = new SelectList(db.DEFIs, "DEF_ID", "DEF_ID", coureurInscription.defi.DEF_ID);
            return View(coureurInscription);
        }

        /// <summary>
        /// Ajoute un inscrit du club à un defi
        /// </summary>
        /// <param name="ListJoueurViewModel">LA liste des viewModel de la liste des coureurs à inscrire au défi</param>
        /// <param name="coureurInscription"></param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("AddInscritDefi")]
        public ActionResult AddInscritDefi(FormCollection ListJoueurViewModel, InscriptionClubCourreurDefie coureurInscription)
        {
            int i;
            int count = coureurInscription.listCoureur.Count();

            string sender = "dylan.btx.test@gmail.com";
            string mdp = "marathon@02";
            string receiver = "dylan.btx.test@gmail.com";
            string subject = "Inscription épreuve au club Marathon 2015";

            for (i = 0; i < count; i++)
            {
                if (coureurInscription.listEtat[i] == true)
                {
                    int id = coureurInscription.listCoureur[i].COU_ID;

                    string body;

                    string link = "<a href=\"http://localhost:2409/Clubs/ValidAddInscritDefi?idCoureur=" +
                        coureurInscription.listCoureur[i].COU_ID.ToString() +
                        "&idDefi=" +
                        coureurInscription.defi.DEF_ID.ToString() +
                        "\">cliquer pour validation</a>";


                    try
                    {
                        body = "Votre club souhaite vous inscrire au défi " +  coureurInscription.defi.DEF_NOM + " " + link;
                    }
                    catch (Exception)
                    {
                        body = link;
                    }

                    // receiver = coureurInscription.listCoureur[i].COU_EMAIL;
                    Email.SendEmail(sender, mdp, receiver, subject, body);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Test la validation d'un inscrit à un défi
        /// </summary>
        /// <param name="idCoureur">L'id du coureur à inscrire au defi.</param>
        /// <param name="idDefi">L'id du défi auquel inscrire le coureur</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpGet, ActionName("ValidAddInscritDefi")]
        public ActionResult ValidAddInscritDefi(int? idCoureur, int? idDefi)
        {
            List<COUREUR> coureurs = db.COUREURs.ToList();

            COUREUR cou = (from c in db.COUREURs
                           where c.COU_ID == idCoureur
                           select c).First();

            DEFI def = (from d in db.DEFIs
                        where d.DEF_ID == idDefi
                        select d).First();

            def.T_E_COUREUR_COU.Add(cou);

            db.Entry(def).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return RedirectToAction("InscriptionDefiFail", "Home");
            }

            return RedirectToAction("InscriptionDefiOK", "Home");
        }
    }
}
