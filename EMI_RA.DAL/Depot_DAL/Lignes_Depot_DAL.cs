using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public class Lignes_Depot_DAL : Depot_DAL<Lignes_DAL>
    {
        public Lignes_Depot_DAL()
            : base()
        {

        }

        public override List<Lignes_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idLignes, idProduits, idListesDAchats, quantite from lignes";
            //pour lire les lignes une par une
            var reader = commande.ExecuteReader();

            var listeDeLignes = new List<Lignes_DAL>();

            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var ligne = new Lignes_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3) );

                listeDeLignes.Add(ligne);
            }

            DetruireConnexionEtCommande();

            return listeDeLignes;
        }

        public override Lignes_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idLignes, idProduits, idListesDAchats, quantite from lignes where idLignes=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeDeLignes = new List<Lignes_DAL>();

            Lignes_DAL ligne;
            if (reader.Read())
            {
                ligne = new Lignes_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
            }
            else
                throw new Exception($"Pas de ligne dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return ligne;
        }

        public override Lignes_DAL Insert(Lignes_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into lignes ( idProduits, idListesDAchats, quantite)"
                                    + " values (@idProduits, @idListesDAchats, @quantite); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idProduits", ligne.IdProduits));
            commande.Parameters.Add(new SqlParameter("@idListesDAchats", ligne.IdListesDAchats));
            commande.Parameters.Add(new SqlParameter("@quantite", ligne.Quantite));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            ligne.ID = ID;

            DetruireConnexionEtCommande();

            return ligne;
        }

        public override Lignes_DAL Update(Lignes_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update lignes set idProduits = @idProduits, idListesDAchats = @idListesDAchats, quantite = @quantite"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            commande.Parameters.Add(new SqlParameter("@idProduits", ligne.IdProduits));
            commande.Parameters.Add(new SqlParameter("@idListesDAchats", ligne.IdListesDAchats));
            commande.Parameters.Add(new SqlParameter("@quantite", ligne.Quantite));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la ligne avec l'ID  {ligne.ID}");
            }

            DetruireConnexionEtCommande();

            return ligne;
        }

        public override void Delete(Lignes_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from lignes where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la ligne avec l'ID {ligne.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
