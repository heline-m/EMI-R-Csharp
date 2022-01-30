using Microsoft.Win32;
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
using Microsoft.Office.Interop.Excel;
using System.IO;
using EMI_RA.API.Client;
using System.Net.Http;

namespace EMI_RA.WPF
{
    /// <summary>
    /// Logique d'interaction pour Commande.xaml
    /// </summary>
    public partial class Commande : System.Windows.Controls.Page
    {
        public Commande()
        {
            InitializeComponent();
        }

        private async void Choisir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            OpenFileDialog1.ShowDialog();

         var  open = OpenFileDialog1.OpenFile();


            var nom = OpenFileDialog1.FileName;

            string ligne;
            int compteur = 0;

          StreamReader reader = new StreamReader(open);
            while ((ligne = reader.ReadLine()) != null){
                String[] substring = ligne.Split(' ');
                foreach (String s in substring)
                {
                    Console.WriteLine(s);
                }
                compteur++;
            }
            var clientApi = new Client("https://localhost:44313/", new HttpClient());
          //  var adherent = await clientApi.;

            /*   using(OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"})
               {
                   if (OpenFileDialog.ShowDialog() == DialogResult.Ok)
                   {

                   }
               }*/
        }
    }
}
