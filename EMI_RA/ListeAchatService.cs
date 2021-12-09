using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class ListeAchatService : IListeAchatService
    {
        private ListeAchat_Depot_DAL depot = new ListeAchat_Depot_DAL();

        public List<ListeAchat> GetAllListeAchat()
        {
            var listeAchat = depot.GetAll()
                .Select(l => new ListeAchat(l.IdListesDAchats,
                                            l.IdAdherents,
                                            l.IdPaniersGlobaux,
                                            l.Annee,
                                            l.NumeroSemaine
                    ))
                .ToList();

            return listeAchat;
        }
        public ListeAchat GetListeAchatByID(int idListeAchat)
        {
            var listeAchat = depot.GetByID(idListeAchat);

            return new ListeAchat(listeAchat.IdListesDAchats,
                                  listeAchat.IdAdherents,
                                  listeAchat.IdPaniersGlobaux,
                                  listeAchat.Annee,
                                  listeAchat.NumeroSemaine);
        }
        
        public ListeAchat Insert(ListeAchat l)
        {
            var listeAchat = new ListeAchat_DAL(l.IdListesDAchats,
                                            l.IdAdherents,
                                            l.IdPaniersGlobaux,
                                            l.Annee,
                                            l.NumeroSemaine);
            depot.Insert(listeAchat);
            l.IdListesDAchats = listeAchat.IdListesDAchats;

            return l;
        }

        public ListeAchat Update(ListeAchat l)
        {
            var listeAchat = new ListeAchat_DAL(l.IdListesDAchats,
                                            l.IdAdherents,
                                            l.IdPaniersGlobaux,
                                            l.Annee,
                                            l.NumeroSemaine);
            depot.Update(listeAchat);

            return l;
        }

        public void Delete(ListeAchat l)
        {
            var listeAchat = new ListeAchat_DAL(l.IdListesDAchats,
                                            l.IdAdherents,
                                            l.IdPaniersGlobaux,
                                            l.Annee,
                                            l.NumeroSemaine);
            depot.Delete(listeAchat);
        }
        
    }
    
}
