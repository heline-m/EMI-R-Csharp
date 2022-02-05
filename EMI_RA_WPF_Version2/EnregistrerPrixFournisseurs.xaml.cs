using EMI_RA.API.Client;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace EMI_RA_WPF
{
    /// <summary>
    /// Logique d'interaction pour EnregistrerPrixFournisseurs.xaml
    /// </summary>
    public partial class EnregistrerPrixFournisseurs : Page
    {
        public EnregistrerPrixFournisseurs()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Panier";
            dlg.DefaultExt = ".csv";
            dlg.Filter = "Text documents (.csv)|*.csv";
            string fileText = "reference ;quantite ;prix unitaire HT";
            Nullable<bool> result = dlg.ShowDialog();


            var clientApi = new Client("https://localhost:44313/", new HttpClient());
            var fichier = "https://localhost:44313/PaniersGlobaux/panier/1";

            var adherent = clientApi.PanierAllAsync(1);


            var list = adherent.Result;
            string liste2 = "reference ;quantite ;prix unitaire HT ;\n";
            for (int i = 0; i < list.Count(); i++)
            {
                liste2 = liste2 + list.ElementAt(i);
            }



            // var open = adherent.OpenFile();

            if (result == true)
            {
                // Save document
                // string filename = dlg.FileName;
                File.WriteAllText(dlg.FileName, liste2);
            }
        }
    }
}
