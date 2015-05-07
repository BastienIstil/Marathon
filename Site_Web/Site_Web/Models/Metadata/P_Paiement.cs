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
            [Display(Name = "N° paiement")]             
            public int PAI_ID { get; set; }
            [Display(Name = "Montant")]
            public int PAI_MONTANT { get; set; }
            [Display(Name = "Moyen de paiement")]
            public string PAI_MOYENDEPAIEMENT { get; set; }
            [Display(Name = "Date")]
            public System.DateTime PAI_DATEPAIEMENT { get; set; }
        }
    }
}