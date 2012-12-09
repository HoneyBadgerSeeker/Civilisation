#ifndef __WRAPPER__
#define __WRAPPER__

#include "..\AlgorithmeCPP\algo_carte.h"
#pragma comment(lib, "AlgorithmeCPP.lib")

using namespace System;

namespace Wrapper {
	public ref class Wrapper_Algo_carte {
	private:
		Algo_carte* algo_carte;
	public:
		Wrapper_Algo_carte(int taille, int nb_joueurs) { algo_carte = Algo_carte_new(taille, nb_joueurs); }
		~Wrapper_Algo_carte() { Algo_carte_delete(algo_carte); }
		int* generationCarte() { return algo_carte->generationCarte();}
		int* cases_a_suggerees(int x_colon, int y_colon) { algo_carte->cases_a_suggerees(x_colon,y_colon); return algo_carte->_cases_suggerees; }
		int rend_ressource_fer_une_case(int x, int y){ return algo_carte->rend_ressource_fer_une_case(x,y); };
		int rend_ressource_nourriture_une_case(int x, int y){ return algo_carte->rend_ressource_nourriture_une_case(x,y); };
	};
}



#endif