using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA.DAL
{
    public class PaniersGlobaux_DAL
    {
        public int idPaniersGlobaux { get; set; }
        public List<PaniersGlobaux_DAL> PaniersGlobaux { get; set; }
        public int numeroSemaine { get; set; }
        public int annee { get; set; }
        public PaniersGlobaux_DAL(int IdPaniersGlobaux, int NumeroSemaine, int Annee)
                    => (idPaniersGlobaux, numeroSemaine, annee) = (IdPaniersGlobaux, NumeroSemaine, Annee);
    }
}
