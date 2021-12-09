using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class AssoProduitsFournisseursServices : IAssoProduitsFournisseursServices
    {
        private AssoProduitsFournisseurs_Depot_DAL depot = new AssoProduitsFournisseurs_Depot_DAL();
        
        public List<AssoProduitsFournisseurs> GetAll()
        {
            var assoProduits = depot.GetAll()
                .Select(a => new AssoProduitsFournisseurs(a.IdFournisseurs,
                                        a.IdProduits
                                        ))
                .ToList();

            return assoProduits;
        }
        public AssoProduitsFournisseurs GetByIdProduit(int idProduits)
        {
            var a = depot.GetByIdProduit(idProduits);

            return new AssoProduitsFournisseurs(a.IdFournisseurs,
                                        a.IdProduits
                              );
        }
        public AssoProduitsFournisseurs GetByIdFournisseurs(int idFournisseurs)
        {
            var a = depot.GetByIdFournisseurs(idFournisseurs);

            return new AssoProduitsFournisseurs(a.IdFournisseurs,
                                        a.IdProduits
                              );
        }
        public AssoProduitsFournisseurs Insert(AssoProduitsFournisseurs a)
        {
            var assoProduits = new AssoProduitsFournisseurs_DAL(a.IdFournisseurs,
                                        a.IdProduits);
            depot.Insert(assoProduits);
            

            return a;
        }



    }
}
