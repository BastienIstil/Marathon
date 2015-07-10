using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Site_Web.Controllers;
using Site_Web.App_Data;

namespace Site_Web.Class_Metier.ViewCustomModels
{

    public enum NiveauAuthentification
    {
        COUREUR = 0,
        CLUB = 1,
        SECRETAIRE = 2,
        ADMIN = 3
    }

    public enum NiveauAuthentificationInscription
    {
        COUREUR = 0,
        CLUB = 1
    }

    public class InscritCustom
    {

        public InscritCustom()
        {
            this.T_E_COUREUR_COU = new HashSet<COUREUR>();
            this.T_R_CLUB_CLU = new HashSet<CLUB>();
        }
    
        public int INS_ID { get; set; }

        [Required(ErrorMessage = "Le champ est obligatoire")]
        [EmailAddress]
        [StringLength(255, ErrorMessage = "Le champ est obligatoire")]
        public string INS_LOGIN { get; set; }

        [Required(ErrorMessage = "Le champ est obligatoire")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6, ErrorMessage ="Veuillez remplir au moins 6 caractères")]
        public string INS_MDP { get; set; }

        [Required(ErrorMessage = "Le champ est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [System.Web.Mvc.Compare("INS_MDP", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string Confirm_INS_MDP { get; set; }
        public NiveauAuthentificationInscription INS_NIVEAUAUTHENTIFICATION { get; set; }
    
        public virtual ICollection<COUREUR> T_E_COUREUR_COU { get; set; }
        public virtual ICollection<CLUB> T_R_CLUB_CLU { get; set; }


        public static NiveauAuthentification getLevelAutenticate(string userMail)
        {
            MarathonEntities db = new MarathonEntities();
            INSCRIT ins = db.INSCRITs.FirstOrDefault(u => u.INS_LOGIN == userMail);
            db.Dispose();
            return (NiveauAuthentification)ins.INS_NIVEAUAUTHENTIFICATION;
        }
        public static NiveauAuthentificationInscription getStatus(string userMail)
        {
            MarathonEntities db = new MarathonEntities();
            INSCRIT ins = db.INSCRITs.FirstOrDefault(u => u.INS_LOGIN == userMail);
            db.Dispose();
            return (NiveauAuthentificationInscription)ins.INS_NIVEAUAUTHENTIFICATION;
        }
    }
}