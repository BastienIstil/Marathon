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
    public class TempsCoureurBorneController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: TempsCoureurBorne
        public ActionResult Index()
        {
            var tEMPSCOUBORNEs = db.TEMPSCOUBORNEs.Include(t => t.T_E_COUREUR_COU).Include(t => t.T_R_BORNE_BOR);
            return View(tEMPSCOUBORNEs.ToList());
        }

        // GET: TempsCoureurBorne/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPSCOUBORNE tEMPSCOUBORNE = db.TEMPSCOUBORNEs.Find(id);
            if (tEMPSCOUBORNE == null)
            {
                return HttpNotFound();
            }
            return View(tEMPSCOUBORNE);
        }

        // GET: TempsCoureurBorne/Create
        public ActionResult Create()
        {
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM");
            ViewBag.BOR_ID = new SelectList(db.BORNEs, "BOR_ID", "BOR_ID");
            return View();
        }

        // POST: TempsCoureurBorne/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOR_ID,COU_ID,TCB_TEMPS")] TEMPSCOUBORNE tEMPSCOUBORNE)
        {
            if (ModelState.IsValid)
            {
                db.TEMPSCOUBORNEs.Add(tEMPSCOUBORNE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", tEMPSCOUBORNE.COU_ID);
            ViewBag.BOR_ID = new SelectList(db.BORNEs, "BOR_ID", "BOR_ID", tEMPSCOUBORNE.BOR_ID);
            return View(tEMPSCOUBORNE);
        }

        // GET: TempsCoureurBorne/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPSCOUBORNE tEMPSCOUBORNE = db.TEMPSCOUBORNEs.Find(id);
            if (tEMPSCOUBORNE == null)
            {
                return HttpNotFound();
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", tEMPSCOUBORNE.COU_ID);
            ViewBag.BOR_ID = new SelectList(db.BORNEs, "BOR_ID", "BOR_ID", tEMPSCOUBORNE.BOR_ID);
            return View(tEMPSCOUBORNE);
        }

        // POST: TempsCoureurBorne/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOR_ID,COU_ID,TCB_TEMPS")] TEMPSCOUBORNE tEMPSCOUBORNE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEMPSCOUBORNE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", tEMPSCOUBORNE.COU_ID);
            ViewBag.BOR_ID = new SelectList(db.BORNEs, "BOR_ID", "BOR_ID", tEMPSCOUBORNE.BOR_ID);
            return View(tEMPSCOUBORNE);
        }

        // GET: TempsCoureurBorne/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPSCOUBORNE tEMPSCOUBORNE = db.TEMPSCOUBORNEs.Find(id);
            if (tEMPSCOUBORNE == null)
            {
                return HttpNotFound();
            }
            return View(tEMPSCOUBORNE);
        }

        // POST: TempsCoureurBorne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEMPSCOUBORNE tEMPSCOUBORNE = db.TEMPSCOUBORNEs.Find(id);
            db.TEMPSCOUBORNEs.Remove(tEMPSCOUBORNE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TempsCoureurBorne/VoirTemps/5
        public ActionResult VoirTemps(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPSCOUBORNE tEMPSCOUBORNE = db.TEMPSCOUBORNEs.Find(id);
            if (tEMPSCOUBORNE == null)
            {
                return HttpNotFound();
            }
            return View(tEMPSCOUBORNE);
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
