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
        /// <summary>
        /// metadonnées de la classe Participation, avec les libellés de chacun des champs
        /// </summary>
        public class PARTICIPATIONMetadata
        {
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "ID Participant"
            /// </summary>
            [Display(Name = "ID Participant")]
            public string PAR_ID { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Dossard"
            /// </summary>
            [Display(Name = "Dossard")]
            public string PAR_DOSSARD { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Temps estimé"
            /// </summary>
            [Display(Name = "Temps estimé")]
            public string PAR_TEMPS_ESTIME { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Nombre de participant à la course"
            /// </summary>
            [Display(Name = "Nombre de participant à la course")]
            public string PAR_NBPARTICIPANTCOURSE { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Participe à la pasta party"
            /// </summary>
            [Display(Name = "Participe à la pasta party")]
            public string PAR_PARTICIPEPASTAPARTY { get; set; }
            /// <summary>
            /// Cette propriété de métadata surcharge le libellé par "Nombre de participant à la pasta party"
            /// </summary>
            [Display(Name = "Nombre de participant à la pasta party")]
            public string PAR_NBPARTICIPANTPASTAPARTY { get; set; }
        }
    }
}