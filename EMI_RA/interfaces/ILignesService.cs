using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface ILignesService
    {
        public List<Lignes> GetAllLignes();
        public Lignes GetLignesByID(int ID);
        public Lignes Insert(Lignes l);
        public Lignes Update(Lignes l);
        public void Delete(Lignes l);
    }
}
