using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class LignesServices : ILignesService
    {
        private Lignes_Depot_DAL depot = new Lignes_Depot_DAL();

        public List<Lignes> GetAllLignes()
        {
            var lignes = depot.GetAll()
                .Select(l => new Lignes(l.ID,
                                        l.IdProduits,
                                        l.IdListesDAchats,
                                        l.Quantite
                                        ))
                .ToList();

            return lignes;
        }

        public Lignes GetLignesByID(int idLignes)
        {
            var l = depot.GetByID(idLignes);

            return new Lignes(l.ID,
                              l.IdProduits,
                              l.IdListesDAchats,
                              l.Quantite);
            
        }

        public Lignes Insert(Lignes l)
        {
            var ligne = new Lignes_DAL(l.ID,
                              l.IdProduits,
                              l.IdListesDAchats,
                              l.Quantite);
            depot.Insert(ligne);
            l.ID = ligne.ID;

            return l;
        }

        public Lignes Update(Lignes l)
        {
            var ligne = new Lignes_DAL(l.ID,
                                       l.IdProduits,
                                       l.IdListesDAchats,
                                       l.Quantite);
            depot.Update(ligne);

            return l;
        }

        public void Delete(Lignes l)
        {
            var ligne = new Lignes_DAL(l.ID,
                                       l.IdProduits,
                                       l.IdListesDAchats,
                                       l.Quantite);
            depot.Delete(ligne);
        }
    }
}
