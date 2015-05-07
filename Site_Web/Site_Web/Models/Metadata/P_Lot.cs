﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(LOTMetadata))]
    public partial class LOT
    {
        public class LOTMetadata
        {
            [Display(Name = "N° de lot")]
            public int LOT_ID { get; set; }
            [Display(Name = "Nom")]
            public string LOT_NOM { get; set; }
        }
    }
}