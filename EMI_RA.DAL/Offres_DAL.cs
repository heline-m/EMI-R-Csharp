using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class Offres_DAL
    {
        public List<Offres_DAL> Offres { get; set; }
        public int IdFournisseurs { get; set; }
        public int IdLignesPaniers { get; set; }
        public int Prix { get; set; }


        public Offres_DAL(int idFournisseurs, int idLignesPaniers, int prix)
                    => (IdFournisseurs, IdLignesPaniers, Prix) = (idFournisseurs, idLignesPaniers, prix);


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

                    //TODO finir cette ligne 
                    commande.CommandText = "insert into offres () values ;";
                                            
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
