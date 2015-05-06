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
    public class DefisController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Defis
        public ActionResult Index()
        {
            return View(db.DEFIs.ToList());
        }

        // GET: Defis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEFI dEFI = db.DEFIs.Find(id);
            if (dEFI == null)
            {
                return HttpNotFound();
            }
            return View(dEFI);
        }

        // GET: Defis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Defis/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEF_ID,DEF_NOM,DEF_NOMBREMAXPARTICIPANT")] DEFI dEFI)
        {
            if (ModelState.IsValid)
            {
                db.DEFIs.Add(dEFI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEFI);
        }

        // GET: Defis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEFI dEFI = db.DEFIs.Find(id);
            if (dEFI == null)
            {
                return HttpNotFound();
            }
            return View(dEFI);
        }

        // POST: Defis/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEF_ID,DEF_NOM,DEF_NOMBREMAXPARTICIPANT")] DEFI dEFI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEFI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEFI);
        }

        // GET: Defis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEFI dEFI = db.DEFIs.Find(id);
            if (dEFI == null)
            {
                return HttpNotFound();
            }
            return View(dEFI);
        }

        // POST: Defis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEFI dEFI = db.DEFIs.Find(id);
            db.DEFIs.Remove(dEFI);
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
