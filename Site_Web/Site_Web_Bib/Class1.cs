using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site_Web.App_Data;


namespace Site_Web_Bib
{
    public class Class1
    {

        public ActionResult function(){
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
