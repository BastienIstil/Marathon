using Site_Web.App_Data;
using System.Collections.Generic;

namespace Site_Web.Models
{
    public class ClassementViewModel
    {

        public ClassementViewModel()
        {

        }

        public CLASSEMENT classement;
        public List<COUREUR> listeCoureurs;
        public COURSE Course;
        public List<bool> Active;


    }
}