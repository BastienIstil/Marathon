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
    public class GenerationsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Generations
        public ActionResult Index()
        {
            var gENERATIONs = db.GENERATIONs.Include(g => g.T_E_CLASSEMENT_CLA).Include(g => g.T_E_COUREUR_COU).Include(g => g.T_R_COURSE_COR);
            return View(gENERATIONs.ToList());
        }

        // GET: Generations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENERATION gENERATION = db.GENERATIONs.Find(id);
            if (gENERATION == null)
            {
                return HttpNotFound();
            }
            return View(gENERATION);
        }

        // GET: Generations/Create
        public ActionResult Create()
        {
            ViewBag.CLA_ID = new SelectList(db.CLASSEMENTs, "CLA_ID", "CLA_ID");
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM");
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            return View();
        }

        // POST: Generations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GEN_ID,COU_ID,CLA_ID,COR_ID")] GENERATION gENERATION)
        {
            if (ModelState.IsValid)
            {
                db.GENERATIONs.Add(gENERATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLA_ID = new SelectList(db.CLASSEMENTs, "CLA_ID", "CLA_ID", gENERATION.CLA_ID);
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM", gENERATION.COU_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", gENERATION.COR_ID);
            return View(gENERATION);
        }

        // GET: Generations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENERATION gENERATION = db.GENERATIONs.Find(id);
            if (gENERATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLA_ID = new SelectList(db.CLASSEMENTs, "CLA_ID", "CLA_ID", gENERATION.CLA_ID);
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM", gENERATION.COU_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", gENERATION.COR_ID);
            return View(gENERATION);
        }

        // POST: Generations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GEN_ID,COU_ID,CLA_ID,COR_ID")] GENERATION gENERATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gENERATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLA_ID = new SelectList(db.CLASSEMENTs, "CLA_ID", "CLA_ID", gENERATION.CLA_ID);
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_PRENOM", gENERATION.COU_ID);
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", gENERATION.COR_ID);
            return View(gENERATION);
        }

        // GET: Generations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENERATION gENERATION = db.GENERATIONs.Find(id);
            if (gENERATION == null)
            {
                return HttpNotFound();
            }
            return View(gENERATION);
        }

        // POST: Generations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENERATION gENERATION = db.GENERATIONs.Find(id);
            db.GENERATIONs.Remove(gENERATION);
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
