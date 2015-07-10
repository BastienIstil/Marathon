using Site_Web.App_Data;
using System.Collections.Generic;
using Site_Web.Class_Metier;

namespace Site_Web.Models
{
    /// <summary>
    /// ViewModel servant a plusieur view du ClassementController
    /// </summary>
    public class ClassementViewModel
    {

        /// <summary>
        /// Constructeur par défaut du ViewModel
        /// </summary>
        public ClassementViewModel()
        {

        }

        /// <summary>
        /// Les différentes lignes composant le classement fournie par le controlleur
        /// </summary>
        public List<ClassementRow> lignes;

        /// <summary>
        /// La liste des courses concernant le classement
        /// </summary>
        public List<COURSE> courses;

        /// <summary>
        /// La liste des catégorie concernant le classement
        /// </summary>
        public List<CATEGORIE> categories;
    }
}