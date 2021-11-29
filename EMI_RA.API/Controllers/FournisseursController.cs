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
    public class FournisseursController : Controller
    {
        // GET: api/<FournisseursController>
        //[HttpGet]
        //public IEnumerable<Fournisseurs_DTO> GetAllFournisseurs()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<FournisseursController>/5
        [HttpGet("{idFournisseurs}")]
        public string Get(int idFournisseurs)
        {
            return "value";
        }

        //// POST api/<FournisseursController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<FournisseursController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FournisseursController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
