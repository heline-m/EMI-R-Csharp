using EMI_RA.API.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
using static EMI_RA.WPF.GestionnaireDeFenetres;

namespace EMI_RA.WPF
{
    /// <summary>
    /// Logique d'interaction pour WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public WindowMenu()
        {
            InitializeComponent();
            //var pageParDefault = new PageParDefault();
            //Main.Navigate(pageParDefault);

            //GestionnaireDeFenetres.pageParDefault = new PageParDefault();
            //Main.Content= GestionnaireDeFenetres.pageParDefault;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            var clientApi = new Client("https://localhost:44355/", new HttpClient());

            //le async et le await c'est de la programmation asynchrone en C#
            GestionnaireDeFenetres.WindowMenu = this;
        }

        private void MenuItemVoirFournisseurs_click(object sender, RoutedEventArgs e)
        {
            GestionnaireDeFenetres.Fournisseurs = new Fournisseurs();
            Main.Content = GestionnaireDeFenetres.Fournisseurs;

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

        public void Hide_Button()
        {
            modifier.Visibility = Visibility.Hidden;
        }

        public void View_Button()
        {
            modifier.Visibility = Visibility.Visible;
        }

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

        private void modifier_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Fournisseurs))
                {
                    //Main.Content = new modifierFournisseur();
                }

            } else if (Main.Content == null)
            {

            }
        }

    }
}
