using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCounter.Server.NewFolder;
[ApiController]
[Route("api/[controller]")]
public class DatiEventoController : ControllerBase
{
    private readonly Data.EventManagerDbContext db;

    public DatiEventoController(Data.EventManagerDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this.db.Eventi.Select(x => new Client.Models.ElementoListaEventi()
        {
            Id = x.Id,
            Nome = x.Nome,
            Localita = x.Localita,
            Data = x.Data
        }).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = this.db.Eventi
            .Where(x => x.Id == id)
            .Select(x => new Client.Models.Evento()
            {
                Id = x.Id,
                Nome = x.Nome,
                Localita = x.Localita,
                Data = x.Data,
                Descrizione = x.Descrizione,
                Note = x.Note
            }).SingleOrDefault();

        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(Client.Models.Evento item)
    {
        if (ModelState.IsValid)
        {
            var entity = new Models.DatiEvento()
            {
                Id = item.Id,
                Nome = item.Nome,
                Localita = item.Localita,
                Data = item.Data,
                Descrizione = item.Descrizione,
                Note = item.Note
            };
            this.db.Add(entity);
            this.db.SaveChanges();
            item.Id = entity.Id;
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, item);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, BlazorCounter.Client.Models.Evento item)
    {
        if (ModelState.IsValid)
        {
            var entity = this.db.Eventi.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            entity.Nome = item.Nome;
            entity.Localita = item.Localita;
            entity.Data = item.Data;
            entity.Descrizione = item.Descrizione;
            entity.Note = item.Note;
            this.db.SaveChanges();
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entity = this.db.Eventi.SingleOrDefault(x => x.Id == id);
        if (entity == null) return NotFound();
        this.db.Remove(entity);
        this.db.SaveChanges();
        return NoContent();
    }
}