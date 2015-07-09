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
    public class CoursesController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.COURSEs.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COR_NOM,COR_DISTANCE,COR_DATE,COR_NOMBREMAXPARTICIPANT,COR_PRIX")] COURSE cOURSE)
        {
            if (ModelState.IsValid)
            {
                db.COURSEs.Add(cOURSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOURSE);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        // POST: Courses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COR_ID,COR_NOM,COR_DISTANCE,COR_DATE,COR_NOMBREMAXPARTICIPANT,COR_PRIX")] COURSE cOURSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOURSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOURSE);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COURSE cOURSE = db.COURSEs.Find(id);
            db.COURSEs.Remove(cOURSE);
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
