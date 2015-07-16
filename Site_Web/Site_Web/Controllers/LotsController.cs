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
    /// <summary>
    /// Lots controller est le controlleur gérant le CRUD et différente vues lié au model LOT.
    /// </summary>
    public class LotsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des lots.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            var lOTs = db.LOTs.Include(l => l.T_E_COUREUR_COU);
            return View(lOTs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'un lot.
        /// </summary>
        /// <param name="id">L'id correspondant au lot devant être détaillé.</param>
        /// <returns>La view detail avec les informations du lot fournie en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOT lOT = db.LOTs.Find(id);
            if (lOT == null)
            {
                return HttpNotFound();
            }
            return View(lOT);
        }

        /// <summary>
        /// Permet la création d'un lot.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera un nouveau lot.
        /// </returns>
        public ActionResult Create()
        {
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM");
            return View();
        }

        /// <summary>
        /// Permet la création d'un lot en POST.
        /// </summary>
        /// <param name="lOT">Le lot correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOT_ID,COU_ID,LOT_NOM")] LOT lOT)
        {
            if (ModelState.IsValid)
            {
                db.LOTs.Add(lOT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", lOT.COU_ID);
            return View(lOT);
        }

        /// <summary>
        /// Permet la modification d'un lot en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au lot devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ledit lot.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOT lOT = db.LOTs.Find(id);
            if (lOT == null)
            {
                return HttpNotFound();
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", lOT.COU_ID);
            return View(lOT);
        }

        /// <summary>
        /// Permet la modification d'un lot en POST.
        /// </summary>
        /// <param name="lOT">Le lot correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOT_ID,COU_ID,LOT_NOM")] LOT lOT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", lOT.COU_ID);
            return View(lOT);
        }

        /// <summary>
        /// Permet la suppression d'un lot en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au lot devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOT lOT = db.LOTs.Find(id);
            if (lOT == null)
            {
                return HttpNotFound();
            }
            return View(lOT);
        }

        /// <summary>
        /// Permet la suppression d'un lot en POST.
        /// </summary>
        /// <param name="id">L'id correspondant au lot devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOT lOT = db.LOTs.Find(id);
            db.LOTs.Remove(lOT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Destructeur de l'objet
        /// </summary>
        /// <param name="disposing">Le paramètre disposing est un booléen qui indique si l'appel de la méthode provient d'une méthode Dispose (sa valeur est true) ou d'un Finalize (sa valeur est false).</param>
        
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
