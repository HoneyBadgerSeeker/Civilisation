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
using System.Windows.Shapes;
using PCivilisation;
using PImplEii;
using PImplInfo;
using PInterfaces_Fabrique_Abstraite;
using PJoueur;
namespace Civilisation
{
    /// <summary>
    /// Logique d'interaction pour FenetreProduction.xaml
    /// </summary>
    /// 


    public partial class FenetreProduction : Window
    {
        // partie en cours
        Ville _ville_sel = new Ville(12,1,"tata");

        // joueur a qui appartient la ville
        Joueur _j_actuel;

        // fabrique permettant de créer les unités
        FabriqueUnite _fabrique_unite;

        // cout des unites
        int cout_dir = 200;
        int cout_ens = 60;
        int cout_etu = 100;

        // constructeur de la fenetre de production de la ville
        // Remarque : les joueurs ne peuvent pas qu'annuler une seule production en cours
        // si une production est deja en cours il faut l'annuler pour pouvoir faire une autre
        // production en cours
        // cela permet d'eviter d'avoir a gerer une file d'unite mais c'est limitant
        // cela oblige le joueur a chaque tour a lancer la creation d'une unité, il ne peut pas faire
        // de file de production d'unités
        public FenetreProduction(Ville v, Joueur j)
        {

            /****************************************************************/
            /****************************************************************/
            /****************************************************************/
            /****************************************************************/

            //  A MODIFIER UNE FOIS LES VILLES GEREES SUR LA CARTE
            // CELA PERMET JUSTE DE VOIR LE FONCTIONNEMENT TYPE DE LA PRODUCTION SUR UNE VILLE TEST

            //_ville_sel = v; a décommenter une fois la gestion de l'affichage des villes sur la carte
            // _j_actuel = j;
            _ville_sel._ressourceFer = 450; // v._ressourceFer test à modif
            _ville_sel._ressourceNourriture = 42; // v._ressourceNourriture test à modif

            _j_actuel = new Joueur("Popo", new Eii("Cataka"), PConstantes.CouleurJoueur.BLEU); // test à suppr

            _ville_sel._unite_en_prod = new EnseignantEii(15, 2); // test à suppr

            /****************************************************************/
            /****************************************************************/
            /****************************************************************/
            /****************************************************************/


            // initialisation de la fabrique en fonction du type de la civilisation du joueur
            if (_j_actuel._civ is Eii)
            {
                _fabrique_unite = new FabriqueUniteEii();
            }
            else if (_j_actuel._civ is Info)
            {
                _fabrique_unite = new FabriqueUniteInfo();
            }

  
            InitializeComponent();
            this.Title = _ville_sel._nomVille;

            // initialisation de l'affichage des ressources en fer de la ville
            label_ville_fer.Content = _ville_sel._ressourceFer;

            // initialisation de l'affichage des ressources en nourriture de la ville
            label_ville_nourriture.Content = _ville_sel._ressourceNourriture;
            


            // initialisation de l'affichage de la production en cours;
            if (_ville_sel._unite_en_prod == null)
            {
                label_ville_production_en_cours.Content = "Aucune";
                button_annuler_production.IsEnabled = false;
            }
            else
            {
                button_annuler_production.IsEnabled = true;
                Unite tmp = _ville_sel._unite_en_prod;
                string typeUnite = tmp.GetType().Name;
                if (typeUnite.Contains("Dir"))
                {
                    label_ville_production_en_cours.Content = "Directeur";
                }
                else if (typeUnite.Contains("Ens"))
                {
                    label_ville_production_en_cours.Content = "Enseignant";
                }
                else if (typeUnite.Contains("Etu"))
                {
                    label_ville_production_en_cours.Content = "Etudiant";
                }

                // Desactive les boutons d'achats d'unités car une unité est déjà en production
                desactiverBoutonAchat();
            }

            // initialisation de l'affichage des couts des unités
            label_cout_fer_directeur.Content = cout_dir;
            label_cout_fer_enseignant.Content = cout_ens;
            label_cout_fer_etudiant.Content = cout_etu;

        }

        private void Button_click_revenir_sur_carte(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_click_creerDirecteur(object sender, RoutedEventArgs e)
        {
            // l'achat peut-il se faire?
            if (_ville_sel._ressourceFer >= cout_dir)
            {
                // si oui alors

                // gere la dépense
                _ville_sel._ressourceFer -= cout_dir;

                // modification de la production en cours
                _ville_sel._unite_en_prod = _fabrique_unite.creerDirecteur(_ville_sel._posx_ville, _ville_sel._posy_ville);
          
                // mise à jour du label de production en cours
                label_ville_production_en_cours.Content = "Directeur";

                // mise à jour du label des ressources en fer de la ville
                label_ville_fer.Content = _ville_sel._ressourceFer;

                // on autorise l'annulation de la production en cours
                button_annuler_production.IsEnabled = true;

                // Desactive les boutons d'achats d'unités car une unité est déjà en production
                desactiverBoutonAchat();
            }
            else
            {
                FenetreProductionErreur fenetre = new FenetreProductionErreur(this);
                fenetre.Show();
            }
        }

        private void Button_click_creerEnseignant(object sender, RoutedEventArgs e)
        {
            if (_ville_sel._ressourceFer >= cout_ens)
            {
                // si oui alors

                // gere la dépense
                _ville_sel._ressourceFer -= cout_ens;

                // ajout a la production en cours
                _ville_sel._unite_en_prod = _fabrique_unite.creerEnseignant(_ville_sel._posx_ville, _ville_sel._posy_ville);

                // mise à jour du label de production en cours
                label_ville_production_en_cours.Content = "Enseignant";

                // mise à jour du label des ressources en fer de la ville
                label_ville_fer.Content = _ville_sel._ressourceFer;

                // on autorise l'annulation de la production en cours
                button_annuler_production.IsEnabled = true;

                // Desactive les boutons d'achats d'unités car une unité est déjà en production
                desactiverBoutonAchat();
            }
            else
            {
                FenetreProductionErreur fenetre = new FenetreProductionErreur(this);
                fenetre.Show();
            }
        }

        private void Button_click_creerEtudiant(object sender, RoutedEventArgs e)
        {
            if (_ville_sel._ressourceFer >= cout_etu)
            {
                // si oui alors

                // gere la dépense
                _ville_sel._ressourceFer -= cout_etu;

                // ajout a la production en cours
                _ville_sel._unite_en_prod = _fabrique_unite.creerEtudiant(_ville_sel._posx_ville, _ville_sel._posy_ville);

                // mise à jour du label de production en cours
                label_ville_production_en_cours.Content = "Etudiant";

                // mise à jour du label des ressources en fer de la ville
                label_ville_fer.Content = _ville_sel._ressourceFer;

                // on autorise l'annulation de la production en cours
                button_annuler_production.IsEnabled = true;

                // Desactive les boutons d'achats d'unités car une unité est déjà en production
                desactiverBoutonAchat();
            }
            else
            {
                FenetreProductionErreur fenetre = new FenetreProductionErreur(this);
                fenetre.Show();
            }
        }

        private void Button_click_annuler_prod_en_cours(object sender, RoutedEventArgs e)
        {
            // on ajoute le ressources de la production annulées à la ville
            if (_ville_sel._unite_en_prod != null)
            {
                Unite tmp = _ville_sel._unite_en_prod;
                string typeUnite = tmp.GetType().Name;
                if (typeUnite.Contains("Dir"))
                {
                    // mise à jour des ressources en fer de la ville
                    _ville_sel._ressourceFer += cout_dir;
                }
                else if (typeUnite.Contains("Ens"))
                {
                    _ville_sel._ressourceFer += cout_ens;
                }
                else if (typeUnite.Contains("Etu"))
                {
                    _ville_sel._ressourceFer += cout_etu;
                }
            }
            // mise à jour du label des ressources en fer de la ville
            label_ville_fer.Content = _ville_sel._ressourceFer; 

            // on retire l'unite en cours production
            _ville_sel._unite_en_prod = null;

            // on met à jour le label de la production en cours
            label_ville_production_en_cours.Content = "Aucune";

            // on desactive le bouton pour annuler la production en cours puisqu'il n'y en a plus
            button_annuler_production.IsEnabled = false;

            // Active les boutons d'achats d'unités car aucune unité est en production
            activerBoutonAchat();
        }

        // Desactive les boutons d'achats d'unités quand une unité est déjà en production
        public void desactiverBoutonAchat()
        {
            button_prod_dir.IsEnabled = false;
            button_prod_ens.IsEnabled = false;
            button_prod_etu.IsEnabled = false;
        }

        // Desactive les boutons d'achats d'unités quand une unité est déjà en production
        public void activerBoutonAchat()
        {
            button_prod_dir.IsEnabled = true;
            button_prod_ens.IsEnabled = true;
            button_prod_etu.IsEnabled = true;
        }

    }
}
