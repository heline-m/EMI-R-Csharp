using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EMI_RA.DAL
{
    public abstract class Produits_Depot_DAL : Depot_DAL<Produits_DAL>
    {
        public Produits_Depot_DAL()
            : base()
        {

        }
        public override List<Produits_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idProduits, libelle, marque, idFournisseurs, reference from produits";
            //pour lire les lignes une par une
            var reader = commande.ExecuteReader();

            var listeDeProduits= new List<Produits_DAL>();

            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var produits = new Produits_DAL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(2), reader.GetString(3));

                listeDeProduits.Add(produits);
            }

            DetruireConnexionEtCommande();

            return listeDeProduits;
        }

        public override Produits_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idProduits, libelle, marque, idFournisseurs, reference from produits where ID = @idProduits";
            commande.Parameters.Add(new SqlParameter("@idProduits", ID));
            var reader = commande.ExecuteReader();

            var listeDeProduits = new List<Produits_DAL>();

            Produits_DAL produits;
            if (reader.Read())
            {
                produits = new Produits_DAL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetInt32(2), reader.GetString(3));
            }
            else
                throw new Exception($"Pas de produit dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return produits;
        }

        public override Produits_DAL Insert(Produits_DAL produits)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into produits (libelle, marque, idFournisseurs, reference) values (@libelle, @marque, @idFournisseurs, @reference) ; SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@libelle", produits.Libelle));
            commande.Parameters.Add(new SqlParameter("@marque", produits.Marque));
            commande.Parameters.Add(new SqlParameter("@idFournisseurs", produits.IdFournisseurs));
            commande.Parameters.Add(new SqlParameter("@reference", produits.Reference));
            var ID = (int)commande.ExecuteScalar();

            
        
            produits.ID = ID;

            DetruireConnexionEtCommande();

            return produits;
        }

        public override Produits_DAL Update(Produits_DAL produits)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update produits set libelle = @libelle, marque = @marque, idFournisseurs  = @idFournisseurs, reference = @reference where idProduits=@idProduits";
            commande.Parameters.Add(new SqlParameter("@libelle", produits.Libelle));
            commande.Parameters.Add(new SqlParameter("@marque", produits.Marque));
            commande.Parameters.Add(new SqlParameter("@idFournisseurs", produits.IdFournisseurs));
            commande.Parameters.Add(new SqlParameter("@reference", produits.Reference));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le produit avec l'ID  {produits.ID}");
            }

            DetruireConnexionEtCommande();

            return produits;
        }

        public override void Delete(Produits_DAL produits)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from produits where idProduits = @idProduits";
            commande.Parameters.Add(new SqlParameter("@idProduits", produits.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le produit avec l'ID {produits.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
