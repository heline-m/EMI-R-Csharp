using EMI_RA.DAL;
using EMI_RA.DTO;
using Microsoft.AspNetCore.Http;
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
    public class FournisseursController : Controller
    {
        private IFournisseursService service;

        public FournisseursController(IFournisseursService srv)
        {
            service = srv;
        }

        // GET: api/<FournisseursController>
        [HttpGet]
        public IEnumerable<Fournisseurs_DTO> GetAllFournisseurs()
        {
            return service.GetAllFournisseurs().Select(f => new Fournisseurs_DTO()
            {
                IdFournisseurs = f.IdFournisseurs,
                Societe = f.Societe,
                CiviliteContact = f.CiviliteContact,
                NomContact = f.NomContact,
                PrenomContact = f.PrenomContact,
                Email = f.Email,
                Adresse = f.Adresse,
            });
        }

        [HttpPost("commande/{IdFournisseurs}")]
        public void AlimenterCatalogue(int IdFournisseurs, IFormFile csvFile)
        {
            service.alimenterCatalogue(IdFournisseurs, csvFile);
        }

        [HttpPost]
        public Fournisseurs_DTO Insert(Fournisseurs_DTO f)
        {
            var f_metier = service.Insert(new Fournisseurs(f.IdFournisseurs,
                                                           f.Societe,
                                                           f.CiviliteContact,
                                                           f.NomContact,
                                                           f.PrenomContact,
                                                           f.Email,
                                                           f.Adresse));
            //Je récupère l'ID
            f.IdFournisseurs = f_metier.IdFournisseurs;
            //je renvoie l'objet DTO
            return f;
        }

        // PUT api/<FournisseursController>/5
        [HttpPut]
        public Fournisseurs_DTO Update(Fournisseurs_DTO f)
        {
            var f_metier = service.Update(new Fournisseurs(f.IdFournisseurs,
                                                           f.Societe,
                                                           f.CiviliteContact,
                                                           f.NomContact,
                                                           f.PrenomContact,
                                                           f.Email,
                                                           f.Adresse));
            //Je récupère l'ID
            f.IdFournisseurs = f_metier.IdFournisseurs;
            //je renvoie l'objet DTO
            return f;
        }

        // DELETE api/<FournisseursController>/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            service.Delete(new Fournisseurs(id));
        }
    }
}
