using EMI_RA.API.Client;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static EMI_RA.WPF.GestionnaireDeFenetres;

namespace EMI_RA.WPF
{
    /// <summary>
    /// Logique d'interaction pour Fournisseurs.xaml
    /// </summary>
    public partial class Fournisseurs : Page
    {
        public Fournisseurs()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            var clientApi = new Client("https://localhost:44313/", new HttpClient());

            //le async et le await c'est de la programmation asynchrone en C#
            var fournisseurs = await clientApi.FournisseursAllAsync();

            liste.ItemsSource = fournisseurs;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GestionnaireDeFenetres.WindowMenu = new WindowMenu();
            GestionnaireDeFenetres.WindowMenu.View_Button();
        }
    }
}
