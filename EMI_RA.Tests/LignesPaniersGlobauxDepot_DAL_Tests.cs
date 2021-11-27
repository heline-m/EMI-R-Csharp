using EMI_RA.DAL;
using System;
using System.Collections.Generic;
using Xunit;

namespace EMI_RA.DAL.Tests
{
    public class LignesPaniersGlobaux_Depot_DAL : Depot_DAL<LignesPaniersGlobaux_DAL>
    {

        [Fact]
        public void LignesPaniersGlobaux_Depot_DAL_TesterGetAll()
        {

            var depot = new LignesPaniersGlobaux_Depot_DAL();
            var lignesPaniersGlobaux = depot.GetAll();

            Assert.NotNull(lignesPaniersGlobaux);
        }
    }
}
