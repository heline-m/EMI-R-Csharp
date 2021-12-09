using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class ProduitsServices : IProduitsService
    {
        private Produits_Depot_DAL depot = new Produits_Depot_DAL();
        public List<Produits> GetAllProduits()
        {
            var produits = depot.GetAll()
                .Select(p => new Produits(p.ID,
                                        p.Libelle,
                                        p.Marque,
                                        p.IdFournisseurs,
                                        p.Reference
                                        ))
                .ToList();

            return produits;
        }
        public Produits GetProduitsByID(int idProduits)
        {
            var p = depot.GetByID(idProduits);

            return new Produits(p.ID,
                              p.Libelle,
                              p.Marque,
                              p.IdFournisseurs,
                              p.Reference
                              );

        }
        public Produits Insert(Produits p)
        {
            var produit = new Produits_DAL(p.ID,
                              p.Libelle,
                              p.Marque,
                              p.IdFournisseurs,
                              p.Reference);
            depot.Insert(produit);
            p.ID = produit.ID;

            return p;
        }

        public Produits Update(Produits p)
        {
            var produit = new Produits_DAL(p.ID,
                              p.Libelle,
                              p.Marque,
                              p.IdFournisseurs,
                              p.Reference);
            depot.Update(produit);

            return p;
        }
        public void Delete(Produits p)
        {
            var produits = new Produits_DAL(p.ID,
                              p.Libelle,
                              p.Marque,
                              p.IdFournisseurs,
                              p.Reference);
            depot.Delete(produits);
        }
    }
}
