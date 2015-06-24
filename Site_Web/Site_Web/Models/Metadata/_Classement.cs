using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(CLASSEMENTMetadata))]
    public partial class CLASSEMENT
    {
        public class CLASSEMENTMetadata
        {
            [Display(Name = "Temps")]
            public string CLA_TEMPS { get; set; }
        }
    }
}