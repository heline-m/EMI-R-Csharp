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
    public class PaniersGlobauxController : Controller
    {
        private IPaniersGlobauxService service;

        public PaniersGlobauxController(IPaniersGlobauxService srv)
        {
            service = srv;
        }

        // GET: api/<PaniersGlobauxController>
        [HttpGet]
        public IEnumerable<PaniersGlobaux_DTO> GetAllPaniersGlobaux()
        {
            return service.GetAllPaniersGlobaux().Select(p => new PaniersGlobaux_DTO()
            {
                IDPaniersGlobaux = p.IDPaniersGlobaux,
                NumeroSemaine = p.NumeroSemaine,
                Annee = p.Annee
            });
        }
    }
}
