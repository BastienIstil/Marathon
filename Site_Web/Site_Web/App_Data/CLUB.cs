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
    
    public partial class CLUB
    {
        public CLUB()
        {
            this.T_E_COUREUR_COU = new HashSet<COUREUR>();
            this.T_J_PARTICIPATIONENGROUPE_PEG = new HashSet<PARTICIPATIONENGROUPE>();
        }
    
        public int CLU_ID { get; set; }
        public string CLU_NOM { get; set; }
        public int CLU_LICENCE { get; set; }
        public string CLU_EMAIL { get; set; }
    
        public virtual ICollection<COUREUR> T_E_COUREUR_COU { get; set; }
        public virtual ICollection<PARTICIPATIONENGROUPE> T_J_PARTICIPATIONENGROUPE_PEG { get; set; }
    }
}