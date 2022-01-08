using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class LignesPaniersGlobaux
    {
        public int IDProduits { get; set; }
        public int Quantite { get; set; }
        public int IDListesDAchats { get; set; }
        public int IDPaniers { get; set; }
        public int IDLignesPaniersGlobaux { get; set; }

        public LignesPaniersGlobaux(int idProduits, int quantites, int idListesDAchats, int idPaniers) =>
            (IDProduits, Quantite, IDListesDAchats, IDPaniers) = (idProduits, quantites, idListesDAchats, idPaniers);

        public LignesPaniersGlobaux(int idLignesPaniersGlobaux, int idProduits, int quantites, int idListesDAchats, int idPaniers)
                => (IDLignesPaniersGlobaux, IDProduits, Quantite, IDListesDAchats, IDPaniers) = (idLignesPaniersGlobaux, idProduits, quantites, idListesDAchats, idPaniers);
        public LignesPaniersGlobaux(int id)
        {
            IDLignesPaniersGlobaux = id;
        }
    }
}
