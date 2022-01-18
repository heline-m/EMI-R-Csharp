using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMI_RA.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ProduitsController : Controller
    {
        private IProduitsService service;

        public ProduitsController(IProduitsService srv)
        {
            service = srv;
        }

        [HttpGet]
        public IEnumerable<Produits> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public Produits GetProduitsById(int id)
        {
            return service.GetProduitsByID(id);
        }

        [HttpPost("{IdFournisseurs}")]
        public void Insert(int IdFournisseurs, IFormFile csvFile)
        {
            using (StreamReader reader = new StreamReader(csvFile.OpenReadStream()))
            {
                reader.ReadLine();
              
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    string reference = values[0];
                    string libelle = values[1];
                    string marque = values[2];

                    var produit = new Produits(marque, libelle, reference);
                    service.Insert(produit);
                    service.AssoProdFournisseurs(produit, IdFournisseurs);
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            service.Delete(id);
        }

        [HttpDelete]
        public void Delete()
        {
            service.DeleteAll();
        }
    }
}
