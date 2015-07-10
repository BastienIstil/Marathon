using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(INFORMATIONPUBLIQUEMetadata))]
    public partial class INFORMATIONPUBLIQUE
    {
        /// <summary>
        /// metadonnées de la classe Information Publique, avec les libellés de chacun des champs
        /// </summary>
        public class INFORMATIONPUBLIQUEMetadata
        {
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Nom de l'information publique"
            /// </summary>
            [Display(Name = "Nom de l'information publique")]
            public string INF_NOM { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Prénom"
            /// </summary>
            [Display(Name = "Prénom")]
            public string INF_PRENOM { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Email"
            /// </summary>
            [Display(Name = "Email")]
            public string INF_EMAIL { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Contenu"
            /// </summary>
            [Display(Name = "Contenu")]
            public string INF_CONTENUE { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Titre"
            /// </summary>
            [Display(Name = "Titre")]
            public string INF_TITRE { get; set; }
        }
    }
}