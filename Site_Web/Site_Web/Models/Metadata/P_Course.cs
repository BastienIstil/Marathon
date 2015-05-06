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
            [Display(Name = "N° de course")]
            public int COR_ID { get; set; }
            [Display(Name = "Nom")]
            public string COR_NOM { get; set; }
            [Display(Name = "Distance")]
            public int COR_DISTANCE { get; set; }
            [Display(Name = "Date")]
            public Nullable<System.DateTime> COR_DATE { get; set; }
            [Display(Name = "Nombre de participants maximum")]
            public Nullable<int> COR_NOMBREMAXPARTICIPANT { get; set; }
            [Display(Name = "Prix")]
            public Nullable<decimal> COR_PRIX { get; set; }
        }
    }
}