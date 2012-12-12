using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCarte;
using PCase;
using Wrapper;
using PConstantes;

namespace TestPoidsMouche
{
    [TestClass]
    public class UnitTestPoidsMoucheCarte
    {
        [TestMethod]
        public unsafe void TestPoidsMouche()
        {
            Carte carte = new Petite(1);
            /*Wrapper_Algo_carte algo = new Wrapper_Algo_carte(25,2);

            carte._tabInt = algo.generationCarte();
            carte.ajouterCases(carte._tabInt);*/

            /*int[] tab = {
            0,0,0,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            0,0,0,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,7,6,6,6,
            0,0,0,7,6,6,6,6,6,6,6,8,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,0,0,0,6,6,6,6,6,7,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,0,0,0,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,0,2,1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,8,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,3,3,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,3,3,6,6,6,6,6,6,7,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,4,3,3,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,3,3,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,3,3,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,3,3,6,7,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,3,3,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,3,3,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,3,3,3,3,3,3,3,5,4,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,8,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,8,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,8,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,
            6,6,6,6,6,6,6,6,6,6,7,6,6,6,6,6,6,6,6,6,6,6,6,8,7 };*/

            Assert.AreEqual(carte.getTaille(), 25, "La taille de la carte n'est pas valide !");
            Assert.AreEqual(carte.caseExiste(24, 24), true, "La verification qu'une case existe ne fonctionne pas !");
            Assert.AreEqual(carte.recupererCase(56, 52), null, "La recuperation d'une fausse case n'est pas correcte !");


            /* testtttt moi */
            /*Wrapper_Algo_carte algo = new Wrapper_Algo_carte(25, 2);
            Case[] _tabCases = new Case[25*25];

            int* tab = algo.generationCarte();

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    Console.WriteLine("tab -> " + tab[i*25+j]);
                    _tabCases[i * 25 + j] = FabriqueCase.INSTANCE.obtenirCase(tab[i * 25 + j]);
                }
            }*/
        }
    }
}
