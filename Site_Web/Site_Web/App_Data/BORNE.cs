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
    
    public partial class BORNE
    {
        public BORNE()
        {
            this.T_J_TEMPSCOUBORNE_TCB = new HashSet<TEMPSCOUBORNE>();
        }
    
        public int BOR_ID { get; set; }
        public int COR_ID { get; set; }
        public int BOR_EMPLACEMENT { get; set; }
    
        public virtual ICollection<TEMPSCOUBORNE> T_J_TEMPSCOUBORNE_TCB { get; set; }
        public virtual COURSE T_R_COURSE_COR { get; set; }
    }
}
