using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class Produits
    {
        public int ID { get; set; }
        public String Libelle { get; set; }
        public String Marque { get; set; }
        public String Reference { get; set; }
        public int IdFournisseurs { get; set; }

        public Produits(String libelle, String marque, int idFournisseurs, String reference)
           => (Libelle, Marque, IdFournisseurs, Reference) = (libelle, marque, idFournisseurs, reference);
        public Produits(int idProduits, String libelle, String marque, int idFournisseurs, String reference)
             => (ID, Libelle, Marque, IdFournisseurs, Reference) = (idProduits, libelle, marque, idFournisseurs, reference);
    }
}
