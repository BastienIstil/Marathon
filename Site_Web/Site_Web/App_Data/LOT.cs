//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Site_Web.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOT
    {
        public int LOT_ID { get; set; }
        public Nullable<int> COU_ID { get; set; }
        public string LOT_NOM { get; set; }
    
        public virtual COUREUR T_E_COUREUR_COU { get; set; }
    }
}
