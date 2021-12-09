using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IAssoProduitsFournisseursServices
    {
        public List<AssoProduitsFournisseurs> GetAll();
        public AssoProduitsFournisseurs GetByIdFournisseurs(int ID);
        public AssoProduitsFournisseurs GetByIdProduit(int ID);
        public AssoProduitsFournisseurs Insert(AssoProduitsFournisseurs a);

    }
}
