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

namespace TestUnitaireMonteurPartie
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void Main()
        {

            CreateurPartie createur = new CreateurPartie();
            List<Joueur> liste = new List<Joueur>();
            Civilisation civ1 = new Info("equipe aurel");
            Civilisation civ2 = new Info("equipe quentin");
            Civilisation civ3 = new Info("equipe florian");
            Civilisation civ4 = new Info("equipe nicos");
            liste.Add(new Joueur("aurel", civ1));
            liste.Add(new Joueur("quentin", civ2));
            liste.Add(new Joueur("florian", civ3));
            liste.Add(new Joueur("nicos", civ4));

            foreach (Joueur j in liste)
            {
                System.Console.WriteLine(j._nomJoueur);
            }
            createur.construire(TypeCarte.PETITE, liste);

            Partie p = createur.getPartie();
            List<Joueur> liste_comp = p.liste_joueurs;

            Assert.AreEqual(liste_comp, liste, "La liste des joueurs ne correspond pas !");
            
            while (true) ;
        }
    }
}
