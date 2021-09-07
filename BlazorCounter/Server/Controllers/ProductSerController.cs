using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCounter.Server.Data;
using BlazorCounter.Server.Models;

namespace BlazorCounter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductSerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductSer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSer>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/ProductSer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSer>> GetProductSer(int id)
        {
            var productSer = await _context.Product.FindAsync(id);

            if (productSer == null)
            {
                return NotFound();
            }

            return productSer;
        }

        // PUT: api/ProductSer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSer(int id, ProductSer productSer)
        {
            if (id != productSer.Id)
            {
                return BadRequest();
            }

            _context.Entry(productSer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSerExists(id))
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

        // POST: api/ProductSer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductSer>> PostProductSer(ProductSer productSer)
        {
            _context.Product.Add(productSer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSer", new { id = productSer.Id }, productSer);
        }

        // DELETE: api/ProductSer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSer(int id)
        {
            var productSer = await _context.Product.FindAsync(id);
            if (productSer == null)
            {
                return NotFound();
            }

            _context.Product.Remove(productSer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductSerExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
