using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site_Web.App_Data;

namespace Site_Web.Controllers
{
    public class ParticipationsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Participations
        public ActionResult Index()
        {
            var pARTICIPATIONs1 = db.PARTICIPATIONs1.Include(p => p.T_E_COUREUR_COU).Include(p => p.T_E_PAIEMENT_PAI).Include(p => p.T_R_COURSE_COR);
            return View(pARTICIPATIONs1.ToList());
        }

        // GET: Participations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs1.Find(id);
            if (pARTICIPATION == null)
            {
                return HttpNotFound();
            }
            return View(pARTICIPATION);
        }

        // GET: Participations/Create
        public ActionResult Create()
        {
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM");
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT");
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            return View();
        }

        // POST: Participations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PAR_ID,COU_ID,COR_ID,PAI_ID,PAR_PASTAPARTY,PAR_TEMPSESTIME,PAR_NOMBREPASTAPARTY,PAR_DOSSARD")] PARTICIPATION pARTICIPATION)
        {
            if (ModelState.IsValid)
            {
                db.PARTICIPATIONs1.Add(pARTICIPATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM", pARTICIPATION.COU_ID);
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT", pARTICIPATION.PAI_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATION.COR_ID);
            return View(pARTICIPATION);
        }

        // GET: Participations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs1.Find(id);
            if (pARTICIPATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM", pARTICIPATION.COU_ID);
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT", pARTICIPATION.PAI_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATION.COR_ID);
            return View(pARTICIPATION);
        }

        // POST: Participations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PAR_ID,COU_ID,COR_ID,PAI_ID,PAR_PASTAPARTY,PAR_TEMPSESTIME,PAR_NOMBREPASTAPARTY,PAR_DOSSARD")] PARTICIPATION pARTICIPATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARTICIPATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM", pARTICIPATION.COU_ID);
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT", pARTICIPATION.PAI_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATION.COR_ID);
            return View(pARTICIPATION);
        }

        // GET: Participations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs1.Find(id);
            if (pARTICIPATION == null)
            {
                return HttpNotFound();
            }
            return View(pARTICIPATION);
        }

        // POST: Participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs1.Find(id);
            db.PARTICIPATIONs1.Remove(pARTICIPATION);
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
    }
}
