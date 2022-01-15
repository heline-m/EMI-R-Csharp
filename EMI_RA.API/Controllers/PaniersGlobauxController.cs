using EMI_RA.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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
                IDPaniersGlobaux = p.ID,
                NumeroSemaine = p.NumeroSemaine,
                Annee = p.Annee
            });
        }

        [HttpGet("panier")]
        public FileStreamResult getPanier()
        {
            int annee = DateTime.Now.AddDays(-7).Year;
            int semaine = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(-7), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

            String filename = "Panier_" + annee + "_S" + semaine + ".csv";

            Stream stream = service.genererPanierStream(annee, semaine);

            return new FileStreamResult(stream, "application/csv")
            {
                FileDownloadName = filename
            };
        }

        [HttpGet("panier/{idFournisseur}")]
        public FileStreamResult getPanier([FromRoute] int idFournisseur)
        {
            int annee = DateTime.Now.AddDays(-7).Year;
            int semaine = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(-7), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

            String filename = "Panier_" + annee + "_S" + semaine + ".csv";

            Stream stream = service.genererPanierStream(annee, semaine, idFournisseur);

            return new FileStreamResult(stream, "application/csv")
            {
                FileDownloadName = filename
            };
        }
    }
}
