using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PJoueur;
using PInterfaces_Fabrique_Abstraite;
using PCivilisation;
using PImplInfo;
using PPartie;
using PMonteurPartie;
using System.Collections.Generic;
using PConstantes;

namespace TestUnitaireMonteur
{
    [TestClass]
    public class UnitTest1_Monteur
    {
        [TestMethod]
        public void TestMonteur()
        {
            CreateurPartie createur = new CreateurPartie();
            List<Joueur> liste = new List<Joueur>();
            Civilisation civ1 = new Info("equipe aurel");
            Civilisation civ2 = new Info("equipe quentin");
            Civilisation civ3 = new Info("equipe florian");
            Civilisation civ4 = new Info("equipe nicos");
            liste.Add(new Joueur("aurel", civ1,PConstantes.CouleurJoueur.BLEU));
            liste.Add(new Joueur("quentin", civ2, PConstantes.CouleurJoueur.NOIR));
            liste.Add(new Joueur("florian", civ3, PConstantes.CouleurJoueur.ROUGE));
            liste.Add(new Joueur("nicos", civ4, PConstantes.CouleurJoueur.VERT));

            foreach (Joueur j in liste)
            {
                System.Console.WriteLine(j._nomJoueur);
            }
            createur.construire(TypeCarte.PETITE, liste);

            Partie p = createur.getPartie();
            List<Joueur> liste_comp = p._liste_joueurs;

            Assert.AreEqual(liste_comp, liste, "La liste des joueurs ne correspond pas !");
            Assert.AreEqual(p._nbJoueur, 4, "Mauvais nombre de joueurs dans la carte !");
            Assert.AreEqual(p._tour, 0, "Le tour n'est pas initialisé à 0 !");
            /* pour tester quel joueur a été choisi en premier -> peut amener une erreur */
            //Assert.AreEqual(p._joueurCourant, (new Joueur("aurel", civ1), "Le joueur courant n'est pas aurel !");

        }
    }
}

