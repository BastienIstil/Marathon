using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(PARTICIPATIONMetadata))]
    public partial class PARTICIPATION
    {
        public class PARTICIPATIONMetadata
        {
            [Display(Name = "N° participation")]
            public int PAR_ID { get; set; }
            [Display(Name = "Participation au repas")]
            public Nullable<bool> PAR_PASTAPARTY { get; set; }
            [Display(Name = "Temps estimé")]
            public Nullable<int> PAR_TEMPSESTIME { get; set; }
            [Display(Name = "Nombre de participants")]
            public Nullable<int> PAR_NOMBREPASTAPARTY { get; set; }
            [Display(Name = "Dossard")]
            public int PAR_DOSSARD { get; set; }
        }
    }
}