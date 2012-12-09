using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PJoueur;
using PInterfaces_Fabrique_Abstraite;
using PCivilisation;
using PImplInfo;

namespace TestUnitaireSurJoueur
{
    [TestClass]
    public class UnitTest1_AjoutUniteListe
    {
        [TestMethod]
        public void TestAjoutUniteListe()
        {
            Info civ =  new Info("Testouille");
            Joueur aurel = new Joueur("Aurelien", civ);

            Unite bla = new EtudiantInfo(7,7);
            aurel.ajouterUnite(bla);

            Assert.AreEqual(aurel._liste_unite.Count, 1, "La liste des unites ne correspond pas");

        }
    }
}
