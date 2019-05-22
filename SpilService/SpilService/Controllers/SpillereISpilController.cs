﻿using System;
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
    public class SpillereISpilController : ControllerBase
    {
        // GET: api/SpillereISpil
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            SqlQuery sqlQuery = new SqlQuery();
            List<Ven> vennelisteISpil = sqlQuery.HentVennerSpecifikSpil(id);
            //serializer Runde til json og gør det til string til sidst
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Ven>));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, vennelisteISpil);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            string json = sr.ReadToEnd();
            return json;
        }

        // POST: api/SpillereISpil
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SpillereISpil/5
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
