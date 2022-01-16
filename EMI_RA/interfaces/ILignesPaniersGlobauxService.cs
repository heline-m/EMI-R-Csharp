using Microsoft.AspNetCore.Http;
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
        public LignesPaniersGlobaux Insert(LignesPaniersGlobaux l);

    }
}
