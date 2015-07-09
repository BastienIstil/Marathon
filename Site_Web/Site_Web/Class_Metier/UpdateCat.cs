using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_Web.Class_Metier
{
    public class UpdateCat
    {

        public static int getCat(DateTime birthdayDate)
        {
            DateTime now = DateTime.Now;

            int diff = now.Year - birthdayDate.Year;

            if (diff >= 70)
                return 11; // Vétérans 4  
            if (diff >= 60)
                return 10; // Vétérans 3 
            if (diff >= 50)
                return 9; // Vétérans 2 
            if (diff >= 40)
                return 8; // Vétérans 1                   
            else if (diff >= 20)
                return 7; // Seniors /Espoirs
            else if (diff >= 18)
                return 1; //Juniors           
            else if (diff >= 16)
                return 6;// Cadets    
            else if (diff >= 14)
                return 5;// Minimes      
            else if (diff >= 12)
                return 4;// Benjamins                   

            return 3;// Poussins    
        }
    }
}