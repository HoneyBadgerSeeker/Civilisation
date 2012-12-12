using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrapper;

namespace TestWrapperAlgo_carte
{
    class Program
    {

        static unsafe void Main(string[] args)
        {
            int taille = 100;
            Wrapper_Algo_carte carte = new Wrapper_Algo_carte(taille, 2);
            int* res = carte.generationCarte();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\..\..\Fichiers textes\CarteTest.txt"))
            {
                for (int i = 0; i < taille; i++)
                {
                    for (int j = 0; j < taille; j++)
                    {
                        file.Write(res[i * taille + j]);
                    }
                    file.Write("\n");
                }
                file.Close();
            }
       }
    }
}
