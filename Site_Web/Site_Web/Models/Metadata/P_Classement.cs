using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.Models
{
    [MetadataType(typeof(CLASSEMENTMetadata))]

    public partial class CLASSEMENT
    {
        public class CLASSEMENTMetadata
        {
            [Display(Name = "")]
            public int CLA_ID { get; set; }
            public Nullable<int> CLA_TEMPS { get; set; }
        }
    }
}