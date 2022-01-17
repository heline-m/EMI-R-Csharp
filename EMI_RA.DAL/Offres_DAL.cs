using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMI_RA.DAL
{
    public class Offres_DAL
    {
        public int IdOffres { get; set; }
        public int IdFournisseurs { get; set; }
        public int IdPaniers { get; set; }
        public int IdProduits { get; set; }
        public int Quantite { get; set; }
        public float Prix { get; set; }
        public Boolean Gagne { get; set; }

        public Offres_DAL(int idFournisseurs, int idPaniers, int idProduits, int quantite, float prix)
                    => (IdFournisseurs, IdPaniers, IdProduits, Quantite, Prix) = (idFournisseurs, idPaniers, idProduits, quantite, prix);
        public Offres_DAL(int idOffres, int idFournisseurs, int idPaniers, int idProduits, int quantite, float prix, Boolean gagne)
                    => (IdOffres, IdFournisseurs, IdPaniers, IdProduits, Quantite, Prix, Gagne) = (idOffres, idFournisseurs, idPaniers, idProduits, quantite, prix, gagne);
    }   
}
