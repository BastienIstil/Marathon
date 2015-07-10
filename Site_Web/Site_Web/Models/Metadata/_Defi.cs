using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(DEFIMetadata))]
    public partial class DEFI
    {
        /// <summary>
        /// metadonnées de la classe Défi, avec les libellés de chacun des champs
        /// </summary>
        public class DEFIMetadata
        {
            [Display(Name = "Nom du défi")]
            public string DEF_NOM { get; set; }

            [Display(Name = "Nombre de participant max")]
            public string DEF_NOMBREMAXPARTICIPANT { get; set; }
        }
    }
}