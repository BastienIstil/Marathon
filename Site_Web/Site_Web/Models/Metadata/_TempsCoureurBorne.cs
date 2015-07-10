using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(TEMPSCOUREURBORNEMetadata))]
    public partial class TEMPSCOUBORNE
    {
        /// <summary>
        /// metadonnées de la classe TempsCoureurBorne, avec le libellé du champ temps
        /// </summary>
        public class TEMPSCOUREURBORNEMetadata
        {
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Temps"
            /// </summary>
            [Display(Name = "Temps")]
            public string TCB_TEMPS { get; set; }
        }
    }
}