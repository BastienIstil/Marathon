using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(PASTAPARTYMetadata))]
    public partial class PASTAPARTY
    {
        /// <summary>
        /// metadonnées de la classe PastaParty, avec les libellés de chacun des champs
        /// </summary>
        public class PASTAPARTYMetadata
        {
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "ID Pasta Party"
            /// </summary>
            [Display(Name = "ID Pasta Party")]
            public string PAS_ID { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Nombre maximum de participant"
            /// </summary>
            [Display(Name = "Nombre maximum de participant")]
            public string PAS_NBMAXPARTICIPANT { get; set; }
        }
    }
}