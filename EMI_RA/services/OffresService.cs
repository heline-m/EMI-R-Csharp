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
                .Select(o => new Offres(o.IdFournisseurs,
                                        o.IdLignesPaniers,
                                        o.Prix
                                        ))
                .ToList();

            return offre;
        }

        public Offres GetOffreByIDFournisseur(int idFournisseur)
        {
            var o = depot.GetByIDFournisseur(idFournisseur);

            return new Offres(o.IdFournisseurs,
                              o.IdLignesPaniers,
                              o.Prix);

        }

        public Offres GetOffreByIDLignesPaniers(int idLignesPaniers)
        {
            var o = depot.GetByIDLignesPaniers(idLignesPaniers);

            return new Offres(o.IdFournisseurs,
                              o.IdLignesPaniers,
                              o.Prix);

        }

        public Offres Insert(Offres o)
        {
            var offre = new Offres_DAL(o.IdFournisseurs,
                              o.IdLignesPaniers,
                              o.Prix);
            depot.Insert(offre);
            o.IdFournisseurs = offre.IdFournisseurs;

            return o;
        }


    }

    
}
