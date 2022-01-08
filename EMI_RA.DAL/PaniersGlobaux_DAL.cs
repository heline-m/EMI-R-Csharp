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
        public int IDPaniersGlobaux { get; set; }

        public List<PaniersGlobaux_DAL> PaniersGlobaux { get; set; }
        public int NumeroSemaine { get; set; }
        public int Annee { get; set; }
        public PaniersGlobaux_DAL(int numeroSemaine, int annee)
                    => (NumeroSemaine, Annee) = (numeroSemaine, annee);

        public PaniersGlobaux_DAL(int idPaniersGlobaux, int numeroSemaine, int annee)
                    => (IDPaniersGlobaux, NumeroSemaine, Annee) = (idPaniersGlobaux, numeroSemaine, annee);
    }
}
