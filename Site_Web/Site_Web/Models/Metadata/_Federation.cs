using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(FEDERATIONMetadata))]
    public partial class FEDERATION
    {
        public class FEDERATIONMetadata
        {
            [Display(Name = "Nom de la fédération")]
            public string FED_NOM { get; set; }
        }
    }
}