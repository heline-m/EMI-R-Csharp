using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public class PaniersGlobaux_DAL
    {
        public int idPaniersGlobaux { get; set; }

        public List<PaniersGlobaux_DAL> PaniersGlobaux { get; set; }
        public int numeroSemaine { get; set; }
        public int annee { get; set; }

        public PaniersGlobaux_DAL(int IdPaniersGlobaux, int NumeroSemaine, int Annee)
                    => (idPaniersGlobaux, numeroSemaine, annee) = (IdPaniersGlobaux, NumeroSemaine, Annee);


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

                    //définir l'instruction SQL
                    //avec des paramètres si besoin
                    //SELECT SCOPE_IDENTITY() va renvoyer l'ID créé
                    commande.CommandText = "insert into paniersGlobaux (idPaniersGlobaux, numeroSemaine, annee)"
                                            + " values (@idPaniersGlobaux, @numeroSemaine, @annee); SELECT SCOPE_IDENTITY()";
                    idPaniersGlobaux = (int)commande.ExecuteScalar();
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
