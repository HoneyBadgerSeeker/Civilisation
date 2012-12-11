using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wrapper;
using PConstantes;
using Civilisation.PoidsMoucheTexturesCases;
using Civilisation;
using PMonteurPartie;
using PJoueur;
using PCivilisation;
using PPartie;
using PInterfaces_Fabrique_Abstraite;
using PImplInfo;
using PImplEii;

namespace Civilisation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public unsafe partial class MainWindow : Window
    {

        // fabrique des textures
        FabriqueTexturesCases _fabriqueTextures;
        FabriqueTexturesUnites _fabriqueTexturesUnites;
        // contient les types des cases de la carte
        int* _tabInt_carte;

        // taille de la carte
        int _taille;
        
        // partie en cours
        Partie _partie;

        // ville selectionnee
        Ville _ville_sel;
        
        // constructeur de la fenetre principale du jeu
        public unsafe MainWindow(Partie partie)
        {
            InitializeComponent();

            // Initialisation de la partie
            _partie = partie;

            // recuperation de la taille de la carte pour la générer
            _taille = _partie._carte.getTaille();

            // recuperation des types de cases de la carte pour la générer
            _tabInt_carte = _partie._carte._tabInt;

            // initialisation de la fabrique de texture
            _fabriqueTextures = new FabriqueTexturesCases();

            // initialisation de la fabrique de texture des unités
            _fabriqueTexturesUnites = new FabriqueTexturesUnites();



        }

        /************************************************************************************************/
        /************************************************************************************************/
        /************************************************************************************************/
        /************************************************************************************************/
        /* Affichage de la carte et des unités */

        private unsafe void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            for (int c = 0; c < _taille; c++)
            {
                carteGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            }
            int l;
            for (l = 0; l < _taille; l++)
            {
                carteGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
                for (int c = 0; c < _taille; c++)
                {
                    // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    // le rectangle possède une référence sur sa tuile
                    var tile = _tabInt_carte[l * _taille + c];
                    var rectangle_case = createRectangleTerrain(c, l, tile);
                    carteGrid.Children.Add(rectangle_case); // On ajoute les terrains
                    if (tile != PConstantes.TypeCase.DESERT && tile != PConstantes.TypeCase.MONTAGNE && tile != PConstantes.TypeCase.PLAINE)
                    {
                        var rectangle_ressource = createRectangleRessource(c, l, tile);
                        carteGrid.Children.Add(rectangle_ressource); // On ajoute les ressources
                    }

                }
            }

            // ajout des unités sur la carte
            foreach (Joueur j in _partie._liste_joueurs) // NE PAS OUBLIER DE GERER LES COULEURS DES JOUEUUUURS
            {                                               // peut correspondre à une méthode a par entiere mise la juste pour tester
                // creation d'une couleur ici
                // a chaque tour de boucle on en crée une nouvelle
                /**/

                foreach (Unite u in j._liste_unite)
                {
                    if (u is EtudiantEii || u is EtudiantInfo)
                    {
                        var rectangle_unite = createRectangleUnite(u._posx_unite, u._posy_unite, PConstantes.TypeUnite.ETUDIANT);
                        carteGrid.Children.Add(rectangle_unite);
                    }
                    else if (u is DirecteurEii || u is DirecteurInfo)
                    {
                        var rectangle_unite = createRectangleUnite(u._posx_unite, u._posy_unite, PConstantes.TypeUnite.DIRECTEUR);
                        carteGrid.Children.Add(rectangle_unite);
                    }
                    else if (u is EnseignantEii || u is EnseignantInfo)
                    {
                        var rectangle_unite = createRectangleUnite(u._posx_unite, u._posy_unite, PConstantes.TypeUnite.ENSEIGNANT);
                        carteGrid.Children.Add(rectangle_unite);
                    }

                    // ajout de la couleur sur la case ici

                    /**/

                }
            }

            // position de la camera sur la premiere unite de la liste du joueur courant
            Unite u1 = _partie._joueurCourant._liste_unite.ElementAt(0);
            //scrollbar.ScrollToHorizontalOffset(1000);
            //scrollbar.ScrollToHorizontalOffset(carteGrid.Height * (u1._posy_unite) / _taille);

        }

        // Rend un rectangle contenant les textures des terrains
        private Rectangle createRectangleTerrain(int c, int l, int tile)
        {
            var rectangle = new Rectangle();
            rectangle.Fill = _fabriqueTextures.obtenirTextureCaseTerrain(tile);
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile; // Tag : ref par defaut sur la tuile logique
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

        // Rend un rectangle contenant les textures des ressources
        private Rectangle createRectangleRessource(int c, int l, int tile)
        {
            var rectangle = new Rectangle();
            rectangle.Fill = _fabriqueTextures.obtenirTextureCaseRessource(tile);
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile; // Tag : ref par defaut sur la tuile logique
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

        // Rend un rectangle contenant les textures des unités
        private Rectangle createRectangleUnite(int c, int l, int unite)
        {
            var rectangle = new Rectangle();
            rectangle.Fill = _fabriqueTexturesUnites.obtenirTextureUnite(unite);
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = unite; // Tag : ref par defaut sur la tuile logique

            // ajouter aussi un handler pour le clavier! -> gerer les deplacements

            // selection de la case via la souris
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

        /************************************************************************************************/
        /************************************************************************************************/
        /************************************************************************************************/
        /************************************************************************************************/
        /* Handler */

        void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            int colonne = Grid.GetColumn(rectangle);
            int ligne = Grid.GetRow(rectangle);
            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionRectangle, colonne);
            Grid.SetRow(selectionRectangle, ligne);
            selectionRectangle.Visibility = System.Windows.Visibility.Visible;

            // mise a jour des labels concernant les ressources CASES
            label_case_fer.Content = _partie._carte.recupererCase(ligne, colonne).getFer();
            label_case_nourriture.Content = _partie._carte.recupererCase(ligne, colonne).getNourriture();

            // mise a jour des labels concernant les ressources VILLES
            if (_partie._joueurCourant._civ._villes.Count > 0)
            {
                foreach (Ville v in _partie._joueurCourant._civ._villes)
                {
                    if (v._posx_ville == ligne && v._posy_ville == colonne)
                    {
                        label_nom_ville.Content = v._nomVille;
                        label_ville_fer.Content = v._ressourceFer;
                        label_ville_nourriture.Content = v._ressourceNourriture;
                        label_ville_taille.Content = v._habitants;
                        label_ville_tour_agrandissement.Content = "A determiner";
                        bouton_production_ville.IsEnabled = true;
                        _ville_sel = v;
                        break;
                    }
                }
            }
            else
            {
                label_nom_ville.Content = "Aucune ville sélectionnée";
                label_ville_taille.Content = "N\\A";
                label_ville_fer.Content = "N\\A";
                label_ville_nourriture.Content = "N\\A";
                label_ville_tour_agrandissement.Content = "A determiner";
                bouton_production_ville.IsEnabled = false;
            }

            e.Handled = true;
        }

        private void Button_click_fin_tour(object sender, RoutedEventArgs e)
        {
            // Action a effectuer lors de la fin du tour
            // passer la main au joueur suivant.
            // label_nb_avant_fin a decrementer
            // mettre a jour les production des villes

        }

        private void Button_Click_prod_ville(object sender, RoutedEventArgs e)
        {
            FenetreProduction fenetre = new FenetreProduction(_ville_sel, _partie._joueurCourant);
            fenetre.Show();
        }




    }
}
