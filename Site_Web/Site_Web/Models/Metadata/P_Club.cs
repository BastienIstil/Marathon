using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.Models
{
    [MetadataType(typeof(CLUBMetadata))]
    public partial class CLUB
    {
        public class CLUBMetadata
        {
            [Display(Name = "N° du club")]
            public int CLU_ID { get; set; }
            [Display(Name = "Nom")]
            public string CLU_NOM { get; set; }
            [Display(Name = "N° licence")]
            public int CLU_LICENCE { get; set; }
            [Display(Name = "Adresse Email")]
            public string CLU_EMAIL { get; set; }
        }
    }
}