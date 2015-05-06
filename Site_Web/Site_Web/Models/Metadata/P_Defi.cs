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
        public class DEFIMetadata
        {
            [Display(Name = "N° de défi")]
            public int DEF_ID { get; set; }
            [Display(Name = "Nom")]
            public string DEF_NOM { get; set; }
            [Display(Name = "Nombre de participants maximum")]
            public int DEF_NOMBREMAXPARTICIPANT { get; set; }
        }
    }
}