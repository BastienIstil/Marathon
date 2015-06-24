using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(COURREURMetadata))]
    public partial class COUREUR
    {
        public class COURREURMetadata
        {
            [Display(Name="Nom")]
            public string COU_NOM { get; set; }
        }
    }
}