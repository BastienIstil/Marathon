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
    public class CategoriesController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.CATEGORIEs.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CAT_ID,CAT_LIBELLE")] CATEGORIE cATEGORIE)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIEs.Add(cATEGORIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIE);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // POST: Categories/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CAT_ID,CAT_LIBELLE")] CATEGORIE cATEGORIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIE);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            db.CATEGORIEs.Remove(cATEGORIE);
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
