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
        /// <summary>
        /// metadonnées de la classe Inscrit, avec les libellés de chacun des champs
        /// </summary>
        public class INSCRITMetadata
        {
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Adresse email"
            /// </summary>
            [Display(Name = "Adresse email")]
            public string INS_LOGIN { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Mot de passe"
            /// </summary>
            [Display(Name = "Mot de passe")]
            public string INS_MDP { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Niveau authentification"
            /// </summary>
            [Display(Name = "Niveau authentification")]
            public string INS_NIVEAUAUTHENTIFICATION { get; set; }
        }
    }
}