using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_Web.Class_Metier
{
    /// <summary>
    /// Class conteneur utilisable par le ViewModel TempsBorneViewModel
    /// </summary>
    public partial class TempsBorneRow
    {
        /// <summary>
        /// Nom du coureur
        /// </summary>
        [Display(Name = "Nom du coureur")]
        public string nomCoureur;

        /// <summary>
        /// Prenom du coureur
        /// </summary>
        [Display(Name = "Prenom du coureur")]
        public string prenomCoureur;

        /// <summary>
        /// Dictionnaire des temps borne [id de la borne ,temps en heure:minute:seconde]
        /// </summary>
        public Dictionary<int, String> TempsBorne;

        /// <summary>
        /// Constructeur par défaut de la classe
        /// </summary>
        public TempsBorneRow()
        {

        }




    }
}