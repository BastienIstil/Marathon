using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Site_Web.App_Data;

namespace SiteWebTest
{
    [TestClass]
    public class CoureursTest
    {
        MarathonEntititesTest db = new MarathonEntititesTest();


        // Tous les components du coureur ne seronts testé
        // car elles sont misent en place dans kes dataComponent et donc géré par le
        // frameworks

        [TestMethod]
        public void TestCoureurNull()
        {
            T_E_COUREUR_COU c = null;
            try
            {
                db.T_E_COUREUR_COU.Add(c);
                db.SaveChanges();
            }
            catch (SystemException)
            {
                Assert.Fail("Echec de la mise a jour bdd");
            }

            try{
                Assert.AreEqual(c, db.T_E_COUREUR_COU.Find(c.COU_ID), "Object identiqe");
            }
            catch(SystemException){
                Assert.Fail("Echec de la mise a jour bdd");
            }
        }

        [TestMethod]
        public void TestCoureurWithoutForeignKey()
        {
            T_E_COUREUR_COU c = new T_E_COUREUR_COU();
            c.COU_ID = 5000;
            c.COU_ADRESSE = "50 rue des alliès";
            c.COU_CERTIFICATMEDICAL = "path/to/server";
            c.COU_CODEPOSTAL = "38000";
            c.COU_DATENAISSANCE = System.DateTime.Now;
            c.COU_EMAIL = "test@hotmail.fr";
            c.COU_ENTREPRISEGROUPEASSOCIATION = "les alliès";
            c.COU_FAX = "0477889966";
            c.COU_FEDERATION = "";
            c.COU_NOM = "Smith";
            c.COU_NUMEROLICENCE = "04565132";
            c.COU_PAYS = "France";
            c.COU_PRENOM = "John";
            c.COU_SEXE = "M";
            c.COU_TELEPHONE = "0475963215";
            c.COU_VILLE = "Annecy";

            try
            {
                db.T_E_COUREUR_COU.Add(c);
                db.SaveChanges();
            }
            catch (SystemException)
            {
                Assert.Fail("Echec de la mise a jour bdd");
            }

            try
            {
                Assert.AreEqual(c, db.T_E_COUREUR_COU.Find(c.COU_ID), "Object identiqe");
                db.T_E_COUREUR_COU.Remove(c);
            }
            catch (SystemException)
            {
                Assert.Fail("Echec de la mise a jour bdd");
            }
        }

        [TestMethod]
        public void TestCoureurWithForeignKey()
        {
            T_E_COUREUR_COU c = new T_E_COUREUR_COU();
            c.COU_ADRESSE = "50 rue des alliès";
            c.COU_CERTIFICATMEDICAL = "path/to/server";
            c.COU_CODEPOSTAL = "38000";
            c.COU_DATENAISSANCE = System.DateTime.Now;
            c.COU_EMAIL = "smith@hotmail.fr";
            c.COU_ENTREPRISEGROUPEASSOCIATION = "les alliès";
            c.COU_FAX = "0477889966";
            c.COU_FEDERATION = "";
            c.COU_NOM = "John";
            c.COU_NUMEROLICENCE = "04565132";
            c.COU_PAYS = "France";
            c.COU_PRENOM = "Smith";
            c.COU_SEXE = "M";
            c.COU_TELEPHONE = "0475963215";
            c.COU_VILLE = "Annecy";


            c.INS_ID = 7;
            c.FED_ID = 1;
            c.CAT_ID = 1;
            
            try
            {
                db.T_E_COUREUR_COU.Add(c);
                db.SaveChanges();
            }
            catch (SystemException)
            {
                Assert.Fail("Echec de la mise a jour bdd");
            }

            try
            {
                Assert.AreEqual(c, db.T_E_COUREUR_COU.Find(c.COU_ID), "Object identiqe");
                db.T_E_COUREUR_COU.Remove(c);
                db.SaveChanges();
            }
            catch (SystemException)
            {
                Assert.Fail("Echec de la mise a jour bdd");
            }
        }
    }
}
