using EMI_RA.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpGet]
        public IEnumerable<Produits_DTO> GetAllProduits()
        {
            return service.GetAllProduits().Select(p => new Produits_DTO()
            {
                ID = p.ID,
                Libelle = p.Libelle,
                Marque = p.Marque,
                IdFournisseurs = p.IdFournisseurs,
                Reference = p.Reference,
            });
        }

        [HttpPost]
        public Produits_DTO Insert(Produits_DTO p)
        {
            var p_metier = service.Insert(new Produits(p.ID,
                                                   p.Libelle,
                                                   p.Marque,
                                                   p.IdFournisseurs,
                                                   p.Reference
                                                  ));
            //Je récupère l'ID
            p.ID = p_metier.ID;
            //je renvoie l'objet DTO
            return p;
        }

       
    }
}
