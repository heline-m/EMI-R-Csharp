using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class PaniersGlobauxService : IPaniersGlobauxService
    {
        private PaniersGlobaux_Depot_DAL depot = new PaniersGlobaux_Depot_DAL();

        public List<PaniersGlobaux> GetAllPaniersGlobaux()
        {
            var paniersGlobaux = depot.GetAll()
                .Select(p => new PaniersGlobaux(p.IDPaniersGlobaux,
                                                p.NumeroSemaine,
                                                p.Annee
                                                ))
                .ToList();

            return paniersGlobaux;
        }

        public PaniersGlobaux GetPaniersGlobauxByID(int idPaniersGlobaux)
        {
            var p = depot.GetByID(idPaniersGlobaux);

            return new PaniersGlobaux(p.IDPaniersGlobaux,
                                      p.NumeroSemaine,
                                      p.Annee);
        }

        public PaniersGlobaux Insert(PaniersGlobaux p)
        {
            var paniersGlobaux = new PaniersGlobaux_DAL(p.IDPaniersGlobaux,
                                                        p.NumeroSemaine,
                                                        p.Annee);
            depot.Insert(paniersGlobaux);
            p.IDPaniersGlobaux = paniersGlobaux.IDPaniersGlobaux;

            return p;
        }

        public PaniersGlobaux Update(PaniersGlobaux p)
        {
            var paniersGlobaux = new PaniersGlobaux_DAL(p.IDPaniersGlobaux,
                                                        p.NumeroSemaine,
                                                        p.Annee);
            depot.Update(paniersGlobaux);

            return p;
        }

        public void Delete(PaniersGlobaux p)
        {
            var panierGlobaux = new PaniersGlobaux_DAL(p.IDPaniersGlobaux,
                                                       p.NumeroSemaine,
                                                       p.Annee);
            depot.Delete(panierGlobaux);
        }
    }
}
