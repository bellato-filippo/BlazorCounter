using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCounter.Server.Data;
using BlazorCounter.Server.Models;

namespace BlazorCounter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottoSerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdottoSerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProdottoSer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdottoSer>>> GetProdotto()
        {
            return await _context.Prodotto.ToListAsync();
        }

        // GET: api/ProdottoSer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdottoSer>> GetProdottoSer(int id)
        {
            var prodottoSer = await _context.Prodotto.FindAsync(id);

            if (prodottoSer == null)
            {
                return NotFound();
            }

            return prodottoSer;
        }

        // PUT: api/ProdottoSer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdottoSer(int id, ProdottoSer prodottoSer)
        {
            if (id != prodottoSer.Id)
            {
                return BadRequest();
            }

            _context.Entry(prodottoSer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdottoSerExists(id))
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

        // POST: api/ProdottoSer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdottoSer>> PostProdottoSer(ProdottoSer prodottoSer)
        {
            _context.Prodotto.Add(prodottoSer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdottoSer", new { id = prodottoSer.Id }, prodottoSer);
        }

        // DELETE: api/ProdottoSer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdottoSer(int id)
        {
            var prodottoSer = await _context.Prodotto.FindAsync(id);
            if (prodottoSer == null)
            {
                return NotFound();
            }

            _context.Prodotto.Remove(prodottoSer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdottoSerExists(int id)
        {
            return _context.Prodotto.Any(e => e.Id == id);
        }
    }
}
