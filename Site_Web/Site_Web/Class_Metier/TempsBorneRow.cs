using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_Web.Class_Metier
{
    public partial class TempsBorneRow
    {
        
        [Display(Name = "Nom du coureur")]
        public string nomCoureur;

        [Display(Name = "Prenom du coureur")]
        public string prenomCoureur;


        public Dictionary<int, String> TempsBorne;
        public TempsBorneRow()
        {

        }


    }
}