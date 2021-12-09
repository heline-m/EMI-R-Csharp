using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_RA
{
    public interface IPaniersGlobauxService
    {
        public List<PaniersGlobaux> GetAllPaniersGlobaux();
        public PaniersGlobaux GetPaniersGlobauxByID(int IDPanierGlobaux);
        public PaniersGlobaux Insert(PaniersGlobaux p);
        public PaniersGlobaux Update(PaniersGlobaux p);
        public void Delete(PaniersGlobaux p);
    }
}
