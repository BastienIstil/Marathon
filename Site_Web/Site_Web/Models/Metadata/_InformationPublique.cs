using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(INFORMATIONPUBLIQUEMetadata))]
    public partial class INFORMATIONPUBLIQUE
    {
        public class INFORMATIONPUBLIQUEMetadata
        {
            [Display(Name = "Nom de l'information publique")]
            public string INF_NOM { get; set; }

            [Display(Name = "Prénom")]
            public string INF_PRENOM { get; set; }

            [Display(Name = "Email")]
            public string INF_EMAIL { get; set; }

            [Display(Name = "Contenu")]
            public string INF_CONTENUE { get; set; }

            [Display(Name = "Titre")]
            public string INF_TITRE { get; set; }
        }
    }
}