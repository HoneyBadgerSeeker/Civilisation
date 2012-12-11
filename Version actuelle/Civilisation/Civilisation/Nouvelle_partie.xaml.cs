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
using PJoueur;
using PMonteurPartie;
using PPartie;
using PCarte;
using PCivilisation;
using PConstantes;

namespace Civilisation
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Nouvelle_partie : Window
    {
        // Taille de la carte
        int _taille;

        // monteur de la partie en cours
        MonteurCreationPartieAbstraite _monteur;

        // partie en cours
        Partie _partie;

        // liste des joueurs
        List<Joueur> _liste_joueur_courant;

        public Nouvelle_partie() // il faut gerer le cas ou tout n'est pas correctement rentré => impossible de lancer la partie, il faut griser le bouton partie.
        {
            InitializeComponent();

            // initialisation du monteur
            _monteur = new MonteurCreationPartie();

            // initialisation de la liste des joueurs
            _liste_joueur_courant = new List<Joueur>();

            // desactivation des elements inutilisables tant que l'on n'a pas coché un joueur
            textbox_joueur1.IsEnabled = false;
            textbox_joueur2.IsEnabled = false;
            textbox_joueur3.IsEnabled = false;
            textbox_joueur4.IsEnabled = false;
            textbox_civilisation1.IsEnabled = false;
            textbox_civilisation2.IsEnabled = false;
            textbox_civilisation3.IsEnabled = false;
            textbox_civilisation4.IsEnabled = false;
        }

        // creation de la partie
        private unsafe void Button_Click_lancer_partie(object sender, RoutedEventArgs e) // quand le joueur clique sur lancer la partie on présume qu'il a rempli tout les champs
        {

            Joueur j1 = null;
            Joueur j2 = null;
            Joueur j3 = null;
            Joueur j4 = null;

            // creation et ajout des joueurs dans la liste des joueurs

            if ((bool)chkActiveJ1.IsChecked)
            {
                if ((bool)j1info.IsChecked) // si info est coché alors le joueur est info
                {
                    j1 = new Joueur(textbox_joueur1.Text, new Info(textbox_civilisation1.Text));
                    _liste_joueur_courant.Add(j1);
                }
                else // sinon il est Eii
                {
                    j1 = new Joueur(textbox_joueur1.Text, new Eii(textbox_civilisation1.Text));
                    _liste_joueur_courant.Add(j1);
                }
                
            }
            if ((bool)chkActiveJ2.IsChecked)
            {
                if ((bool)j2info.IsChecked) // si info est coché alors le joueur est info
                {
                    j2 = new Joueur(textbox_joueur2.Text, new Info(textbox_civilisation2.Text));
                    _liste_joueur_courant.Add(j2);
                }
                else // sinon il est Eii
                {
                    j2 = new Joueur(textbox_joueur2.Text, new Eii(textbox_civilisation2.Text));
                     _liste_joueur_courant.Add(j2);
                }
                
            }
            if ((bool)chkActiveJ3.IsChecked)
            {
                if ((bool)j3info.IsChecked) // si info est coché alors le joueur est info
                {
                    j3 = new Joueur(textbox_joueur3.Text, new Info(textbox_civilisation3.Text));
                     _liste_joueur_courant.Add(j3);
                }
                else // sinon il est Eii
                {
                    j3 = new Joueur(textbox_joueur3.Text, new Eii(textbox_civilisation3.Text));
                    _liste_joueur_courant.Add(j3);
                }
            }
            if ((bool)chkActiveJ4.IsChecked)
            {
                if ((bool)j4info.IsChecked) // si info est coché alors le joueur est info
                {
                    j4 = new Joueur(textbox_joueur4.Text, new Info(textbox_civilisation4.Text));
                     _liste_joueur_courant.Add(j4);
                }
                else // sinon il est Eii
                {
                   j4 = new Joueur(textbox_joueur4.Text, new Eii(textbox_civilisation4.Text));
                    _liste_joueur_courant.Add(j4);
                }
            }

         
            // creation de la partie
            _partie = _monteur.creerNouvellePartie(_taille, _liste_joueur_courant);

            // ajout des unités de début de partie à chaque joueur
            // recuperation des positions de chaque joueurs
            int* tab_placement_j = _partie._carte._algo.rend_placement_joueurs();

            // on regarde que les joueurs existent bien
            if (j1 != null && j2 != null) // si oui on lui ajoute les unités de base
            {
                j1._liste_unite.Add(j1._fabrique.creerEtudiant(tab_placement_j[0],tab_placement_j[1]));
                j1._liste_unite.Add(j1._fabrique.creerEnseignant(tab_placement_j[0], tab_placement_j[1]));
                j2._liste_unite.Add(j2._fabrique.creerEtudiant(tab_placement_j[2], tab_placement_j[3]));
                j2._liste_unite.Add(j2._fabrique.creerEnseignant(tab_placement_j[2], tab_placement_j[3]));
            }
            if (j3 != null && j4 != null) 
            {
                j3._liste_unite.Add(j3._fabrique.creerEtudiant(tab_placement_j[4], tab_placement_j[5]));
                j3._liste_unite.Add(j3._fabrique.creerEnseignant(tab_placement_j[4], tab_placement_j[5]));
                j4._liste_unite.Add(j4._fabrique.creerEtudiant(tab_placement_j[6], tab_placement_j[7]));
                j4._liste_unite.Add(j4._fabrique.creerEnseignant(tab_placement_j[6], tab_placement_j[7]));
            }

            // creation de la fenetre du jeu
            MainWindow jeu = new MainWindow(_partie);

            jeu.Show();
            this.Close();

        }


            


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Menu_principal menu = new Menu_principal();
            menu.Show();
            this.Close();
        }

        // activation/desactivation des options en fonction des joueurs selectionnés.

        /******************** joueur 1 **********************/
        private void CheckBox_Checked_1_j1(object sender, RoutedEventArgs e) // check box joueur
        {
            textbox_joueur1.IsEnabled = true;
            textbox_civilisation1.IsEnabled = true;
            j1info.IsEnabled = true;
            j1eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_1_j1(object sender, RoutedEventArgs e) // uncheck box joueur
        {
            j1info.IsChecked = false;
            j1eii.IsChecked = false;
            j1info.IsEnabled = false;
            j1eii.IsEnabled = false;
            textbox_joueur1.IsEnabled = false;
            textbox_joueur1.Clear();
            textbox_civilisation1.IsEnabled = false;
            textbox_civilisation1.Clear();
        }
        private void CheckBox_UnChecked_7_j1info(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j1eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_8_j1eii(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j1info.IsEnabled = true;
        }
        private void CheckBox_Checked_7_j1(object sender, RoutedEventArgs e) // check box choix civilisation info 
        {
            j1eii.IsEnabled = false;
        }
        private void CheckBox_Checked_8_j1(object sender, RoutedEventArgs e) // check box choix civilisation eii 
        {
            j1info.IsEnabled = false;
        }


        /******************** joueur 2 **********************/
        private void CheckBox_Checked_2_j2(object sender, RoutedEventArgs e) // check box joueur
        {
            textbox_joueur2.IsEnabled = true;
            textbox_civilisation2.IsEnabled = true;
            j2info.IsEnabled = true;
            j2eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_2_j2(object sender, RoutedEventArgs e) // uncheck box joueur
        {
            j2info.IsChecked = false;
            j2eii.IsChecked = false;
            j2info.IsEnabled = false;
            j2eii.IsEnabled = false;
            textbox_joueur2.IsEnabled = false;
            textbox_joueur2.Clear();
            textbox_civilisation2.IsEnabled = false;
            textbox_civilisation2.Clear();
        }
        private void CheckBox_UnChecked_9_j2info(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j2eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_10_j2eii(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j2info.IsEnabled = true;
        }
        private void CheckBox_Checked_9_j2(object sender, RoutedEventArgs e) // check box choix civilisation info 
        {
            j2eii.IsEnabled = false;
        }
        private void CheckBox_Checked_10_j2(object sender, RoutedEventArgs e) // check box choix civilisation eii 
        {
            j2info.IsEnabled = false;
        }


        /******************** joueur 3 **********************/
        private void CheckBox_Checked_3_j3(object sender, RoutedEventArgs e) // check box joueur
        {
            textbox_joueur3.IsEnabled = true;
            textbox_civilisation3.IsEnabled = true;
            j3info.IsEnabled = true;
            j3eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_3_j3(object sender, RoutedEventArgs e) // uncheck box joueur
        {
            j3info.IsChecked = false;
            j3eii.IsChecked = false;
            j3info.IsEnabled = false;
            j3eii.IsEnabled = false;
            textbox_joueur3.IsEnabled = false;
            textbox_joueur3.Clear();
            textbox_civilisation3.IsEnabled = false;
            textbox_civilisation3.Clear();
        }
        private void CheckBox_UnChecked_11_j3info(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j3eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_12_j3eii(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j3info.IsEnabled = true;
        }
        private void CheckBox_Checked_11_j3(object sender, RoutedEventArgs e) // check box choix civilisation info 
        {
            j3eii.IsEnabled = false;
        }
        private void CheckBox_Checked_12_j3(object sender, RoutedEventArgs e) // check box choix civilisation eii 
        {
            j3info.IsEnabled = false;
        }


        /******************** joueur 4 **********************/
        private void CheckBox_Checked_4_j4(object sender, RoutedEventArgs e) // check box joueur
        {
            textbox_joueur4.IsEnabled = true; 
            textbox_civilisation4.IsEnabled = true;
            j4info.IsEnabled = true;
            j4eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_4_j4(object sender, RoutedEventArgs e) // uncheck box joueur
        {
            j4info.IsChecked = false;
            j4eii.IsChecked = false;
            j4info.IsEnabled = false;
            j4eii.IsEnabled = false;
            textbox_joueur4.IsEnabled = false;
            textbox_joueur4.Clear();
            textbox_civilisation4.IsEnabled = false;
            textbox_civilisation4.Clear();
        }
        private void CheckBox_UnChecked_13_j4info(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j4eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_14_j4eii(object sender, RoutedEventArgs e) // uncheck box choix civilisation
        {
            j4info.IsEnabled = true;
        }
        private void CheckBox_Checked_13_j4(object sender, RoutedEventArgs e) // check box choix civilisation info 
        {
            j4eii.IsEnabled = false;
        }
        private void CheckBox_Checked_14_j4(object sender, RoutedEventArgs e) // check box choix civilisation eii 
        {
            j4info.IsEnabled = false;
        }



        // gestion de la taille de la carte

        /******************** petite **********************/
        private void CheckBox_Checked_5_petite(object sender, RoutedEventArgs e) // check box de la petite carte
        {
            normale.IsEnabled = false;
            _taille = TypeCarte.PETITE;
  
        }
        private void CheckBox_UnChecked_5_petite(object sender, RoutedEventArgs e) // uncheck box de la petite carte
        {
            normale.IsEnabled = true;
        }


        /******************** normale **********************/
        private void CheckBox_Checked_6_normale(object sender, RoutedEventArgs e) // check box de la normale carte
        {
            petite.IsEnabled = false;
            _taille = TypeCarte.NORMALE;

        }
        private void CheckBox_UnChecked_6_normale(object sender, RoutedEventArgs e) // uncheck box de la normale carte
        {
            petite.IsEnabled = true;
        }




    }
}
