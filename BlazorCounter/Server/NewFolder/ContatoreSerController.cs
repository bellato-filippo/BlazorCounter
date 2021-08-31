using Microsoft.AspNetCore.Mvc;

namespace BlazorCounter.Server.NewFolder;
[ApiController]
[Route("api/[controller]")]

public class ContatoreSerController : ControllerBase
{
    private readonly Data.EventManagerDbContext db;

    public ContatoreSerController(Data.EventManagerDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this.db.Contatore.Select(x => new Client.Models.ContatoreCli()
        {
            Id = x.Id,
            Valore = x.Valore,
        }).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = this.db.Contatore
            .Where(x => x.Id == id)
            .Select(x => new Client.Models.ContatoreCli()
            {
                Id = x.Id,
                Valore = x.Valore,
            }).SingleOrDefault();

        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(BlazorCounter.Client.Models.ContatoreCli item)
    {
        if (ModelState.IsValid)
        {
            var entity = new Models.ContatoreSer()
            {
                Id = item.Id,
                Valore = item.Valore,
            };
            this.db.Add(entity);
            this.db.SaveChanges();
            item.Id = entity.Id;
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, item);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, BlazorCounter.Client.Models.ContatoreCli item)
    {
        if (ModelState.IsValid)
        {
            var entity = this.db.Contatore.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            entity.Valore = item.Valore;
            this.db.SaveChanges();
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entity = this.db.Contatore.SingleOrDefault(x => x.Id == id);
        if (entity == null) return NotFound();
        this.db.Remove(entity);
        this.db.SaveChanges();
        return NoContent();
    }
}

/*
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
*/