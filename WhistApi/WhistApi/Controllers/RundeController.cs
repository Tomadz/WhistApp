using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhistApi.Models;
using WhistApi.Models.Context;

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
        public async Task<ActionResult<IEnumerable<Runde>>> GetTodoItems()
        {
            return await _context.Runder.ToListAsync();
        }

        // GET: api/runde/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Runde>> GetRunde(int id)
        {
            var Runde = await _context.Runder.FindAsync(id);

            if (Runde == null)
            {
                return NotFound();
            }

            return Runde;
        }
        // POST: api/Runde
        [HttpPost]
        public async Task<ActionResult<Runde>> PostRunde(Runde item)
        {
            _context.Runder.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRunde), new { id = item.Id }, item);
        }

        // PUT: api/Runde/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunde(int id, Runde item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Runde/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRunde(long id)
        {
            var todoItem = await _context.Runder.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Runder.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}