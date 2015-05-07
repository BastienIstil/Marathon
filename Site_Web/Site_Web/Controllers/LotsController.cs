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
    public class LotsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Lots
        public ActionResult Index()
        {
            var lOTs = db.LOTs.Include(l => l.T_E_COUREUR_COU);
            return View(lOTs.ToList());
        }

        // GET: Lots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOT lOT = db.LOTs.Find(id);
            if (lOT == null)
            {
                return HttpNotFound();
            }
            return View(lOT);
        }

        // GET: Lots/Create
        public ActionResult Create()
        {
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM");
            return View();
        }

        // POST: Lots/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOT_ID,COU_ID,LOT_NOM")] LOT lOT)
        {
            if (ModelState.IsValid)
            {
                db.LOTs.Add(lOT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", lOT.COU_ID);
            return View(lOT);
        }

        // GET: Lots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOT lOT = db.LOTs.Find(id);
            if (lOT == null)
            {
                return HttpNotFound();
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", lOT.COU_ID);
            return View(lOT);
        }

        // POST: Lots/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOT_ID,COU_ID,LOT_NOM")] LOT lOT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", lOT.COU_ID);
            return View(lOT);
        }

        // GET: Lots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOT lOT = db.LOTs.Find(id);
            if (lOT == null)
            {
                return HttpNotFound();
            }
            return View(lOT);
        }

        // POST: Lots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOT lOT = db.LOTs.Find(id);
            db.LOTs.Remove(lOT);
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
