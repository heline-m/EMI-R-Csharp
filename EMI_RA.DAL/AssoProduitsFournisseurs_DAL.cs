using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public class AssoProduitsFournisseurs_DAL
    {

        public int IdFournisseurs { get; set; }
        public int IdProduits { get; set; }



        public AssoProduitsFournisseurs_DAL(int idFournisseurs, int idProduits)
            => (IdFournisseurs, IdProduits) = (idFournisseurs, idProduits);

    }
}
