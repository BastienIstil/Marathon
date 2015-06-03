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

using Site_Web.Class_Metier.ViewCustomModels;

namespace Site_Web.Controllers
{
    public class ClubsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Clubs
        public ActionResult Index()
        {
            return View(db.CLUBs.ToList());
        }

        // GET: Clubs/Details/5
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

        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLU_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL")] CLUB cLUB)
        {
            if (ModelState.IsValid)
            {
                db.CLUBs.Add(cLUB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLUB);
        }

        // GET: Clubs/Edit/5
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
            return View(cLUB);
        }

        // POST: Clubs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLU_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL")] CLUB cLUB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLUB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLUB);
        }

        // GET: Clubs/Delete/5
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

        // POST: Clubs/Delete/5
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


        // GET: Clubs/Ajout Coureur
        public ActionResult AddCoureur(int? id)
        {
            CoureurInscription coureurInscription = new CoureurInscription();
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
        public ActionResult AddCoureur([Bind(Include = "listCoureur,listEtat")] CoureurInscription coureurInscription)
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
                        SendEmail();
                    }
                }
            }
            else
            {
                TempData["Erreur"] = "Veuillez selectionner un coureur à ajouter dans votre club";
            }
            
            return RedirectToAction("Index"); 
        }

        public static void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("dylan.btx.test@gmail.com ");
                mail.To.Add("dylan.btx.test@gmail.com ");
                mail.Subject = "Test Mail - 1";

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = "Write some HTML code here";

                mail.Body = htmlBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("dylan.btx.test@gmail.com ", "marathon@02");
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
