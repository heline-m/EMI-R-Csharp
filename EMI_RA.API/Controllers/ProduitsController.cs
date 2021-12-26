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
    public class ProduitsController : Controller
    {
        private IProduitsService service;

        public ProduitsController(IProduitsService srv)
        {
            service = srv;
        }

        // GET: api/<ProduitsController>
        //[HttpGet]
        //public IEnumerable<Produits_DTO> GetAllProduits()
        //{
        //    return service.GetAllProduits().Select(p => new Produits_DTO()
        //    {
        //        ID = p.ID,
        //        Libelle = p.Libelle,
        //        Marque = p.Marque,
        //        //IdFournisseurs = p.IdFournisseurs,
        //        Reference = p.Reference,
        //    });
        //}

        [HttpGet]
        public IEnumerable<Produits> Get()
        {
            return service.GetAll();
        }

        // GET api/<ProduitsController>/5
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

        //// PUT api/<ProduitsController>/5
        //[HttpPut]
        //public Produits_DTO Update(Produits_DTO p)
        //{
        //    var p_metier = service.Update(new Produits(p.ID,
        //                                               p.Libelle,
        //                                               p.Marque,
        //                                               p.IdFournisseurs,
        //                                               p.Reference));
        //    //Je récupère l'ID
        //    p.ID = p_metier.ID;
        //    //je renvoie l'objet DTO
        //    return p;
        //}

        // DELETE api/<ProduitsController>/5
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
