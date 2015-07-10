using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Site_Web.Controllers;
using Site_Web.App_Data;

namespace Site_Web.Class_Metier.ViewCustomModels
{
    /// <summary>
    /// Enum possible pour la connection 
    /// </summary>
    public enum NiveauAuthentification
    {
        COUREUR = 0,
        CLUB = 1,
        SECRETAIRE = 2,
        ADMIN = 3
    }
    
    /// <summary>
    /// Enum possible pour l'inscription 
    /// </summary>
    public enum NiveauAuthentificationInscription
    {
        COUREUR = 0,
        CLUB = 1
    }

    /// <summary>
    /// ViewModel servant a plusieur view du ClassementController
    /// </summary>
    public class InscritCustom
    {
        /// <summary>
        /// Constructeur par défaut du ViewModel
        /// </summary>
        public InscritCustom()
        {
            this.T_E_COUREUR_COU = new HashSet<COUREUR>();
            this.T_R_CLUB_CLU = new HashSet<CLUB>();
        }
    
        /// <summary>
        /// ID correspondant à l'inscrit dans la BDD
        /// </summary>
        public int INS_ID { get; set; }

        /// <summary>
        /// Login de l'inscrit définie comme adresse Email de 255 de longueur maximum et requis dans le formulaire
        /// </summary>
        [Required(ErrorMessage = "Le champ est obligatoire")]
        [EmailAddress]
        [StringLength(255, ErrorMessage = "Le champ est obligatoire")]
        public string INS_LOGIN { get; set; }

        /// <summary>
        /// Mot de passe de l'inscrit définie comme requis dans le formulaire et de longueur comprise entre 6 et 255
        /// </summary>
        [Required(ErrorMessage = "Le champ est obligatoire")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6, ErrorMessage ="Veuillez remplir au moins 6 caractères")]
        public string INS_MDP { get; set; }

        /// <summary>
        /// Comfirmation de mot de passe définie comme requis dans le formulaire et identique au mot de passe
        /// </summary>
        [Required(ErrorMessage = "Le champ est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [System.Web.Mvc.Compare("INS_MDP", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string Confirm_INS_MDP { get; set; }

        /// <summary>
        /// Enum définissant le niveaux d'authentification de l'inscrit
        /// </summary>
        public NiveauAuthentificationInscription INS_NIVEAUAUTHENTIFICATION { get; set; }
    
        /// <summary>
        /// List de coureur compris dans les inscrits
        /// </summary>
        public virtual ICollection<COUREUR> T_E_COUREUR_COU { get; set; }

        /// <summary>
        /// List de club compris dans les inscrits
        /// </summary>
        public virtual ICollection<CLUB> T_R_CLUB_CLU { get; set; }


        /// <summary>
        /// Retourne le niveau d'authentification de l'inscrit actuel 
        /// </summary>
        /// <param name="userMail">Est définie par l'INS_LOGIN ou User.Identity.Name.</param>
        /// <returns>Le niveau d'authentification de l'inscrit.</returns>
        public static NiveauAuthentification getLevelAutenticate(string userMail)
        {
            MarathonEntities db = new MarathonEntities();
            INSCRIT ins = db.INSCRITs.FirstOrDefault(u => u.INS_LOGIN == userMail);
            db.Dispose();
            return (NiveauAuthentification)ins.INS_NIVEAUAUTHENTIFICATION;
        }

        /// <summary>
        /// Retourne le niveau d'authentification de l'inscrit actuel 
        /// </summary>
        /// <param name="userMail">Est définie par l'INS_LOGIN ou User.Identity.Name.</param>
        /// <returns>Le niveau d'authentification de l'inscrit.</returns>
        public static NiveauAuthentificationInscription getStatus(string userMail)
        {
            MarathonEntities db = new MarathonEntities();
            INSCRIT ins = db.INSCRITs.FirstOrDefault(u => u.INS_LOGIN == userMail);
            db.Dispose();
            return (NiveauAuthentificationInscription)ins.INS_NIVEAUAUTHENTIFICATION;
        }
    }
}