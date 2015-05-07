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
    public class InformationsPubliqueController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: InformationsPublique
        public ActionResult Index()
        {
            return View(db.INFORMATIONPUBLIQUEs.ToList());
        }

        // GET: InformationsPublique/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            if (iNFORMATIONPUBLIQUE == null)
            {
                return HttpNotFound();
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        // GET: InformationsPublique/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformationsPublique/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "INF_ID,INF_NOM,INF_PRENOM,INF_EMAIL,INF_CONTENUE")] INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE)
        {
            if (ModelState.IsValid)
            {
                db.INFORMATIONPUBLIQUEs.Add(iNFORMATIONPUBLIQUE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNFORMATIONPUBLIQUE);
        }

        // GET: InformationsPublique/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            if (iNFORMATIONPUBLIQUE == null)
            {
                return HttpNotFound();
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        // POST: InformationsPublique/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "INF_ID,INF_NOM,INF_PRENOM,INF_EMAIL,INF_CONTENUE")] INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNFORMATIONPUBLIQUE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        // GET: InformationsPublique/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            if (iNFORMATIONPUBLIQUE == null)
            {
                return HttpNotFound();
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        // POST: InformationsPublique/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            db.INFORMATIONPUBLIQUEs.Remove(iNFORMATIONPUBLIQUE);
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
