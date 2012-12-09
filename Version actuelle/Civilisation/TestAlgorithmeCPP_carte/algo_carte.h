#define DESERT 0
#define DESERT_FER 1
#define DESERT_NOURRITURE 2
#define MONTAGNE 3
#define MONTAGNE_FER 4
#define MONTAGNE_NOURRITURE 5
#define PLAINE 6
#define PLAINE_FER 7
#define PLAINE_NOURRITURE 8

class Algo_carte
{
private:
	int _taille;
	int* _tab;
public:
	Algo_carte(const int taille);
	int* generationCarte();
	~Algo_carte();
};
