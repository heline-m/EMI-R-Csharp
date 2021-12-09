using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class FournisseursService : IFournisseursService
    {
        private Fournisseurs_Depot_DAL depot = new Fournisseurs_Depot_DAL();

        public List<Fournisseurs> GetAllFournisseurs()
        {
            var fournisseurs = depot.GetAll()
                .Select(f => new Fournisseurs(f.IdFournisseurs,
                                              f.Societe,
                                              f.CiviliteContact,
                                              f.NomContact,
                                              f.PrenomContact,
                                              f.Email,
                                              f.Adresse
                        ))
                .ToList();
            
            return fournisseurs;
        }

        public Fournisseurs GetFournisseursByID(int idFournisseurs)
        {
            var f = depot.GetByID(idFournisseurs);

            return new Fournisseurs(f.IdFournisseurs,
                                    f.Societe,
                                    f.CiviliteContact,
                                    f.NomContact,
                                    f.PrenomContact,
                                    f.Email,
                                    f.Adresse);
        }

        public Fournisseurs Insert(Fournisseurs f)
        {
            var fournisseur = new Fournisseurs_DAL(f.IdFournisseurs,
                                                   f.Societe,
                                                   f.CiviliteContact,
                                                   f.NomContact,
                                                   f.PrenomContact,
                                                   f.Email,
                                                   f.Adresse);
            depot.Insert(fournisseur);
            f.IdFournisseurs = fournisseur.IdFournisseurs;

            return f;
        }

        public Fournisseurs Update(Fournisseurs f)
        {
            var fournisseur = new Fournisseurs_DAL(f.IdFournisseurs,
                                                   f.Societe,
                                                   f.CiviliteContact,
                                                   f.NomContact,
                                                   f.PrenomContact,
                                                   f.Email,
                                                   f.Adresse);
            depot.Update(fournisseur);

            return f;
        }

        public void Delete(Fournisseurs f)
        {
            var fournisseur = new Fournisseurs_DAL(f.IdFournisseurs,
                                                      f.Societe,
                                                      f.CiviliteContact,
                                                      f.NomContact,
                                                      f.PrenomContact,
                                                      f.Email,
                                                      f.Adresse);
            depot.Delete(fournisseur);

        }
    }
}
