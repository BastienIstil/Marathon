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
    /// Categories controller est le controlleur gérant le CRUD et différente vues lié au model BORNE.
    /// </summary>
    public class CategoriesController : Controller
    {


        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des catégories.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            return View(db.CATEGORIEs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'une catégorie.
        /// </summary>
        /// <param name="id">L'id correspondant à la catégorie devant être détaillée.</param>
        /// <returns>La view detail avec les informations de la catégorie fournie en paramètre.</returns>
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

        /// <summary>
        /// Permet la création d'une catégorie.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera une nouvelle catégorie.
        /// </returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Permet la création d'une catégorie en POST.
        /// </summary>
        /// <param name="cATEGORIE">La catégorie correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
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

        /// <summary>
        /// Permet la modification d'une catégorie en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la catégorie devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ladite catégorie.
        /// </returns>
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

        /// <summary>
        /// Permet la modification d'une catégorie en POST.
        /// </summary>
        /// <param name="cATEGORIE">La catégorie correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
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

        /// <summary>
        /// Permet la suppression d'une catégorie en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la catégorie devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
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

        /// <summary>
        /// Permet la suppression d'une catégorie en POST.
        /// </summary>
        /// <param name="id">L'id correspondant à la catégorie devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            db.CATEGORIEs.Remove(cATEGORIE);
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
