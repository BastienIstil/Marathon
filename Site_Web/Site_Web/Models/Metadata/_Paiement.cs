using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(PAIEMENTMetadata))]
    public partial class PAIEMENT
    {
        public class PAIEMENTMetadata
        {
            [Display(Name = "Montant")]
            public string PAI_MONTANT { get; set; }

            [Display(Name = "Moyen de paiement")]
            public string PAI_MOYENPAIEMENT { get; set; }

            [Display(Name = "Date de paiement")]
            public string PAI_DATEPAIEMENT { get; set; }
        }
    }
}