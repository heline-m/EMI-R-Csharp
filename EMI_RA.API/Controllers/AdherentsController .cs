using EMI_RA.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMI_RA.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AdherentsController : Controller
    {
        private IAdherentsService service;
        private IListeAchatService listeAchatService;

        public AdherentsController(IAdherentsService srv, IListeAchatService listeAchatService)
        {
            service = srv;
            this.listeAchatService = listeAchatService;
        }

        // GET: api/<FournisseursController>
        [HttpGet]
        public IEnumerable<Adherents_DTO> GetAllAdherents()
        {
            return service.GetAllAdherents().Select(a => new Adherents_DTO()
            {
                ID = a.ID,
                Societe = a.Societe,
                CiviliteContact = a.CiviliteContact,
                NomContact = a.NomContact,
                PrenomContact = a.PrenomContact,
                Email = a.Email,
                Adresse = a.Adresse,
            });
        }

        [HttpPost("commande/{IdAdherent}")]
        public void GenererListeAchat(int IdAdherent, IFormFile csvFile)
        {
            listeAchatService.genererListeAchat(IdAdherent, csvFile);
        }
        [HttpPost]
        public Adherents_DTO Insert(Adherents_DTO a)
        {
            var a_metier = service.Insert(new Adherents(a.ID,
                                                        a.Societe,
                                                        a.CiviliteContact,
                                                        a.NomContact,
                                                        a.PrenomContact,
                                                        a.Email,
                                                        a.Adresse));
            //Je récupère l'ID
            a.ID = a_metier.ID;
            //je renvoie l'objet DTO
            return a;
        }

        // PUT api/<AdherentsController>/5
        [HttpPut]
        public Adherents_DTO Update(Adherents_DTO a)
        {
            var a_metier = service.Update(new Adherents(a.ID,
                                                        a.Societe,
                                                        a.CiviliteContact,
                                                        a.NomContact,
                                                        a.PrenomContact,
                                                        a.Email,
                                                        a.Adresse));
            //Je récupère l'ID
            a.ID = a_metier.ID;
            //je renvoie l'objet DTO
            return a;
        }
    
        // DELETE api/<AdherentsController>/5
        [HttpDelete ("{id}")]
        public void Delete([FromRoute] int id)
        {
            service.Delete(new Adherents(id));
        }
    }
}
