using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Site_Web.App_Data;

namespace Site_Web.Class_Metier.ViewCustomModels
{
    /// <summary>
    /// ViewModel servant a l'inscription d'un coureur a un club
    /// </summary>
    public class CoureurInscriptions
    {
        /// <summary>
        /// Constructeur par défaut du ViewModel
        /// </summary>
        public CoureurInscriptions()
        {

        }
        
        /// <summary>
        /// L'ensemble des coureur sans club
        /// </summary>
        public List<COUREUR> listCoureur {get; set;}

        /// <summary>
        /// Une liste correspondant au nombre de coureur sans club, pour savoir si le club décide ou non d'inscrire le membres
        /// </summary>
        public List<bool> listEtat {get; set;}

        /// <summary>
        /// L'id du club voulant inscrire les membres
        /// </summary>
        public Nullable<int> CLU_ID { get; set; }
    }
}