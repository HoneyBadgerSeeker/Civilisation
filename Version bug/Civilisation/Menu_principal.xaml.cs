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

namespace Civilisation
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Menu_principal : Window
    {
        public Menu_principal()
        {
            InitializeComponent();
            
        }
        private void nouvelle_partie_Bouton(object sender, RoutedEventArgs e)
        {
            Nouvelle_partie main = new Nouvelle_partie();
            main.Show();
            this.Close();
        } 

        private void quitter_Bouton(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 

    }
}
