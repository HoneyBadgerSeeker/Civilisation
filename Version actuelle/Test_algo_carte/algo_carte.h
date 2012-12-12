#define DESERT 0
#define DESERT_FER 1
#define DESERT_NOURRITURE 2
#define MONTAGNE 3
#define MONTAGNE_FER 4
#define MONTAGNE_NOURRITURE 5
#define PLAINE 6
#define PLAINE_FER 7
#define PLAINE_NOURRITURE 8

#include <iostream>
#include <list>
#include <sstream>
using namespace std;

class Algo_carte
{
private:
 int _taille;
 int* _tab;
 int _nb_joueurs;
 int* _placement_joueurs; // Description du tableau à la fin du .h
 int* _cases_suggerees; // Description du tableau à la fin du .h
public:
 Algo_carte(const int taille, const int _nb_joueurs);
 list<int> decompose_nombre(int nombre, int nb_decomposition);
 int* generationCarte();
 void cases_a_suggerees(int x_colon, int y_colon);
 int rend_ressource_fer(int x, int y);
 int rend_ressource_nourriture(int x, int y);
 ~Algo_carte();
};


// _placement_joueurs contient :
//_placement_joueurs[0] = coordonnée X du joueur 1
//_placement_joueurs[1] = coordonnée Y du joueur 1
//_placement_joueurs[2] = coordonnée X du joueur 2
//_placement_joueurs[3] = coordonnée Y du joueur 2
//_placement_joueurs[4] = coordonnée X du joueur 3
//_placement_joueurs[5] = coordonnée Y du joueur 3
//_placement_joueurs[6] = coordonnée X du joueur 4
//_placement_joueurs[7] = coordonnée Y du joueur 4

// _cases_suggerees contient :
//_cases_suggerees[0] = nombre maximum de FER dans le périmètre du colon
//_cases_suggerees[1] = coordonnée X du nombre maximum de FER dans le périmètre du colon
//_cases_suggerees[2] = coordonnée Y du nombre maximum de FER dans le périmètre du colon
//_cases_suggerees[3] = second nombre maximum de FER dans le périmètre du colon
//_cases_suggerees[4] = coordonnée X du second nombre maximum de FER dans le périmètre du colon
//_cases_suggerees[5] = coordonnée Y du second nombre maximum de FER dans le périmètre du colon
//_cases_suggerees[6] = nombre maximum de NOURRITURE dans le périmètre du colon
//_cases_suggerees[7] = coordonnée X du nombre maximum de NOURRITURE dans le périmètre du colon
//_cases_suggerees[8] = coordonnée Y du nombre maximum de NOURRITURE dans le périmètre du colon