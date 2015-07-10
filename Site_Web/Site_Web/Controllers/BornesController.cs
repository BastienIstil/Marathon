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
    /// Bornes controller est le controlleur gérant le CRUD et différente vues lié au model BORNE.
    /// </summary>
    public class BornesController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        

        /// <summary>
        /// Index du CRUD des bornes.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            var bORNEs = db.BORNEs.Include(b => b.T_R_COURSE_COR);
            return View(bORNEs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'une borne
        /// </summary>
        /// <param name="id">L'id correspondant à la borne devant être détaillé.</param>
        /// <returns>La view detail avec les informations de la borne fournie en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORNE bORNE = db.BORNEs.Find(id);
            if (bORNE == null)
            {
                return HttpNotFound();
            }
            return View(bORNE);
        }

        /// <summary>
        /// Permet la création d'une borne.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera une nouvelle borne.
        /// </returns>
        public ActionResult Create()
        {
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            return View();
        }

        /// <summary>
        /// Permet la création d'une borne en POST.
        /// </summary>
        /// <param name="bORNE">La borne correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOR_ID,COR_ID,BOR_EMPLACEMENT")] BORNE bORNE)
        {
            if (ModelState.IsValid)
            {
                db.BORNEs.Add(bORNE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", bORNE.COR_ID);
            return View(bORNE);
        }

        /// <summary>
        /// Permet la modification d'une borne en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la borne devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ladite borne.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORNE bORNE = db.BORNEs.Find(id);
            if (bORNE == null)
            {
                return HttpNotFound();
            }
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", bORNE.COR_ID);
            return View(bORNE);
        }

        /// <summary>
        /// Permet la modification d'une borne en POST.
        /// </summary>
        /// <param name="bORNE">La borne correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOR_ID,COR_ID,BOR_EMPLACEMENT")] BORNE bORNE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bORNE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM", bORNE.COR_ID);
            return View(bORNE);
        }

        /// <summary>
        /// Permet la suppression d'une borne en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la borne devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BORNE bORNE = db.BORNEs.Find(id);
            if (bORNE == null)
            {
                return HttpNotFound();
            }
            return View(bORNE);
        }

        /// <summary>
        /// Permet la suppression d'une borne en POST.
        /// </summary>
        /// <param name="id">L'id correspondant à la borne devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BORNE bORNE = db.BORNEs.Find(id);
            db.BORNEs.Remove(bORNE);
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
