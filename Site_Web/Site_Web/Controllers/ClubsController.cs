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
    public class ClubsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: CLUBs
        public ActionResult Index()
        {
            var cLUBs = db.CLUBs.Include(c => c.T_E_INSCRIT_INS).Include(c => c.T_R_FEDERATION_FED);
            return View(cLUBs.ToList());
        }

        // GET: CLUBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLUB cLUB = db.CLUBs.Find(id);
            if (cLUB == null)
            {
                return HttpNotFound();
            }
            return View(cLUB);
        }

        // GET: CLUBs/Create
        public ActionResult Create()
        {
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN");
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM");
            return View();
        }

        // POST: CLUBs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLU_ID,FED_ID,INS_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL,CLU_ADRESSE,CLU_CODEPOSTAL,CLU_VILLE,CLU_PAYS,CLU_TELEPHONE,CLU_FAX,CLU_NUMERO")] CLUB cLUB)
        {
            if (ModelState.IsValid)
            {
                db.CLUBs.Add(cLUB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cLUB.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cLUB.FED_ID);
            return View(cLUB);
        }

        // GET: CLUBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLUB cLUB = db.CLUBs.Find(id);
            if (cLUB == null)
            {
                return HttpNotFound();
            }
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cLUB.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cLUB.FED_ID);
            return View(cLUB);
        }

        // POST: CLUBs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLU_ID,FED_ID,INS_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL,CLU_ADRESSE,CLU_CODEPOSTAL,CLU_VILLE,CLU_PAYS,CLU_TELEPHONE,CLU_FAX,CLU_NUMERO")] CLUB cLUB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLUB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cLUB.INS_ID);
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cLUB.FED_ID);
            return View(cLUB);
        }

        // GET: CLUBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLUB cLUB = db.CLUBs.Find(id);
            if (cLUB == null)
            {
                return HttpNotFound();
            }
            return View(cLUB);
        }

        // POST: CLUBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLUB cLUB = db.CLUBs.Find(id);
            db.CLUBs.Remove(cLUB);
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

        public ActionResult EditProfile()
        {
            INSCRIT inscrit = (from u in db.INSCRITs
                               where u.INS_LOGIN == User.Identity.Name
                               select u).First();

            int idInscrit = inscrit.INS_ID;

            List<CLUB> listClub = (from c in db.CLUBs
                                   where c.INS_ID == idInscrit
                                   select c).ToList();

            CLUB club;

            if (listClub.Count() == 0)
            {
                club = new CLUB();
                club.CLU_EMAIL = User.Identity.Name;
            }
            else
                club = listClub.ElementAt(0);

            club.INS_ID = idInscrit;
            return View(club);
        }

        // POST: Coureurs/Profile/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "CLU_ID,FED_ID,INS_ID,CLU_NOM,CLU_LICENCE,CLU_EMAIL,CLU_ADRESSE,CLU_CODEPOSTAL,CLU_VILLE,CLU_PAYS,CLU_TELEPHONE,CLU_FAX,CLU_NUMERO")] CLUB club)
        {
            if (ModelState.IsValid)
            {
                if (!db.COUREURs.Any(d => d.CLU_ID == club.CLU_ID))
                {
                    INSCRIT inscrit = (from u in db.INSCRITs
                                       where u.INS_LOGIN == User.Identity.Name
                                       select u).First();

                    club.INS_ID = inscrit.INS_ID;
                    db.CLUBs.Add(club);
                }
                else
                {
                    db.Entry(club).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(club);
        }
    }
}
