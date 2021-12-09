using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IProduitsService
    {
        public List<Produits> GetAllProduits();
        public Produits GetProduitsByID(int ID);
        public Produits Insert(Produits p);
        public Produits Update(Produits p);
        public void Delete(Produits p);
    }
}
