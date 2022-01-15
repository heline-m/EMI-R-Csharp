using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class Offres
    {
        public int IdFournisseurs { get; set; }
        public int IdPaniers { get; set; }
        public int IdProduits { get; set; }
        public int Quantite { get; set; }
        public float Prix { get; set; }

        public Offres(int idFournisseurs, int idPaniers, int idProduits, int quantite, float prix)
                    => (IdFournisseurs, IdPaniers, IdProduits, Quantite, Prix) = (idFournisseurs, idPaniers, idProduits, quantite, prix);

    }
}
