using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.Models
{
    [MetadataType(typeof(COUREURMetadata))]
    public partial class COUREUR
    {
        public class COUREURMetadata
        {
            [Display(Name = "N° Coureur")]
            public int COU_ID { get; set; }
            [Display(Name = "Prenom")]
            public string COU_PRENOM { get; set; }
            [Display(Name = "Nom")]
            public string COU_NOM { get; set; }
            [Display(Name = "Date de naissance")]
            public System.DateTime COU_DATENAISSANCE { get; set; }
            [Display(Name = "Sexe")]
            public string COU_SEXE { get; set; }
            [Display(Name = "N° Licence")]
            public string COU_NUMEROLICENCE { get; set; }
            [Display(Name = "Fédération")]
            public string COU_FEDERATION { get; set; }
            [Display(Name = "Email")]
            public string COU_EMAIL { get; set; }
            [Display(Name = "Adresse")]
            public string COU_ADRESSE { get; set; }
            [Display(Name = "Code Postal")]
            public string COU_CODEPOSTAL { get; set; }
            [Display(Name = "Ville")]
            public string COU_VILLE { get; set; }
            [Display(Name = "Pays")]
            public string COU_PAYS { get; set; }
            [Display(Name = "Telephone")]
            public string COU_TELEPHONE { get; set; }
            [Display(Name = "Fax")]
            public string COU_FAX { get; set; }
            [Display(Name = "Groupe")]
            public string COU_ENTREPRISEGROUPEASSOCIATION { get; set; }
            [Display(Name = "Certificat médical")]
            public string COU_CERTIFICATMEDICAL { get; set; }
        }
    }
}