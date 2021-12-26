using EMI_RA.DAL;
using EMI_RA.DTO;
using System;
using System.Collections.Generic;

namespace EMI_RA
{
    public class ProduitsServices : IProduitsService
    {
        private Produits_Depot_DAL depotProduits = new Produits_Depot_DAL();
        private AssoProduitsFournisseurs_Depot_DAL depotAsso = new AssoProduitsFournisseurs_Depot_DAL();

        public List<Produits> GetAll()
        {
            var result = new List<Produits>();
            
            foreach (var p in depotProduits.GetAll())
            {
                Produits produit = new Produits(p.ID, p.Libelle, p.Marque, p.IdFournisseurs, p.Reference);
                result.Add(produit);
            }
            return result;
        }
       
        public Produits GetProduitsByID(int idProduits)
        {
            var p = depotProduits.GetByID(idProduits);
            return new Produits(p.ID, p.Reference, p.Libelle, p.Marque);
        }
        public Produits Insert(Produits produit)
        {
            var produitDal = new Produits_DAL(produit.Reference, produit.Libelle, produit.Marque);
            produit.ID = depotProduits.Insert(produitDal).ID;

            return produit;
        }

        public void Update(Produits produit)
        {
            var produitDal = new Produits_DAL(produit.ID, produit.Reference, produit.Libelle, produit.Marque);
            depotProduits.Update(produitDal);
        }

        public void Delete(int id)
        {
            Produits_DAL Produit;
            Produit = depotProduits.GetByID(id);
            depotProduits.Delete(Produit);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
        public void AssoProdFournisseurs(Produits produit, int idFournisseur)
        {
            var associations = new AssoProduitsFournisseurs_DAL((int)produit.ID, idFournisseur);
            depotAsso.Insert(associations);
        }

        public Produits GetByRef(string reference)
        {
            var p = depotProduits.GetByRef(reference);
            return new Produits(p.ID, p.Reference, p.Libelle, p.Marque);
        }
    }
}
