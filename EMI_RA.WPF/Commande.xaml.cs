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

        private void Choisir_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("hello");

            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            OpenFileDialog1.ShowDialog();

            var  open = OpenFileDialog1.OpenFile();
         

            var nom = OpenFileDialog1.FileName;

            string ligne;
            int compteur = 0;
       OpenFileDialog opfd = new OpenFileDialog();
            if(opfd.ShowDialog() == true)
            {
                txt.Text = File.ReadAllText(opfd.FileName);
            }
                StreamReader reader = new StreamReader(open);
            while ((ligne = reader.ReadLine()) != null){
                String[] substring = ligne.Split(' ');
                foreach (String s in substring)
                {
                    Console.WriteLine(s);
                }
                compteur++;
            }
            FileParameter file = new FileParameter(open);
            var clientApi = new Client("https://localhost:44313/", new HttpClient());
           // var adherent =  clientApi.CommandeAsync(1,file);
            clientApi.CommandeAsync(1, file);

            /*   using(OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"})
               {
                   if (OpenFileDialog.ShowDialog() == DialogResult.Ok)
                   {

                   }
               }*/


        }
        private void Choisir2_Click(object sender, RoutedEventArgs e)
        {
           
            string fileText = "reference ;quantite ;prix unitaire HT";

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Panier";
            dlg.DefaultExt = ".csv";
            dlg.Filter = "Text documents (.csv)|*.csv";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Save document
                // string filename = dlg.FileName;
                File.WriteAllText(dlg.FileName, fileText);
            }

        }
    }
}
