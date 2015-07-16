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
    /// InformationPublique est le controlleur gérant le CRUD et différente vues lié au model INFORMATIONPUBLIQUE.
    /// </summary>
    public class InformationPubliqueController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des informations publiques.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            return View(db.INFORMATIONPUBLIQUEs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'une information publique.
        /// </summary>
        /// <param name="id">L'id correspondant à l'information publique devant être détaillé.</param>
        /// <returns>La view detail avec les informations de l'information publique fournie en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            if (iNFORMATIONPUBLIQUE == null)
            {
                return HttpNotFound();
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        /// <summary>
        /// Permet la création d'une information publique.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera une nouvelle information publique.
        /// </returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Permet la création d'une information publique en POST.
        /// </summary>
        /// <param name="iNFORMATIONPUBLIQUE">L'information publique correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "INF_ID,INF_NOM,INF_PRENOM,INF_EMAIL,INF_CONTENUE,INF_TITRE")] INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE)
        {
            if (ModelState.IsValid)
            {
                db.INFORMATIONPUBLIQUEs.Add(iNFORMATIONPUBLIQUE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNFORMATIONPUBLIQUE);
        }

        /// <summary>
        /// Permet la modification d'une information publique en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à l'information publique devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ladite information publique.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            if (iNFORMATIONPUBLIQUE == null)
            {
                return HttpNotFound();
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        /// <summary>
        /// Permet la modification d'une information publique en POST.
        /// </summary>
        /// <param name="iNFORMATIONPUBLIQUE">L'information publique correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "INF_ID,INF_NOM,INF_PRENOM,INF_EMAIL,INF_CONTENUE,INF_TITRE")] INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNFORMATIONPUBLIQUE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        /// <summary>
        /// Permet la suppression d'une information publique en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à l'information publique devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            if (iNFORMATIONPUBLIQUE == null)
            {
                return HttpNotFound();
            }
            return View(iNFORMATIONPUBLIQUE);
        }

        /// <summary>
        /// Permet la suppression d'une information publique en POST.
        /// </summary>
        /// <param name="id">L'id correspondant à l'information publique devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INFORMATIONPUBLIQUE iNFORMATIONPUBLIQUE = db.INFORMATIONPUBLIQUEs.Find(id);
            db.INFORMATIONPUBLIQUEs.Remove(iNFORMATIONPUBLIQUE);
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
