using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpilService.Models;

namespace SpilService.Controllers.SpilController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpilController : ControllerBase
    {
        // GET: api/Spil
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Spil/5
        [HttpGet("{id}", Name = "Get1")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Spil
        [HttpPost]
        public int Post(Ven[] spildeltagere)
        {
            SpilSQL SQL = new SpilSQL();

            Regelsæt statiskRegelsæt = new Regelsæt();
            statiskRegelsæt.Id = 1;

            int spilId = SQL.OpretSpil(spildeltagere, statiskRegelsæt);

            return spilId;
        }

        // PUT: api/Spil/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
