//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteWebTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_J_TEMPSCOUBORNE_TCB
    {
        public int BOR_ID { get; set; }
        public int COU_ID { get; set; }
        public Nullable<int> TCB_TEMPS { get; set; }
    
        public virtual T_E_COUREUR_COU T_E_COUREUR_COU { get; set; }
        public virtual T_R_BORNE_BOR T_R_BORNE_BOR { get; set; }
    }
}