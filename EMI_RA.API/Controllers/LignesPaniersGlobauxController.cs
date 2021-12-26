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
    public class LignesPaniersGlobauxController : Controller
    {
        private ILignesPaniersGlobauxService service;

        public LignesPaniersGlobauxController(ILignesPaniersGlobauxService srv)
        {
            service = srv;
        }

        // GET: api/<LignesPaniersGlobauxController>
        [HttpGet]
        public IEnumerable<LignesPaniersGlobaux_DTO> GetPaniersGlobauxByID()
        {
            return service.GetAllLignesPaniersGlobaux().Select(l => new LignesPaniersGlobaux_DTO()
            {
                IDProduits = l.IDProduits,
                Quantite = l.Quantite,
                IDListesDAchats = l.IDListesDAchats,
                IDPaniers = l.IDPaniers,
                IDLignesPaniersGlobaux = l.IDLignesPaniersGlobaux
            });
        }

        [HttpPost]
        public LignesPaniersGlobaux_DTO Insert(LignesPaniersGlobaux_DTO l)
        {
            var l_metier = service.Insert(new LignesPaniersGlobaux(l.IDProduits,
                                                                   l.Quantite,
                                                                   l.IDListesDAchats,
                                                                   l.IDPaniers,
                                                                   l.IDLignesPaniersGlobaux));
            //Je récupère l'ID
            l.IDLignesPaniersGlobaux = l_metier.IDLignesPaniersGlobaux;
            //je renvoie l'objet DTO
            return l;
        }

        // PUT api/<LignesPaniersGlobauxController>/5
        [HttpPut]
        public LignesPaniersGlobaux_DTO Update(LignesPaniersGlobaux_DTO l)
        {
            var l_metier = service.Update(new LignesPaniersGlobaux(l.IDProduits,
                                                                   l.Quantite,
                                                                   l.IDListesDAchats,
                                                                   l.IDPaniers,
                                                                   l.IDLignesPaniersGlobaux));
            //Je récupère l'ID
            l.IDLignesPaniersGlobaux = l_metier.IDLignesPaniersGlobaux;
            //je renvoie l'objet DTO
            return l;
        }

        // DELETE api/<ProduitsController>/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            service.Delete(new LignesPaniersGlobaux(id));
        }

    }
}
