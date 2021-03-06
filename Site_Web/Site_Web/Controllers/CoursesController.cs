﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site_Web.App_Data;
using Site_Web.Class_Metier.ViewCustomModels;

namespace Site_Web.Controllers
{
    /// <summary>
    /// Courses controller est le controlleur gérant le CRUD et différente vues lié au model COURSE.
    /// </summary>
    public class CoursesController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index du CRUD des courses.
        /// </summary>
        /// <returns> la view Index.</returns>
        public ActionResult Index()
        {
            return View(db.COURSEs.ToList());
        }

        /// <summary>
        /// Affiche le detail d'une course.
        /// </summary>
        /// <param name="id">L'id correspondant à la course devant être détaillée.</param>
        /// <returns>La view detail avec les informations de la course fournie en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        /// <summary>
        /// Permet la création d'une course.
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera une nouvelle borne.
        /// </returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Permet la création d'une course en POST.
        /// </summary>
        /// <param name="cOURSE">La course correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COR_NOM,COR_DISTANCE,COR_DATE,COR_NOMBREMAXPARTICIPANT,COR_PRIX")] COURSE cOURSE)
        {
            if (ModelState.IsValid)
            {
                db.COURSEs.Add(cOURSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOURSE);
        }

        /// <summary>
        /// Permet la modification d'une course en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la course devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ladite course.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        /// <summary>
        /// Permet la modification d'une course en POST.
        /// </summary>
        /// <param name="cOURSE">La course correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COR_ID,COR_NOM,COR_DISTANCE,COR_DATE,COR_NOMBREMAXPARTICIPANT,COR_PRIX")] COURSE cOURSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOURSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOURSE);
        }

        /// <summary>
        /// Permet la suppression d'une course en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la course devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        /// <summary>
        /// Permet la suppression d'une course en POST.
        /// </summary>
        /// <param name="id">L'id correspondant à la course devant être supprimé.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COURSE cOURSE = db.COURSEs.Find(id);
            db.COURSEs.Remove(cOURSE);
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
        /// Permet l'inscription d'un coureur à une course
        /// </summary>
        /// <returns>La view inscription si la validation est bonne.</returns>
        [HttpGet, ActionName("InscriptionCoureurCourse")]
        public ActionResult InscriptionCoureurCourse()
        {
            // check if inscrit
            // On récupere l'inscrit
            INSCRIT inscrit = (from u in db.INSCRITs
                               where u.INS_LOGIN == User.Identity.Name
                               select u).First();

            int idInscrit = inscrit.INS_ID;

            // check if profile is set
            // On récupere le coureur
            COUREUR courreur = (from c in db.COUREURs
                                       where c.INS_ID == idInscrit
                                       select c).FirstOrDefault();

            if (courreur == null)
                return RedirectToAction("EditProfile", "Coureurs");
            // On récupere la liste de course de sa catégorie
            List<COURSE> courses = db.COURSEs.ToList();

            // On élimine les courses déjà pleine
            foreach (COURSE course in courses)
            {
                int count = (from p in db.PARTICIPATIONs.ToList()
                             where p.COR_ID == course.COR_ID
                             select p).ToList().Count();

                if (course.COR_NOMBREMAXPARTICIPANT <= count)
                    courses.Remove(course);
            }

            // On élimine les courses dont il fait déjà parti
            List<PARTICIPATION> listPariticipation = new List<PARTICIPATION>();

            foreach(COURSE course in courses){
               PARTICIPATION participation =   (from par in db.PARTICIPATIONs
                                                 where par.COU_ID == courreur.COU_ID && par.COR_ID == course.COR_ID
                                                select par).FirstOrDefault();

               if (participation == null) continue;

               listPariticipation.Add(participation);
            }

            foreach (PARTICIPATION par in listPariticipation)
            {
               COURSE course = (from cour in courses
                                where cour.COR_ID == par.COR_ID
                                select cour).First();
                courses.Remove(course);
            }
            

            // On envoie a la vue le coureur + la listes des courses + une liste de booléen

            InscriptionCourreurCourseModel inscription = new InscriptionCourreurCourseModel();

            inscription.coureur = courreur;
            inscription.listCourse = courses;
            inscription.listEtatInscription = new List<bool>();
            inscription.listEtatPastaParty = new List<bool>();
            inscription.tempsEstime = new List<int?>();

            foreach (COURSE course in courses)
            {
                inscription.listEtatInscription.Add(false);
                inscription.listEtatPastaParty.Add(false);
                inscription.tempsEstime.Add(null);
            }

            ViewBag.FED_ID = new SelectList(db.FEDERATIONs, "FED_ID", "FED_NOM", courreur.FED_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORIEs, "CAT_ID", "CAT_LIBELLE", courreur.CAT_ID);
            ViewBag.INS_ID = new SelectList(db.INSCRITs, "INS_ID", "INS_LOGIN", courreur.INS_ID);
            ViewBag.CLUB_ID = new SelectList(db.INSCRITs, "CLU_ID", "CLUB_ID", courreur.CLU_ID);

            return View(inscription);
        }


        /// <summary>
        /// Permet l'inscription d'un coureur à une course
        /// </summary>
        /// <param name="inscription">L'objet inscription pour la validation de celle-ci.</param>
        /// <returns>La view index si la validation est bonne.</returns>
        [HttpPost, ActionName("InscriptionCoureurCourse")]
        [ValidateAntiForgeryToken]
        public ActionResult InscriptionCoureurCourse(InscriptionCourreurCourseModel inscription)
        {
            if (inscription.listEtatInscription == null)
                return RedirectToAction("Index", "Home");


            for (int i = 0; i < inscription.listEtatInscription.Count; i++)
            {
                if (inscription.listEtatInscription[i]) // Participation Course
                {
                    PARTICIPATION par = new PARTICIPATION(); // Check dossard présent dans la course
                    par.PAR_NBPARTICIPANTCOURSE = 1;
                    par.PAR_PARTICIPEPASTAPARTY = false;
                    par.PAR_TEMPS_ESTIME = inscription.tempsEstime[i];
                    par.COU_ID = inscription.coureur.COU_ID;
                    par.CLU_ID = 1;
                    par.COR_ID = inscription.listCourse[i].COR_ID;
                    par.PAS_ID = inscription.listCourse[i].COR_ID;

                    int count = (from p in db.PARTICIPATIONs.ToList()
                                 where p.COR_ID == inscription.listCourse[i].COR_ID
                                 select p).ToList().Count();

                    par.PAR_DOSSARD = count + 1;

                    if (inscription.listEtatPastaParty[i]) // Participation Pasta Party
                        par.PAR_PARTICIPEPASTAPARTY = true;

                    db.PARTICIPATIONs.Add(par);
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }
    }
}
