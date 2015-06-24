using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(INSCRITMetadata))]
    public partial class INSCRIT
    {
        public class INSCRITMetadata
        {
            [Display(Name = "Adresse email")]
            public string INS_LOGIN { get; set; }

            [Display(Name = "Mot de passe")]
            public string INS_MDP { get; set; }

            [Display(Name = "Niveau authentification")]
            public string INS_NIVEAUAUTHENTIFICATION { get; set; }
        }
    }
}