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
    
    public partial class DEFI
    {
        public DEFI()
        {
            this.T_R_COURSE_COR = new HashSet<COURSE>();
            this.T_E_COUREUR_COU = new HashSet<COUREUR>();
        }
    
        public int DEF_ID { get; set; }
        public string DEF_NOM { get; set; }
        public int DEF_NOMBREMAXPARTICIPANT { get; set; }
    
        public virtual ICollection<COURSE> T_R_COURSE_COR { get; set; }
        public virtual ICollection<COUREUR> T_E_COUREUR_COU { get; set; }
    }
}