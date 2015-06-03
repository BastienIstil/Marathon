using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site_Web.App_Data;
using Site_Web.Class_Metier.ViewCustomModels;
using System.Net.Mail;

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
            return View(club);
        }

        // GET: Clubs/Ajout Coureur
        public ActionResult AddCoureur(int? id)
        {
            CoureurInscriptions coureurInscription = new CoureurInscriptions();
            coureurInscription.listCoureur = db.COUREURs.ToList();  // TODO UPGRADE VERIFICATION APPARTENANCE A UN CLUB
            coureurInscription.listEtat = new List<bool>();
            coureurInscription.club = db.CLUBs.Find(id);

            foreach (COUREUR c in coureurInscription.listCoureur)
            {
                coureurInscription.listEtat.Add(false);
            }

            return View(coureurInscription);
        }

        //Ajout d'un coureur au club
        [HttpPost, ActionName("AddCoureur")]
        [ValidateAntiForgeryToken]
        public ActionResult AddCoureur([Bind(Include = "listCoureur,listEtat")] CoureurInscriptions coureurInscription)
        {
            if (coureurInscription.listCoureur != null)
            {
                int i = 0;
                int count = coureurInscription.listCoureur.Count();

                for (i = 0; i < count; i++)
                {
                    if (coureurInscription.listEtat[i] == true)
                    {
                        //coureurInscription.listCoureur[i];
                        String body = "localhost:2409";
                        SendEmail(body);
                    }
                }
            }
            else
            {
                TempData["Erreur"] = "Veuillez selectionner un coureur à ajouter dans votre club";
            }

            return RedirectToAction("Index");
        }

        public static void SendEmail(String body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("dylan.btx.test@gmail.com");
                mail.To.Add("dylan.btx.test@gmail.com");
                mail.Subject = "Test Mail - Adhérer au club";

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = body;

                mail.Body = htmlBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("dylan.btx.test@gmail.com", "");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
