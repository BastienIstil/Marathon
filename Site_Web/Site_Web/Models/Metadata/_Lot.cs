using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(LOTMetadata))]
    public partial class LOT
    {
        /// <summary>
        /// metadonnées de la classe Lot, avec le libellé du champ nom
        /// </summary>
        public class LOTMetadata
        {
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Nom  du lot"
            /// </summary>
            [Display(Name = "Nom  du lot")]
            public string LOT_NOM { get; set; }
        }
    }
}