using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(PARTICIPATIONENGROUPEMetadata))]
    public partial class PARTICIPATIONENGROUPE
    {
        public class PARTICIPATIONENGROUPEMetadata
        {
            [Display(Name = "N° participation")]
            public int PEG_ID { get; set; }
            [Display(Name = "N° coureur")]
            public int COU_ID { get; set; }
            [Display(Name = "N° club")]
            public int CLU_ID { get; set; }
            [Display(Name = "N° paiement")]
            public int PAI_ID { get; set; }
            [Display(Name = "Nombre de participant")]
            public Nullable<int> PEG_NOMBREPARTICIPANT { get; set; }
            [Display(Name = "Nombre de participant pasta party")]
            public Nullable<int> PEG_NOMBREPASTAPARTY { get; set; }
        }
    }
}