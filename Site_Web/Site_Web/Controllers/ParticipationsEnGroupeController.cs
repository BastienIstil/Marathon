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
    public class ParticipationsEnGroupeController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: ParticipationsEnGroupe
        public ActionResult Index()
        {
            var pARTICIPATIONENGROUPEs = db.PARTICIPATIONENGROUPEs.Include(p => p.T_E_PAIEMENT_PAI).Include(p => p.T_R_CLUB_CLU).Include(p => p.T_R_COURSE_COR);
            return View(pARTICIPATIONENGROUPEs.ToList());
        }

        // GET: ParticipationsEnGroupe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATIONENGROUPE pARTICIPATIONENGROUPE = db.PARTICIPATIONENGROUPEs.Find(id);
            if (pARTICIPATIONENGROUPE == null)
            {
                return HttpNotFound();
            }
            return View(pARTICIPATIONENGROUPE);
        }

        // GET: ParticipationsEnGroupe/Create
        public ActionResult Create()
        {
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT");
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM");
            ViewBag.COU_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            return View();
        }

        // POST: ParticipationsEnGroupe/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PEG_ID,COU_ID,CLU_ID,PAI_ID,PEG_NOMBREPARTICIPANT,PEG_NOMBREPASTAPARTY")] PARTICIPATIONENGROUPE pARTICIPATIONENGROUPE)
        {
            if (ModelState.IsValid)
            {
                db.PARTICIPATIONENGROUPEs.Add(pARTICIPATIONENGROUPE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT", pARTICIPATIONENGROUPE.PAI_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", pARTICIPATIONENGROUPE.CLU_ID);
            ViewBag.COU_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATIONENGROUPE.COU_ID);
            return View(pARTICIPATIONENGROUPE);
        }

        // GET: ParticipationsEnGroupe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATIONENGROUPE pARTICIPATIONENGROUPE = db.PARTICIPATIONENGROUPEs.Find(id);
            if (pARTICIPATIONENGROUPE == null)
            {
                return HttpNotFound();
            }
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT", pARTICIPATIONENGROUPE.PAI_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", pARTICIPATIONENGROUPE.CLU_ID);
            ViewBag.COU_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATIONENGROUPE.COU_ID);
            return View(pARTICIPATIONENGROUPE);
        }

        // POST: ParticipationsEnGroupe/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PEG_ID,COU_ID,CLU_ID,PAI_ID,PEG_NOMBREPARTICIPANT,PEG_NOMBREPASTAPARTY")] PARTICIPATIONENGROUPE pARTICIPATIONENGROUPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARTICIPATIONENGROUPE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PAI_ID = new SelectList(db.PAIEMENTs, "PAI_ID", "PAI_MOYENDEPAIEMENT", pARTICIPATIONENGROUPE.PAI_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", pARTICIPATIONENGROUPE.CLU_ID);
            ViewBag.COU_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", pARTICIPATIONENGROUPE.COU_ID);
            return View(pARTICIPATIONENGROUPE);
        }

        // GET: ParticipationsEnGroupe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPATIONENGROUPE pARTICIPATIONENGROUPE = db.PARTICIPATIONENGROUPEs.Find(id);
            if (pARTICIPATIONENGROUPE == null)
            {
                return HttpNotFound();
            }
            return View(pARTICIPATIONENGROUPE);
        }

        // POST: ParticipationsEnGroupe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARTICIPATIONENGROUPE pARTICIPATIONENGROUPE = db.PARTICIPATIONENGROUPEs.Find(id);
            db.PARTICIPATIONENGROUPEs.Remove(pARTICIPATIONENGROUPE);
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
