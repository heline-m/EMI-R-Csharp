using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IFournisseursService
    {
        public List<Fournisseurs> GetAllFournisseurs();
        public void alimenterCatalogue(int IdFournisseurs, IFormFile csvFile);
        public void alimenterCatalogueVersion2(int IdFournisseurs, IEnumerable<String> csvFile);
        public Fournisseurs GetFournisseursByID(int IdFournisseurs);
        public Fournisseurs Insert(Fournisseurs f);
        public Fournisseurs Update(Fournisseurs f);
        public void Delete(Fournisseurs f);
        public Fournisseurs ResetPassword(Fournisseurs f);
        public Fournisseurs UpdatePassword(Fournisseurs f);

    }
}
