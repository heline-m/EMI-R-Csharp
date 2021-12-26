using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class ListeAchat_DAL
    {
        public int ID { get; set; }

        public List<ListeAchat_DAL> ListeAchat { get; set; }
        public int IdAdherents { get; set; }
        public int IdPaniersGlobaux { get; set; }
        public int Annee { get; set; }
        public int NumeroSemaine { get; set; }

        //constructeur par défaut 
        public ListeAchat_DAL(int idAdherents, int idPaniersGlobaux, int annee, int numeroSemaine)
        =>(IdAdherents, IdPaniersGlobaux, Annee, NumeroSemaine) = (idAdherents, idPaniersGlobaux, annee, numeroSemaine);
        public ListeAchat_DAL(int ID, int idAdherents, int idPaniersGlobaux, int annee, int numeroSemaine)
                    => (ID, IdAdherents, IdPaniersGlobaux, Annee, NumeroSemaine) = (ID,idAdherents,idPaniersGlobaux, annee, numeroSemaine);


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
                    commande.CommandText = "insert into listeDAchats (idAdherents, idPaniersGlobaux, annee, numeroSemaine)"
                                            + " values ( @idAdherents, @idPaniersGlobaux, @annee, @numeroSemaine); select scope_identity()";
                    commande.Parameters.Add(new SqlParameter("@idAdherents", IdAdherents));
                    commande.Parameters.Add(new SqlParameter("@idPaniersGlobaux", IdPaniersGlobaux));
                    commande.Parameters.Add(new SqlParameter("@annee", Annee));
                    commande.Parameters.Add(new SqlParameter("@numeroSemaine", NumeroSemaine));
                    ID = (int)commande.ExecuteScalar();
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
