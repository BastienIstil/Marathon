using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site_Web.App_Data;
using Site_Web.Models;
using Site_Web.Class_Metier;

namespace Site_Web.Controllers
{
    /// <summary>
    /// Classements controller est le controlleur gérant le CRUD et différente vues lié au model CLASSEMENT.
    /// </summary>
    public class ClassementsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        /// <summary>
        /// Index des classements.
        /// </summary>
        /// <param name="choixcourse">L'id correspondant à la course sur laquelle effectuer le filtre.</param>
        /// <param name="choixcategorie">L'id correspondant à la caégorie sur laquelle effectuer le filtre.</param>
        /// <returns> la view Index.</returns>
        public ActionResult Index(int choixcourse = 0, int choixcategorie = 0)
        {

            // Chargement du ViewModel personnalisé :
            ClassementViewModel classementRows = new ClassementViewModel();

            // Creation d'une liste de classement :
            List<CLASSEMENT> classement;


            // Si le filtre du choix de la course est null alors on retourne tous les temps :
            // Sinon on sort les course dont l'ID est passé en parametre de fonction.
            if (choixcourse == 0)
            {
                classement = db.CLASSEMENTs.ToList();

            }
            else
            {
                classement = (from course in db.CLASSEMENTs
                                               where course.COR_ID == choixcourse
                                               select course).ToList();
            }
            
            // Creation de la liste des catégories :
            List<CATEGORIE> categories = db.CATEGORIEs.ToList();

            // Création de la liste des différentes courses :
            List<COURSE> Course = db.COURSEs.ToList();

            // Si le filtre du choix de la categorie est null alors on retourne tous les temps :
            // Sinon on sort les catégories dont l'ID est passé en parametre de fonction.
            if (choixcategorie == 0)
            {
                List<COUREUR> listeCoureurs = db.COUREURs.ToList();
            }
            else
            {
                List<COUREUR> listeCoureurs = (from coureur in db.COUREURs
                              where coureur.CAT_ID == choixcategorie
                              select coureur).ToList();
            }

            classementRows.lignes = new List<ClassementRow>();


            if (Course == null) Course = new List<COURSE>();

            // Liste de toute les courses :
            classementRows.courses = Course;

            // Liste de toute les catégories :
            classementRows.categories = categories;

            // Variables pour le ViewModel :
            int tps = 0;
            string nomcoureur = "";
            string prenomcoureur = "";
            string nomcourse = "";

            foreach (CLASSEMENT clas in classement)
            {
                ClassementRow row = new ClassementRow();

                tps = clas.CLA_TEMPS.Value;

                // Recuperer toute les infos coureur à partir de son ID sur la ligne du classement :
                COUREUR cour = (from coureur in db.COUREURs
                                where coureur.COU_ID == clas.COU_ID
                                select coureur).First();

                // Récupere le nom + prenom pour la ligne
                nomcoureur = cour.COU_NOM;
                prenomcoureur = cour.COU_PRENOM;

                // Récuperation des infos de la course :
                COURSE course = (from cours in db.COURSEs
                                 where cours.COR_ID == clas.COR_ID
                                 select cours).First();

                // Récuperation des infos de la catégorie :
                CATEGORIE cat = (from categorie in db.CATEGORIEs
                                 where cour.CAT_ID == categorie.CAT_ID
                                 select categorie).First();


                // Alimentation du nom de la course
                nomcourse = course.COR_NOM;



                row.nomCoureur = nomcoureur;
                row.prenomCoureur = prenomcoureur;
                row.nomCourse = nomcourse;
                row.categorieCoureur = cat.CAT_LIBELLE;

                /// Algorithme pour convertir des secondes en "HH:MM:SS" 

                int sec = tps % 60;
                int min = (tps - sec) / 60;
                int heure = min / 60;
                min = min % 60;
 
                row.temps = heure+"H:"+min+"min:"+sec+"s";


                classementRows.lignes.Add(row);

            }
            

            return View(classementRows);
        }

        /// <summary>
        /// Affiche le detail d'une ligne du classement.
        /// </summary>
        /// <param name="id">L'id correspondant à la ligne du classement.</param>
        /// <returns>La view detail avec les informations du classement fournie en paramètre.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            if (cLASSEMENT == null)
            {
                return HttpNotFound();
            }
            return View(cLASSEMENT);
        }

        /// <summary>
        /// Permet la création d'une ligne du classement..
        /// </summary>
        /// <returns>La view création (GET) qui, si la validation du formulaire est bonne.
        /// créera une nouvelle ligne du classement.
        /// </returns>
        public ActionResult Create()
        {
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM");
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            return View();
        }

        /// <summary>
        /// Permet la création d'une ligne du classement en POST.
        /// </summary>
        /// <param name="cLASSEMENT">La ligne du classement correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view création (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COU_ID,COR_ID,CLA_TEMPS")] CLASSEMENT cLASSEMENT)
        {
            if (ModelState.IsValid)
            {
                db.CLASSEMENTs.Add(cLASSEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", cLASSEMENT.COU_ID);
            ViewBag.COR_ID = new SelectList(db.BORNEs, "COR_ID", "COR_ID", cLASSEMENT.COR_ID);
            return View(cLASSEMENT);
        }


        /// <summary>
        /// Permet la modification d'une ligne du classement en GET.
        /// </summary>
        /// <param name="id">L'id correspondant au classement devant être modifié.</param>
        /// <returns>La view de modification (GET) qui, si la validation du formulaire est bonne.
        /// modifiera ladite ligne du classement.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            if (cLASSEMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", cLASSEMENT.COU_ID);
            ViewBag.COR_ID = new SelectList(db.BORNEs, "COR_ID", "COR_ID", cLASSEMENT.COR_ID);
            return View(cLASSEMENT);
        }

        /// <summary>
        /// Permet la modification d'une ligne du classement en POST.
        /// </summary>
        /// <param name="cLASSEMENT">La ligne du classement correspondant au formulaire remplie par l'utilisateur.</param>
        /// <returns>La view de modification (POST) si la validation est fausse.
        /// La view index si la validation est bonne.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLA_ID,CLA_TEMPS")] CLASSEMENT cLASSEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASSEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM", cLASSEMENT.COU_ID);
            ViewBag.COR_ID = new SelectList(db.BORNEs, "COR_ID", "COR_ID", cLASSEMENT.COR_ID);
            return View(cLASSEMENT);
        }


        /// <summary>
        /// Permet la suppression d'une ligne du classement en GET.
        /// </summary>
        /// <param name="id">L'id correspondant à la ligne du classement devant être supprimé.</param>
        /// <returns>La view de confirmation de suppression(GET).
        /// </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            db.CLASSEMENTs.Remove(cLASSEMENT);
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
