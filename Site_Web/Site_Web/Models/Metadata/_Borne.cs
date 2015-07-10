using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(BORNEMetadata))]
    
    public partial class BORNE
    {
        /// <summary>
        /// metadonnées de la classe Borne, avec les libellés des champs ID et emplacement
        /// </summary>
        public class BORNEMetadata
        {
            [Display(Name = "ID Borne")]
            public string BOR_ID { get; set; }

            [Display(Name = "Emplacement")]
            public string BOR_EMPLACEMENT { get; set; }
        }
    }
}