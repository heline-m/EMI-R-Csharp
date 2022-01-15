using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IOffresService
    {
        public Offres Insert(Offres offres);
        public List<Offres> GetAllOffres();
        public Offres GetOffreByIDLignesPaniers(int idLignesPaniers);
        public Offres GetOffreByIDFournisseur(int idFournisseur);
        
    }
}
