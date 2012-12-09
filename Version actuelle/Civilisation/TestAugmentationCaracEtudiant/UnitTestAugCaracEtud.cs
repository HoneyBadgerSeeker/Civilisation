using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCarte;
using PImplInfo;
using PImplEii;
using PConstantes;
using PJoueur;
using PCivilisation;
using PCase;
using PInterfaces_Fabrique_Abstraite;
using System.Collections.Generic;

namespace TestAugmentationCaracEtudiant
{
    [TestClass]
    public class UnitTestAugCaracEtud
    {
        [TestMethod]
        public void TestAugCarcEtud()
        {
            Carte carte = new Petite(1);
            Joueur aurel = new Joueur("aurel", new Info("toto"));
            DirecteurInfo dir = new DirecteurInfo(7,7);

            aurel.ajouterUnite(dir);

            EtudiantInfo etud = new EtudiantInfo(7,7);

            /* tests avant augmentation caracteristiques */
            Assert.AreEqual(aurel.contientDirecteur(7,7), true, "Le resultat contient directeur ne fonctionne pas !");
            Assert.AreEqual(etud._vie, 10, "AVANT -> Nb vie etudiant incorrect !");
            Assert.AreEqual(etud._attaque, 4, "AVANT -> Nb attaque etudiant incorrect !");
            Assert.AreEqual(etud._defense, 2, "AVANT -> Nb defense etudiant incorrect !");
            Assert.AreEqual(etud._mouvement, 2, "AVANT -> Nb mouvement etudiant incorrect !");

            etud.augmenterCarac();

            /* tests avant augmentation caracteristiques */
             Assert.AreEqual(etud._vie, 10, "APRES -> Nb vie etudiant incorrect !");
             Assert.AreEqual(etud._attaque, 6, "APRES -> Nb attaque etudiant incorrect !");
             Assert.AreEqual(etud._defense, 3, "APRES -> Nb defense etudiant incorrect !");
             Assert.AreEqual(etud._mouvement, 2, "APRES -> Nb mouvement etudiant incorrect !");


        }
    }
}
