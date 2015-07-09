using System;
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
    public class CoursesController : Controller
    {
        private MarathonEntities db = new MarathonEntities();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.COURSEs.ToList());
        }

        // GET: Courses/Details/5
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

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Courses/Edit/5
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

        // POST: Courses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Courses/Delete/5
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

        // POST: Courses/Delete/5
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

        [HttpPost, ActionName("InscriptionCoureurCourse")]
        [ValidateAntiForgeryToken]
        public ActionResult InscriptionCoureurCourse(InscriptionCourreurCourseModel inscription)
        {
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
