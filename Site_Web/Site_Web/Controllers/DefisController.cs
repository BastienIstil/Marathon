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
    /// Defis controller est le controlleur gérant le CRUD et différente vues lié au model DEFI.
    /// </summary>
    public class DefisController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des defis.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            return View(db.DEFIs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'un defi
        /// </summary>
        /// <param name="id">L'id correspondant au defi devant être détaillé.</param>
        /// <returns>La view detail avec les informations du defi fournie en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEFI dEFI = db.DEFIs.Find(id);
            if (dEFI == null)
            {
                return HttpNotFound();
            }
            return View(dEFI);
        }

        /// <summary>
        /// Permet la création d'un defi.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera un nouveau defi.
        /// </returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Permet la création d'un defi en POST.
        /// </summary>
        /// <param name="dEFI">Le defi correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEF_ID,DEF_NOM,DEF_NOMBREMAXPARTICIPANT")] DEFI dEFI)
        {
            if (ModelState.IsValid)
            {
                db.DEFIs.Add(dEFI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEFI);
        }

        /// <summary>
        /// Permet la modification d'un defi en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au defi devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ledit defi.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEFI dEFI = db.DEFIs.Find(id);
            if (dEFI == null)
            {
                return HttpNotFound();
            }
            return View(dEFI);
        }

        /// <summary>
        /// Permet la modification d'un defi en POST.
        /// </summary>
        /// <param name="dEFI">Le defi correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEF_ID,DEF_NOM,DEF_NOMBREMAXPARTICIPANT")] DEFI dEFI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEFI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEFI);
        }

        /// <summary>
        /// Permet la suppression d'un defi en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au defi devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEFI dEFI = db.DEFIs.Find(id);
            if (dEFI == null)
            {
                return HttpNotFound();
            }
            return View(dEFI);
        }

        /// <summary>
        /// Permet la suppression d'un defi en POST.
        /// </summary>
        /// <param name="id">L'id correspondant au defi devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEFI dEFI = db.DEFIs.Find(id);
            db.DEFIs.Remove(dEFI);
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
