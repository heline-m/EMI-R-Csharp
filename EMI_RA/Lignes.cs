using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class Lignes
    {
        public int ID { get; set; }
        public int IdProduits { get; set; }
        public int IdListesDAchats { get; set; }
        public int Quantite { get; set; }

        public Lignes(int idProduits, int idListesDAchats, int quantite)
            => (IdProduits, IdListesDAchats, Quantite) = (idProduits, idListesDAchats, quantite);
        public Lignes(int id, int idProduits, int idListesDAchats, int quantite)
                    => (ID, IdProduits, IdListesDAchats, Quantite) = (id, idProduits, idListesDAchats, quantite);

    }
}
