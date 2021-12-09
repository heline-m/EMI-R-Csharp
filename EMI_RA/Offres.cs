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
        public int IdLignesPaniers { get; set; }
        public int Prix { get; set; }

        public Offres(int idFournisseurs, int idLignesPaniers, int prix)
                    => (IdFournisseurs, IdLignesPaniers, Prix) = (idFournisseurs, idLignesPaniers, prix);

    }
}
