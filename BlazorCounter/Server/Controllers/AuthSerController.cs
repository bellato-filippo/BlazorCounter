using Microsoft.AspNetCore.Mvc;
using BlazorCounter.Server.Data;

namespace BlazorCounter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthSerController : ControllerBase
    {
        private readonly EventManagerDbContext db;

        public AuthSerController(EventManagerDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.db.Auth.Select(x => new Client.Models.AuthCli()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Password = x.Password
            }).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.db.Auth
                .Where(x => x.Id == id)
                .Select(x => new Client.Models.AuthCli()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Password = x.Password
                }).SingleOrDefault();

            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(BlazorCounter.Client.Models.AuthCli item)
        {
            if (ModelState.IsValid)
            {
                var entity = new Models.AuthSer()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Password = item.Password
                };
                this.db.Add(entity);
                this.db.SaveChanges();
                item.Id = entity.Id;
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, item);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Client.Models.AuthCli item)
        {
            if (ModelState.IsValid)
            {
                var entity = this.db.Auth.SingleOrDefault(x => x.Id == id);
                if (entity == null) return NotFound();
                entity.Id = item.Id;
                entity.FirstName = item.FirstName;
                entity.LastName = item.LastName;
                entity.Password = item.Password;
                this.db.SaveChanges();
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = this.db.Auth.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            this.db.Remove(entity);
            this.db.SaveChanges();
            return NoContent();
        }
    }
}
