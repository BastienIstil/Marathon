using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(CLUBMetadata))]
    public partial class CLUB
    {
        public class CLUBMetadata
        {
            [Display(Name = "Nom du club")]
            public string CLU_NOM { get; set; }

            [Display(Name = "Licence")]
            public string CLU_LICENCE { get; set; }

            [Display(Name = "Email")]
            public string CLU_EMAIL { get; set; }

            [Display(Name = "Adresse")]
            public string CLU_ADRESSE { get; set; }

            [Display(Name = "Code postal")]
            public string CLU_CODEPOSTAL { get; set; }

            [Display(Name = "Ville")]
            public string CLU_VILLE { get; set; }

            [Display(Name = "Pays")]
            public string CLU_PAYS { get; set; }

            [Display(Name = "Téléphone")]
            public string CLU_TELEPHONE { get; set; }

            [Display(Name = "Fax")]
            public string CLU_FAX { get; set; }

            [Display(Name = "Numéro")]
            public string CLU_NUMERO { get; set; }
        }
    }
}