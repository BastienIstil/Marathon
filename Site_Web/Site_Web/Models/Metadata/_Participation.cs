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
            [Display(Name = "ID Participant")]
            public string PAR_ID { get; set; }

            [Display(Name = "Dossard")]
            public string PAR_DOSSARD { get; set; }

            [Display(Name = "Temps estimé")]
            public string PAR_TEMPS_ESTIME { get; set; }

            [Display(Name = "Nombre de participant à la course")]
            public string PAR_NBPARTICIPANTCOURSE { get; set; }

            [Display(Name = "Participe à la pasta party")]
            public string PAR_PARTICIPEPASTAPARTY { get; set; }

            [Display(Name = "Nombre de participant à la pasta party")]
            public string PAR_NBPARTICIPANTPASTAPARTY { get; set; }
        }
    }
}