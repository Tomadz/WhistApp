using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhistApi.Models;

namespace WhistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RundeController : ControllerBase
    {
        private readonly RundeContext _context;
        public RundeController(RundeContext context)
        {
            _context = context;
        }

        // GET: api/runde
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Runde>>> GetRunder()
        {
            return await _context.Runder.ToListAsync();
        }

        // GET api/runde/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Runde>> GetRunde(int id)
        {
            var runde = await _context.Runder.FindAsync(id);

            if (runde == null)
                return NotFound();

            return runde;
        }

        // POST api/runde
        [HttpPost]
        public async Task<ActionResult<Runde>> PostRunde(Runde runde)
        {
            _context.Runder.Add(runde);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRunde), new { id = runde.Id }, runde);
        }

        // PUT api/runde/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunde(int id, Runde runde)
        {
            if (id != runde.Id)
                return BadRequest();

            _context.Entry(runde).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/runde/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRunde(int id)
        {
            var runde = await _context.Runder.FindAsync(id);

            if (runde == null)
                return NotFound();

            _context.Runder.Remove(runde);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}