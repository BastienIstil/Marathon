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
    using System.ComponentModel.DataAnnotations;
    
    public partial class COUREUR
    {
        public COUREUR()
        {
            this.T_E_PARTICIPATION_PAR = new HashSet<PARTICIPATION>();
            this.T_J_CLASSEMENT_CLA = new HashSet<CLASSEMENT>();
            this.T_J_TEMPSCOUBORNE_TCB = new HashSet<TEMPSCOUBORNE>();
            this.T_R_LOT_LOT = new HashSet<LOT>();
            this.T_R_DEFI_DEF = new HashSet<DEFI>();
        }
    
        public int COU_ID { get; set; }
        public int INS_ID { get; set; }
        public Nullable<int> FED_ID { get; set; }
        public Nullable<int> CLU_ID { get; set; }
        public int CAT_ID { get; set; }
        public string COU_NOM { get; set; }
        public string COU_PRENOM { get; set; }

        [DisplayFormat(ApplyFormatInEditMode= true, DataFormatString="{0:d}" )]
        public System.DateTime COU_DATENAISSANCE { get; set; }
        public string COU_SEXE { get; set; }
        public string COU_NUMEROLICENCE { get; set; }
        public string COU_FEDERATION { get; set; }
        public string COU_EMAIL { get; set; }
        public string COU_ADRESSE { get; set; }
        public string COU_CODEPOSTAL { get; set; }
        public string COU_VILLE { get; set; }
        public string COU_PAYS { get; set; }
        public string COU_TELEPHONE { get; set; }
        public string COU_FAX { get; set; }
        public string COU_ENTREPRISEGROUPEASSOCIATION { get; set; }
        public string COU_CERTIFICATMEDICAL { get; set; }
    
        public virtual FEDERATION T_R_FEDERATION_FED { get; set; }
        public virtual CLUB T_R_CLUB_CLU { get; set; }
        public virtual CATEGORIE T_R_CATEGORIE_CAT { get; set; }
        public virtual INSCRIT T_E_INSCRIT_INS { get; set; }
        public virtual ICollection<PARTICIPATION> T_E_PARTICIPATION_PAR { get; set; }
        public virtual ICollection<CLASSEMENT> T_J_CLASSEMENT_CLA { get; set; }
        public virtual ICollection<TEMPSCOUBORNE> T_J_TEMPSCOUBORNE_TCB { get; set; }
        public virtual ICollection<LOT> T_R_LOT_LOT { get; set; }
        public virtual ICollection<DEFI> T_R_DEFI_DEF { get; set; }
    }
}
