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
        public int IDProduits { get;  set; }
        public int Quantite { get;  set; }
        public int IDListesDAchats { get; set; }
        public int IDPaniers { get; set; }

        public int IDLignesPaniersGlobaux { get; set; }

        public LignesPaniersGlobaux_DAL(int idProduits, int quantites, int idListesDAchats, int idPaniers) => 
            (IDProduits, Quantite, IDListesDAchats, IDPaniers) = (idProduits, quantites, idListesDAchats, idPaniers);

        public LignesPaniersGlobaux_DAL(int idLignesPaniersGlobaux, int idProduits, int quantites, int idListesDAchats, int idPaniers)
                => (IDLignesPaniersGlobaux, IDProduits, Quantite, IDListesDAchats, IDPaniers) = (IDLignesPaniersGlobaux, idProduits, quantites, idListesDAchats, idPaniers);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into lignesPaniersGlobaux(idProduits, quantite, idListesDAchats, idPaniers)"
                                    + " values (@idProduits, @quantite, @idListesDAchats, @idPaniers";
                commande.Parameters.Add(new SqlParameter("@idProduits", IDProduits));
                commande.Parameters.Add(new SqlParameter("@quantite", Quantite));
                commande.Parameters.Add(new SqlParameter("@idListesDAchats", IDListesDAchats));
                commande.Parameters.Add(new SqlParameter("@idPaniers", IDPaniers));

                commande.ExecuteNonQuery();
            }
        }
    }
}
