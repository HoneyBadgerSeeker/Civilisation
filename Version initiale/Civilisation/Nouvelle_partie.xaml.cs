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
namespace Civilisation
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Nouvelle_partie : Window
    {
        public Nouvelle_partie()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Menu_principal menu = new Menu_principal();
            menu.Show();
            this.Close();
        }
        private void CheckBox_Checked_1_j1(object sender, RoutedEventArgs e)
        {
            j1info.IsEnabled = true;
            j1eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_1_j1(object sender, RoutedEventArgs e)
        {
            j1info.IsChecked = false;
            j1eii.IsChecked = false;
            j1info.IsEnabled = false;
            j1eii.IsEnabled = false;
        }
        private void CheckBox_UnChecked_7_j1info(object sender, RoutedEventArgs e)
        {
            j1eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_8_j1eii(object sender, RoutedEventArgs e)
        {
            j1info.IsEnabled = true;
        }
        private void CheckBox_Checked_2_j2(object sender, RoutedEventArgs e)
        {
            j2info.IsEnabled = true;
            j2eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_2_j2(object sender, RoutedEventArgs e)
        {
            j2info.IsChecked = false;
            j2eii.IsChecked = false;
            j2info.IsEnabled = false;
            j2eii.IsEnabled = false;
        }
        private void CheckBox_UnChecked_9_j2info(object sender, RoutedEventArgs e)
        {
            j2eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_10_j2eii(object sender, RoutedEventArgs e)
        {
            j2info.IsEnabled = true;
        }
        private void CheckBox_Checked_3_j3(object sender, RoutedEventArgs e)
        {
            j3info.IsEnabled = true;
            j3eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_3_j3(object sender, RoutedEventArgs e)
        {
            j3info.IsChecked = false;
            j3eii.IsChecked = false;
            j3info.IsEnabled = false;
            j3eii.IsEnabled = false;
        }
        private void CheckBox_UnChecked_11_j3info(object sender, RoutedEventArgs e)
        {
            j3eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_12_j3eii(object sender, RoutedEventArgs e)
        {
            j3info.IsEnabled = true;
        }
        private void CheckBox_Checked_4_j4(object sender, RoutedEventArgs e)
        {
            j4info.IsEnabled = true;
            j4eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_4_j4(object sender, RoutedEventArgs e)
        {
            j4info.IsChecked = false;
            j4eii.IsChecked = false;
            j4info.IsEnabled = false;
            j4eii.IsEnabled = false;
        }
        private void CheckBox_UnChecked_13_j4info(object sender, RoutedEventArgs e)
        {
            j4eii.IsEnabled = true;
        }
        private void CheckBox_UnChecked_14_j4eii(object sender, RoutedEventArgs e)
        {
            j4info.IsEnabled = true;
        }
        private void CheckBox_Checked_5_petite(object sender, RoutedEventArgs e)
        {
            normale.IsEnabled = false;
  
        }
        private void CheckBox_UnChecked_5_petite(object sender, RoutedEventArgs e)
        {
            normale.IsEnabled = true;

        }
        private void CheckBox_Checked_6_normale(object sender, RoutedEventArgs e)
        {
            petite.IsEnabled = false;
        }
        private void CheckBox_UnChecked_6_normale(object sender, RoutedEventArgs e)
        {
            petite.IsEnabled = true;

        }
        private void CheckBox_Checked_7_j1(object sender, RoutedEventArgs e)
        {
            j1eii.IsEnabled = false;
        }
        private void CheckBox_Checked_8_j1(object sender, RoutedEventArgs e)
        {
            j1info.IsEnabled = false;
        }
        private void CheckBox_Checked_9_j2(object sender, RoutedEventArgs e)
        {
            j2eii.IsEnabled = false;
        }
        private void CheckBox_Checked_10_j2(object sender, RoutedEventArgs e)
        {
            j2info.IsEnabled = false;
        }
        private void CheckBox_Checked_11_j3(object sender, RoutedEventArgs e)
        {
            j3eii.IsEnabled = false;
        }
        private void CheckBox_Checked_12_j3(object sender, RoutedEventArgs e)
        {
            j3info.IsEnabled = false;
        }
        private void CheckBox_Checked_13_j4(object sender, RoutedEventArgs e)
        {
            j4eii.IsEnabled = false;
        }
        private void CheckBox_Checked_14_j4(object sender, RoutedEventArgs e)
        {
            j4info.IsEnabled = false;
        }

    }
}
