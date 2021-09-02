
using Microsoft.AspNetCore.Mvc;

namespace BlazorCounter.Server.NewFolder;
[ApiController]
[Route("api/[controller]")]
public class NomeSerController : ControllerBase
{
    private readonly Data.EventManagerDbContext db;

    public NomeSerController(Data.EventManagerDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this.db.Nome.Select(x => new Client.Models.NomeCli()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int Id)
    {
        var result = this.db.Nome
            .Where(x => x.Id == Id)
            .Select(x =>  new Client.Models.NomeCli()
            {
            Id = x.Id,
            Name = x.Name,
            }).SingleOrDefault();
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(Client.Models.NomeCli item)
    {
        if (ModelState.IsValid)
        {
            var entity = new Models.NomeSer()
            {
                Id = item.Id,
                Name = item.Name,
            };
            this.db.Add(entity);
            this.db.SaveChanges();
            item.Id = entity.Id;
            return CreatedAtAction(nameof(Get), new { Id = entity.Id }, item);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Client.Models.NomeCli item)
    {
        if (ModelState.IsValid)
        {
            var entity = this.db.Nome.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            entity.Name = item.Name;
            this.db.SaveChanges();
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entity = this.db.Nome.SingleOrDefault(x => x.Id == id);
        if (entity == null) return NotFound();
        this.db.Remove(entity);
        this.db.SaveChanges();
        return NoContent();
    }
}
