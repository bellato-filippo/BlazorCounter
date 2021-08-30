using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCounter.Server.Data;
using BlazorCounter.Server.Models;

namespace BlazorCounter.Server.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoreSerController : ControllerBase
    {
        private readonly EventManagerDbContext _context;

        public ContatoreSerController(EventManagerDbContext context)
        {
            _context = context;
        }

        // GET: api/ContatoreSer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoreSer>>> GetContatore()
        {
            return await _context.Contatore.ToListAsync();
        }

        // GET: api/ContatoreSer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoreSer>> GetContatoreSer(int id)
        {
            var contatoreSer = await _context.Contatore.FindAsync(id);

            if (contatoreSer == null)
            {
                return NotFound();
            }

            return contatoreSer;
        }

        // PUT: api/ContatoreSer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatoreSer(int id, ContatoreSer contatoreSer)
        {
            if (id != contatoreSer.Id)
            {
                return BadRequest();
            }

            _context.Entry(contatoreSer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoreSerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContatoreSer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContatoreSer>> PostContatoreSer(ContatoreSer contatoreSer)
        {
            _context.Contatore.Add(contatoreSer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContatoreSer", new { id = contatoreSer.Id }, contatoreSer);
        }

        // DELETE: api/ContatoreSer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContatoreSer(int id)
        {
            var contatoreSer = await _context.Contatore.FindAsync(id);
            if (contatoreSer == null)
            {
                return NotFound();
            }

            _context.Contatore.Remove(contatoreSer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatoreSerExists(int id)
        {
            return _context.Contatore.Any(e => e.Id == id);
        }
    }
}
