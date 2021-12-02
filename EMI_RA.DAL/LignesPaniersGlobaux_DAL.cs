using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EMI_RA.DAL
{
    public class LignesPaniersGlobaux_DAL
    {
        public int idProduits_DAL { get;  set; }
        public int quantite { get;  set; }
        public int idListesDAchats_DAL { get; set; }
        public int idPaniers_DAL { get; set; }

        public int idLignesPaniersGlobaux { get; set; }

        //public LignesPaniersGlobaux_DAL(int quantite) => (quantite) = (quantite);

        public LignesPaniersGlobaux_DAL(int IDLignesPaniersGlobaux, int idProduits, int quantites, int idListesDAchats, int idPaniers)
                => (idLignesPaniersGlobaux, idProduits_DAL, quantite, idListesDAchats_DAL, idPaniers_DAL) = (IDLignesPaniersGlobaux, idProduits, quantites, idListesDAchats, idPaniers);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into lignesPaniersGlobaux(idProduits, quantite, idListesDAchats, idPaniers)"
                                    + " values (@idProduits, @quantite, @idListesDAchats, @idPaniers";
                commande.Parameters.Add(new SqlParameter("@idProduits", idProduits_DAL));
                commande.Parameters.Add(new SqlParameter("@quantite", quantite));
                commande.Parameters.Add(new SqlParameter("@idListesDAchats", idListesDAchats_DAL));
                commande.Parameters.Add(new SqlParameter("@idPaniers", idPaniers_DAL));

                commande.ExecuteNonQuery();
            }
        }
    }
}
