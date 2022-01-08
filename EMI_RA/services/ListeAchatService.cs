using EMI_RA.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
                .Select(l => new ListeAchat(l.ID,
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

            return new ListeAchat(listeAchat.ID,
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
            listeAchat = depot.Insert(listeAchat);
            l.IdListesDAchats = listeAchat.ID;

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

        public void genererListeAchat(int IdAdherent, IFormFile csvFile)
        {

            ProduitsServices produitsServices = new ProduitsServices();
            LignesServices lignesServices = new LignesServices();

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = DateTime.Now;
            Calendar cal = dfi.Calendar;
            var listeAchat = new ListeAchat(IdAdherent, date.Year, cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
            listeAchat = Insert(listeAchat);

            using (StreamReader reader = new StreamReader(csvFile.OpenReadStream()))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    string reference = values[0];
                    string quantite = values[1];

                    Produits produits = produitsServices.GetByRef(reference);

                    Lignes ligne = new Lignes(produits.ID, listeAchat.IdListesDAchats, Int32.Parse(quantite));
                    lignesServices.Insert(ligne);
                }
            }
        }
    }
    
}
