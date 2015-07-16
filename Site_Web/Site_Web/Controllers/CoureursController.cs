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
    /// Coureurs controller est le controlleur gérant le CRUD et différente vues lié au model COUREUR.
    /// </summary>
    public class CoureursController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des bornes.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            var cOUREURs = db.COUREURs.Include(c => c.T_R_FEDERATION_FED).Include(c => c.T_R_CLUB_CLU).Include(c => c.T_R_CATEGORIE_CAT).Include(c => c.T_E_INSCRIT_INS);
            return View(cOUREURs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'un coureur
        /// </summary>
        /// <param name="id">L'id correspondant au coureur devant être détaillé.</param>
        /// <returns>La view detail avec les informations du coureur fournie en paramètre.</returns>
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

        /// <summary>
        /// Permet la création d'un coureur.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera un nouveau coureur.
        /// </returns>
        public ActionResult Create()
        {
            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM");
            ViewBag.CLU_ID = new SelectList(db.CLUBs, "CLU_ID", "CLU_NOM");
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE");
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN");
            return View();
        }

        /// <summary>
        /// Permet la création d'un coureur en POST.
        /// </summary>
        /// <param name="cOUREUR">Le coureur correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
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

        /// <summary>
        /// Permet la modification d'un coureur en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au coureur devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ledit coureur.
        /// </returns>
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

        /// <summary>
        /// Permet la modification d'un coureur en POST.
        /// </summary>
        /// <param name="cOUREUR">Le coureur correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
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

        /// <summary>
        /// Permet la suppression d'un coureur en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au coureur devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
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

        /// <summary>
        /// Permet la suppression d'un coureur en POST.
        /// </summary>
        /// <param name="id">L'id correspondant au coureur devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
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


        /// <summary>
        /// Permet l'édition d'un inscrit (inscrit à une course)
        /// </summary>
        /// <returns>La view index si la validation est bonne.</returns>
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

        /// <summary>
        /// Permet l'édition d'un inscrit (inscrit à une course) en ajoutant son certificat médical
        /// </summary>
        /// <param name="cOUREUR">L'id correspondant a l'inscrit devant être modifié.</param>
        /// <param name="file">Le fichier devant être ajouté et affilié à l'inscrit</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(COUREUR cOUREUR,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string certif = "";
                string fileRepository = ""; 
                string path = "";
                // file is uploaded

                if(file != null)
                    certif = System.IO.Path.GetFileName(file.FileName);

                if (!db.COUREURs.Any(d => d.COU_ID == cOUREUR.COU_ID))
                {
                    INSCRIT inscrit = (from u in db.INSCRITs
                                       where u.INS_LOGIN == User.Identity.Name
                                       select u).First();

                    cOUREUR.INS_ID = inscrit.INS_ID;
                    cOUREUR.CAT_ID = Site_Web.Class_Metier.UpdateCat.getCat(cOUREUR.COU_DATENAISSANCE);


                    if (file != null)
                    {
                        fileRepository = System.IO.Path.Combine(User.Identity.Name, certif);
                        path = System.IO.Path.Combine(Server.MapPath("~/document/coureur"), fileRepository);
                        cOUREUR.COU_CERTIFICATMEDICAL = path;
                    }

                    db.COUREURs.Add(cOUREUR);
                }
                else
                {
                    cOUREUR.CAT_ID = Site_Web.Class_Metier.UpdateCat.getCat(cOUREUR.COU_DATENAISSANCE);

                    if (file != null)
                    {
                        fileRepository = System.IO.Path.Combine(User.Identity.Name, certif);
                        path = System.IO.Path.Combine(Server.MapPath("~/document/coureur"), fileRepository);
                        cOUREUR.COU_CERTIFICATMEDICAL = path;
                    }
                    db.Entry(cOUREUR).State = EntityState.Modified;
                }


                db.SaveChanges();

                if (file != null)
                {
                    if (System.IO.Directory.Exists(Server.MapPath("~/document")) == false)
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/document"));
                    if (System.IO.Directory.Exists(Server.MapPath("~/document/coureur")) == false)
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/document/coureur"));
                    if (System.IO.Directory.Exists(Server.MapPath("~/document/coureur/" + User.Identity.Name)) == false)
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/document/coureur/" + User.Identity.Name));
                    file.SaveAs(path);
                }

                return RedirectToAction("EditProfile", "Coureurs");
            } 

            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", cOUREUR.FED_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", cOUREUR.CAT_ID);
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", cOUREUR.INS_ID);

            return View(cOUREUR);
        }
    }
}
