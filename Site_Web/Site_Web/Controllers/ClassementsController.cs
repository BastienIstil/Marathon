﻿using System;
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
    public class ClassementsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Classements
        public ActionResult Index()
        {
            return View(db.CLASSEMENTs.ToList());
        }

        // GET: Classements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            if (cLASSEMENT == null)
            {
                return HttpNotFound();
            }
            return View(cLASSEMENT);
        }

        // GET: Classements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLA_ID,CLA_TEMPS")] CLASSEMENT cLASSEMENT)
        {
            if (ModelState.IsValid)
            {
                db.CLASSEMENTs.Add(cLASSEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLASSEMENT);
        }

        // GET: Classements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            if (cLASSEMENT == null)
            {
                return HttpNotFound();
            }
            return View(cLASSEMENT);
        }

        // POST: Classements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLA_ID,CLA_TEMPS")] CLASSEMENT cLASSEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASSEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLASSEMENT);
        }

        // GET: Classements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            if (cLASSEMENT == null)
            {
                return HttpNotFound();
            }
            return View(cLASSEMENT);
        }

        // POST: Classements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            db.CLASSEMENTs.Remove(cLASSEMENT);
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