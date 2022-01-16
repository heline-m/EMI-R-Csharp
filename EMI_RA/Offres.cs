using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class Offres
    {
        public int IdOffres { get; set; }
        public int IdFournisseurs { get; set; }
        public int IdPaniers { get; set; }
        public int IdProduits { get; set; }
        public int Quantite { get; set; }
        public float Prix { get; set; }
        public Boolean Gagne { get; set; }

        public Offres(int idFournisseurs, int idPaniers, int idProduits, int quantite, float prix)
                    => (IdFournisseurs, IdPaniers, IdProduits, Quantite, Prix) = (idFournisseurs, idPaniers, idProduits, quantite, prix);
        public Offres(int idOffres, int idFournisseurs, int idPaniers, int idProduits, int quantite, float prix, Boolean gagne)
                    => (IdOffres, IdFournisseurs, IdPaniers, IdProduits, Quantite, Prix, Gagne) = (idOffres, idFournisseurs, idPaniers, idProduits, quantite, prix, gagne);

    }
}
