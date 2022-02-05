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

namespace EMI_RA.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           // var w = new MainWindow();
            InitializeComponent();
            //var pageParDefault = new PageParDefault();
            //Main.Navigate(pageParDefault);

            //GestionnaireDeFenetres.pageParDefault = new PageParDefault();
            //Main.Navigate(GestionnaireDeFenetres.pageParDefault);
            
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            var clientApi = new Client("https://localhost:44313/", new HttpClient());

            //le async et le await c'est de la programmation asynchrone en C#
            //var fournisseurs = await clientApi.FournisseursAllAsync();

            GestionnaireDeFenetres.MainWindow = this;
        }

        void voirAdherent(object sender, RoutedEventArgs e)
        {
            GestionnaireDeFenetres.Page1 = new Page1();
            Main.Content = GestionnaireDeFenetres.Page1;
        }
        void voirFournisseur(object sender, RoutedEventArgs e)
        {
            GestionnaireDeFenetres.Fournisseurs = new Fournisseurs();
            //w.Show();
            // MessageBox.Show("hello");
            Main.Navigate(GestionnaireDeFenetres.Fournisseurs);
        }
        void voirPanier(object sender, RoutedEventArgs e)
        {

           /* if (GestionnaireDeFenetres.pageParDefault == null)
            {
                GestionnaireDeFenetres.pageParDefault = new PageParDefault();
            }*/
            //w.Show();
            // MessageBox.Show("hello");
            Main.Navigate(GestionnaireDeFenetres.pageParDefault);
        }

        private void voirPanier1(object sender, RoutedEventArgs e)
        {

        }

        private void Suivant2(object sender, RoutedEventArgs e)
        {
            var pageAdherents = new Fournisseurs();
            Main.Navigate(pageAdherents);
        }


        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Fournisseurs))
                {
                    
                    //Main.Content = new ajouterFournisseur();
                }
                //if (Main.Content.GetType() == typeof(Adherent))
                //{
                //    Main.Content = new ajouterAdherent();
                //}
                //if (Main.Content.GetType() == typeof(Reference))
                //{
                //    Main.Content = new ajouterReference();
                //}
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Fournisseurs))
                {
                    //Main.Content = new supprFournisseur();
                }
                //if (Main.Content.GetType() == typeof(Adherent))
                //{
                //    Main.Content = new supprAdherent();
                //}
                //if (Main.Content.GetType() == typeof(Reference))
                //{
                //    Main.Content = new supprReference();
                //}

            }
        }
        private void Modif_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                //if (Main.Content.GetType() == typeof(Reference))
                //{

                //    ReferenceTemp reference = (ReferenceTemp)LesFenetres.Reference.liste.SelectedItem;
                //    Main.Content = new modifReference(reference);
                //}
                if (Main.Content.GetType() == typeof(Fournisseurs))
                {
                    Fournisseurs_DTO fournisseur = (Fournisseurs_DTO)GestionnaireDeFenetres.Fournisseurs.liste.SelectedItem;
                    //Main.Content = new modifFournisseur(fournisseur);
                }
                //if (Main.Content.GetType() == typeof(Adherent))
                //{
                //    AdherentTemp adherent = (AdherentTemp)LesFenetres.Adherent.liste.SelectedItem;
                //    Main.Content = new modifAdherent(adherent);
                //}
            }
        }
        
    }
}
