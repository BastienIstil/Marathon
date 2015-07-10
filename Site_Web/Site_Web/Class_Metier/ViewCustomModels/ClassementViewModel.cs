using Site_Web.App_Data;
using System.Collections.Generic;
using Site_Web.Class_Metier;

namespace Site_Web.Models
{
    public class ClassementViewModel
    {

        public ClassementViewModel()
        {

        }

        public List<ClassementRow> lignes;

        public List<COURSE> courses;

        public List<CATEGORIE> categories;
    }
}