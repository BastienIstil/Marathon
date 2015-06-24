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
    public class ClubsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: CLUBs
        public ActionResult Index()
        {

            var cLUBs = db.CLUBs.Include(c => c.T_E_INSCRIT_INS).Include(c => c.T_R_FEDERATION_FED);
            return View(cLUBs.ToList());
        }

        // GET: CLUBs/Details/5
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

        // GET: CLUBs/Create
        public ActionResult Create()
        {
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN");
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM");
            return View();
        }

        // POST: CLUBs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLU_ID,FED_ID,INS_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL,CLU_ADRESSE,CLU_CODEPOSTAL,CLU_VILLE,CLU_PAYS,CLU_TELEPHONE,CLU_FAX,CLU_NUMERO")] CLUB cLUB)
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

        // GET: CLUBs/Edit/5
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

        // POST: CLUBs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLU_ID,FED_ID,INS_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL,CLU_ADRESSE,CLU_CODEPOSTAL,CLU_VILLE,CLU_PAYS,CLU_TELEPHONE,CLU_FAX,CLU_NUMERO")] CLUB cLUB)
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

        // GET: CLUBs/Delete/5
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

        // POST: CLUBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLUB cLUB = db.CLUBs.Find(id);
            db.CLUBs.Remove(cLUB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

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

        // POST: Coureurs/Profile/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "CLU_ID,FED_ID,INS_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL,CLU_ADRESSE,CLU_CODEPOSTAL,CLU_VILLE,CLU_PAYS,CLU_TELEPHONE,CLU_FAX,CLU_NUMERO")] CLUB club)
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




        //////////////////////////////////////////////////////////////////
        ///////////
        /////////// Ajout courreur inscrit au club
        ///////////
        //////////////////////////////////////////////////////////////////
        // GET: Clubs/Ajout Coureur
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
                coureurInscription.CLU_ID = club.CLU_ID;
            }

            foreach (COUREUR c in coureurInscription.listCoureur)
            {
                coureurInscription.listEtat.Add(false);
            }

            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_ID", coureurInscription.CLU_ID);
            return View(coureurInscription);
        }

        //Ajout d'un coureur au club
        [HttpPost, ActionName("AddCoureur")]
        public ActionResult AddCoureur(FormCollection ListJoueurViewModel, CoureurInscriptions coureurInscription)
        {
            int i;
            int count = coureurInscription.listCoureur.Count();

            string sender = "dylan.btx.test@gmail.com";
            string mdp = "marathon@02";
            string receiver = "dylan.btx.test@gmail.com";
            string subject = "Test Mail - Adhérer au club";

            for (i = 0; i < count; i++)
            {
                if (coureurInscription.listEtat[i] == true)
                {
                    int id = coureurInscription.listCoureur[i].COU_ID;


                    string link = "<a href=\"http://localhost:2409/Clubs/ValidCoureurToClub?idClub=" +
                        coureurInscription.CLU_ID.ToString() + "&idCoureur=" +
                        coureurInscription.listCoureur[i].COU_ID.ToString() + "\">nom du lien</a>";

                    string body = link;

                    // receiver = coureurInscription.listCoureur[i].COU_EMAIL;
                    Email.SendEmail(sender, mdp, receiver, subject, body);   
                }
            }

            return RedirectToAction("Index");
        }


        [HttpGet, ActionName("ValidCoureurToClub")]
        public ActionResult ValidCoureurToClub(int? idClub, int? idCoureur)
        {
            CLUB club = db.CLUBs.Find(idClub);
           // COUREUR coureur = db.COUREURs.Find(idCoureur);
            List<COUREUR> coureurs = db.COUREURs.ToList();

            COUREUR cou = (from c in db.COUREURs
                           where c.COU_ID == idCoureur
                           select c).First();

            cou.CLU_ID = club.CLU_ID;

            db.Entry(cou).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return RedirectToAction("InscriptionClubFail","Home");
            }

            return RedirectToAction("InscriptionClubOK", "Home");
        }

        //////////////////////////////////////////////////////////////////
        ///////////
        /////////// Ajout inscrit club au défis
        ///////////
        //////////////////////////////////////////////////////////////////
        // GET: Clubs/Ajout Coureur
        public ActionResult AddInscritDefi()
        {
            InscriptionClubCourreurDefie coureurInscription = new InscriptionClubCourreurDefie();

            if (InscritCustom.getLevelAutenticate(User.Identity.Name) == NiveauAuthentification.CLUB)
            {
                INSCRIT inscrit = db.INSCRITs.FirstOrDefault(i => i.INS_LOGIN == User.Identity.Name);
                CLUB club = db.CLUBs.FirstOrDefault(c => c.INS_ID == inscrit.INS_ID);

                coureurInscription.listCoureur = (from c in db.COUREURs
                                                  where c.CLU_ID == club.CLU_ID
                                                  select c).ToList();  // TODO UPGRADE VERIFICATION APPARTENANCE A UN CLUB
                coureurInscription.listEtat = new List<bool>();
            }

            foreach (COUREUR c in coureurInscription.listCoureur)
            {
                coureurInscription.listEtat.Add(false);
            }

            coureurInscription.defi = db.DEFIs.FirstOrDefault();

            ViewBag.DEF_ID = new SelectList(db.DEFIs, "DEF_ID", "DEF_ID", coureurInscription.defi.DEF_ID);
            return View(coureurInscription);
        }

        //Ajout d'un coureur au club
        [HttpPost, ActionName("AddInscritDefi")]
        public ActionResult AddInscritDefi(FormCollection ListJoueurViewModel, InscriptionClubCourreurDefie coureurInscription)
        {
            int i;
            int count = coureurInscription.listCoureur.Count();

            string sender = "dylan.btx.test@gmail.com";
            string mdp = "marathon@02";
            string receiver = "dylan.btx.test@gmail.com";
            string subject = "Test Mail - Adhérer au club";

            for (i = 0; i < count; i++)
            {
                if (coureurInscription.listEtat[i] == true)
                {
                    int id = coureurInscription.listCoureur[i].COU_ID;


                    string link = "<a href=\"http://localhost:2409/Clubs/ValidAddInscritDefi?idCoureur=" +
                        coureurInscription.listCoureur[i].COU_ID.ToString() +
                        "&idDefi=" +
                        coureurInscription.defi.DEF_ID.ToString() +
                        "\">nom du lien</a>";

                    string body = link;

                    // receiver = coureurInscription.listCoureur[i].COU_EMAIL;
                    Email.SendEmail(sender, mdp, receiver, subject, body);
                }
            }

            return RedirectToAction("Index");
        }


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
