using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_Web.App_Data;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.Class_Metier.ViewCustomModels
{
    /// <summary>
    /// ViewModel servant a plusieur view du ClassementController
    /// </summary>
    public class InscriptionCourreurCourseModel
    {
        /// <summary>
        /// Constructeur par défaut du ViewModel
        /// </summary>
        public InscriptionCourreurCourseModel()
        {

        }

        /// <summary>
        /// L'ensemble des courses auquel le courreur n'est pas inscrit
        /// </summary>
        public List<COURSE> listCourse { get; set; }

        /// <summary>
        /// Une liste correspondant au nombre de coureur, savoir si le courreur participe ou non a la course
        /// </summary>
        public List<bool> listEtatInscription { get; set; }

        /// <summary>
        /// Une liste correspondant au nombre de coureur, savoir si le courreur participe ou non a la pastaparty
        /// </summary>
        public List<bool> listEtatPastaParty { get; set; }

        /// <summary>
        /// Une liste correspondant au nombre de coureur, savoir si le temps qu'estime le courreur a faire la course
        /// </summary>
        public List<int?> tempsEstime { get; set; }

        /// <summary>
        /// Le courreur voulant s'inscrire a la course
        /// </summary>
        public COUREUR coureur { get; set; }

    }
}