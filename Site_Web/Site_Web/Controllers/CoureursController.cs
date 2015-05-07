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
    public class CoureursController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Coureurs
        public ActionResult Index()
        {
            var cOUREURs = db.COUREURs.Include(c => c.T_R_CLUB_CLU).Include(c => c.T_R_CATEGORIE_CAT);
            return View(cOUREURs.ToList());
        }

        // GET: Coureurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COUREUR cOUREUR = db.COUREURs.Find(id);
            if (cOUREUR == null)
            {
                return HttpNotFound();
            }
            return View(cOUREUR);
        }

        // GET: Coureurs/Create
        public ActionResult Create()
        {
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM");
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE");
            return View();
        }

        // POST: Coureurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COU_ID,CAT_ID,CLU_ID,COU_PRENOM,COU_NOM,COU_DATENAISSANCE,COU_SEXE,COU_NUMEROLICENCE,COU_FEDERATION,COU_EMAIL,COU_ADRESSE,COU_CODEPOSTAL,COU_VILLE,COU_PAYS,COU_TELEPHONE,COU_FAX,COU_ENTREPRISEGROUPEASSOCIATION,COU_CERTIFICATMEDICAL")] COUREUR cOUREUR)
        {
            if (ModelState.IsValid)
            {
                db.COUREURs.Add(cOUREUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", cOUREUR.CLU_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            return View(cOUREUR);
        }

        // GET: Coureurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COUREUR cOUREUR = db.COUREURs.Find(id);
            if (cOUREUR == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", cOUREUR.CLU_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            return View(cOUREUR);
        }

        // POST: Coureurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COU_ID,CAT_ID,CLU_ID,COU_PRENOM,COU_NOM,COU_DATENAISSANCE,COU_SEXE,COU_NUMEROLICENCE,COU_FEDERATION,COU_EMAIL,COU_ADRESSE,COU_CODEPOSTAL,COU_VILLE,COU_PAYS,COU_TELEPHONE,COU_FAX,COU_ENTREPRISEGROUPEASSOCIATION,COU_CERTIFICATMEDICAL")] COUREUR cOUREUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOUREUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", cOUREUR.CLU_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            return View(cOUREUR);
        }

        // GET: Coureurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COUREUR cOUREUR = db.COUREURs.Find(id);
            if (cOUREUR == null)
            {
                return HttpNotFound();
            }
            return View(cOUREUR);
        }

        // POST: Coureurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COUREUR cOUREUR = db.COUREURs.Find(id);
            db.COUREURs.Remove(cOUREUR);
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
