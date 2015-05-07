using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(BORNEMetaData))]
    public partial class BORNE
    {
        public class BORNEMetaData
        {
            [Display(Name="N° de borne")]
            public int BOR_ID { get; set; }
            [Display(Name = "N° de course")]
            public int COR_ID { get; set; }
            [Display(Name = "Emplacement de la borne")]
            public int BOR_EMPLACEMENT { get; set; }
        }
    }
}