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
                .Select(offre => new Offres(offre.IdOffres,
                                            offre.IdFournisseurs,
                                            offre.IdPaniers,
                                            offre.IdProduits,
                                            offre.Quantite,
                                            offre.Prix,
                                            offre.Gagne))
                .ToList();

            return offre;
        }

        public Offres GetOffreByIDFournisseur(int idFournisseur)
        {
            var offre = depot.GetByIDFournisseur(idFournisseur);

            return new Offres(offre.IdOffres,
                                            offre.IdFournisseurs,
                                            offre.IdPaniers,
                                            offre.IdProduits,
                                            offre.Quantite,
                                            offre.Prix,
                                            offre.Gagne);

        }

        public List<Offres> GetOffreByIDPaniers(int idPaniers)
        {
            var offre = depot.GetByIDPaniers(idPaniers)
                .Select(offre => new Offres(offre.IdOffres,
                                            offre.IdFournisseurs,
                                            offre.IdPaniers,
                                            offre.IdProduits,
                                            offre.Quantite,
                                            offre.Prix,
                                            offre.Gagne))
                .ToList();

            return offre;

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
        public void Update(Offres offres)
        {
            var offre = new Offres_DAL(offres.IdOffres,
                                        offres.IdFournisseurs,
                                        offres.IdPaniers,
                                        offres.IdProduits,
                                        offres.Quantite,
                                        offres.Prix,
                                        offres.Gagne);
            depot.Update(offre);
        }

        public List<Offres> GetMeilleursOffres(int idPaniers)
        {
            var offre = depot.GetGagneByIDPaniers(idPaniers)
                .Select(offre => new Offres(offre.IdOffres,
                                            offre.IdFournisseurs,
                                            offre.IdPaniers,
                                            offre.IdProduits,
                                            offre.Quantite,
                                            offre.Prix,
                                            offre.Gagne))
                .ToList();

            return offre;
        }

    }

    
}
