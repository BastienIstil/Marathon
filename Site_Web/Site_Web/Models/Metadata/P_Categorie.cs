using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(CATEGORIEMetadata))]
    public partial class CATEGORIE
    {
        public class CATEGORIEMetadata
        {
            [Display(Name = "N° de categorie")]
            public int CAT_ID { get; set; }
            [Display(Name = "Libellé")]
            public string CAT_LIBELLE { get; set; }
        }
    }
}