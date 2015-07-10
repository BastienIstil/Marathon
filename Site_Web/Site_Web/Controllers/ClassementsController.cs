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
    public class ClassementsController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Classements
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
            
            // Creaino de la liste des catégories :
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

        // GET: Classements/Details/5
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

        // GET: Classements/Create
        public ActionResult Create()
        {
            ViewBag.COU_ID = new SelectList(db.COUREURs, "COU_ID", "COU_NOM");
            ViewBag.COR_ID = new SelectList(db.COURSEs, "COR_ID", "COR_NOM");
            return View();
        }

        // POST: Classements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
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


        // GET: Classements/Edit/5
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

        // POST: Classements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Classements/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Classements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASSEMENT cLASSEMENT = db.CLASSEMENTs.Find(id);
            db.CLASSEMENTs.Remove(cLASSEMENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Marathon(int choixcourse)
        {

            ClassementViewModel classementRows = new ClassementViewModel();

            List<CLASSEMENT> classement = (from course in db.CLASSEMENTs
                                           where course.COR_ID == choixcourse
                                           select course).ToList();
            List<COURSE> Course = db.COURSEs.ToList();
            List<COUREUR> listeCoureurs = db.COUREURs.ToList();

            classementRows.lignes = new List<ClassementRow>();

            if (classement == null) classement = new List<CLASSEMENT>();
            if (Course == null) Course = new List<COURSE>();
            if (listeCoureurs == null) listeCoureurs = new List<COUREUR>();

            int tps = 0;
            string nomcoureur = "";
            string prenomcoureur = "";
            string nomcourse = "";

            foreach (CLASSEMENT clas in classement)
            {
                ClassementRow row = new ClassementRow();

                tps = clas.CLA_TEMPS.Value;

                COUREUR cour = (from coureur in db.COUREURs
                                where coureur.COU_ID == clas.COU_ID
                                select coureur).First();

                nomcoureur = cour.COU_NOM;
                prenomcoureur = cour.COU_PRENOM;

                COURSE course = (from cours in db.COURSEs
                                 where cours.COR_ID == clas.COR_ID
                                 select cours).First();

                nomcourse = course.COR_NOM;

                row.nomCoureur = nomcoureur;
                row.prenomCoureur = prenomcoureur;
                row.nomCourse = nomcourse;
                int sec = tps % 60;
                int min = (tps - sec) / 60;
                int heure = min / 60;
                min = min % 60;

                row.temps = heure + "H:" + min + "min:" + sec + "s";

                classementRows.lignes.Add(row);

            }


            return View(classementRows);
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
