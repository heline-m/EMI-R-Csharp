using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class Fournisseurs_DAL
    {
        public int IdFournisseurs { get; set; }

        public List<Fournisseurs_DAL> Fournisseurs { get; set; }
        public String Societe { get; set; }
        public String CiviliteContact { get; set; }
        public String NomContact { get; set; }
        public String PrenomContact { get; set; }
        public String Email { get; set; }
        public String Adresse { get; set; }

        public Fournisseurs_DAL(int iDFournisseurs, String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse)
                    => (IdFournisseurs, Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse) = (iDFournisseurs, societe, civiliteContact, nomContact, prenomContact, email, adresse);


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
                    commande.Parameters.Add(new SqlParameter("@idFournisseurs", IdFournisseurs));
                    commande.Parameters.Add(new SqlParameter("@societe", Societe));
                    commande.Parameters.Add(new SqlParameter("@civiliteContact", CiviliteContact));
                    commande.Parameters.Add(new SqlParameter("@nomContact", NomContact));
                    commande.Parameters.Add(new SqlParameter("@prenomContact", PrenomContact));
                    commande.Parameters.Add(new SqlParameter("@email", Email));
                    commande.Parameters.Add(new SqlParameter("@adresse", Adresse));

                    IdFournisseurs = (int)commande.ExecuteScalar();
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
