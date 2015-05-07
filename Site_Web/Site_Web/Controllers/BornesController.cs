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
    public class BornesController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Bornes
        public ActionResult Index()
        {
            var bORNEs = db.BORNEs.Include(b => b.T_R_COURSE_COR);
            return View(bORNEs.ToList());
        }

        // GET: Bornes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORNE bORNE = db.BORNEs.Find(id);
            if (bORNE == null)
            {
                return HttpNotFound();
            }
            return View(bORNE);
        }

        // GET: Bornes/Create
        public ActionResult Create()
        {
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            return View();
        }

        // POST: Bornes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOR_ID,COR_ID,BOR_EMPLACEMENT")] BORNE bORNE)
        {
            if (ModelState.IsValid)
            {
                db.BORNEs.Add(bORNE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", bORNE.COR_ID);
            return View(bORNE);
        }

        // GET: Bornes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORNE bORNE = db.BORNEs.Find(id);
            if (bORNE == null)
            {
                return HttpNotFound();
            }
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", bORNE.COR_ID);
            return View(bORNE);
        }

        // POST: Bornes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOR_ID,COR_ID,BOR_EMPLACEMENT")] BORNE bORNE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bORNE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", bORNE.COR_ID);
            return View(bORNE);
        }

        // GET: Bornes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORNE bORNE = db.BORNEs.Find(id);
            if (bORNE == null)
            {
                return HttpNotFound();
            }
            return View(bORNE);
        }

        // POST: Bornes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BORNE bORNE = db.BORNEs.Find(id);
            db.BORNEs.Remove(bORNE);
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
