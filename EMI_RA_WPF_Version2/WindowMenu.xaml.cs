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
        private void MenuItemModifierAdherent_click(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.modifierAdherent == null)
            {
                GestionnaireDeFenetres.modifierAdherent = new ModifierAdherent();
            }
            //w.Show();
            // MessageBox.Show("hello");
            Main.Navigate(GestionnaireDeFenetres.modifierAdherent);

        }
        
             private void MenuItemAjouterFournisseurs_click(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.AjouterFournisseurs == null)
            {
                GestionnaireDeFenetres.AjouterFournisseurs = new AjouterFournisseurs();
            }
   
            Main.Navigate(GestionnaireDeFenetres.AjouterFournisseurs);

        }
        
               private void MenuItemModifierFournisseurs_click(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.modifierFournisseur == null)
            {
                GestionnaireDeFenetres.modifierFournisseur = new ModifierFournisseur();
            }

            Main.Navigate(GestionnaireDeFenetres.modifierFournisseur);

        }
        private void MenuItemModifierCommande_click(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Commande == null)
            {
                GestionnaireDeFenetres.Commande = new Commande();
            }

            Main.Navigate(GestionnaireDeFenetres.Commande);

        }
        
            private void MenuItemEnregistrerPrix_click(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.enregistrerPrixFournisseurs == null)
            {
                GestionnaireDeFenetres.enregistrerPrixFournisseurs = new EMI_RA_WPF.EnregistrerPrixFournisseurs();
            }

            Main.Navigate(GestionnaireDeFenetres.enregistrerPrixFournisseurs);

        }


    }
}
