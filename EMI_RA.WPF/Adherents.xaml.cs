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
using System.Windows.Shapes;



namespace EMI_RA.WPF
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class ListeAdherent : Window
    {
        public ListeAdherent()
        {
            InitializeComponent();
            // créer un foreach
            //foreach()


            //List<User> items = new List<User>();
            //items.Add(new User() { Name = "John Doe", Age = 42, Sex = SexType.Male });
            //items.Add(new User() { Name = "Jane Doe", Age = 39, Sex = SexType.Female });
            //items.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = SexType.Male });
            //lvUsers.ItemsSource = items;

            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            //view.GroupDescriptions.Add(groupDescription);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            var clientApi = new Client("https://localhost:44319/", new HttpClient());

            //le async et le await c'est de la programmation asynchrone en C#
            var adherents = await clientApi.AdherentsAllAsync();

            liste.ItemsSource = adherents;
        }
    }
}
