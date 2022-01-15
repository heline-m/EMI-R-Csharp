using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class OffresService : IOffresService
    {
        private Offres_Depot_DAL depot = new Offres_Depot_DAL();

        public List<Offres> GetAllOffres()
        {
            var offre = depot.GetAll()
                .Select(offre => new Offres(offre.IdFournisseurs,
                                            offre.IdPaniers,
                                            offre.IdProduits,
                                            offre.Quantite,
                                            offre.Prix))
                .ToList();

            return offre;
        }

        public Offres GetOffreByIDFournisseur(int idFournisseur)
        {
            var offre = depot.GetByIDFournisseur(idFournisseur);

            return new Offres(offre.IdFournisseurs,
                              offre.IdPaniers,
                              offre.IdProduits,
                              offre.Quantite,
                              offre.Prix);

        }

        public Offres GetOffreByIDLignesPaniers(int idLignesPaniers)
        {
            var offre = depot.GetByIDLignesPaniers(idLignesPaniers);

            return new Offres(offre.IdFournisseurs,
                              offre.IdPaniers,
                              offre.IdProduits,
                              offre.Quantite,
                              offre.Prix);

        }

        public Offres Insert(Offres offres)
        {
            var offre = new Offres_DAL(offres.IdFournisseurs,
                                       offres.IdPaniers,
                                       offres.IdProduits,
                                       offres.Quantite,
                                       offres.Prix);
            depot.Insert(offre);
            offre.IdFournisseurs = offre.IdFournisseurs;

            return offres;
        }


    }

    
}
