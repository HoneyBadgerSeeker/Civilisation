#include "algo_carte.h"
#include <time.h>

#include <stdio.h>
int main( int argc, const char* argv[] )
{
	printf( "Hello World\n\n" );
	srand(time(NULL));
	cout << "\n===============GRANDE=============\n" << endl;
	Algo_carte* algo = new Algo_carte(100,4);
	int* _tab = algo->generationCarte();
	algo->cases_a_suggerees(4,4);
	/*algo->decompose_nombre(21,8);
	algo->decompose_nombre(49,5);
	algo->decompose_nombre(28,12);
	algo->decompose_nombre(21,10);
	algo->decompose_nombre(21,2);
	algo->decompose_nombre(51,6);
	cout << "\n===============Cas d'erreur=============\n" << endl;
	algo->decompose_nombre(75,60); // oui car 75/60 < 2. Fonctionne a present.
	cout << "\n===============PETITE=============\n" << endl;
	Algo_carte* algop = new Algo_carte(25);
	int* _tabp = algo->generationCarte();
	algop->decompose_nombre(5,2);
	algop->decompose_nombre(7,3);
	algop->decompose_nombre(13,4);
	algop->decompose_nombre(17,5);
	algop->decompose_nombre(13,2);
	cout << "\n===============Cas d'erreur=============\n" << endl;
	algop->decompose_nombre(7,5); // oui car 7/5 < 2. Fonctione a present.*/
	while(1);
}