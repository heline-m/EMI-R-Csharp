using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IProduitsService
    {
        public List<Produits> GetAll();
        public Produits GetProduitsByID(int ID);
        public Produits Insert(Produits p);
        public void Update(Produits p);
        public void Delete(int produitId);
        public void DeleteAll();
        public void AssoProdFournisseurs(Produits produit, int IdFournisseurs);
    }
}
