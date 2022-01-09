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
        private LignesPaniersGlobaux_Depot_DAL depot = new LignesPaniersGlobaux_Depot_DAL();
        private PaniersGlobauxService paniersGlobauxService = new PaniersGlobauxService();

        //public List<LignesPaniersGlobaux> GetAllListeAchat()
        //{
        //    var listeAchat = depot.GetAll()
        //        .Select(l => new LignesPaniersGlobaux(l.ID,
        //                                    l.IdAdherents,
        //            ))
        //        .ToList();

        //    return listeAchat;
        //}
        //public LignesPaniersGlobaux GetListeAchatByID(int idListeAchat)
        //{
        //    var listeAchat = depot.GetByID(idListeAchat);

        //    return new LignesPaniersGlobaux(listeAchat.ID,
        //                          listeAchat.IdAdherents,
        //                          listeAchat.IdPaniersGlobaux,
        //                          listeAchat.Annee,
        //                          listeAchat.NumeroSemaine);
        //}

        //public LignesPaniersGlobaux Insert(LignesPaniersGlobaux l)
        //{
        //    var listeAchat = new ListeAchat_DAL(l.IdListesDAchats,
        //                                    l.IdAdherents,
        //                                    l.IdPaniersGlobaux,
        //                                    l.Annee,
        //                                    l.NumeroSemaine);
        //    listeAchat = depot.Insert(listeAchat);
        //    l.IdListesDAchats = listeAchat.ID;

        //    return l;
        //}

        //public LignesPaniersGlobaux Update(LignesPaniersGlobaux l)
        //{
        //    var listeAchat = new ListeAchat_DAL(l.IdListesDAchats,
        //                                    l.IdAdherents,
        //                                    l.IdPaniersGlobaux,
        //                                    l.Annee,
        //                                    l.NumeroSemaine);
        //    depot.Update(listeAchat);

        //    return l;
        //}

        //public void Delete(LignesPaniersGlobaux l)
        //{
        //    var listeAchat = new ListeAchat_DAL(l.IdListesDAchats,
        //                                    l.IdAdherents,
        //                                    l.IdPaniersGlobaux,
        //                                    l.Annee,
        //                                    l.NumeroSemaine);
        //    depot.Delete(listeAchat);
        //}

        public void genererListeAchat(int IdAdherent, IFormFile csvFile)
        {

            ProduitsServices produitsServices = new ProduitsServices();

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = DateTime.Now;
            Calendar cal = dfi.Calendar;

            // récupération du panier global
            PaniersGlobaux paniersGlobaux = paniersGlobauxService.getPanierGlobal();

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

                    var lignesPaniersGlobaux = new LignesPaniersGlobaux_DAL(produits.ID, Int32.Parse(quantite), paniersGlobaux.ID, IdAdherent);
                    depot.Insert(lignesPaniersGlobaux);
                }
            }
        }
    }

}
