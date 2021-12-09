using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public class AssoProduitsFournisseurs_DAL
    {

        public int IdFournisseurs { get; set; }
        public int IdProduits { get; set; }



        public AssoProduitsFournisseurs_DAL(int idFournisseurs, int idProduits)
            => (IdFournisseurs, IdProduits) = (idFournisseurs, idProduits);

       /* internal void Insert()
        {
            var chaineConnexion = "Data Source=localhost;Initial Catalog=EMI-r;Integrated Security=True";

            using (var connexion = new SqlConnection(chaineConnexion))
            {
                connexion.Open();

                using (var commande = new SqlCommand())
                {
                    commande.Connection = connexion;

                    commande.CommandText = "insert into assoProduitsFournisseurs (idFournisseurs, idProduits ) values (@idFournisseurs, @idProduits)";
                    commande.Parameters.Add(new SqlParameter("@idProduits", IdProduits));
                    commande.Parameters.Add(new SqlParameter("@idFournisseurs", IdFournisseurs));


                    //définir l'instruction SQL
                    // avec des paramètres si besoin 

                }
                connexion.Close();
            }*/
        }




    }
}
