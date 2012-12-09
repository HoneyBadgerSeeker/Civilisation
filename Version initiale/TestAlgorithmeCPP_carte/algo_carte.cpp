#include <iostream>
#include <time.h>
#include "algo_carte.h"

Algo_carte::Algo_carte(const int taille) {
	_taille = taille;
	_tab = new int[_taille*_taille];
	srand(time(NULL));
}

int* Algo_carte::generationCarte() {

	// Remplissage de la carte avec des plaines
	for(int i=0;i<(_taille*_taille);i++) 
	{
		_tab[i] = PLAINE;
	}

	// Remplissage de la carte avec montagnes et deserts.

	// tab_nb_cases_courantes[0] = nombre de cases de desert 
	// tab_nb_cases_courantes[1] =  nombre de cases de montage
	// tab_nb_cases_courantes[2] =  nombre de cases de plaine
	int tab_nb_cases_courantes[3] = {0,0,0};
	

	// Nombre de cases moyenne au départ
	int nb_case_type = _taille / 3;

	// tab_nb_cases_total[0] = nombre de cases de desert 
	// tab_nb_cases_total[1] =  nombre de cases de montage
	// tab_nb_cases_total[2] =  nombre de cases de plaine
	int tab_nb_cases_total[3] = {nb_case_type,nb_case_type,nb_case_type};	
	
	nb_case_type= rand() % - (nb_case_type/2);


	return _tab;
}

Algo_carte::~Algo_carte(){
	delete [] _tab;
}

Algo_carte* Algo_carte_new(int taille) { return new Algo_carte(taille); }
void Algo_carte_delete(Algo_carte* algo_carte) { delete algo_carte; }
int* Algo_carte_generer(Algo_carte* algo_carte) { return algo_carte->generationCarte();}