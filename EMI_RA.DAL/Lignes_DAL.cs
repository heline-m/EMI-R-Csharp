using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class Lignes_DAL
    {
        public int ID { get; set; }

        public List<Lignes_DAL> Fournisseurs { get; set; }
        public int IdProduits { get; set; }
        public int IdListesDAchats { get; set; }
        public int Quantite { get; set; }
        

        public Lignes_DAL(int idProduits, int idListesDAchats, int quantite)
                    => (IdProduits, IdListesDAchats, Quantite) = (idProduits, idListesDAchats, quantite);
        public Lignes_DAL(int id, int idProduits, int idListesDAchats, int quantite)
                    => (ID, IdProduits, IdListesDAchats, Quantite) = (id, idProduits, idListesDAchats, quantite);


        // TODO : remplacer le string fourisseur par le Fournisseur une fois cet objet créé
        public void Insert()
        {
            var chaineConnexion = @"Data Source=localhost\sql2019;Initial Catalog=EMI-r;Integrated Security=True";

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

                    //TODO à finir la requète
                    commande.CommandText = "insert into lignes (idProduits, idListesDAchats, quantite) values (@idProduits, @idListesDAchats, @quantite); SELECT SCOPE_IDENTITY()";
         
                    ID = (int)commande.ExecuteScalar();
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
