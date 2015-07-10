using Site_Web.App_Data;
using System.Collections.Generic;
using Site_Web.Class_Metier;

namespace Site_Web.Models
{
    /// <summary>
    /// ViewModel servant a plusieur view du ClassementController
    /// </summary>
    public class TempsBorneViewModel
    {
        /// <summary>
        /// Constructeur par défaut du ViewModel
        /// </summary>
        public TempsBorneViewModel()
        {

        }

        /// <summary>
        /// Une liste de lignes correspondant au information voulue d'une borne
        /// </summary>
        public List<TempsBorneRow> lignes;

        /// <summary>
        /// Liste du nombre de borne pour un couple [coureur , course]
        /// </summary>
        public List<int> nbBornes;
    }
}