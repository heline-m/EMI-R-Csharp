using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public class Produits_DAL
    {
        public int ID { get; set; }
        public List<Produits_DAL> Produits { get; set; }
        public String Libelle { get; set; }
        public String Marque { get; set; }
        public String Reference { get; set; }
        public int IdFournisseurs { get; set; }
        public List<AssoProduitsFournisseurs_DAL> ProduitsFournisseurs { get; set; }

        public Produits_DAL(String libelle, String marque, int idFournisseurs, String reference)
            => (Libelle, Marque, IdFournisseurs, Reference) = (libelle, marque, idFournisseurs, reference);
        public Produits_DAL(int idProduits, String libelle, String marque, int idFournisseurs, String reference)
            => (ID, Libelle, Marque, IdFournisseurs, Reference) = (idProduits, libelle, marque, idFournisseurs, reference);

        public void Insert()
        {
            var chaineConnexion = "Data Source=localhost;Initial Catalog=EMI-r;Integrated Security=True";

            //Créer une connexion
            using (var connexion = new SqlConnection(chaineConnexion))
            {
                //ouvrir la connexion
                connexion.Open();

                //créer une commande pour l'instruction SQL à executer
                using (var commande = new SqlCommand())
                {
                    //définir la connexion à utiliser
                    commande.Connection = connexion;

                    //définir l'instruction SQL
                    //avec des paramètres si besoin
                    //SELECT SCOPE_IDENTITY() va renvoyer l'ID créé

                    commande.CommandText = "insert into produits (libelle, marque, idFournisseurs, reference) values (@libelle, @marque, @idFournisseurs, @reference) ; SELECT SCOPE_IDENTITY()";
                    commande.Parameters.Add(new SqlParameter("@libelle", Libelle));
                    commande.Parameters.Add(new SqlParameter("@marque", Marque));
                    commande.Parameters.Add(new SqlParameter("@idFournisseurs", IdFournisseurs));
                    commande.Parameters.Add(new SqlParameter("@reference", Reference));
                    ID = (int)commande.ExecuteScalar();


                }


                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
