using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCivilisation;

namespace TestUnitaireSurVille
{
    [TestClass]
    public class UnitTest1_Ressource_Habitant
    {
        [TestMethod]
        public void TestRessourceNourriture()
        {
            Ville montyvillion = new Ville(15, 20, "Montivillion");
            montyvillion._ressourceNourriture=25;
            montyvillion.produireHabitants();
            montyvillion.produireHabitants();
            // assert
            int nbHabitantActuel = montyvillion._habitants;
            int nbHabitantFinal = 3 ;
            int nbRessourceActuelle = montyvillion._ressourceNourriture;

            Assert.AreEqual(nbHabitantFinal, nbHabitantActuel, "Nombre habitant incorrect");
            Assert.AreEqual(0, nbRessourceActuelle, "Nombre ressource incorrect");

        }
    }
}
