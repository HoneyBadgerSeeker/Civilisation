using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PJoueur;
using PInterfaces_Fabrique_Abstraite;
using PImplInfo;
using PCivilisation;
namespace PremierTestUnitaire1311
{
    [TestClass]
    public class JoueurTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Joueur aurel = new Joueur("Aurelien", new Info("Testouille"));
            Unite bla = new EtudiantInfo();
            aurel.ajouterUnite(bla);

        }
    }
}
