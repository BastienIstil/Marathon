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
    
    public partial class PASTAPARTY
    {
        public PASTAPARTY()
        {
            this.T_E_PARTICIPATION_PAR = new HashSet<PARTICIPATION>();
        }
    
        public int PAS_ID { get; set; }
        public Nullable<int> PAS_NBMAXPARTICIPANT { get; set; }
    
        public virtual ICollection<PARTICIPATION> T_E_PARTICIPATION_PAR { get; set; }
    }
}