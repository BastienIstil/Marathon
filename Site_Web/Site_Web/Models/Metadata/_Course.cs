using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(COURSEMetadata))]
    public partial class COURSE
    {
        public class COURSEMetadata
        {
            [Display(Name = "Nom de la course")]
            public string COR_NOM { get; set; }

            [Display(Name = "Distance")]
            public string COR_DISTANCE { get; set; }

            [Display(Name = "Date")]
            public string COR_DATE { get; set; }

            [Display(Name = "Nombre de participant max")]
            public string COR_NOMBREMAXPARTICIPANT { get; set; }

            [Display(Name = "prix")]
            public string COR_PRIX { get; set; }
        }
    }
}