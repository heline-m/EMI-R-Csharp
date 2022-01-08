using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IOffresService
    {
        public List<Offres> GetAllOffres();
        public Offres GetOffreByIDFournisseur(int IdFournisseur);
        public Offres GetOffreByIDLignesPaniers(int IdLignesPaniers);
        public Offres Insert(Offres o);
    }
}
