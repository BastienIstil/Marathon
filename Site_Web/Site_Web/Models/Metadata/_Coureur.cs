using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.App_Data
{
    [MetadataType(typeof(COUREURMetadata))]
    public partial class COUREUR
    {
        public class COUREURMetadata
        {
            [Display(Name = "Nom du coureur")]
            public string COU_NOM { get; set; }

            [Display(Name = "Prénom")]
            public string COU_PRENOM { get; set; }

            [Display(Name = "Email")]
            public string COU_EMAIL { get; set; }

            [Display(Name = "Date de naissance")]
            public string COU_DATENAISSANCE { get; set; }

            [Display(Name = "Sexe")]
            public string COU_SEXE { get; set; }

            [Display(Name = "numéro de licence")]
            public string COU_NUMEROLICENCE { get; set; }

            [Display(Name = "Fédération du coureur")]
            public string COU_FEDERATION { get; set; }

            [Display(Name = "Adresse")]
            public string COU_ADRESSE { get; set; }

            [Display(Name = "Code postalr")]
            public string COU_CODEPOSTAL { get; set; }

            [Display(Name = "Ville")]
            public string COU_VILLE { get; set; }

            [Display(Name = "Pays")]
            public string COU_PAYS { get; set; }

            [Display(Name = "Téléphone")]
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