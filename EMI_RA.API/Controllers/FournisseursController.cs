﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        public IEnumerable<Fournisseurs> GetAllFournisseurs()
        {
            return service.GetAllFournisseurs().Select(f => new Fournisseurs(
                f.IdFournisseurs,
                f.Societe,
                f.CiviliteContact,
                f.NomContact,
                f.PrenomContact,
                f.Email,
                f.Adresse,
                f.DateAdhesion,
                f.Actif));
        }

        [HttpPost("catalogue/{IdFournisseurs}")]
        public void AlimenterCatalogue(int IdFournisseurs, IFormFile csvFile)
        {
            service.alimenterCatalogue(IdFournisseurs, csvFile);
        }
        [HttpPost("catalogueVersion2/{IdFournisseurs}")]
        public void AlimenterCatalogueString(int IdFournisseurs, List<string> csvFile)
        {
            service.alimenterCatalogueVersion2(IdFournisseurs, csvFile);
        }

        [HttpPost]
        public Fournisseurs Insert(Fournisseurs f)
        {
            var f_metier = service.Insert(f);

            return f_metier;
        }

        [HttpPut]
        public Fournisseurs Update(Fournisseurs f)
        {
            var f_metier = service.Update(f);

            return f_metier;
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            service.Delete(new Fournisseurs(id));
        }
    }
}
