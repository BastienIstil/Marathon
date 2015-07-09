using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_Web.App_Data;
using System.ComponentModel.DataAnnotations;

namespace Site_Web.Class_Metier.ViewCustomModels
{
    public class InscriptionCourreurCourseModel
    {

        public InscriptionCourreurCourseModel()
        {

        }

        public List<COURSE> listCourse { get; set; }


        public string InscriptionCourse;
        public string InscriptionPastaparty;
        public string TempsEstimé;

        public int nbParticipant;

        public List<bool> listEtatInscription { get; set; }
        public List<bool> listEtatPastaParty { get; set; }
        public List<int?> tempsEstime { get; set; }
        public COUREUR coureur { get; set; }

    }
}