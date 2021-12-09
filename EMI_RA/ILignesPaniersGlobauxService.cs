using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface ILignesPaniersGlobauxService
    {
        public List<LignesPaniersGlobaux> GetAllLignesPaniersGlobaux();
        public LignesPaniersGlobaux GetLignesPaniersGlobauxByID(int IDLignesPaniersGlobaux);
        public LignesPaniersGlobaux Insert(LignesPaniersGlobaux l);
        public LignesPaniersGlobaux Update(LignesPaniersGlobaux l);
        public void Delete(LignesPaniersGlobaux l);
    }
}
