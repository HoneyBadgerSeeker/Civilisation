#include "algo_carte.h"
#include <iostream>
#include <fstream>
#include <time.h>
Algo_carte::Algo_carte(const int taille, int nb_joueurs) {
	srand(time(NULL));
	_taille = taille;
	_tab = new int[_taille*_taille];
	_placement_joueurs = new int[2*nb_joueurs]; // De taille 2*nombre de joueur, car chaque possède un abscisse et une ordonnée
	_cases_suggerees = new int[9];
}

int* Algo_carte::generationCarte() {

	int i;
	// Remplissage de la carte avec des plaines
	for(i=0;i<(_taille*_taille);i++) 
	{
		_tab[i] = PLAINE;
	}
	
	// On dit que les deux dernières cases de type PLAINE venant d'être posées sont des cases de type PLAINE_FER et PLAINE_NOURRITURE
	// Ceci fonctionnement également si le dernier bloc est un bloc de taille 2*2. Il n'existe pas de bloc 1*1.
	_tab[i-1]=PLAINE_FER;
	_tab[i-2]=PLAINE_NOURRITURE;
	// Remplissage de la carte avec montagnes et deserts.

	// tab_nb_cases_courantes[0] = nombre de cases de desert 
	// tab_nb_cases_courantes[1] =  nombre de cases de montagne
	// tab_nb_cases_courantes[2] =  nombre de cases de plaine
	int tab_nb_cases_courantes[3] = {0,0,0};
	cout << "tab_nb_cases_courantes	-> " ;
	for each (int i in tab_nb_cases_courantes){cout << i << "| ";} cout << endl;

	// Nombre de cases moyenne au départ pour chaque type de case ( Plaine, Desert, Montagne )
	int nb_case_type = _taille / 3;
	cout << "nb_case_type -> " << nb_case_type << endl;

	// tab_nb_cases_total[0] = nombre de cases de desert 
	// tab_nb_cases_total[1] =  nombre de cases de montagne
	// tab_nb_cases_total[2] =  nombre de cases de plaine
	int tab_nb_cases_total[3] = {nb_case_type,nb_case_type,nb_case_type};	
	cout << "tab_nb_cases_total (D,M,P) -> " ;
	for each (int i in tab_nb_cases_total){cout << i << "| ";} cout << endl;

	////////////////////////////////////////// 
	//Calcul du nombre total de case plaine, desert et montagne
	////////////////////////////////////////// 

	int random1 = rand() % (nb_case_type/2);
	cout << "random1 -> " << random1 << endl;

	int choix = rand() % 2; // Utilise pour ajouter/soustraire des types de cases
	if(choix){ // alors on ajoute a MONTAGNE le premier random et on soustrait à DESERT le deuxieme random qui se fait dans ce if
		cout << "On entre dans choix AJOUTE pour MONTAGNE -- SOUSTRAIRE pour DESERT" << endl;
		// On ajoute a MONTAGNE le random1 -> MONTAGNE grossit
		tab_nb_cases_total[1]+=random1;
		// On décrémente de la PLAINE de random1 -> PLAINE maigrit
		tab_nb_cases_total[2]-=random1;
		// On lance un second random nomme random2
		cout << "tab_nb_cases_total apres le random1 (D,M,P) -> " ;
		for each (int i in tab_nb_cases_total){cout << i << "| ";} cout << endl;

		int random2 = rand() % (nb_case_type/2);
		cout << "random2 -> " << random2 << endl;
		// On soustrait a Desert le random2 -> DESERT maigrit
		tab_nb_cases_total[0]-=random2;
		// On incrémente de la PLAINE de random2 -> PLAINE grossit
		tab_nb_cases_total[2]+=random2;
		cout << "tab_nb_cases_total apres les randoms (D,M,P) -> " ;
		for each (int i in tab_nb_cases_total){cout << i << "| ";} cout << endl;

	}else{ // sinon on ajoute a DESERT et on soustrait à MONTAGNE le deuxieme random qui se fait dans ce else
		cout << "On entre dans choix SOUSTRAIRE pour MONTAGNE -- AJOUTER pour DESERT" << endl;
		// On ajoute a DESERT le random1 -> DESERT grossit
		tab_nb_cases_total[0]+=random1;
		// On décrémente de la PLAINE de random1 -> PLAINE maigrit
		tab_nb_cases_total[2]-=random1;
		// On lance un second random nomme random2
		cout << "tab_nb_cases_total apres le random1 (D,M,P) -> " ;
		for each (int i in tab_nb_cases_total){cout << i << "| ";} cout << endl;

		int random2 = rand() % (nb_case_type/2);
		cout << "random2 -> " << random2 << endl;
		// On soustrait a MONTAGNE le random2 -> MONTAGNE maigrit
		tab_nb_cases_total[1]-=random2;
		// On incrémente de la PLAINE de random2 -> PLAINE grossit
		tab_nb_cases_total[2]+=random2;
		cout << "tab_nb_cases_total apres les randoms (D,M,P) -> " ;
		for each (int i in tab_nb_cases_total){cout << i << "| ";} cout << endl;
	}

	////////////////////////////////////////// 
	//Placement des blocs de cases des types principaux ( MONTAGNE et DESERT ) sur la carte
	////////////////////////////////////////// 
	
	int nb_bloc_montagne = rand() % (tab_nb_cases_total[0]/4) + 1;
	int nb_bloc_desert = rand() % (tab_nb_cases_total[1]/4) + 1;

	cout << nb_bloc_montagne << " nb_bloc montagne" << endl;
	cout << nb_bloc_desert << " nb_bloc desert" << endl;

	list<int> l_desert = decompose_nombre(tab_nb_cases_total[0],nb_bloc_desert); // Liste contenant un ensemble de nombre tel que la somme de cet ensemble égal au nombre en question
	list<int> l_montagne = decompose_nombre(tab_nb_cases_total[1],nb_bloc_montagne); // Liste contenant un ensemble de nombre tel que la somme de cet ensemble égal au nombre en question

	list<int>::iterator l_d_deb = l_desert.begin(); // Iterateurs sur la liste contenant la taille des blocs de DESERT à insérer
	list<int>::iterator l_d_fin = l_desert.end(); 

	list<int>::iterator l_m_deb = l_montagne.begin(); // Iterateurs sur la liste contenant la taille des blocs de MONTAGNE à insérer
	list<int>::iterator l_m_fin = l_montagne.end();

	i = 0; // Indice pour parcourir le tableau des cases
	int j = 0;

	int suite_m = 0;
	int decalage = *l_d_deb;
	while(l_d_deb != l_d_fin){ // Insertion des blocs de DESERT sur la carte	
		for( i = suite_m ; i < suite_m+decalage ; i++ ){ // Insertion d'un bloc de taille decalage*decalage
			for(  j = suite_m ; j < suite_m+decalage ; j++){
				_tab[i*_taille+j] = DESERT;
			}
		}
		suite_m+=decalage;
		l_d_deb++;
		decalage = *l_d_deb; // ajout de l'espace ou non entre les blocs, ici aucun espace entre les blocs

	}
	// On dit que les deux dernières cases de type DESERT venant d'être posées sont des cases de type DESERT_FER et DESERT_NOURRITURE
	// Ceci fonctionnement également si le dernier bloc est un bloc de taille 2*2. Il n'existe pas de bloc 1*1.
	_tab[(i-1)*_taille+j-1]=DESERT_FER;
	_tab[(i-1)*_taille+j-2]=DESERT_NOURRITURE;

	int suite=suite_m; // On commence juste après les blocs de MONTAGNE à poser des blocs de DESERT
	decalage = *l_m_deb; // ajout de l'espace ou non entre les blocs

	while(l_m_deb != l_m_fin){ // Insertion des blocs de DESERT sur la carte	
		for( i = suite ; i < suite+decalage ; i++ ){ // Insertion d'un bloc de taille decalage*decalage
			for(  j = suite ; j < suite+decalage ; j++){
				_tab[i*_taille+j] = MONTAGNE;
			}
		}
		decalage = *l_m_deb; // ajout de l'espace ou non entre les blocs, ici aucun espace entre les blocs
		suite+=decalage;
		l_m_deb++;

	}

	// On dit que les deux dernières cases de type MONTAGNE venant d'être posées sont des cases de type MONTAGNE_FER et MONTAGNE_NOURRITURE
	// Ceci fonctionnement également si le dernier bloc est un bloc de taille 2*2. Il n'existe pas de bloc 1*1.
	_tab[(i-1)*_taille+j-1]=MONTAGNE_FER;
	_tab[(i-1)*_taille+j-2]=MONTAGNE_NOURRITURE;

	////////////////////////////////////////// 
	//Placement des blocs de cases ressources de façon aléatoire sur la carte
	////////////////////////////////////////// 

	int nombre_ressource_max = _taille / 2 ;
	int nombre_ressource = 0;
	int caseX = 0;
	int caseY = 0;
	int case_remplir;
	choix=0;
	while( nombre_ressource != nombre_ressource_max ) { // Tant que le nombre de ressource maximale n'est pas atteinte, on ajoute des ressources
		caseX = rand() % _taille; // Choix au hasard d'une case à remplir avec du FER ou de la NOURRITURE
		caseY = rand() % _taille;
		case_remplir = caseX*_taille+caseY; // Mise en mémoire du calcul de la case
		choix = rand() % 2; // Choix de la ressource à remplir, si choix = 1 on essaye d'ajouter un terrain NOURRITURE sinon on essaye d'ajouter un terrain FER
		cout << choix << endl;
		if(choix){
			if(_tab[case_remplir] == MONTAGNE  && _tab[case_remplir] != MONTAGNE_FER){
				_tab[case_remplir] = MONTAGNE_NOURRITURE;
				nombre_ressource++;
			}
			else if(_tab[case_remplir] == PLAINE  && _tab[case_remplir] != PLAINE_FER){
			_tab[case_remplir] = PLAINE_NOURRITURE;
			nombre_ressource++;
			}
			else if(_tab[case_remplir] == DESERT  && _tab[case_remplir] != DESERT_FER){
			_tab[case_remplir] = DESERT_NOURRITURE;
			nombre_ressource++;
			}
		}else{
			if(_tab[case_remplir] == MONTAGNE  && _tab[case_remplir] != MONTAGNE_NOURRITURE){
				_tab[case_remplir] = MONTAGNE_FER;
				nombre_ressource++;
			}
			else if(_tab[case_remplir] == PLAINE  && _tab[case_remplir] != PLAINE_NOURRITURE){
				_tab[case_remplir] = PLAINE_FER;
				nombre_ressource++;
			}

			else if(_tab[case_remplir] == DESERT  && _tab[case_remplir] != DESERT_NOURRITURE){
				_tab[case_remplir] = DESERT_FER;
				nombre_ressource++;
			}
		}
	}
	
	////////////////////////////////////////// 
	//Placement des joueurs sur la carte
	////////////////////////////////////////// 

	if(_nb_joueurs == 2){ // les 2 joueurs sont placés sur la diagonale HAUT-GAUCHE vers BAS-DROITE
		_placement_joueurs[0] = 0;			// le joueur 1 commence en HAUT-GAUCHE en position 0 * 0
		_placement_joueurs[0] = 0; 
		_placement_joueurs[1] = _taille-1;  // le joueur 2 commence en BAS-DROITE en position _taille-1 * _taille-1
		_placement_joueurs[1] = _taille-1; 
	}else{ // les 4 joueurs sont placés sur la diagonale HAUT-GAUCHE vers BAS-DROITE et sur la diagonale BAS-GAUCHE vers HAUT-DROITE
		_placement_joueurs[0] = 0;			// le joueur 1 commence en HAUT-GAUCHE en position 0 * 0
		_placement_joueurs[0] = 0; 
		_placement_joueurs[1] = _taille-1;  // le joueur 2 commence en BAS-DROITE en position _taille-1 * _taille-1
		_placement_joueurs[1] = _taille-1; 
		_placement_joueurs[2] = 0;			// le joueur 3 commence en BAS-GAUCHE en position 0 * _taille-1
		_placement_joueurs[2] = _taille-1; 
		_placement_joueurs[3] = _taille-1;  // le joueur 4 commence en HAUT-DROITE en position _taille-1 * 0
		_placement_joueurs[3] = 0; 
	}

	// Peut être utilisé pour sauvegarder une carte générée aléatoirement

	/*ofstream fichier("test_wrapper_algocpp.txt", ios::out | ios::trunc);  // ouverture en écriture avec effacement du fichier ouvert
 
    if(fichier){
		for( i = 0 ; i < _taille ; i++ ){
			for(  j = 0 ; j < _taille ; j++){
				fichier << _tab[i*_taille+j];
			}
				fichier << "\n";
		}
        fichier.close();
	}else{ cerr << "Impossible d'ouvrir le fichier !" << endl; }*/
	return _tab;
}

// Suggere les cases sur lesquelles il faut fonder une ville pour un colon donné
// Les deux premières cases correspondent aux cases où il y a un maximum de FER
// La troisieme case correspond a la case où il y a un maximum de NOURRITURE
void Algo_carte::cases_a_suggerees(int x_colon, int y_colon){
	int* fer= new int[_taille*_taille]; // Tableau contenant les ressources en FER par blocs 3*3 
										// dont le centre du bloc correspond a la case a partir de laquelle le calcul a été effectué
										// Ainsi rend_ressource_fer(2,3) rend le nombre de FER présent autour de la case (2,3)
	int* nourriture= new int[_taille*_taille]; // Idem mais pour les ressources
	int i=0; // Initialisation des variables nécessaires au parcours des tableaux
	int j=0;
	for(i=0; i<_taille ; i++){ // Remplissage des tableaux des ressources FER et NOURRITURE
		for(j=0; j<_taille ; j++){ 
			fer[i*_taille+j]=rend_ressource_fer(i,j);
			nourriture[i*_taille+j]=rend_ressource_nourriture(i,j);

		}
	}
	// Coefficient permettant de délimiter la zone à analyser autour du colon
	int coefficient_analyse= 8;//_taille/_nb_joueurs;

	int maxfer_0=-1; // Initialisé à -1, ainsi si jamais le maximum est 0 FER alors on aura les bonnes coordonnées
	int maxfer_0_x=-1; // Coordonnées de la case contenant le maximum de FER dans le périmètre
	int maxfer_0_y=-1;
	int maxfer_1 = -1;
	int maxfer_1_x=-1; // Coordonnées de la case contenant le nombre maximum de FER juste avant maxfer_0 dans le périmètre
	int maxfer_1_y=-1;
	int maxnourriture_x=-1; // Coordonnées de la case contenant le maximum de NOURRITURE dans le périmètre
	int maxnourriture_y=-1;
	int maxnourriture = -1;

	i = x_colon- 3;
	j = y_colon - 3;
	int imax = x_colon+ 3;
	int jmax = y_colon + 3;
	for(i; i<imax ; i++){
		for(j;j<jmax; j++){
			if(fer[i*_taille+j] >  maxfer_0){
				maxfer_0=fer[i*_taille+j];
				maxfer_0_x=i;
				maxfer_0_y=j;
			}else if(fer[i*_taille+j] <=  maxfer_0 && maxfer_0_x != maxfer_1_x && maxfer_0_y != maxfer_1_y){
				maxfer_1=fer[i*_taille+j];
				maxfer_1_x=i;
				maxfer_1_y=j;
			}
			if(nourriture[i*_taille+j] >  maxnourriture){
				maxnourriture=nourriture[i*_taille+j];
				maxnourriture_x=i;
				maxnourriture_y=j;
			}
		}
		j=y_colon - 3;
	}
	cout << " MAX0 FER "<< maxfer_0 << " en " << maxfer_0_x << ";" << maxfer_0_y << endl;
	cout << " MAX1 FER "<< maxfer_1 << " en " << maxfer_1_x << ";" << maxfer_1_y << endl;
	cout << " MAX2 NOURRITURE "<< maxnourriture << " en " << maxnourriture_x << ";" << maxnourriture_y << endl;
	_cases_suggerees[0] = maxfer_0;
	_cases_suggerees[1] = maxfer_0_x;
	_cases_suggerees[2] = maxfer_0_y;
	_cases_suggerees[3] = maxfer_1;
	_cases_suggerees[4] = maxfer_1_x;
	_cases_suggerees[5] = maxfer_1_y;
	_cases_suggerees[6] = maxnourriture;
	_cases_suggerees[7] = maxnourriture_x;
	_cases_suggerees[8] = maxnourriture_y;

	delete[] fer;
	delete[] nourriture;

}

// Retourne le nombre de fer total d'un bloc de 4x4 cases
int Algo_carte::rend_ressource_fer(int x, int y){
	if( x < 3 || y < 3 || x > (_taille-4) || y > (_taille-4) ) { return 0; } // Le cas où l'on test les cases au bord de la carte n'est pas à traité puisqu'elles le seront quand on traitera le bloc 3*3 les ayant comme bord
	int fer=0;
	int i=x-3; // La ligne supérieure du bloc 4*4 possède une abscisse de x-3 du bloc 4*4 a testé
	int imax=x+3;
	int j=y-3; // Le bloc commence trois ordonnées avant la case centrale de coordonnées (x,y)
	int jmax=y+3;
	int calcul_case=0;
	int type_case=0;
	for(i; i<imax;i++){
		for(j;j<jmax;j++){
			calcul_case=i*_taille+j;
			type_case = _tab[calcul_case];
			switch (type_case){
			case DESERT : fer+=2;
						  break;
			case DESERT_FER : fer+=4;
						  break;
			case DESERT_NOURRITURE : fer+=2;
						  break;
			case MONTAGNE : fer+=3;
						  break;
			case MONTAGNE_FER : fer+=5;
						  break;
			case MONTAGNE_NOURRITURE : fer+=3;
						  break;
			case PLAINE : fer+=1;
						  break;
			case PLAINE_FER : fer+=3;
						  break;
			case PLAINE_NOURRITURE : fer+=1;
						  break;
			default : fer+=0;
			}
		}
		j=y-3;
	}
	return fer;
}

// Retourne le nombre de nourriture total d'un bloc de 4x4 cases
int Algo_carte::rend_ressource_nourriture(int x, int y){
	if( x < 3 || y < 3 || x > (_taille-4) || y > (_taille-4) ) { return 0; } // Le cas où l'on test les cases au bord de la carte n'est pas à traité puisqu'elles le seront quand on traitera le bloc 3*3 les ayant comme bord
	int nourriture=0;
	int i=x-3; // La ligne supérieure du bloc 4*4 possède une abscisse de x-3 du bloc 4*4 a testé
	int imax=x+3;
	int j=y-3; // Le bloc commence trois ordonnée avant la case centrale de coordonnées (x,y)
	int jmax=y+3;
	int calcul_case=0;
	int type_case=0;
	for(i; i<imax;i++){
		for(j;j<jmax;j++){
			calcul_case=i*_taille+j;
			type_case = _tab[calcul_case];
			switch (type_case){
			case DESERT : nourriture+=0;
						  break;
			case DESERT_FER : nourriture+=0;
						  break;
			case DESERT_NOURRITURE : nourriture+=2;
						  break;
			case MONTAGNE : nourriture+=0;
						  break;
			case MONTAGNE_FER : nourriture+=0;
						  break;
			case MONTAGNE_NOURRITURE : nourriture+=2;
						  break;
			case PLAINE : nourriture+=3;
						  break;
			case PLAINE_FER : nourriture+=3;
						  break;
			case PLAINE_NOURRITURE : nourriture+=5;
						  break;
			default : nourriture+=0;
			}
		}
		j=y-3;
	}
	return nourriture;
}

// Retourne le nombre de fer total d'un bloc de 4x4 cases
int Algo_carte::rend_ressource_fer_une_case(int x, int y){
	int	calcul_case=x*_taille+y;
	int type_case = _tab[calcul_case];
	int fer=0;
	switch (type_case){
		case DESERT : fer+=2;
			break;
		case DESERT_FER : fer+=4;
			break;
		case DESERT_NOURRITURE : fer+=2;
			break;
		case MONTAGNE : fer+=3;
			break;
		case MONTAGNE_FER : fer+=5;
			break;
		case MONTAGNE_NOURRITURE : fer+=3;
			break;
		case PLAINE : fer+=1;
			break;
		case PLAINE_FER : fer+=3;
			break;
		case PLAINE_NOURRITURE : fer+=1;
			break;
		default : fer+=0;
	}
	return fer;
}

// Retourne le nombre de nourriture total d'un bloc de 4x4 cases
int Algo_carte::rend_ressource_nourriture_une_case(int x, int y){
	int	calcul_case=x*_taille+y;
	int type_case = _tab[calcul_case];
	int nourriture=0;
	switch (type_case){
		case DESERT : nourriture+=0;
			break;
		case DESERT_FER : nourriture+=0;
			break;
		case DESERT_NOURRITURE : nourriture+=2;
			break;
		case MONTAGNE : nourriture+=0;
			break;
		case MONTAGNE_FER : nourriture+=0;
			break;
		case MONTAGNE_NOURRITURE : nourriture+=2;
			break;
		case PLAINE : nourriture+=3;
			break;
		case PLAINE_FER : nourriture+=3;
			break;
		case PLAINE_NOURRITURE : nourriture+=5;
			break;
		default : nourriture+=0;
	}
	return nourriture;
}

// Fonction qui décompose un nombre en somme de sous nombre 
list<int> Algo_carte::decompose_nombre(int nombre, int nb_decomposition){
	list<int> l;
	int tmpasuprr=nb_decomposition;
	int tmp = nombre / nb_decomposition; 
	//int coefficient = 25; valeur par defaut
	int coefficient = rand() % 35 + 20; // Coefficient utilise pour garantir une valeur, aleatoire, commune a la liste
	while(tmp<2){ // Si tmp est inferieur a 2 alors on diminue le nombre de decomposition car un bloc de 1*1 case n'existe pas,
		nb_decomposition--; // on doit avoir un bloc de 2*2 cases au minimum
		tmp = nombre / nb_decomposition;
	}
	if(tmp>(_taille/coefficient)){ // On regarde si nombre est divisible par nb_decomposition, si oui alors on ajoute  
		while(nb_decomposition>0){ // nb_decomposition fois le resultat tmp a la liste.
			l.push_back(tmp);
			nb_decomposition--;
		}
	}else{
		while(tmp<(_taille/coefficient)){ // Sinon, on diminue le nombre de decompostion jusqu'a obtenir un nombre tmp valide tel que
			tmp = nombre / nb_decomposition; // l.size() * tmp environ egal au nombre a decomposer
			nb_decomposition--;
		}
		while(nb_decomposition>0){ // On ajoute nb_decomposition fois le nombre tmp a la liste
			l.push_back(tmp); // Ainsi l.size() * tmp environ egal  au nombre a decomposer
			nb_decomposition--;
		}
	}
	if((nombre - (l.size()*tmp))>=2){ // Si apres tout ce qu'on a ajoute a la liste, le nombre n'est pas encore la somme des elements de la liste
		l.push_back(nombre - (l.size()*tmp)); // on ajoute le reste a la liste
	}
	// Affichage de la decomposition
	cout << "\nAffichage de la liste des nombres pour " <<nombre<< " en "<<tmpasuprr<<" parties"<< endl;
	list<int>::iterator i = l.begin();
	list<int>::iterator i2 = l.end();
	for(;i!=i2;i++){
		cout << *i << '|';
	}
	return l;
}

Algo_carte::~Algo_carte(){
	delete [] _tab;
	delete [] _placement_joueurs;
	delete [] _cases_suggerees;
}

Algo_carte* Algo_carte_new(int taille, int nb_joueurs) { return new Algo_carte(taille,nb_joueurs); }
void Algo_carte_delete(Algo_carte* algo_carte) { delete algo_carte; }
int* Algo_carte_generer(Algo_carte* algo_carte) { return algo_carte->generationCarte();}
void Algo_carte_cases_a_suggerees(Algo_carte* algo_carte, int x_colon, int y_colon) { algo_carte->cases_a_suggerees(x_colon, y_colon);}
int Algo_carte_rend_ressource_fer_une_case(Algo_carte* algo_carte, int x, int y) { return algo_carte->rend_ressource_fer_une_case(x, y);}
int Algo_carte_rend_ressource_nourriture_une_case(Algo_carte* algo_carte, int x, int y) { return algo_carte->rend_ressource_nourriture_une_case(x, y);}