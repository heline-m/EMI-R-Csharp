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
            var pageParDefault = new PageParDefault();
            Main.Navigate(pageParDefault);

            GestionnaireDeFenetres.pageParDefault = new PageParDefault();
            Main.Navigate(GestionnaireDeFenetres.pageParDefault);
            
        }
        
        void voirAdherent(object sender, RoutedEventArgs e)
        {
            if(GestionnaireDeFenetres.Page1 == null)
            {
                GestionnaireDeFenetres.Page1 = new Page1();
            }
            //w.Show();
           // MessageBox.Show("hello");
            Main.Navigate(GestionnaireDeFenetres.Page1);
            // this.Hide();
        }
        void voirFournisseur(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Page2 == null)
            {
                GestionnaireDeFenetres.Page2 = new Page2();
            }
            //w.Show();
            // MessageBox.Show("hello");
            Main.Navigate(GestionnaireDeFenetres.Page2);
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
    }
}
