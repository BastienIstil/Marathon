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
    /// Federations controller est le controlleur gérant le CRUD et différente vues lié au model FEDERATION.
    /// </summary>
    public class FederationsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des federations.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            return View(db.FEDERATIONs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'une federation
        /// </summary>
        /// <param name="id">L'id correspondant à la federation devant être détaillé.</param>
        /// <returns>La view detail avec les informations de la federation fournie en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            if (fEDERATION == null)
            {
                return HttpNotFound();
            }
            return View(fEDERATION);
        }

        /// <summary>
        /// Permet la création d'une federation.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera une nouvelle federation.
        /// </returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Permet la création d'une federation en POST.
        /// </summary>
        /// <param name="fEDERATION">La federation correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FED_ID,FED_NOM")] FEDERATION fEDERATION)
        {
            if (ModelState.IsValid)
            {
                db.FEDERATIONs.Add(fEDERATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fEDERATION);
        }

        /// <summary>
        /// Permet la modification d'une federation en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la federation devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ladite federation.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            if (fEDERATION == null)
            {
                return HttpNotFound();
            }
            return View(fEDERATION);
        }

        /// <summary>
        /// Permet la modification d'une federation en POST.
        /// </summary>
        /// <param name="fEDERATION">La federation correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FED_ID,FED_NOM")] FEDERATION fEDERATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fEDERATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fEDERATION);
        }

        /// <summary>
        /// Permet la suppression d'une federation en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la federation devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            if (fEDERATION == null)
            {
                return HttpNotFound();
            }
            return View(fEDERATION);
        }

        /// <summary>
        /// Permet la suppression d'une federation en POST.
        /// </summary>
        /// <param name="id">L'id correspondant à la federation devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FEDERATION fEDERATION = db.FEDERATIONs.Find(id);
            db.FEDERATIONs.Remove(fEDERATION);
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
        public ActionResult Modif(int? id)
        {
            return View(db.FEDERATIONs.ToList());
        }
    }
}
