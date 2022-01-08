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

        public Fournisseurs GetFournisseursByID(int IdFournisseurs);
        public Fournisseurs Insert(Fournisseurs f);
        public Fournisseurs Update(Fournisseurs f);
        public void Delete(Fournisseurs f);
    }
}
