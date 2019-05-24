using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpilService.Models;

namespace SpilService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesetController : ControllerBase
    {
        // GET: api/Regelsæt
        [HttpGet]
        public List<Regelsæt> Get()
        {
            SqlQuery sqlQuery = new SqlQuery();
            List<Regelsæt> regelsæts = sqlQuery.HentAlleRegler();
            /* //serializer Runde til json og gør det til string til sidst
             DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Regelsæt>));
             MemoryStream msObj = new MemoryStream();
             js.WriteObject(msObj, regelsæts);
             msObj.Position = 0;
             StreamReader sr = new StreamReader(msObj);
             string json = sr.ReadToEnd();
             return json;*/
            return regelsæts;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Regelsæt Get(int id)
        {
            SqlQuery sqlQuery = new SqlQuery();
            Regelsæt regelsæt = sqlQuery.HentSpecifikkeRegler(id);
            /*  //serializer Runde til json og gør det til string til sidst
              DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Regelsæt));
              MemoryStream msObj = new MemoryStream();
              js.WriteObject(msObj, regelsæt);
              msObj.Position = 0;
              StreamReader sr = new StreamReader(msObj);
              string json = sr.ReadToEnd();
              return json;*/
            return regelsæt;
        }

        // POST: api/Regelsæt
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Regelsæt/5
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
