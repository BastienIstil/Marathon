using Site_Web.App_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_Web.Class_Metier
{
    /// <summary>
    /// Class conteneur utilisable par le ViewModel ClassementViewModel
    /// </summary>
    public partial class ClassementRow
    {
        /// <summary>
        /// Temp final du coureur
        /// </summary>
        [Display(Name = "Temps final")]
        public string temps;

        /// <summary>
        /// Nom du coureur
        /// </summary>
        [Display(Name = "Nom du coureur")]
        public string nomCoureur;

        /// <summary>
        /// Prénom du coureur
        /// </summary>
        [Display(Name = "Prenom du coureur")]
        public string prenomCoureur;

        /// <summary>
        /// Catégorie du coureur
        /// </summary>
        [Display(Name = "Catégorie")]
        public string categorieCoureur;

        [Display(Name = "Course")]
        public string nomCourse;

        /// <summary>
        /// Constructeur par défaut de la classe
        /// </summary>
        public ClassementRow()
        {

        }


    }
}