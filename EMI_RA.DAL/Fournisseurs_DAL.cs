using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class Fournisseurs_DAL
    {
        public int ID { get; set; }

        public List<Fournisseurs_DAL> Fournisseurs { get; set; }
        public String Societe { get; set; }
        public String CiviliteContact { get; set; }
        public String NomContact { get; set; }
        public String PrenomContact { get; set; }
        public String Email { get; set; }
        public String Adresse { get; set; }

        public Fournisseurs_DAL(int idFournisseurs, String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse)
                    => (ID, Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse) = (idFournisseurs, societe, civiliteContact, nomContact, prenomContact, email, adresse);


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

                    //définir l'instruction SQL
                    //avec des paramètres si besoin
                    //SELECT SCOPE_IDENTITY() va renvoyer l'ID créé
                    commande.CommandText = "insert into fournisseurs (societe)"
                                            + " values ('" + Societe + "'); SELECT SCOPE_IDENTITY()";
                    ID = (int)commande.ExecuteScalar();
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
