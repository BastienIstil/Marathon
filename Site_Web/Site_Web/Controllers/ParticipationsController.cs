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
            var pARTICIPATIONs = db.PARTICIPATIONs.Include(p => p.T_E_COUREUR_COU).Include(p => p.T_E_PAIEMENT_PAI1).Include(p => p.T_R_COURSE_COR).Include(p => p.T_E_PASTAPARTY_PAS).Include(p => p.T_R_CLUB_CLU);
            return View(pARTICIPATIONs.ToList());
        }

        // GET: Participations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs.Find(id);
            if (pARTICIPATION == null)
            {
                return HttpNotFound();
            }
            return View(pARTICIPATION);
        }

        // GET: Participations/Create
        public ActionResult Create()
        {
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM");
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENPAIEMENT");
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            ViewBag.PAS_ID = new SelectList(db.PASTAPARTies, "PAS_ID", "PAS_ID");
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM");
            return View();
        }

        // POST: Participations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PAR_ID,CLU_ID,COR_ID,PAS_ID,COU_ID,PAI_ID,PAR_DOSSARD,PAR_TEMPS_ESTIME,PAR_NBPARTICIPANTCOURSE,PAR_PARTICIPEPASTAPARTY,PAR_NBPARTICIPANTPASTAPARTY")] PARTICIPATION pARTICIPATION)
        {
            if (ModelState.IsValid)
            {
                db.PARTICIPATIONs.Add(pARTICIPATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", pARTICIPATION.COU_ID);
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENPAIEMENT", pARTICIPATION.PAI_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATION.COR_ID);
            ViewBag.PAS_ID = new SelectList(db.PASTAPARTies, "PAS_ID", "PAS_ID", pARTICIPATION.PAS_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", pARTICIPATION.CLU_ID);
            return View(pARTICIPATION);
        }

        // GET: Participations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs.Find(id);
            if (pARTICIPATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", pARTICIPATION.COU_ID);
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENPAIEMENT", pARTICIPATION.PAI_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATION.COR_ID);
            ViewBag.PAS_ID = new SelectList(db.PASTAPARTies, "PAS_ID", "PAS_ID", pARTICIPATION.PAS_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", pARTICIPATION.CLU_ID);
            return View(pARTICIPATION);
        }

        // POST: Participations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PAR_ID,CLU_ID,COR_ID,PAS_ID,COU_ID,PAI_ID,PAR_DOSSARD,PAR_TEMPS_ESTIME,PAR_NBPARTICIPANTCOURSE,PAR_PARTICIPEPASTAPARTY,PAR_NBPARTICIPANTPASTAPARTY")] PARTICIPATION pARTICIPATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARTICIPATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", pARTICIPATION.COU_ID);
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENPAIEMENT", pARTICIPATION.PAI_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATION.COR_ID);
            ViewBag.PAS_ID = new SelectList(db.PASTAPARTies, "PAS_ID", "PAS_ID", pARTICIPATION.PAS_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", pARTICIPATION.CLU_ID);
            return View(pARTICIPATION);
        }

        // GET: Participations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs.Find(id);
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
            PARTICIPATION pARTICIPATION = db.PARTICIPATIONs.Find(id);
            db.PARTICIPATIONs.Remove(pARTICIPATION);
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
