using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class Adherents_DAL
    {
        public int ID { get; set; }

        public List<Adherents_DAL> Adherents { get; set; }
        public String Societe { get; set; }
        public String CiviliteContact { get; set; }
        public String NomContact { get; set; }
        public String PrenomContact { get; set; }
        public String Email { get; set; }
        public String Adresse { get; set; }
        public DateTime? DateAdhesion { get; set; }

        //constructeur par défaut 
        public Adherents_DAL(String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse)
        =>(Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse) = (societe, civiliteContact, nomContact, prenomContact, email, adresse);
        public Adherents_DAL(int idAdherents, String societe, String civiliteContact, String nomContact, String prenomContact, String email, String adresse, DateTime? dateAdhesion)
                    => (ID, Societe, CiviliteContact, NomContact, PrenomContact, Email, Adresse, DateAdhesion) = (idAdherents, societe, civiliteContact, nomContact, prenomContact, email, adresse, dateAdhesion);


        // TODO : remplacer le string ad par le Fournisseur une fois cet objet créé
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
                    commande.CommandText = "insert into adherent (societe, civiliteContact, nomContact, prenomContact, email, adresse, dateAdhesion)"
                                            + " values (@societe, @civiliteContact, @nomContact, @prenomContact, @email, @adresse, GetDate()); select scope_identity()";
                    commande.Parameters.Add(new SqlParameter("@societe", Societe));
                    commande.Parameters.Add(new SqlParameter("@civiliteContact", CiviliteContact));
                    commande.Parameters.Add(new SqlParameter("@nomContact", NomContact));
                    commande.Parameters.Add(new SqlParameter("@prenomContact", PrenomContact));
                    commande.Parameters.Add(new SqlParameter("@email", Email));
                    commande.Parameters.Add(new SqlParameter("@adresse", Adresse));
                    ID = (int)commande.ExecuteScalar();
                }

                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
