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
    
    public partial class TEMPSCOUBORNE
    {
        public int BOR_ID { get; set; }
        public int COU_ID { get; set; }
        public Nullable<int> TCB_TEMPS { get; set; }
    
        public virtual COUREUR T_E_COUREUR_COU { get; set; }
        public virtual BORNE T_R_BORNE_BOR { get; set; }
    }
}
