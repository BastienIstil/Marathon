using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.Models
{
    [MetadataType(typeof(TEMPSCOUBORNEMetadata))]
    public partial class TEMPSCOUBORNE
    {
        public class TEMPSCOUBORNEMetadata
        {
            [Display(Name = "Temps à la borne")]
            public Nullable<int> TCB_TEMPS { get; set; }
        }
    }
}