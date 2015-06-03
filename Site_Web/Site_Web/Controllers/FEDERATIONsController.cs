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
    public class FederationsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: FEDERATIONs
        public ActionResult Index()
        {
            return View(db.FEDERATIONs.ToList());
        }

        // GET: FEDERATIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            if (fEDERATION == null)
            {
                return HttpNotFound();
            }
            return View(fEDERATION);
        }

        // GET: FEDERATIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FEDERATIONs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FED_ID,FED_NOM")] FEDERATION fEDERATION)
        {
            if (ModelState.IsValid)
            {
                db.FEDERATIONs.Add(fEDERATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fEDERATION);
        }

        // GET: FEDERATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            if (fEDERATION == null)
            {
                return HttpNotFound();
            }
            return View(fEDERATION);
        }

        // POST: FEDERATIONs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FED_ID,FED_NOM")] FEDERATION fEDERATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fEDERATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fEDERATION);
        }

        // GET: FEDERATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            if (fEDERATION == null)
            {
                return HttpNotFound();
            }
            return View(fEDERATION);
        }

        // POST: FEDERATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            db.FEDERATIONs.Remove(fEDERATION);
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
