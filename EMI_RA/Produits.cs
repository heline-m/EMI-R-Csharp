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
        public string Libelle { get; set; }
        public string Marque { get; set; }
        public string Reference { get; set; }
        public int IdFournisseurs { get; set; }

        public Produits(string libelle, string marque, int idFournisseurs, string reference)
           => (Libelle, Marque, IdFournisseurs, Reference) = (libelle, marque, idFournisseurs, reference);
        public Produits(int idProduits, string libelle, string marque, int idFournisseurs, string reference)
             => (ID, Libelle, Marque, IdFournisseurs, Reference) = (idProduits, libelle, marque, idFournisseurs, reference); 
        public Produits(int idProduits, string reference, string libelle, string marque)
              => (ID, Reference, Libelle, Marque) = (idProduits, reference, libelle, marque);
        public Produits (string reference, string libelle, string marque)
              => (Reference, Libelle, Marque) = (reference, libelle, marque);
        public Produits(int id)
        {
            ID = id;
        }

    }
}
