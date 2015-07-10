using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(PAIEMENTMetadata))]
    public partial class PAIEMENT
    {
        /// <summary>
        /// metadonnées de la classe Paiement, avec les libellés de chacun des champs
        /// </summary>
        public class PAIEMENTMetadata
        {
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Montant"
            /// </summary>
            [Display(Name = "Montant")]
            public string PAI_MONTANT { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Moyen de paiement"
            /// </summary>
            [Display(Name = "Moyen de paiement")]
            public string PAI_MOYENPAIEMENT { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Date de paiement"
            /// </summary>
            [Display(Name = "Date de paiement")]
            public string PAI_DATEPAIEMENT { get; set; }
        }
    }
}