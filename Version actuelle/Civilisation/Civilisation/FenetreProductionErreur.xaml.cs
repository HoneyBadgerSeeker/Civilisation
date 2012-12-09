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
    /// Logique d'interaction pour FenetreProductionErreur.xaml
    /// </summary>
    public partial class FenetreProductionErreur : Window
    {
        public FenetreProductionErreur(FenetreProduction fp)
        {
            InitializeComponent();
            this.Owner = fp;
        }

        private void Button_click_ok(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
