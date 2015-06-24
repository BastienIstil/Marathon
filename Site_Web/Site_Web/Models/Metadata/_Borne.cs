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
        public class BORNEMetadata
        {
            [Display(Name = "Emplacement")]
            public string BOR_EMPLACEMENT { get; set; }
        }
    }
}