using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public class ListeAchat
    {
        
        public int IdListesDAchats { get; set; }
        public int IdAdherents { get; set; }
        public int IdPaniersGlobaux { get; set; }
        public int Annee { get; set; }
        public int NumeroSemaine { get; set; }

        //constructeur par défaut 
        public ListeAchat(int idAdherents, int idPaniersGlobaux, int annee, int numeroSemaine)
        => (IdAdherents, IdPaniersGlobaux, Annee, NumeroSemaine) = (idAdherents, idPaniersGlobaux, annee, numeroSemaine);
        public ListeAchat(int idListesDAchats, int idAdherents, int idPaniersGlobaux, int annee, int numeroSemaine)
                    => (IdListesDAchats, IdAdherents, IdPaniersGlobaux, Annee, NumeroSemaine) = (idListesDAchats, idAdherents, idPaniersGlobaux, annee, numeroSemaine);

    }
}
