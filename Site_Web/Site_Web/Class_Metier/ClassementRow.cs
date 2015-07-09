using Site_Web.App_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_Web.Class_Metier
{
    public partial class ClassementRow
    {
        [Display(Name = "Temps final")]
        public string temps;

        [Display(Name = "Nom du coureur")]
        public string nomCoureur;

        [Display(Name = "Prenom du coureur")]
        public string prenomCoureur;

        [Display(Name = "Catégorie")]
        public string categorieCoureur;

        [Display(Name = "Course")]
        public string nomCourse;


        public ClassementRow()
        {

        }


    }
}