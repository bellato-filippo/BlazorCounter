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
    public IActionResult Post(Client.Models.ContatoreCli item)
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

