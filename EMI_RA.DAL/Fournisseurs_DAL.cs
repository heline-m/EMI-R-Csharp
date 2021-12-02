using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class Fournisseurs_DAL
    {
        public int idFournisseurs { get; set; }

        public List<Fournisseurs_DAL> Fournisseurs { get; set; }
        public String societe { get; set; }
        public String civiliteContact { get; set; }
        public String nomContact { get; set; }
        public String prenomContact { get; set; }
        public String email { get; set; }
        public String adresse { get; set; }

        public Fournisseurs_DAL(int iDFournisseurs, String Societe, String CiviliteContact, String NomContact, String PrenomContact, String Email, String Adresse)
                    => (idFournisseurs, societe, civiliteContact, nomContact, prenomContact, email, adresse) = (iDFournisseurs, Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse);


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
                    commande.CommandText = "insert into fournisseurs(idFournisseurs, societe, civiliteContact, nomContact, prenomContact, email, adresse)"
                                    + " values (@idFournisseurs, @societe, @civiliteContact, @nomContact, @prenomContact, @email, @adresse";
                    commande.Parameters.Add(new SqlParameter("@idFournisseurs", idFournisseurs));
                    commande.Parameters.Add(new SqlParameter("@societe", societe));
                    commande.Parameters.Add(new SqlParameter("@civiliteContact", civiliteContact));
                    commande.Parameters.Add(new SqlParameter("@nomContact", nomContact));
                    commande.Parameters.Add(new SqlParameter("@prenomContact", prenomContact));
                    commande.Parameters.Add(new SqlParameter("@email", email));
                    commande.Parameters.Add(new SqlParameter("@adresse", adresse));

                    idFournisseurs = (int)commande.ExecuteScalar();
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
