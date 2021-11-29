using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public abstract class AssoProduitsFournisseurs_Depot_DAL : Depot_DAL<AssoProduitsFournisseurs_DAL>
    {
        public AssoProduitsFournisseurs_Depot_DAL()
            : base()
        {

        }
        public override List<AssoProduitsFournisseurs_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idProduits, idFournisseurs from assoProduitsFournisseurs";
            //pour lire les lignes une par une
            var reader = commande.ExecuteReader();

            var listeDeProduitsFournisseurs = new List<AssoProduitsFournisseurs_DAL>();

            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var ProduitsFournisseurs = new AssoProduitsFournisseurs_DAL(reader.GetInt32(0), reader.GetInt32(2));

                listeDeProduitsFournisseurs.Add(ProduitsFournisseurs);
            }

            DetruireConnexionEtCommande();

            return listeDeProduitsFournisseurs;
        }

        public override AssoProduitsFournisseurs_DAL Insert(AssoProduitsFournisseurs_DAL assoProduitsFournisseurs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into assoProduitsFournisseurs (idFournisseurs, idProduits ) values (@idFournisseurs, @idProduits)";
            commande.Parameters.Add(new SqlParameter("@idProduits", assoProduitsFournisseurs.IdProduits));
            commande.Parameters.Add(new SqlParameter("@idFournisseurs", assoProduitsFournisseurs.IdFournisseurs));
            
            DetruireConnexionEtCommande();

            return assoProduitsFournisseurs;
        }
        public override AssoProduitsFournisseurs_DAL Update(AssoProduitsFournisseurs_DAL assoProduitsFournisseurs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update assoProduitsFournisseurs set idFournisseurs = @idFournisseurs, idProduits = @idProduits)";

            commande.Parameters.Add(new SqlParameter("@idProduits", assoProduitsFournisseurs.IdProduits));
            commande.Parameters.Add(new SqlParameter("@idFournisseurs", assoProduitsFournisseurs.IdFournisseurs));

 
            DetruireConnexionEtCommande();

            return assoProduitsFournisseurs;
        }

        
    }
}
