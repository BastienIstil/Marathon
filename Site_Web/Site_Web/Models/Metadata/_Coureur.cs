using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(COUREURMetadata))]
    public partial class COUREUR
    {
        public class COUREURMetadata
        {
            [Display(Name = "Nom du coureur")]
            public string COU_NOM { get; set; }

            [Display(Name = "Prénom")]
            public string COU_PRENOM { get; set; }
        }
    }
}