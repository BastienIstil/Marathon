﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(CATEGORIEMetadata))]
    public partial class CATEGORIE
    {
        /// <summary>
        /// metadonnées de la classe Categorie, avec le libellé 
        /// </summary>
        public class CATEGORIEMetadata
        {
            [Display(Name = "Libellé")]
            public string CAT_LIBELLE { get; set; }
        }
    }
}