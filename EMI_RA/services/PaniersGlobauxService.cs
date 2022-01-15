using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class PaniersGlobauxService : IPaniersGlobauxService
    {
        private PaniersGlobaux_Depot_DAL depot = new PaniersGlobaux_Depot_DAL();
        private LignesPaniersGlobauxService lignesPaniersGlobauxService = new LignesPaniersGlobauxService();
        private ProduitsServices produitsServices = new ProduitsServices();

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

        public PaniersGlobaux GetPanierSemainePrecedente()
        {
            int annee = DateTime.Now.AddDays(-7).Year;
            int semaine = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(-7), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

            return this.getGlobal(annee, semaine);
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
            int semaine = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

            return this.getGlobal(annee, semaine);
        }
        public PaniersGlobaux getGlobal(int annee, int semaine)
        {
            PaniersGlobaux_DAL paniersGlobauxDAL = depot.GetByYearAndWeek(annee, semaine);

            if (paniersGlobauxDAL == null)
            {
                paniersGlobauxDAL = new PaniersGlobaux_DAL(semaine, annee);
                depot.Insert(paniersGlobauxDAL);
            }
            return new PaniersGlobaux(paniersGlobauxDAL.IDPaniersGlobaux, paniersGlobauxDAL.NumeroSemaine, paniersGlobauxDAL.Annee);
        }
        public Stream genererPanierStream(int annee, int semaine)
        {
            StringBuilder contentBuilder = new StringBuilder("reference;quantite;prix unitaire HT\n");

            PaniersGlobaux paniersGlobaux = this.getGlobal(annee, semaine);
            List<LignesPaniersGlobaux> lignesPaniersGlobaux = lignesPaniersGlobauxService.GetLignesPaniersGlobauxByPanierGlobauxID(paniersGlobaux.ID);

            List<LignesPaniersGlobaux> lignesAgregees = lignesPaniersGlobaux
                            .GroupBy(l => l.IDProduits)
                            .Select(ligneGroupe => new LignesPaniersGlobaux(ligneGroupe.Select(p => p.IDProduits).First(),
                                                                            ligneGroupe.Sum(p => p.Quantite)))
                            .ToList();

            foreach (var ligne in lignesAgregees)
            {
                Produits produits = produitsServices.GetProduitsByID(ligne.IDProduits);

                contentBuilder
                    .Append(produits.Reference)
                    .Append(";")
                    .Append(ligne.Quantite)
                    .Append(";0")
                    .Append("\n");
            }

            byte[] bytes = Encoding.ASCII.GetBytes(contentBuilder.ToString());
            MemoryStream stream = new MemoryStream(bytes);
            return stream;
        }
        public Stream genererPanierStream(int annee, int semaine, int idFournisseur)
        {
            StringBuilder contentBuilder = new StringBuilder("reference;quantite;prix unitaire HT\n");

            PaniersGlobaux paniersGlobaux = this.getGlobal(annee, semaine);
            List<LignesPaniersGlobaux> lignesPaniersGlobaux = lignesPaniersGlobauxService.GetLignesPaniersGlobauxByPanierGlobauxIDAndFournisseurID(paniersGlobaux.ID, idFournisseur);

            List<LignesPaniersGlobaux> lignesAgregees = lignesPaniersGlobaux
                            .GroupBy(l => l.IDProduits)
                            .Select(ligneGroupe => new LignesPaniersGlobaux(ligneGroupe.Select(p => p.IDProduits).First(),
                                                                            ligneGroupe.Sum(p => p.Quantite)))
                            .ToList();

            foreach (var ligne in lignesAgregees)
            {
                Produits produits = produitsServices.GetProduitsByID(ligne.IDProduits);

                contentBuilder
                    .Append(produits.Reference)
                    .Append(";")
                    .Append(ligne.Quantite)
                    .Append(";0")
                    .Append("\n");
            }

            byte[] bytes = Encoding.ASCII.GetBytes(contentBuilder.ToString());
            MemoryStream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
