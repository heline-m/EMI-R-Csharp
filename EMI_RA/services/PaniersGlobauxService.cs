using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public PaniersGlobaux GetPaniersGlobauxByID(int annee, int semaine)
        {
            var p = depot.GetByYearAndWeek(annee, semaine);

            return new PaniersGlobaux(p.IDPaniersGlobaux,
                                      p.NumeroSemaine,
                                      p.Annee);
        }

        public PaniersGlobaux Insert(PaniersGlobaux p)
        {
            var paniersGlobaux = new PaniersGlobaux_DAL(p.ID,
                                                        p.NumeroSemaine,
                                                        p.Annee);
            depot.Insert(paniersGlobaux);
            p.ID = paniersGlobaux.IDPaniersGlobaux;

            return p;
        }

        public PaniersGlobaux Update(PaniersGlobaux p)
        {
            var paniersGlobaux = new PaniersGlobaux_DAL(p.ID,
                                                        p.NumeroSemaine,
                                                        p.Annee);
            depot.Update(paniersGlobaux);

            return p;
        }

        public void Delete(PaniersGlobaux p)
        {
            var panierGlobaux = new PaniersGlobaux_DAL(p.ID,
                                                       p.NumeroSemaine,
                                                       p.Annee);
            depot.Delete(panierGlobaux);
        }

        public PaniersGlobaux getPanierGlobal()
        {
            int annee = DateTime.Now.Year;
            int semaine = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            PaniersGlobaux_DAL paniersGlobauxDAL = depot.GetByYearAndWeek(annee, semaine);

            if(paniersGlobauxDAL == null)
            {
                paniersGlobauxDAL = new PaniersGlobaux_DAL(semaine, annee);
                depot.Insert(paniersGlobauxDAL);
            }

            return new PaniersGlobaux(paniersGlobauxDAL.IDPaniersGlobaux, paniersGlobauxDAL.NumeroSemaine, paniersGlobauxDAL.Annee);
        }
    }
}
