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
            var cOUREURs = db.COUREURs.Include(c => c.T_R_FEDERATION_FED).Include(c => c.T_R_CLUB_CLU).Include(c => c.T_R_CATEGORIE_CAT).Include(c => c.T_E_INSCRIT_INS);
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
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM");
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM");
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE");
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN");
            return View();
        }

        // POST: Coureurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(COUREUR cOUREUR)
        {
            if (ModelState.IsValid)
            {
                db.COUREURs.Add(cOUREUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cOUREUR.FED_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", cOUREUR.CLU_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cOUREUR.INS_ID);
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
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cOUREUR.FED_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", cOUREUR.CLU_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cOUREUR.INS_ID);
            return View(cOUREUR);
        }

        // POST: Coureurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(COUREUR cOUREUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOUREUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cOUREUR.FED_ID);
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM", cOUREUR.CLU_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cOUREUR.INS_ID);
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


        // GET: Coureurs/Edit/5
        public ActionResult EditProfile()
        {
            INSCRIT inscrit = (from u in db.INSCRITs
                               where u.INS_LOGIN == User.Identity.Name
                               select u).First();

            int idInscrit = inscrit.INS_ID;

            List<COUREUR> listCourreur = (from c in db.COUREURs
                                          where c.INS_ID == idInscrit
                                          select c).ToList();

            COUREUR courreur;

            if (listCourreur.Count() == 0)
            {
                courreur = new COUREUR();
                courreur.COU_EMAIL = User.Identity.Name;
            }
            else
                courreur = listCourreur.ElementAt(0);

            courreur.INS_ID = idInscrit;

            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", courreur.FED_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", courreur.CAT_ID);
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", courreur.INS_ID);
            return View(courreur);
        }

        // POST: Coureurs/Profile/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(COUREUR cOUREUR)
        {
            if (ModelState.IsValid)
            {
                if (!db.COUREURs.Any(d => d.COU_ID == cOUREUR.COU_ID))
                {
                    INSCRIT inscrit = (from u in db.INSCRITs
                                       where u.INS_LOGIN == User.Identity.Name
                                       select u).First();

                    cOUREUR.INS_ID = inscrit.INS_ID;
                    cOUREUR.CAT_ID = Site_Web.Class_Metier.UpdateCat.getCat(cOUREUR.COU_DATENAISSANCE);
                    db.COUREURs.Add(cOUREUR);
                }
                else
                {
                    cOUREUR.CAT_ID = Site_Web.Class_Metier.UpdateCat.getCat(cOUREUR.COU_DATENAISSANCE);
                    db.Entry(cOUREUR).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("EditProfile", "Coureurs");
            } 

            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cOUREUR.FED_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cOUREUR.INS_ID);

            return View(cOUREUR);
        }
    }
}
