using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class AdherentsService : IAdherentsService
    {
        private Adherents_Depot_DAL depot = new Adherents_Depot_DAL();

        public List<Adherents> GetAllAdherents()
        {
            var adherents = depot.GetAll()
                .Select(a => new Adherents(a.ID,
                                           a.Societe,
                                           a.CiviliteContact,
                                           a.NomContact,
                                           a.PrenomContact,
                                           a.Email,
                                           a.Adresse
                        ))
                .ToList();
            
            return adherents;
        }

        public Adherents GetByID(int idAdherents)
        {
            var a = depot.GetByID(idAdherents);

            return new Adherents(a.ID,
                                 a.Societe,
                                 a.CiviliteContact,
                                 a.NomContact,
                                 a.PrenomContact,
                                 a.Email,
                                 a.Adresse);
        }

        public Adherents Insert(Adherents a)
        {
            var adherents = new Adherents_DAL(a.ID,
                                              a.Societe,
                                              a.CiviliteContact,
                                              a.NomContact,
                                              a.PrenomContact,
                                              a.Email,
                                              a.Adresse,
                                              a.DateAdhesion);
            depot.Insert(adherents);
            a.ID = adherents.ID;

            return a;
        }

        public Adherents Update(Adherents a)
        {
            var adherents = new Adherents_DAL(a.ID,
                                              a.Societe,
                                              a.CiviliteContact,
                                              a.NomContact,
                                              a.PrenomContact,
                                              a.Email,
                                              a.Adresse,
                                              a.DateAdhesion);
            depot.Update(adherents);

            return a;
        }

        public void Delete(Adherents a)
        {
            var adherents = new Adherents_DAL(a.ID,
                                              a.Societe,
                                              a.CiviliteContact,
                                              a.NomContact,
                                              a.PrenomContact,
                                              a.Email,
                                              a.Adresse,
                                              a.DateAdhesion);
            depot.Delete(adherents);

        }
    }
}
