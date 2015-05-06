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
    public class PaimentsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Paiments
        public ActionResult Index()
        {
            return View(db.PAIEMENTs.ToList());
        }

        // GET: Paiments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIEMENT pAIEMENT = db.PAIEMENTs.Find(id);
            if (pAIEMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAIEMENT);
        }

        // GET: Paiments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paiments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PAI_ID,PAI_MONTANT,PAI_MOYENDEPAIEMENT,PAI_DATEPAIEMENT")] PAIEMENT pAIEMENT)
        {
            if (ModelState.IsValid)
            {
                db.PAIEMENTs.Add(pAIEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAIEMENT);
        }

        // GET: Paiments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIEMENT pAIEMENT = db.PAIEMENTs.Find(id);
            if (pAIEMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAIEMENT);
        }

        // POST: Paiments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PAI_ID,PAI_MONTANT,PAI_MOYENDEPAIEMENT,PAI_DATEPAIEMENT")] PAIEMENT pAIEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAIEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAIEMENT);
        }

        // GET: Paiments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIEMENT pAIEMENT = db.PAIEMENTs.Find(id);
            if (pAIEMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAIEMENT);
        }

        // POST: Paiments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAIEMENT pAIEMENT = db.PAIEMENTs.Find(id);
            db.PAIEMENTs.Remove(pAIEMENT);
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
