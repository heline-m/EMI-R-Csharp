using EMI_RA.DAL;
using System;
using Xunit;

namespace EMI_RA.DAL.Tests
{
    public class Fournisseurs_DAL_Tests
    {
        [Fact]
        public void Fournisseurs_Depot_DAL_TesterGetAll()
        {

            var depot = new Fournisseurs_Depot_DAL();
            var fournisseurs = depot.GetAll();

            Assert.NotNull(fournisseurs);
        }

    }
}
