using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpilService.Models;

namespace SpilService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlusController : ControllerBase
    {
        // GET: api/Plus
        [HttpGet]
        public List<Plus> Get()
        {
            SqlQuery sqlQuery = new SqlQuery();
            List<Plus> Pluser = sqlQuery.HentAllePlusser();
            
            return Pluser;
        }

        // GET: api/Plus/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Plus
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Plus/5
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
