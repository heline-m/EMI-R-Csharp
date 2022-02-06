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
using System.Collections;

namespace EMI_RA.WPF
{
    /// <summary>
    /// Logique d'interaction pour Commande.xaml
    /// </summary>
    public partial class Commande : System.Windows.Controls.Page
    {
        Adherents adherent;
        public Commande(EMI_RA.API.Client.Adherents unAdherent)
        {
            InitializeComponent();
            adherent = unAdherent;
        }

        private void Choisir_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("hello");

          /*  OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            OpenFileDialog1.ShowDialog();

            var  open = OpenFileDialog1.OpenFile();
         

            var nom = OpenFileDialog1.FileName;*/

            string ligne;
            int compteur = 0;

            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            opfd.ShowDialog();
            var liste = File.ReadAllText(opfd.FileName);
            

            //var open = OpenFileDialog1.OpenFile();

            var fichiercsv = File.ReadLines(opfd.FileName);
            List<string> fichier = fichiercsv.Skip(1).Take(fichiercsv.Count()-1).ToList();

          /*  if (opfd.ShowDialog() == true)
            {
                txt.Text = fichiercsv.ToString();
            }*/

           // IEnumerable<string> fichier = Enumerable.Empty<string>();

            for (int i = 1; i < fichiercsv.Count(); i++)
            {
               fichier.ToList().Add(fichiercsv.ElementAt(i));
            }
           
       
              //  txt.Text = fichier.ElementAt(1) ;
            
            var clientApi = new Client("https://localhost:44313/", new HttpClient());
            var commande = clientApi.CommandeVersion2Async(adherent.Id, fichier);

            /*     StreamReader reader = new StreamReader(open);
             List<String> liste = new List<String>();
             while ((ligne = reader.ReadLine()) != null){
                 String[] substring = ligne.Split(' ');
                 foreach (String s in substring)
                 {
                     liste.Add(s);
                     resultatPanier.Text = s;
                 }
                 compteur++;
             }*/
            //   FileParameter file = new FileParameter(open);

            //clientApi.CommandeAsync(1, file);

            /*   using(OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"})
               {
                   if (OpenFileDialog.ShowDialog() == DialogResult.Ok)
                   {

                   }
               }*/

        }
    }
}
