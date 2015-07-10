using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_Web.App_Data;


namespace Site_Web.Class_Metier.ViewCustomModels
{
    public class InscriptionClubCourreurDefie
    {
        public InscriptionClubCourreurDefie()
        {

        }
        
        public List<COUREUR> listCoureur {get; set;}
        public List<bool> listEtat {get; set;}

        public DEFI defi { get; set; }
    }
}