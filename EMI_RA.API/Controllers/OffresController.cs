using EMI_RA.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMI_RA.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class OffresController : Controller
    {
        private IOffresService service;

        private ProduitsServices produitsServices = new ProduitsServices();
        private PaniersGlobauxService paniersGlobauxService = new PaniersGlobauxService();
        private OffresService offresService = new OffresService();

        public OffresController(IOffresService srv)
        {
            service = srv;
        }

        [HttpGet]
        public IEnumerable<Offres> Get()
        {
            return service.GetAllOffres();
        }

        // GET api/<ProduitsController>/5
        [HttpGet("offre/fournisseur")]
        public Offres GetOffreByIDFournisseur(int IdFournisseur)
        {
            return service.GetOffreByIDFournisseur(IdFournisseur);
        }

        [HttpPost("{IdFournisseurs}")]
        public void insert(int IdFournisseurs, IFormFile csvfile)
        {
            using (StreamReader reader = new StreamReader(csvfile.OpenReadStream()))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    string reference = values[0];
                    int quantite = int.Parse(values[1]);
                    float prix = float.Parse(values[2]);

                    PaniersGlobaux paniersGlobaux = paniersGlobauxService.GetPanierSemainePrecedente();
                    Produits produits = produitsServices.GetByRef(reference);

                    Offres offre = new Offres(IdFournisseurs, paniersGlobaux.ID, produits.ID, quantite, prix);
                    offresService.Insert(offre);
                }
            }
        }

        // DELETE api/<ProduitsController>/5
        //[HttpDelete("{id}")]
        //public void Delete([FromRoute] int id)
        //{
        //    service.Delete(id);
        //}

        //[HttpDelete]
        //public void Delete()
        //{
        //    service.DeleteAll();
        //}
    }
}
