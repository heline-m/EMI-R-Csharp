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

namespace EMI_RA.WPF
{
    /// <summary>
    /// Logique d'interaction pour WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {
        public WindowMenu()
        {
            InitializeComponent();
            var pageParDefault = new PageParDefault();
            Main.Navigate(pageParDefault);

            GestionnaireDeFenetres.pageParDefault = new PageParDefault();
            Main.Navigate(GestionnaireDeFenetres.pageParDefault);
        }
        private void MenuItemVoirFournisseurs_click(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Fournisseurs == null)
            {
                GestionnaireDeFenetres.Fournisseurs = new Fournisseurs();
            }
            //w.Show();
            // MessageBox.Show("hello");
            Main.Navigate(GestionnaireDeFenetres.Fournisseurs);

        }
        /* private void MenuItemVoirFournisseurs_click(object sender, RoutedEventArgs e)
         {
             if (GestionnaireDeFenetres.Page1 == null)
             {
                 GestionnaireDeFenetres.Page1 = new Page1();
             }
             //w.Show();
             // MessageBox.Show("hello");
             Main.Navigate(GestionnaireDeFenetres.Page1);
             // this.Hide();

         }*/

        private void MenuItemAjouterAdherent_click(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.ajouterAdhérent == null)
            {
                GestionnaireDeFenetres.ajouterAdhérent = new AjouterAdhérent();
            }
            //w.Show();
            // MessageBox.Show("hello");
            Main.Navigate(GestionnaireDeFenetres.ajouterAdhérent);

        }
    }
}
