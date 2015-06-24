using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(TEMPSCOUREURBORNEMetadata))]
    public partial class TEMPSCOUREURBORNE
    {
        public class TEMPSCOUREURBORNEMetadata
        {
            [Display(Name = "Temps")]
            public string TCB_TEMPS { get; set; }
        }
    }
}