using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_Web.App_Data;


namespace Site_Web.Class_Metier.ViewCustomModels
{
    /// <summary>
    /// ViewModel servant a l'inscription d'un coureur à une course par un club
    /// </summary>
    public class InscriptionClubCourreurDefie
    {
        /// <summary>
        /// Constructeur par défaut du ViewModel
        /// </summary>
        public InscriptionClubCourreurDefie()
        {

        }

        /// <summary>
        /// L'ensemble des coureur sans club
        /// </summary>
        public List<COUREUR> listCoureur {get; set;}

        /// <summary>
        /// Une liste correspondant au nombre de coureur, pour savoir si le club décide ou non d'inscrire le membre au défi
        /// </summary>
        public List<bool> listEtat {get; set;}

        /// <summary>
        /// L'id du défi auquel les membres veulent s'inscrire
        /// </summary>
        public DEFI defi { get; set; }
    }
}