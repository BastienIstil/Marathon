using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(PASTAPARTYMetadata))]
    public partial class PASTAPARTY
    {
        public class PASTAPARTYMetadata
        {
            [Display(Name = "Nombre maximum de participant")]
            public string PAS_NBMAXPARTICIPANT { get; set; }
        }
    }
}