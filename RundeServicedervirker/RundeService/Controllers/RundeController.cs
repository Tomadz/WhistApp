using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RundeService.Model;
using RundeService.Model.Context;
using Microsoft.Extensions.DependencyInjection;
namespace RundeService.Controllers
{
    [Route("api/Runde")]
    [ApiController]
    public class RundeController : ControllerBase
    {
        private readonly RundeContext _context;

        public RundeController(RundeContext context)
        {
                _context =context;
        }

        // GET: api/Runde
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Runde>>> GetRunder()
        {
            return await _context.Runder.ToListAsync();
        }

        // GET: api/Runde/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Runde>>> GetRunde(long id)
        {
            var runde = await _context.Runder.Where(r => r.SpilId == id).ToListAsync();

            if (runde == null)
            {
                return NotFound();
            }

            return runde;
        }

        // POST: api/Runde
        [HttpPost]
        public async Task<ActionResult<Runde>> PostRunde(Runde item)
        {
            //publish runden
            Publish.Runde(item);
            //tilføj item til context.runder
          //  _context.Runder.Add(item);
            //vent på det er gemt
            //await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRunde), new { id = item.Id }, item);
        }

        // put: api/Runde
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunde(long id, Runde item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Runde
        [HttpDelete("{spilid}/{rundenr}")]
        public async Task<IActionResult> DeleteTodoItem(int spilid, int rundenr)
        {
            /*var runde = await _context.Runder.FindAsync(spilid,rundenr);

             if (runde == null)
             {
                 return NotFound();
             }

             _context.Runder.Remove(runde);
             await _context.SaveChangesAsync();*/
            Runde runde = new Runde();
            runde.SpilId = spilid;
            runde.RundeNr = rundenr;            

            Publish.Delete(runde);
            return NoContent();
        }




        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
                        
    }
}
